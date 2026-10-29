using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LuckyForge.Offline.Editor
{
    // Opens original scenes for structural/render inspection only. Does not save scene changes.
    public static class SceneRecoveryInspection
    {
        [Serializable] private sealed class SceneInfo
        {
            public string path;
            public int gameObjects;
            public int missingScripts;
            public int canvases;
            public int activeCanvases;
            public int images;
            public int textObjects;
            public List<string> missingScriptObjects = new List<string>();
            public string capture;
        }
        [Serializable] private sealed class Report { public List<SceneInfo> scenes = new List<SceneInfo>(); public List<string> errors = new List<string>(); }
        private static Report report;
        private static int index;
        private static int frames;
        private static Camera recoveryCamera;
        private static RenderTexture texture;
        private static SceneInfo current;
        private static string folder;
        private static readonly string[] paths = {"Assets/Scenes/Loading.unity", "Assets/Scenes/Sahne.unity"};

        public static void RunBatch()
        {
            report = new Report(); index = 0;
            folder = Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Verification", "SceneInspection");
            Directory.CreateDirectory(folder);
            EditorApplication.update += Tick;
            OpenNext();
        }
        private static void OpenNext()
        {
            if (index == paths.Length) { Finish(); return; }
            var scene = EditorSceneManager.OpenScene(paths[index], OpenSceneMode.Single);
            current = new SceneInfo {path = paths[index]};
            report.scenes.Add(current);
            var all = new List<GameObject>();
            foreach (GameObject root in scene.GetRootGameObjects())
                foreach (Transform t in root.GetComponentsInChildren<Transform>(true)) all.Add(t.gameObject);
            current.gameObjects = all.Count;
            foreach (GameObject go in all)
            {
                int missing = GameObjectUtility.GetMonoBehavioursWithMissingScriptCount(go);
                current.missingScripts += missing;
                if (missing > 0 && current.missingScriptObjects.Count < 100) current.missingScriptObjects.Add(go.name + ":" + missing);
                current.images += go.GetComponents<UnityEngine.UI.Image>().Length;
                current.textObjects += go.GetComponents<TMPro.TMP_Text>().Length;
            }
            var cameraObject = new GameObject("RecoveryInspectionCamera");
            recoveryCamera = cameraObject.AddComponent<Camera>();
            recoveryCamera.orthographic = true;
            recoveryCamera.transform.position = new Vector3(0, 0, -100);
            recoveryCamera.orthographicSize = 10;
            recoveryCamera.clearFlags = CameraClearFlags.SolidColor;
            recoveryCamera.backgroundColor = new Color(0.06f, 0.06f, 0.08f);
            recoveryCamera.allowHDR = false;
            texture = new RenderTexture(720, 1280, 24, RenderTextureFormat.ARGB32);
            texture.Create();
            recoveryCamera.targetTexture = texture;
            foreach (GameObject go in all)
                foreach (Canvas canvas in go.GetComponents<Canvas>())
                {
                    current.canvases++;
                    if (canvas.isActiveAndEnabled) current.activeCanvases++;
                    if (canvas.isRootCanvas && canvas.renderMode != RenderMode.WorldSpace)
                    {
                        canvas.renderMode = RenderMode.ScreenSpaceCamera;
                        canvas.worldCamera = recoveryCamera;
                        canvas.planeDistance = 10;
                    }
                }
            Canvas.ForceUpdateCanvases();
            frames = 0;
        }
        private static void Tick()
        {
            if (current == null) return;
            if (++frames < 12) { EditorApplication.QueuePlayerLoopUpdate(); return; }
            try
            {
                Canvas.ForceUpdateCanvases();
                recoveryCamera.Render();
                RenderTexture previous = RenderTexture.active;
                RenderTexture.active = texture;
                var pixels = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
                pixels.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);
                pixels.Apply();
                current.capture = Path.Combine(folder, Path.GetFileNameWithoutExtension(current.path) + ".png");
                File.WriteAllBytes(current.capture, pixels.EncodeToPNG());
                UnityEngine.Object.DestroyImmediate(pixels);
                RenderTexture.active = previous;
                recoveryCamera.targetTexture = null;
                texture.Release();
                UnityEngine.Object.DestroyImmediate(texture);
                UnityEngine.Object.DestroyImmediate(recoveryCamera.gameObject);
                Debug.Log("Scene recovery inspection: " + current.path + ", objects=" + current.gameObjects + ", missing=" + current.missingScripts);
            }
            catch (Exception ex) { report.errors.Add(current.path + ": " + ex); }
            current = null;
            index++;
            try { OpenNext(); } catch (Exception ex) { report.errors.Add(ex.ToString()); Finish(); }
        }
        private static void Finish()
        {
            EditorApplication.update -= Tick;
            File.WriteAllText(Path.Combine(folder, "scene-inspection.json"), JsonUtility.ToJson(report, true));
            EditorApplication.Exit(report.errors.Count == 0 ? 0 : 1);
        }
    }
}
