using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;
namespace LuckyForge.Offline.Editor {
public static class HomeStageVerification {
 [Serializable] public class Result {public bool passed;public int checks;public List<string> failures=new List<string>();}
 static void Check(Result r,bool value,string label){r.checks++;if(!value)r.failures.Add(label);}
 static T Add<T>(Transform parent,string name)where T:Component{var g=new GameObject(name,typeof(RectTransform));g.SetActive(false);g.transform.SetParent(parent,false);return g.AddComponent<T>();}
 static FieldInfo Field(Type type,string name)=>type.GetField(name,BindingFlags.Instance|BindingFlags.Static|BindingFlags.NonPublic|BindingFlags.Public);
 static object Get(object value,string name)=>Field(value.GetType(),name).GetValue(value);
 public static Result RunChecks(string suppliedRoot=null){
 if(EditorApplication.isPlaying)throw new InvalidOperationException("Run in non-playing isolated Editor process.");
 string rootPath=suppliedRoot??Path.Combine(Path.GetTempPath(),"LuckyForgeHomeStageChecks",Guid.NewGuid().ToString("N"));Directory.CreateDirectory(rootPath);
 var result=new Result();var saved=new Dictionary<FieldInfo,object>();
 foreach(var f in typeof(GameManager).GetFields(BindingFlags.Static|BindingFlags.Public|BindingFlags.NonPublic))if(!f.IsLiteral&&!f.IsInitOnly)saved[f]=f.GetValue(null);
 foreach(var f in typeof(Currencys).GetFields(BindingFlags.Static|BindingFlags.Public|BindingFlags.NonPublic))if(!f.IsLiteral&&!f.IsInitOnly)saved[f]=f.GetValue(null);
 var langField=Field(typeof(Lang),"currentLang");object oldLang=langField.GetValue(null);
 var root=new GameObject("HomeStageVerification");root.SetActive(false);var textures=new List<Texture2D>();var sprites=new List<Sprite>();
 try{
 GameManager.Language=0;langField.SetValue(null,null);
 var c=Add<CanvasJobs>(root.transform,"Canvas");var war=Add<WarController>(root.transform,"War");c.warController=war;
 c.siegeName=Add<TextMeshProUGUI>(root.transform,"Name");c.siegeLevel=Add<TextMeshProUGUI>(root.transform,"Level");c.bestsurvive=Add<TextMeshProUGUI>(root.transform,"Best");c.bestsurviveKac=Add<TextMeshProUGUI>(root.transform,"BestCount");war.bolgename=Add<TextMeshProUGUI>(root.transform,"BattleName");
 Check(result,(double)Get(c,"oldpara")==-1d,"ctor oldpara -1");Check(result,(int)Get(c,"oldcrystal")==-1,"ctor oldcrystal -1");Check(result,(int)Get(c,"oldreklamkupon")==-1,"ctor oldreklamkupon -1");Check(result,(float)Get(c,"smoothTime")==3f,"ctor smoothTime 3");
 var names=(string[])Get(c,"Bolgeisimleri");Check(result,names.Length==100,"100 recovered region names");Check(result,names[0]=="Ardent"&&names[1]=="Brinor"&&names[99]=="Vireth","native array store indices");
 GameManager.EliteON=false;GameManager.Level=1;GameManager.BestSurvive=7;c.UpdateStageInfos();
 Check(result,c.siegeName.text=="Brinor "+Lang.Get.bolgesi,"level1 region title");Check(result,c.siegeLevel.text==Lang.Get.lv+"2","level1 next stage 2");Check(result,war.bolgename.text=="Brinor "+Lang.Get.lv+"2","battle region title");Check(result,c.bestsurvive.text==Lang.Get.bestsurvive&&c.bestsurviveKac.text=="7","normal best progress");
 GameManager.Level=101;c.UpdateStageInfos();Check(result,c.siegeName.text=="Brinor "+Lang.Get.bolgesi&&c.siegeLevel.text==Lang.Get.lv+"102","region wraps 100, level remains unwrapped");
 GameManager.EliteON=true;GameManager.EliteLevel=2;GameManager.BestSurviveElites=13;war.MaxWaveCountLevels=new[]{10,20,30,40,50,60,70,80,90,100,110};c.UpdateStageInfos();
 Check(result,c.siegeName.text==Lang.Get.Elite+" "+Lang.Get.bolgesi+" #3","elite title");Check(result,war.bolgename.text==Lang.Get.Elite+" #3","elite battle title");Check(result,c.bestsurvive.text==Lang.Get.BestSurvive+" 13/30","elite progress uses original cap array");Check(result,c.siegeLevel.text==Lang.Get.lv+"102"&&c.bestsurviveKac.text=="7","native elite preserves normal-only labels");
 GameManager.EliteLevel=100;c.UpdateStageInfos();Check(result,c.bestsurvive.text==Lang.Get.BestSurvive+" 13/110","elite cap index clamps10");
 c._para=Add<TextMeshProUGUI>(root.transform,"Coin");c._crystal=Add<TextMeshProUGUI>(root.transform,"Crystal");c._para.text="12345";c._crystal.text="1000";
 Field(typeof(Currencys),"<Coin>k__BackingField").SetValue(null,0d);Field(typeof(Currencys),"<Crystal>k__BackingField").SetValue(null,0);Field(typeof(CanvasJobs),"regenTimer").SetValue(c,0f);
 typeof(CanvasJobs).GetMethod("Update",BindingFlags.NonPublic|BindingFlags.Instance).Invoke(c,null);
 Check(result,c._crystal.text=="0","initial true zero replaces serialized Crystal1000");Check(result,c._para.text==ShortScaleString.parseDouble(0d,1,1000000d,true),"initial true zero replaces serialized Coin");Check(result,Currencys.Coin==0d&&Currencys.Crystal==0,"HUD redraw never grants balance");
 var preview=Add<AnaSayfaEnemyAyarlaryici>(root.transform,"Preview");preview.enemies=new SpriteRenderer[5];for(int i=0;i<5;i++)preview.enemies[i]=Add<SpriteRenderer>(root.transform,"Enemy"+i);
 for(int i=0;i<3;i++){var t=new Texture2D(1,1);textures.Add(t);sprites.Add(Sprite.Create(t,new Rect(0,0,1,1),Vector2.zero));}
 var distribute=typeof(AnaSayfaEnemyAyarlaryici).GetMethod("EneyleriDiz",BindingFlags.Instance|BindingFlags.NonPublic);distribute.Invoke(preview,new object[]{sprites.ToArray()});
 Check(result,preview.enemies[0].sprite==sprites[0]&&preview.enemies[1].sprite==sprites[0]&&preview.enemies[2].sprite==sprites[1]&&preview.enemies[3].sprite==sprites[1]&&preview.enemies[4].sprite==sprites[2],"native preview proportional distribution 5 over3");
 distribute.Invoke(preview,new object[]{new Sprite[0]});Check(result,preview.enemies[4].sprite==sprites[2],"empty preview sprites no-op");distribute.Invoke(preview,new object[]{new[]{sprites[1]}});Check(result,Array.TrueForAll(preview.enemies,e=>e.sprite==sprites[1]),"single preview sprite repeats");
 }catch(Exception e){result.failures.Add(e.ToString());}finally{foreach(var p in saved)p.Key.SetValue(null,p.Value);langField.SetValue(null,oldLang);UnityEngine.Object.DestroyImmediate(root);foreach(var s in sprites)UnityEngine.Object.DestroyImmediate(s);foreach(var t in textures)UnityEngine.Object.DestroyImmediate(t);}
 result.passed=result.failures.Count==0;File.WriteAllText(Path.Combine(rootPath,"home-stage-results.json"),JsonUtility.ToJson(result,true));Debug.Log("HomeStageVerification "+result.passed+" checks="+result.checks+" root="+rootPath);return result;
 }
}
}
