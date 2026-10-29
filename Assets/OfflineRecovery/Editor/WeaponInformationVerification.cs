using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LuckyForge.Offline.Editor
{
    public static class WeaponInformationVerification
    {
        [Serializable]public sealed class Result{public bool passed;public int checks;public List<string> failures=new List<string>();public string scope="Actual original scene icon hierarchy/button args and actual ArrowEpic asset; original RuntimeOnly listeners are inspected separately and display methods called directly in EditMode. Not physical or PlayMode button input.";}
        static void Check(Result r,bool ok,string label){r.checks++;if(!ok)r.failures.Add(label);}
        static TextMeshProUGUI Label(Transform parent,string name){var g=new GameObject(name,typeof(RectTransform),typeof(TextMeshProUGUI));g.transform.SetParent(parent,false);return g.GetComponent<TextMeshProUGUI>();}
        static string PathOf(Transform t){string p=t.name;for(t=t.parent;t;t=t.parent)p=t.name+"/"+p;return p;}
        public static Result RunChecks()
        {
            var r=new Result();var root=new GameObject("WeaponInformationVerification");root.SetActive(false);
            var original=SceneManager.GetSceneByPath("Assets/Scenes/Sahne.unity");bool opened=!original.IsValid()||!original.isLoaded;var previous=SceneManager.GetActiveScene();
            var state=new Dictionary<FieldInfo,object>();foreach(var f in typeof(PlayerData).GetFields(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static))if(!f.IsLiteral&&!f.IsInitOnly)state[f]=f.GetValue(null);
            int language=GameManager.Language;var lang=Lang.currentLang;long damage=Lang.WeaponSkillHasar;var culture=CultureInfo.CurrentCulture;Skill skill=null;double coin=Currencys.Coin;int energy=Currencys.Energy;
            try
            {
                foreach(var f in state.Keys)if(f.FieldType.GetConstructor(Type.EmptyTypes)!=null)f.SetValue(null,Activator.CreateInstance(f.FieldType));
                GameManager.Language=0;Lang.currentLang=null;
                if(opened)original=EditorSceneManager.OpenScene("Assets/Scenes/Sahne.unity",OpenSceneMode.Additive);
                var source=Resources.FindObjectsOfTypeAll<CraftAndSell>().Single(c=>c.gameObject.scene==original);
                Check(r,source.skillIconContent.childCount==4&&source.chooserskill&&source.skilltitle&&source.skillsubtitle&&source.cdpassive,"original information component has4icon slots and exact text/selector links");
                var craft=root.AddComponent<CraftAndSell>();craft.enabled=false;
                craft.skillIconContent=UnityEngine.Object.Instantiate(source.skillIconContent.gameObject,root.transform,false).transform;
                craft.chooserskill=UnityEngine.Object.Instantiate(source.chooserskill.gameObject,root.transform,false).transform;
                craft.cdpassive=Label(root.transform,"Cooldown");craft.skilltitle=Label(root.transform,"Title");craft.skillsubtitle=Label(root.transform,"Subtitle");
                var asset=AssetDatabase.FindAssets("t:ArrowEpic").Select(g=>AssetDatabase.LoadAssetAtPath<ArrowEpic>(AssetDatabase.GUIDToAssetPath(g))).FirstOrDefault(s=>s!=null);
                Check(r,asset&&asset.skillName.SequenceEqual(new[]{"ArrowEpic","ArrowEpic2"})&&asset.requiredLevel.SequenceEqual(new[]{1,8}),"actual original ArrowEpic data has native names and level1/8 boundaries");
                if(!asset)throw new InvalidOperationException("Original ArrowEpic asset missing.");skill=UnityEngine.Object.Instantiate(asset);
                var go=new GameObject("IsolatedSourceCommander");go.transform.SetParent(root.transform);var commander=go.AddComponent<Commander>();commander.enabled=false;commander.StartATK=100;commander.Type=WeaponType.Bow;commander.Rarity=WeaponRarity.Epic;commander.Level=1;
                var skills=go.AddComponent<CommanderSkills>();skills.enabled=false;commander.commanderSkills=skills;skills.skill=skill;skills.activeSkills=new SkillInstance(skill,commander,null);
                typeof(CraftAndSell).GetField("ilkcommander",BindingFlags.NonPublic|BindingFlags.Instance).SetValue(craft,commander);
                for(int i=0;i<4;i++)
                {
                    var row=craft.skillIconContent.GetChild(i);Check(r,row.GetChild(0).GetChild(0).GetComponent<Image>()&&row.GetChild(1),"original icon/lock hierarchy for slot"+i);
                    var button=row.GetComponent<Button>();bool bound=false;
                    if(button)
                    {
                        var serialized=new SerializedObject(button);var calls=serialized.FindProperty("m_OnClick.m_PersistentCalls.m_Calls");
                        for(int j=0;j<calls.arraySize;j++){var call=calls.GetArrayElementAtIndex(j);if(call.FindPropertyRelative("m_MethodName").stringValue!="OpenSkillText")continue;Check(r,call.FindPropertyRelative("m_Target").objectReferenceValue==source&&call.FindPropertyRelative("m_Arguments.m_IntArgument").intValue==i,"original serialized skill callback index"+i);call.FindPropertyRelative("m_Target").objectReferenceValue=craft;bound=true;}
                        serialized.ApplyModifiedPropertiesWithoutUndo();
                    }
                    Check(r,bound,"original skill slot exposes its actual OpenSkillText Button"+i);
                }
                craft.skillIconContent.GetChild(2).gameObject.SetActive(false);craft.skillIconContent.GetChild(3).gameObject.SetActive(true);
                typeof(CraftAndSell).GetMethod("SkillSet",BindingFlags.Instance|BindingFlags.NonPublic).Invoke(craft,null);
                for(int i=0;i<2;i++)Check(r,craft.skillIconContent.GetChild(i).gameObject.activeSelf&&craft.skillIconContent.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>().sprite==skill.skillicon[i],"real source icon populates existing row"+i);
                Check(r,!craft.skillIconContent.GetChild(0).GetChild(1).gameObject.activeSelf&&craft.skillIconContent.GetChild(1).GetChild(1).gameObject.activeSelf,"original level1 first skill unlocked and second locked");
                Check(r,!craft.skillIconContent.GetChild(2).gameObject.activeSelf&&craft.skillIconContent.GetChild(3).gameObject.activeSelf&&!craft.skillIconContent.GetChild(2).GetChild(1).gameObject.activeSelf&&!craft.skillIconContent.GetChild(3).GetChild(1).gameObject.activeSelf,"native unused rows preserve existing activation and only clear lock children");
                // RuntimeOnly listeners are intentionally inactive in EditMode;
                // do not change their original callState to make a fixture pass.
                skill.cooldown=3f;craft.OpenSkillText(0);
                Check(r,craft.chooserskill.gameObject.activeSelf&&craft.chooserskill.position==craft.skillIconContent.GetChild(0).position&&craft.cdpassive.text==Lang.Get.CD+": "+3f.ToString("0.0")+" "+Lang.Get.saniyeuzun,"original first-skill display callback selects position and localized cooldown");
                Check(r,!string.IsNullOrEmpty(craft.skilltitle.text)&&!string.IsNullOrEmpty(craft.skillsubtitle.text)&&craft.skilltitle.text!="Unknown"&&Lang.WeaponSkillHasar>0,"real original SkillInstance title/subtitle and damage placeholder update");
                craft.OpenSkillText(1);Check(r,craft.cdpassive.text==Lang.Get.seviye+" 8 "+Lang.Get.required&&craft.chooserskill.position==craft.skillIconContent.GetChild(1).position,"original second-skill display callback preserves level8 requirement text");
                Check(r,!string.IsNullOrEmpty(craft.skilltitle.text)&&!string.IsNullOrEmpty(craft.skillsubtitle.text),"original locked skill still exposes source title and subtitle");
                commander.Level=8;typeof(CraftAndSell).GetMethod("SkillSet",BindingFlags.Instance|BindingFlags.NonPublic).Invoke(craft,null);Check(r,!craft.skillIconContent.GetChild(1).GetChild(1).gameObject.activeSelf,"real exactlevel8 unlock clears second icon lock");
                craft.OpenSkillText(1);Check(r,craft.cdpassive.text==Lang.Get.passive,"native later-skill branch uses passive label");
                skill.cooldown=0;craft.OpenSkillText(0);Check(r,craft.cdpassive.text==Lang.Get.Luck,"native first zero-cooldown branch retains Luck label");
                skill.cooldown=-1;craft.OpenSkillText(0);Check(r,craft.cdpassive.text==Lang.Get.Luck,"native negative-cooldown boundary retains Luck");
                CultureInfo.CurrentCulture=CultureInfo.GetCultureInfo("fr-FR");skill.cooldown=3.2f;craft.OpenSkillText(0);Check(r,craft.cdpassive.text==Lang.Get.CD+": 3,2 "+Lang.Get.saniyeuzun,"native0.0 formatting follows current culture, no invented invariant formatting");
                Check(r,Currencys.Coin==coin&&Currencys.Energy==energy&&asset.cooldown!=skill.cooldown,"information selection grants/spends nothing and original asset remains unchanged");
            }
            catch(Exception e){r.failures.Add(e.ToString());}
            finally
            {
                CultureInfo.CurrentCulture=culture;GameManager.Language=language;Lang.currentLang=lang;Lang.WeaponSkillHasar=damage;foreach(var item in state)item.Key.SetValue(null,item.Value);
                UnityEngine.Object.DestroyImmediate(root);if(skill)UnityEngine.Object.DestroyImmediate(skill);if(opened&&original.IsValid()&&original.isLoaded)EditorSceneManager.CloseScene(original,true);if(previous.IsValid()&&previous.isLoaded)SceneManager.SetActiveScene(previous);
            }
            r.passed=r.failures.Count==0;var folder=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification");Directory.CreateDirectory(folder);File.WriteAllText(Path.Combine(folder,"weapon-information.json"),JsonUtility.ToJson(r,true));return r;
        }
    }
}
