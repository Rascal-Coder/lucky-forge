using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyForge.Offline.Editor
{
    public static class RogueChoiceVerification
    {
        [Serializable] public sealed class Result { public bool passed; public int checks; public List<string> failures=new List<string>(); }
        static void Check(Result r,bool ok,string name) { r.checks++; if(!ok)r.failures.Add(name); }
        static GameObject Child(GameObject root,string name) { var go=new GameObject(name);go.transform.SetParent(root.transform);return go; }
        public static Result RunChecks()
        {
            var r=new Result();
            int originalLevel=GameManager.Level;
            var originalStats=PlayerData.SkillsStats;
            var originalRandom=UnityEngine.Random.state;
            var root=new GameObject("RogueChoiceVerification");root.SetActive(false);
            try
            {
                var choices=root.AddComponent<RogueLikeSkillSec>();
                choices.InitializeSkills();
                Check(r,choices.SkillList.Count==40 && choices.SkillList.Select(s=>s.Num).SequenceEqual(Enumerable.Range(0,40)),"all40 native records preserve sequence");
                var unit=new SkillUnit(99,"test",12.5f,9,RaritySkill.Epic,3);
                unit.FindSkill();unit.FindSkill();unit.FindSkill();
                Check(r,unit.Level==3 && unit.GetTotalEffect()==37.5f,"real SkillUnit increments and float product");
                PlayerData.SkillsStats=new PlayerData.Skills();
                PlayerData.SkillsStats.commonWeaponATK1=100f;
                choices.SkillList[0].Level=2;
                choices.ApplySkills();
                Check(r,PlayerData.SkillsStats.commonWeaponATK1==20f,"native ApplySkills overwrites, not accumulates");
                var differentInstance=new PlayerData.Skills { commonWeaponATK1=333f };
                differentInstance.ResetAllStats();
                Check(r,PlayerData.SkillsStats.commonWeaponATK1==0f && differentInstance.commonWeaponATK1==333f,"native reset targets global SkillsStats rather than receiver");
                Check(r,!string.IsNullOrEmpty(choices.GetValueAdd(0)) && !choices.GetValueAdd(0).Contains("{0}"),"original localized effect placeholder formats");
                choices.warController=root.AddComponent<WarController>();
                choices.slotMachine=root.AddComponent<SlotMachine>();
                choices.commanderSpawner=root.AddComponent<CommanderSpawner>();
                choices.warController.MaxCastleHealth=500;
                choices.warController.CastleHp=500;
                choices.slotMachine.currentLevel=19;
                choices.commanderSpawner.currentCommanderCount=20;
                choices.CurrentRarity=RaritySkill.Common;
                choices.colorsnedir=new[]{new Color32(1,2,3,255),new Color32(4,5,6,255),new Color32(7,8,9,255),new Color32(10,11,12,255)};
                choices.rarityHighColors=new[]{Color.white,Color.green,Color.blue,Color.yellow};
                choices.skillObj=new GameObject[3];choices._colors=new Image[3];choices._skillName=new TextMeshProUGUI[3];choices._skillSubtitle=new TextMeshProUGUI[3];choices._rarityBackHigh=new Image[3];choices.skilliconsArea=new Transform[3];
                for(int i=0;i<3;i++)
                {
                    var card=Child(root,"Card"+i);choices.skillObj[i]=card;
                    choices._colors[i]=Child(card,"Color").AddComponent<Image>();
                    choices._skillName[i]=Child(card,"Name").AddComponent<TextMeshProUGUI>();
                    choices._skillSubtitle[i]=Child(card,"Description").AddComponent<TextMeshProUGUI>();
                    choices._rarityBackHigh[i]=Child(card,"Rarity").AddComponent<Image>();
                    choices.skilliconsArea[i]=Child(card,"Icons").transform;
                    for(int n=0;n<11;n++) Child(choices.skilliconsArea[i].gameObject,"Icon"+n);
                }
                GameManager.Level=1;
                UnityEngine.Random.InitState(42);
                choices.SkillSecimAcildi();
                Check(r,choices.SelectedSkills.Count==3 && choices.SelectedSkills.Select(s=>s.Num).Distinct().Count()==3,"draw chooses3 distinct native records");
                Check(r,choices.SelectedSkills.All(s=>s.IconNum<6 || s.IconNum==10),"early level/cap/health filters exclude token,heal,slot,summon");
                foreach(var skill in choices.SkillList) skill.Level=skill.MaxLevel;
                choices.SkillList[0].Level=0;
                choices.SkillSecimAcildi();
                Check(r,choices.SelectedSkills.Count==1 && choices.SelectedSkills[0].Num==0,"maxed skills excluded and short pool supported");
                Check(r,choices.skillObj[0].activeSelf && !choices.skillObj[1].activeSelf && !choices.skillObj[2].activeSelf,"short pool hides surplus cards");
                Check(r,choices.skilliconsArea[0].GetChild(0).gameObject.activeSelf && !choices.skilliconsArea[0].GetChild(1).gameObject.activeSelf,"native icon selection updates actual hierarchy");
                choices.SkillList[0].Level=choices.SkillList[0].MaxLevel;
                choices.SkillSecimAcildi();
                Check(r,choices.SelectedSkills.Count==0 && choices.skillObj.All(g=>!g.activeSelf),"empty eligible pool hides allcards");
            }
            catch(Exception ex) { r.failures.Add(ex.ToString()); }
            finally
            {
                GameManager.Level=originalLevel;PlayerData.SkillsStats=originalStats;UnityEngine.Random.state=originalRandom;
                UnityEngine.Object.DestroyImmediate(root);
            }
            r.passed=r.failures.Count==0;
            var path=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification","rogue-choice.json");
            Directory.CreateDirectory(Path.GetDirectoryName(path));File.WriteAllText(path,JsonUtility.ToJson(r,true));
            return r;
        }
    }
}
