using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyForge.Offline.Editor
{
    // Real restored project objects and actual ES3 backend. No replacement game services.
    // RunChecks is synchronous EditMode; RunBatch additionally runs the original
    // public paid callbacks and real Unity coroutines in a dedicated empty PlayMode scene.
    [InitializeOnLoad]
    public static class HomeForgeVerification
    {
        [Serializable] public sealed class Result
        {
            public bool passed;
            public int checks;
            public string testRoot;
            public List<string> failures = new List<string>();
            public List<string> observations = new List<string>();
            public List<string> limitations = new List<string>();
        }
        [Serializable] sealed class Node
        { public string name, active; public int child_count; public Node[] children; }
        const BindingFlags B = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        const string Intent = "LuckyForge.HomeForge.Batch";
        static Fixture live;
        static int stage, freeSpins;
        static double started;
        static int[] previousXp;
        static int previousToken, previousExp, previousLevel;
        static HomeForgeVerification()
        { EditorApplication.playModeStateChanged += Mode; }
        static void Check(Result r, bool yes, string label)
        { r.checks++; if (!yes) r.failures.Add(label); }
        static object Call(object o, string method, params object[] args)
        { return o.GetType().GetMethod(method, B).Invoke(o, args); }
        static void Set(object o, string field, object value)
        { o.GetType().GetField(field, B).SetValue(o, value); }
        static T Get<T>(object o, string field)
        { return (T)o.GetType().GetField(field, B).GetValue(o); }
        static GameObject Child(Transform parent, string name)
        { var o = new GameObject(name, typeof(RectTransform)); o.transform.SetParent(parent, false); return o; }
        static T Add<T>(Transform p, string n) where T : Component
        { return Child(p, n).AddComponent<T>(); }
        static void Wire(object o, Transform p)
        {
            foreach (var f in o.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                if (f.FieldType == typeof(TextMeshProUGUI)) f.SetValue(o, Add<TextMeshProUGUI>(p, f.Name));
                else if (f.FieldType == typeof(GameObject)) f.SetValue(o, Child(p, f.Name));
                else if (f.FieldType == typeof(Button)) f.SetValue(o, Add<Button>(p, f.Name));
                else if (f.FieldType == typeof(Slider)) f.SetValue(o, Add<Slider>(p, f.Name));
                else if (f.FieldType == typeof(ParticleSystem))
                {
                    var ps = Add<ParticleSystem>(p, f.Name); var main = ps.main; main.playOnAwake = false; f.SetValue(o, ps);
                }
                else if (f.FieldType == typeof(Toggle)) f.SetValue(o, Add<Toggle>(p, f.Name));
                else if (f.FieldType == typeof(Animator)) f.SetValue(o, Add<Animator>(p, f.Name));
            }
        }
        static GameObject FromNode(Node node, Transform parent)
        {
            var o = Child(parent, node.name);
            if (node.name == "adet") o.AddComponent<TextMeshProUGUI>();
            else o.AddComponent<Image>();
            foreach (var ch in node.children ?? new Node[0]) FromNode(ch, o.transform);
            o.SetActive(node.active == "1"); return o;
        }
        // Replaced by bind_fixture.py from independent original Sahne serialized hierarchy.
        const string SlotTree = @"{""transform_id"":75485,""name"":""forgeUnit"",""active"":""1"",""children"":[{""transform_id"":69464,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":76300,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":79615,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":2},{""transform_id"":74560,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":76424,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":73219,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":77043,""name"":""light"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":73207,""name"":""locked"",""active"":""1"",""children"":[{""transform_id"":73489,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":75393,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":71715,""name"":""Image (4)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":78291,""name"":""Image (3)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":76136,""name"":""Image"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":76368,""name"":""Image (5)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":6},{""transform_id"":79210,""name"":""light (1)"",""active"":""0"",""children"":[],""child_count"":0}],""child_count"":7}";
        const string AltTree = @"{""transform_id"":67714,""name"":""Content"",""active"":""1"",""children"":[{""transform_id"":72470,""name"":""odulGacha (36)"",""active"":""0"",""children"":[{""transform_id"":69901,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":63701,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":76707,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":73094,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":77149,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":72179,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":76031,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":77739,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":61459,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68901,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":60806,""name"":""odulGacha (37)"",""active"":""0"",""children"":[{""transform_id"":60221,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":65351,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":60473,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":59708,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":67585,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68298,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":64743,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":67397,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":60355,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62058,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":65260,""name"":""odulGacha (38)"",""active"":""0"",""children"":[{""transform_id"":62324,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":67856,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68764,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66727,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":58963,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":60394,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":61989,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":63134,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":61210,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":63281,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":64871,""name"":""odulGacha (39)"",""active"":""0"",""children"":[{""transform_id"":59623,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":64870,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":58605,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":65133,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":67137,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":63534,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68150,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":62359,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66748,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":67883,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":63476,""name"":""odulGacha (40)"",""active"":""0"",""children"":[{""transform_id"":67809,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":62457,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62824,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":63569,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":60057,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66268,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":58646,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":64918,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":63053,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":65030,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":66056,""name"":""odulGacha (41)"",""active"":""0"",""children"":[{""transform_id"":59130,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":68846,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":61290,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":59101,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":64082,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":69049,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":67897,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":60805,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68667,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66538,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":60645,""name"":""odulGacha (42)"",""active"":""0"",""children"":[{""transform_id"":66729,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":64710,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":58841,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":61481,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":62128,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":65855,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":57942,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":61070,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":67473,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68004,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":63164,""name"":""odulGacha (43)"",""active"":""0"",""children"":[{""transform_id"":63748,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":60157,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":61994,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":58364,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":65817,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":61657,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":65561,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":67879,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":65078,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62948,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":62108,""name"":""odulGacha (44)"",""active"":""0"",""children"":[{""transform_id"":64382,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":63623,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68468,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66984,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":60536,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68675,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":64386,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":59988,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":64638,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":60586,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":61132,""name"":""odulGacha (45)"",""active"":""0"",""children"":[{""transform_id"":67517,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":68920,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62675,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62673,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":66757,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62497,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":60288,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":65521,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":61928,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":67736,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":65919,""name"":""odulGacha (46)"",""active"":""0"",""children"":[{""transform_id"":66810,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":63714,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":63537,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66180,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":66443,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":65597,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":59586,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":66181,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":57960,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":61814,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":58080,""name"":""odulGacha (47)"",""active"":""0"",""children"":[{""transform_id"":58949,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":67836,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68982,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":64957,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":67315,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":67184,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":61633,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":60872,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68768,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66051,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":60143,""name"":""odulGacha (48)"",""active"":""0"",""children"":[{""transform_id"":62354,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":62203,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":57961,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":60283,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":67394,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":58833,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66332,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":67468,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":60919,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":64398,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":63228,""name"":""odulGacha (49)"",""active"":""0"",""children"":[{""transform_id"":61270,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":62560,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":58655,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":59335,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":62769,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62410,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":63843,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":59269,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":60092,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62083,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":66319,""name"":""odulGacha (50)"",""active"":""0"",""children"":[{""transform_id"":68604,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":59559,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":59644,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":59194,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":65987,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66059,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":67377,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":59958,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":64034,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":59566,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":63312,""name"":""odulGacha (51)"",""active"":""0"",""children"":[{""transform_id"":60045,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":60696,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66042,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62535,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":68649,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68338,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":60381,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":60161,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":65138,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":61528,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":59394,""name"":""odulGacha (52)"",""active"":""0"",""children"":[{""transform_id"":59358,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":65000,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":67632,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":67393,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":66902,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":59286,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68130,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":58217,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68678,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66033,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":68157,""name"":""odulGacha (53)"",""active"":""0"",""children"":[{""transform_id"":68896,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":68495,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68126,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68647,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":65578,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":58225,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":64582,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":60369,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":65380,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62734,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":61590,""name"":""odulGacha (54)"",""active"":""0"",""children"":[{""transform_id"":59380,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":66773,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":63168,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62892,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":67741,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66118,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62444,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":58851,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":63241,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68306,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":59678,""name"":""odulGacha (55)"",""active"":""0"",""children"":[{""transform_id"":65468,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":66433,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":59070,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":59302,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":65994,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62060,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62541,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":59439,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":63797,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":61349,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":67852,""name"":""odulGacha (56)"",""active"":""0"",""children"":[{""transform_id"":62180,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":66161,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68680,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":63364,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":68902,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66234,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":67415,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":58481,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":65924,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66602,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":67983,""name"":""odulGacha (57)"",""active"":""0"",""children"":[{""transform_id"":65631,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":60417,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62003,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":64945,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":65947,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":57882,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62186,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":60781,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":63488,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":67845,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":61792,""name"":""odulGacha (58)"",""active"":""0"",""children"":[{""transform_id"":67070,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":60449,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66490,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62114,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":66516,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":63480,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66475,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":68929,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":60654,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":58329,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":68399,""name"":""odulGacha (59)"",""active"":""0"",""children"":[{""transform_id"":64319,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":60126,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":63433,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":60800,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":64243,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":61648,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":67563,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":68173,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":67844,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":67958,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":65220,""name"":""odulGacha (60)"",""active"":""0"",""children"":[{""transform_id"":62014,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":61698,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":64711,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":58344,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":62775,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68780,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66144,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":64031,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":60160,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":65720,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":68819,""name"":""odulGacha (61)"",""active"":""0"",""children"":[{""transform_id"":67829,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":58050,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":67896,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":60530,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":59471,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":60928,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66406,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":59104,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":63001,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":67113,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":61825,""name"":""odulGacha (62)"",""active"":""0"",""children"":[{""transform_id"":60710,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":57947,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":65982,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":63303,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":68386,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":65254,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":61235,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":58528,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":59748,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":58995,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":68886,""name"":""odulGacha (63)"",""active"":""0"",""children"":[{""transform_id"":61151,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":58155,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62346,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":66753,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":63741,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":62640,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":67484,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":59495,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":67157,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":59794,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":61713,""name"":""odulGacha (64)"",""active"":""0"",""children"":[{""transform_id"":68264,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":59962,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":65236,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":63036,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":68373,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":60173,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":57876,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":62815,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":61427,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":59447,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7},{""transform_id"":62533,""name"":""odulGacha (65)"",""active"":""0"",""children"":[{""transform_id"":58458,""name"":""Image"",""active"":""1"",""children"":[{""transform_id"":66225,""name"":""Image (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":64346,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":61120,""name"":""Image (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":3},{""transform_id"":65217,""name"":""icon"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":68250,""name"":""adet"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":61546,""name"":""choosed"",""active"":""0"",""children"":[],""child_count"":0},{""transform_id"":63914,""name"":""light"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":61649,""name"":""light (2)"",""active"":""1"",""children"":[],""child_count"":0},{""transform_id"":58862,""name"":""light (1)"",""active"":""1"",""children"":[],""child_count"":0}],""child_count"":7}],""child_count"":30}";
        static RuntimeAnimatorController Controller(string guid)
        { return AssetDatabase.LoadAssetAtPath<RuntimeAnimatorController>(AssetDatabase.GUIDToAssetPath(guid)); }
        const string SlotControllerGuid = "c2aad6482d957cd4a8ab2065d295b7a4";
        const string PackControllerGuid = "79c01dc4971da6345b27dbe9e7b111b0";
        const string CardControllerGuid = "bcfc67848443ce84c9f7eb65ce59a7e6";
        sealed class Fixture : IDisposable
        {
            public Result result;
            public GameObject root;
            public FindNewWeapons find;
            public ForgeSpinner forge;
            public HeroController hero;
            public Commander[] commanders;
            public Sprite sprite;
            public SoundManager actualSound;
            public Dictionary<FieldInfo, object> old = new Dictionary<FieldInfo, object>();
            public string oldRoot;
            public UnityEngine.Random.State random;
            public Fixture(bool active)
            {
                result = new Result { testRoot = Path.Combine(Path.GetTempPath(), "LuckyForgeHomeForgeChecks", Guid.NewGuid().ToString("N")) };
                Directory.CreateDirectory(result.testRoot);
                foreach (var t in new[] { typeof(Currencys), typeof(Lang), typeof(GameManager), typeof(SoundManager), typeof(FindNewWeapons), typeof(Basarimlar), typeof(GunlukGorevler) })
                    foreach (var f in t.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                        if (!f.IsLiteral && !f.IsInitOnly) old[f] = f.GetValue(null);
                oldRoot = (string)typeof(OfflineKeyStore).GetField("verificationRoot", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
                random = UnityEngine.Random.state;
                OfflineKeyStore.SetVerificationRoot(result.testRoot);
                root = new GameObject("HomeForgeVerification"); root.SetActive(false);
                GameManager.Language = 0; GameManager.Level = 3; Lang.currentLang = null;
                Basarimlar.basarilar = new List<BasariGorev>();
                GunlukGorevler.tasks = new List<GunlukGorev>();
                SoundManager.instance = Add<SoundManager>(root.transform, "ActualSoundManager"); SoundManager.instance.enabled = false; actualSound = SoundManager.instance;
                hero = Add<HeroController>(root.transform, "HeroController"); hero.enabled = false;
                hero.rarityColors = new[] { Color.gray, Color.blue, Color.magenta, Color.yellow, Color.red };
                hero.canvasJobs = Add<CanvasJobs>(root.transform, "CanvasJobs"); hero.canvasJobs.enabled = false;
                hero.canvasJobs.golyokbasictxt = Add<TextMeshProUGUI>(root.transform, "InsufficientText");
                hero.canvasJobs.goldyokbasic = Child(root.transform, "InsufficientPanel"); hero.canvasJobs.goldyokbasic.SetActive(false);
                sprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0,0,1,1), Vector2.zero);
                commanders = new Commander[5];
                hero.HeroCommanders = new List<Commander>();
                for (int i=0; i<commanders.Length; i++)
                {
                    Commander c = Add<Commander>(root.transform, "Commander"+i); c.enabled = false;
                    c.HeroNum = i; c.Rarity = (WeaponRarity)i; c.Level = 2; c.StartLevel = 1; c.MaxLevel = 30;
                    c.LevelExp = 0; c.HeroName = "Fixture weapon "+i; c.heroController = hero;
                    c.icon = Add<SpriteRenderer>(c.transform, "OriginalIconInterface"); c.icon.sprite = sprite;
                    commanders[i] = c; hero.HeroCommanders.Add(c);
                }
                find = Add<FindNewWeapons>(root.transform, "FindNewWeapons"); find.enabled = false; Wire(find, find.transform);
                find.heroController = hero; find.iconCurrency = sprite;
                find.karakterlerGenelUI = Add<KarakterlerGenelUI>(root.transform, "KarakterlerGenelUI"); find.karakterlerGenelUI.enabled = false;
                find.karakterlerGenelUI.weapontokenadet = Add<TextMeshProUGUI>(root.transform, "CardBalance");
                find.guidecommanders = new List<Commander>();
                find.alttakim = new[] { Child(find.transform, "Footer0"), Child(find.transform, "Footer1") };
                find.summonbtns = new[] { Add<Button>(find.transform,"Pack250"), Add<Button>(find.transform,"Pack50") };
                find.forgetxts = new[] { Add<TextMeshProUGUI>(find.transform,"Draw1"), Add<TextMeshProUGUI>(find.transform,"Draw5") };
                find.playAnim.runtimeAnimatorController = Controller(PackControllerGuid);
                find.WeaponResults = new FindedWeaponTekliUi[6];
                for (int i=0; i<6; i++)
                {
                    var v = Add<FindedWeaponTekliUi>(find.transform, "Result"+i); v.enabled = false; Wire(v,v.transform);
                    v._icon = Add<Image>(v.transform,"Icon"); v.raritys = Child(v.transform,"Rarity").transform;
                    for (int r=0; r<5; r++) Child(v.raritys,"Rarity"+r);
                    v.animinside.runtimeAnimatorController = Controller(CardControllerGuid);
                    find.WeaponResults[i] = v;
                }
                forge = Add<ForgeSpinner>(root.transform, "ForgeSpinner"); forge.enabled = false; Wire(forge,forge.transform);
                forge.findNewWeapons = find; forge.heroController = hero; forge.canvasJobs = hero.canvasJobs;
                forge.cikanweaponadet.transform.SetParent(Child(forge.transform,"FoundCountPanel").transform,false);
                forge.forinfotext.transform.SetParent(Child(forge.transform,"InfoPanel").transform,false);
                forge.allCommanders = commanders;
                forge.selector = Child(forge.transform,"Selector").transform;
                forge.summonbtns = new[] { Add<Button>(forge.transform,"Spin50"), Add<Button>(forge.transform,"Spin250") };
                forge.Drawx = new[] { Add<TextMeshProUGUI>(forge.transform,"Draw1"), Add<TextMeshProUGUI>(forge.transform,"Draw5") };
                forge.rewardItems = new Transform[16]; forge.rewardLockedAnims = new Animator[16];
                Node slot = JsonUtility.FromJson<Node>(SlotTree);
                for (int i=0; i<16; i++)
                {
                    var o = FromNode(slot,forge.transform); forge.rewardItems[i] = o.transform;
                    forge.rewardLockedAnims[i] = o.AddComponent<Animator>(); forge.rewardLockedAnims[i].runtimeAnimatorController = Controller(SlotControllerGuid);
                }
                forge.altrewardcontent = FromNode(JsonUtility.FromJson<Node>(AltTree),forge.transform).transform;
                forge.altrewardrect = (RectTransform)forge.altrewardcontent;
                forge.rewardGachas = new List<RewardForgeSpinner>();
                for (int i=0; i<5; i++) forge.rewardGachas.Add(new RewardForgeSpinner { rewardType=(RewardType)i, icon=sprite, amount=1, chanceWeight=i==0?40:i==1?10:i==2?2:0 });
                forge.skipAnimationToggle.isOn = false; // Original serialized Toggle90283 is false.
                FindNewWeapons.CurrentLevel = 0; FindNewWeapons.CurrentExp = 0;
                Call(find,"OnEnable"); Call(find,"Start"); Call(forge,"OnEnable"); Call(forge,"Start");
                if (active) root.SetActive(true);
            }
            public void Dispose()
            {
                if(root != null) UnityEngine.Object.DestroyImmediate(root);
                if(actualSound != null) UnityEngine.Object.DestroyImmediate(actualSound.gameObject);
                if(sprite != null) UnityEngine.Object.DestroyImmediate(sprite);
                foreach(var v in old) v.Key.SetValue(null,v.Value);
                UnityEngine.Random.state = random; OfflineKeyStore.SetVerificationRoot(oldRoot);
            }
        }
        static void Flush()
        {
            var settings = new ES3Settings("medupac.es3", ES3.Location.File);
            ES3.StoreCachedFile("medupac.es3",settings); OfflineKeyStore.ResetMemoryForVerification(); ES3.CacheFile("medupac.es3",settings);
        }
        static int Xp(Fixture f) { int n=0; foreach(var c in f.commanders)n+=c.LevelExp; return n; }
        static int[] Snapshot(Fixture f) { var a=new int[f.commanders.Length]; for(int i=0;i<a.Length;i++)a[i]=f.commanders[i].LevelExp;return a; }
        static void Write(Result r)
        {
            r.passed = r.failures.Count==0;
            File.WriteAllText(Path.Combine(r.testRoot,"home-forge-results.json"),JsonUtility.ToJson(r,true));
            Debug.Log("HomeForge checks="+r.checks+" passed="+r.passed+" result="+r.testRoot);
        }
        static void Core(Fixture f)
        {
            var r=f.result; Check(r,forgeShape(f),"Original Sahne16-slot and alternate-content hierarchy available");
            Check(r,Controller(SlotControllerGuid)!=null && Controller(PackControllerGuid)!=null && Controller(CardControllerGuid)!=null,"Three original animation controllers resolve");
            Check(r,f.find.MaxExp()==15 && f.find.GetCurrentChestLevel().Count==5,"Chest level0 original XP threshold15 and five rarity values");
            float[] expected={80f,13f,5f,2f,0f};var distribution=f.find.CalculateRarityDistribution(0);
            for(int i=0;i<5;i++)Check(r,Mathf.Abs(distribution[i]-expected[i])<.00002f,"Original level0 rarity weight"+i);
            var max=f.find.CalculateRarityDistribution(25);float[] maxExpected={30f,25f,25f,20f,0f};
            for(int i=0;i<5;i++)Check(r,max[i]==maxExpected[i],"Original capped level25 rarity weight"+i);
            bool buckets=true; int[] kinds=new int[5];
            for(int i=0;i<500;i++)
            {
                UnityEngine.Random.InitState(i); var state=UnityEngine.Random.state;int raw=UnityEngine.Random.Range(0,100);
                int wanted=raw<7?0:raw<12?1:raw==12?2:raw<=57?3:4;
                UnityEngine.Random.state=state;int got=(int)Call(f.forge,"GetRewardTypeByChance");buckets&=got==wanted;kinds[got]++;
            }
            Check(r,buckets && Array.TrueForAll(kinds,n=>n>0),"500 seeded real Unity random rolls match all five native integer buckets");
            Currencys.WeaponTokenFitle(49);f.find.Spend(0);f.find.Spend(1);
            Check(r,Currencys.WeaponToken==49 && !f.find.IsSummonInProgress && Xp(f)==0,"Both legacy Spend callbacks preserve insufficient balance and XP");
            Set(f.forge,"isSpinning",true); Currencys.WeaponTokenFitle(300);f.forge.Spin10x();f.forge.Spin50x();
            Check(r,Currencys.WeaponToken==300,"Busy spinner paid callbacks do not charge");Set(f.forge,"isSpinning",false);
            Currencys.WeaponTokenFitle(49);f.forge.Spin10x();
            Check(r,Currencys.WeaponToken==49 && f.hero.canvasJobs.goldyokbasic.activeSelf,"Insufficient spinner callback opens actual resource notice without charge");
            Currencys.CoinFitle(0); Currencys.CrystalFitle(0); Currencys.MistikTokenFitle(0);
            Call(f.forge,"GiveReward",new RewardForgeSpinner{rewardType=RewardType.Coin,amount=200});
            Call(f.forge,"GiveReward",new RewardForgeSpinner{rewardType=RewardType.Crystal,amount=5});
            Call(f.forge,"GiveReward",new RewardForgeSpinner{rewardType=RewardType.Mystic,amount=1});
            Call(f.forge,"GiveReward",new RewardForgeSpinner{rewardType=RewardType.Weapon,rarityNum=1,amount=5});
            Check(r,Currencys.Coin==200 && Currencys.Crystal==5 && Currencys.MistikToken==1,"Actual GiveReward preserves200coin/5crystal/1mystic amounts");
            Check(r,f.commanders[1].LevelExp==5 && f.commanders[1].Level==2 && ES3.Load<int>("CommanderHeroExpZ1")==5,"Weapon reward saves exact XP without changing ownership level");
            Flush(); Check(r,ES3.Load<int>("CommanderHeroExpZ1")==5 && ES3.Load<int>("WeaponToken")==49,"Typed reward XP and balance survive actual ES3 disk flush/reload");
            f.commanders[1].Level=30;
            Check(r,Call(f.find,"GenerateRandomWeapon",WeaponRarity.Rare)==null,"Legacy acquisition excludes original serialized MaxLevel30");f.commanders[1].Level=2;
            f.find.AddChestExp(15); Check(r,FindNewWeapons.CurrentLevel==1 && FindNewWeapons.CurrentExp==0 && ES3.Load<int>("WeaponChestLevel")==1,"Exact15chest XP advances and saves level1");
            FindNewWeapons.CurrentLevel=25;FindNewWeapons.CurrentExp=0; f.find.AddChestExp(9999);
            Check(r,FindNewWeapons.CurrentLevel==25 && FindNewWeapons.CurrentExp==9999,"Original cap25 retains excess XP without another level");
            f.find.Close();Flush();Check(r,ES3.Load<int>("WeaponChestCurrentExp")==9999,"Actual Close saves XP and refreshes card balance");
            FindNewWeapons.CurrentLevel=0;FindNewWeapons.CurrentExp=0;
            // Run the real iterator synchronously in EditMode. WaitForSeconds timing is
            // covered separately by RunBatch; this does not claim callback/clock execution.
            f.find.gameObject.SetActive(false);f.find.guidecommanders=new List<Commander>{f.commanders[0],f.commanders[0],f.commanders[0],f.commanders[0],f.commanders[0],f.commanders[4]};
            f.commanders[0].Level=1;int before0=f.commanders[0].LevelExp,before4=f.commanders[4].LevelExp;
            var iterator=f.find.OpenChestsAndShowResults(6,5);int yields=0;while(iterator.MoveNext())yields++;
            Check(r,yields==7 && !f.find.IsSummonInProgress,"Actual legacy reward iterator completes six reveals plus final wait");
            Check(r,f.commanders[0].LevelExp==before0+25 && f.commanders[4].LevelExp==before4+5 && f.find.guidecommanders.Count==0,"Original paid tutorial list gives five common/final weapon cards then clears same list");
            Check(r,f.find.WeaponResults[0].adet.text=="x5" && f.find.WeaponResults[5]._title.text==f.commanders[4].HeroName,"Actual result view fills quantity and weapon name");
            r.observations.Add("Core uses actual Unity objects/Random, restored game classes and actual ES3. Explicit balances and Commander levels are isolated test inputs.");
        }
        static bool forgeShape(Fixture f)
        { return f.forge.rewardItems.Length==16 && f.forge.rewardItems[0].childCount==7 && f.forge.rewardItems[0].GetChild(1).name=="icon" && f.forge.rewardItems[0].GetChild(2).name=="adet" && f.forge.altrewardcontent.childCount>=10; }
        public static Result RunChecks()
        {
            if(EditorApplication.isPlayingOrWillChangePlaymode)throw new InvalidOperationException("RunChecks requires dedicated non-playing Editor.");
            using(var f=new Fixture(false))
            {
                try{Core(f);}catch(Exception e){f.result.failures.Add(e.ToString());}
                f.result.limitations.Add("Synchronous EditMode: iterator waits are enumerated, not timed. Use RunBatch for real paid callback/coroutine coverage.");Write(f.result);return f.result;
            }
        }
        public static void RunBatch()
        {
            if(EditorApplication.isPlayingOrWillChangePlaymode)throw new InvalidOperationException("Dedicated fresh Editor process required.");
            SessionState.SetBool(Intent,true);EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);EditorApplication.EnterPlaymode();
        }
        static void Mode(PlayModeStateChange mode)
        {
            if(!SessionState.GetBool(Intent,false))return;
            if(mode==PlayModeStateChange.EnteredPlayMode)EditorApplication.delayCall+=StartLive;
            if(mode==PlayModeStateChange.EnteredEditMode)
            { int exit=SessionState.GetInt(Intent+".exit",1);SessionState.EraseBool(Intent);EditorApplication.Exit(exit); }
        }
        static void StartLive()
        {
            try
            {
                live=new Fixture(false);Core(live);
                live.find.gameObject.SetActive(true);live.root.SetActive(true);
                // Fresh controlled input after independent core checks.
                foreach(var c in live.commanders){c.Level=2;c.LevelExp=0;ES3.Save<int>("CommanderHeroExpZ"+c.HeroNum,0);}
                live.find.guidecommanders.Clear();FindNewWeapons.CurrentLevel=0;FindNewWeapons.CurrentExp=0;
                Currencys.WeaponTokenFitle(1000);previousToken=1000;previousExp=0;previousLevel=0;previousXp=Snapshot(live);
                stage=0;freeSpins=0;started=EditorApplication.timeSinceStartup;
                live.find.Spend(1);
                Check(live.result,Currencys.WeaponToken==950 && live.find.IsSummonInProgress,"Actual Spend1 callback starts real coroutine and deducts50");
                EditorApplication.update+=Tick;
            }
            catch(Exception e){FailLive(e);}
        }
        static void Tick()
        {
            try
            {
                if(live==null)return;
                if(EditorApplication.timeSinceStartup-started>60)throw new TimeoutException("Home forge PlayMode stage"+stage);
                var f=live;var r=f.result;
                if(stage==0 && !f.find.IsSummonInProgress)
                {
                    Check(r,Xp(f)==6 && Currencys.WeaponToken==950 && FindNewWeapons.CurrentExp==6,"Actual six-card paid callback completes with exact6XP,6chestXP and no refund");
                    f.find.Spend(0);Check(r,Currencys.WeaponToken==700 && f.find.IsSummonInProgress,"Actual Spend0 callback deducts250 and starts five-card multiplier");stage=1;
                }
                else if(stage==1 && !f.find.IsSummonInProgress)
                {
                    Check(r,Xp(f)==36 && Currencys.WeaponToken==700 && FindNewWeapons.CurrentLevel==1 && FindNewWeapons.CurrentExp==21,"Second paid legacy pack adds30cardXP and30chestXP across original15XP threshold");
                    previousToken=Currencys.WeaponToken;f.forge.Spin10x();
                    Check(r,Currencys.WeaponToken==previousToken-50 && f.forge.IsSpinInProgress,"Actual Spin10x callback deducts50 and starts real selector coroutine");f.forge.SkipitBtn();stage=2;
                }
                else if(stage==2 && !f.forge.IsSpinInProgress)
                {
                    int token=Currencys.WeaponToken;
                    if(f.forge.freeSpinBtn.activeSelf && freeSpins<3)
                    {
                        f.forge.OnFreeSpinButton();f.forge.SkipitBtn();freeSpins++;
                        Check(r,Currencys.WeaponToken==token && f.forge.IsSpinInProgress,"Earned free-spin callback repeats at original multiplier without another charge");
                    }
                    else
                    {
                        Check(r,!f.forge.freeSpinBtn.activeSelf && f.forge.closebtn.activeSelf && f.forge.idleobjs.activeSelf && Get<int>(f.forge,"currentFreeThreshold")==5,"Paid spinner and earned repeats settle original UI/threshold state");
                        f.forge.Spin50x();Check(r,Currencys.WeaponToken==token-250 && f.forge.IsSpinInProgress,"Actual Spin50x callback deducts250 and starts multiplier5");f.forge.SkipitBtn();freeSpins=0;stage=3;
                    }
                }
                else if(stage==3 && !f.forge.IsSpinInProgress)
                {
                    if(f.forge.freeSpinBtn.activeSelf && freeSpins<3)
                    {int token=Currencys.WeaponToken;f.forge.OnFreeSpinButton();f.forge.SkipitBtn();freeSpins++;Check(r,Currencys.WeaponToken==token,"Earned multiplier5 repeat is not charged");}
                    else
                    {
                        Check(r,!f.forge.freeSpinBtn.activeSelf && f.forge.closebtn.activeSelf && Get<int>(f.forge,"currentFreeThreshold")==5,"Multiplier5 chain completes at original reset threshold5");
                        int[] xp=Snapshot(f);int token=Currencys.WeaponToken;int level=FindNewWeapons.CurrentLevel,exp=FindNewWeapons.CurrentExp;
                        f.find.Close();Flush();Currencys.WeaponTokenFitle(0); // Verify original disk state from before this deliberate in-memory wipe.
                        OfflineKeyStore.ResetMemoryForVerification();ES3.CacheFile("medupac.es3",new ES3Settings("medupac.es3",ES3.Location.File));Currencys.LoadStartWeaponToken();
                        Check(r,Currencys.WeaponToken==token && ES3.Load<int>("WeaponChestLevel",0)==level && ES3.Load<int>("WeaponChestCurrentExp")==exp,"Final actual callback state survives isolated disk cache reset/reload");
                        for(int i=0;i<xp.Length;i++)Check(r,ES3.Load<int>("CommanderHeroExpZ"+i,0)==xp[i],"Settled weapon XP survives disk reload"+i);
                        r.observations.Add("PlayMode uses actual StartCoroutine/WaitForSeconds and original paid callbacks. SkipitBtn fast-forwards selector waits; skipAnimationToggle remains original false.");
                        FinishLive();
                    }
                }
            }
            catch(Exception e){FailLive(e);}
        }
        static void FailLive(Exception e)
        {
            if(live!=null)live.result.failures.Add(e.ToString());else Debug.LogException(e);FinishLive();
        }
        static void FinishLive()
        {
            EditorApplication.update-=Tick;bool passed=false;
            if(live!=null){Write(live.result);passed=live.result.passed;live.Dispose();live=null;}
            SessionState.SetInt(Intent+".exit",passed?0:1);EditorApplication.ExitPlaymode();
        }
    }
}
