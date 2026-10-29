using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LuckyForge.Offline.Editor
{
    // Captures the actual Editor GameView RenderTexture without changing camera,
    // Canvas mode, scaling, materials or sprite state for capture.
    [InitializeOnLoad]public static class VisualReviewVerification
    {
        const string Key="LuckyForge.VisualReview.Root";const BindingFlags B=BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic;
        static double ready,deadline;static int phase;static bool finishing;static GameObject[] replacedWorld;static EditorWindow view;static Result result;
        [Serializable]public sealed class Result{public bool passed;public string root,identity="UnityEditor GameView actual target buffer; source main30a5e66 baseline/working edits recorded separately";public string setup="Isolated copy of a passed player profile, explicit visual test inputs original Seviye2(default, displayed Lv3)/MainHero1 owned; optional LUCKYFORGE_VISUAL_LEVEL is displayed level; not natural-progress evidence.";public int width,height;public List<WorldFrame> worldTrace=new List<WorldFrame>();public List<string> captures=new List<string>();public List<string> errors=new List<string>();}
        [Serializable]public sealed class Snapshot{public string name;public int width,height,level,hero;public float cameraZ,targetZ,minZ,maxZ;public string musicClip;public bool musicPlaying;public Vector3 actualCameraPosition,worldCameraPosition;public string worldCameraPath;public Chunk[] worldChunks;public bool worldEnabled,worldActive,worldIsActiveEnabled;public float worldOldZ,worldTimer,timeScale,deltaTime;public int worldUpdateILBytes,worldCameraID,handlerCameraID;public string defaultSprite;public List<Graphic> images=new List<Graphic>();public List<Card> cards=new List<Card>();}
        [Serializable]public sealed class WorldFrame{public int frame;public float dt,cameraZ,oldZ;public float[] chunks,parentZ;}
        [Serializable]public sealed class Chunk{public string name,path;public bool active;public Vector3 position;public int rendererCount,activeRenderers,visibleRenderers;public Bounds bounds;}
        [Serializable]public sealed class Graphic{public string path,sprite,texture;public Rect screenRect,spriteRect,textureRect;public Vector2 pivot;public Vector4 padding;public float ppu;public Vector3 meshCenter,meshSize;public bool hasMesh,preserveAspect,useSpriteMesh;public string type;}
        [Serializable]public sealed class Card{public string type,path;public Rect screenRect;}
        static VisualReviewVerification(){if(!string.IsNullOrEmpty(SessionState.GetString(Key,"")))Subscribe();}
        static Type T(string name)=>AppDomain.CurrentDomain.GetAssemblies().Select(a=>a.GetType(name)).First(t=>t!=null);
        static EditorWindow View=>view?view:(view=(EditorWindow)EditorWindow.GetWindow(T("UnityEditor.GameView")));
        static void Subscribe(){EditorApplication.update-=Tick;EditorApplication.update+=Tick;EditorApplication.playModeStateChanged-=Mode;EditorApplication.playModeStateChanged+=Mode;deadline=EditorApplication.timeSinceStartup+180;ready=0;}
        static void FixedGameView()
        {
            var sizesType=T("UnityEditor.GameViewSizes");var singleton=typeof(ScriptableSingleton<>).MakeGenericType(sizesType);var sizes=singleton.GetProperty("instance",BindingFlags.Public|BindingFlags.Static).GetValue(null);
            var group=sizesType.GetMethod("GetGroup",B).Invoke(sizes,new[]{Enum.Parse(T("UnityEditor.GameViewSizeGroupType"),"Standalone")});
            var size=Activator.CreateInstance(T("UnityEditor.GameViewSize"),B,null,new object[]{Enum.Parse(T("UnityEditor.GameViewSizeType"),"FixedResolution"),607,1280,"LuckyForge Visual607x1280"},CultureInfo.InvariantCulture);
            group.GetType().GetMethod("AddCustomSize",B).Invoke(group,new[]{size});int index=(int)group.GetType().GetMethod("GetTotalCount",B).Invoke(group,null)-1;
            View.GetType().GetProperty("selectedSizeIndex",B).SetValue(View,index);View.Show();View.Focus();View.Repaint();
        }
        public static void RunBatch()
        {
            try{Prepare();}catch(Exception e){Debug.LogException(e);SessionState.EraseString(Key);EditorApplication.Exit(1);}
        }
        static void Prepare()
        {
            string project=Directory.GetParent(Application.dataPath).FullName;string label=Environment.GetEnvironmentVariable("LUCKYFORGE_VISUAL_LABEL")??"before";
            string root=Path.Combine(project,"Verification","VisualReview",label+"-"+Guid.NewGuid().ToString("N"));Directory.CreateDirectory(Path.Combine(root,"Profile"));
            string source=Environment.GetEnvironmentVariable("LUCKYFORGE_VISUAL_PROFILE_SOURCE")??Path.Combine(project,"Verification","WindowsPlayer","current9-46d77dd0d56a47fd83bb747e1062ff2e","Profile");if(!Directory.Exists(source))throw new DirectoryNotFoundException("Set LUCKYFORGE_VISUAL_PROFILE_SOURCE to a verified isolated Profile directory for visual review.");foreach(var file in Directory.GetFiles(source))File.Copy(file,Path.Combine(root,"Profile",Path.GetFileName(file)));
            OfflineKeyStore.SetVerificationRoot(Path.Combine(root,"Profile"));ES3.Save<int>("Seviye",int.TryParse(Environment.GetEnvironmentVariable("LUCKYFORGE_VISUAL_LEVEL"),out int displayedLevel)?displayedLevel-1:2);ES3.Save<bool>("GuideDone",true);ES3.Save<bool>("NewUserTPNation",true);ES3.Save<int>("MainHeroNum",1);ES3.Save<int>("MainHeroLevel1",1);ES3.Save<int>("Energy",70);ES3.Save<int>("Crystal",80);ES3.Save<string>("Coin","10144");ES3.Save<int>("WeaponToken",150);ES3.StoreCachedFile("medupac.es3",new ES3Settings("medupac.es3",ES3.Location.File));OfflineKeyStore.SetVerificationRoot(null);
            Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ROOT",null);Environment.SetEnvironmentVariable("LUCKYFORGE_VISUAL_REVIEW_ROOT",root);SessionState.SetString(Key,root);FixedGameView();Subscribe();EditorSceneManager.OpenScene("Assets/Scenes/Loading.unity",OpenSceneMode.Single);EditorApplication.isPlaying=true;Debug.Log("Visual review root="+root);
        }
        static string PathOf(Transform t){string p=t.name;for(t=t.parent;t;t=t.parent)p=t.name+"/"+p;return p;}
        static Rect ScreenRect(RectTransform rect)
        {var c=rect.GetComponentInParent<Canvas>();var camera=c&&c.renderMode!=RenderMode.ScreenSpaceOverlay?c.worldCamera:null;var points=new Vector3[4];rect.GetWorldCorners(points);var a=RectTransformUtility.WorldToScreenPoint(camera,points[0]);var z=RectTransformUtility.WorldToScreenPoint(camera,points[2]);return Rect.MinMaxRect(a.x,a.y,z.x,z.y);}
        static RenderTexture Buffer()
        {
            for(var t=View.GetType();t!=null;t=t.BaseType){var f=t.GetField("m_RenderTexture",B);if(f!=null&&f.GetValue(View)is RenderTexture rt&&rt.width>0)return rt;}
            throw new InvalidOperationException("Actual GameView m_RenderTexture unavailable; no replacement camera render claimed.");
        }
        static void Capture(string name)
        {
            var rt=Buffer();if(rt.width!=607||rt.height!=1280||Screen.width!=607||Screen.height!=1280)throw new InvalidOperationException("Actual GameView viewport differs from607x1280: buffer="+rt.width+"x"+rt.height+" screen="+Screen.width+"x"+Screen.height);
            var s=new Snapshot{name=name,width=Screen.width,height=Screen.height,level=GameManager.Level,defaultSprite=TMPro.TMP_Settings.defaultSpriteAsset?TMPro.TMP_Settings.defaultSpriteAsset.name:"null"};var cam=UnityEngine.Object.FindFirstObjectByType<CameraHandler>();if(cam){s.cameraZ=cam.transform.position.z;s.targetZ=cam.targetZ;s.minZ=cam.minZ;s.maxZ=cam.maxZ;}var hero=UnityEngine.Object.FindFirstObjectByType<HeroController>();if(hero)s.hero=hero.MainHeroNum;
            if(Camera.main)s.actualCameraPosition=Camera.main.transform.position;
            var world=UnityEngine.Object.FindFirstObjectByType<BolumOdulleri>();if(world){s.worldEnabled=world.enabled;s.worldActive=world.gameObject.activeInHierarchy;s.worldIsActiveEnabled=world.isActiveAndEnabled;s.worldOldZ=(float)typeof(BolumOdulleri).GetField("oldpozcamera",B).GetValue(world);s.worldTimer=(float)typeof(BolumOdulleri).GetField("timercamera",B).GetValue(world);s.timeScale=Time.timeScale;s.deltaTime=Time.deltaTime;s.worldUpdateILBytes=typeof(BolumOdulleri).GetMethod("Update",B).GetMethodBody().GetILAsByteArray().Length;s.worldCameraID=world.cameraTransform.GetInstanceID();s.handlerCameraID=world.cameraHandler.transform.GetInstanceID();s.worldCameraPath=PathOf(world.cameraTransform);s.worldCameraPosition=world.cameraTransform.position;s.worldChunks=world.activeBolumler.Where(g=>g!=null).Select(g=>{var renderers=g.GetComponentsInChildren<SpriteRenderer>(true);var active=renderers.Where(r=>r.enabled&&r.gameObject.activeInHierarchy).ToArray();var bounds=new Bounds(g.transform.position,Vector3.zero);bool first=true;foreach(var r in active){if(first){bounds=r.bounds;first=false;}else bounds.Encapsulate(r.bounds);}return new Chunk{name=g.name,path=PathOf(g.transform),active=g.activeInHierarchy,position=g.transform.position,rendererCount=renderers.Length,activeRenderers=active.Length,visibleRenderers=active.Count(r=>r.isVisible),bounds=bounds};}).ToArray();}
            if(SoundManager.instance&&SoundManager.instance.musicSource){var m=SoundManager.instance.musicSource;s.musicClip=m.clip?m.clip.name:"null";s.musicPlaying=m.isPlaying;}
            foreach(var image in UnityEngine.Object.FindObjectsByType<UnityEngine.UI.Image>(FindObjectsSortMode.None))
            {
                if(s.images.Count>=700)break;var g=new Graphic{path=PathOf(image.transform),screenRect=ScreenRect(image.rectTransform),preserveAspect=image.preserveAspect,useSpriteMesh=image.useSpriteMesh,type=image.type.ToString()};var sprite=image.overrideSprite?image.overrideSprite:image.sprite;
                if(sprite){g.sprite=sprite.name;g.texture=sprite.texture?sprite.texture.name:"null";g.spriteRect=sprite.rect;g.pivot=sprite.pivot;g.ppu=sprite.pixelsPerUnit;g.padding=UnityEngine.Sprites.DataUtility.GetPadding(sprite);try{g.textureRect=sprite.textureRect;}catch{} }
                var mesh=image.canvasRenderer.GetMesh();if(mesh&&mesh.vertexCount>0){g.hasMesh=true;g.meshCenter=mesh.bounds.center;g.meshSize=mesh.bounds.size;}s.images.Add(g);
            }
            foreach(var c in UnityEngine.Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))if(c is HeroUpgradeSkinTek||c is TalentTekliUi||c is FindedWeaponTekliUi||c is TalentFindedTekli){var rect=c.transform as RectTransform;if(rect)s.cards.Add(new Card{type=c.GetType().Name,path=PathOf(c.transform),screenRect=ScreenRect(rect)});}
            var old=RenderTexture.active;var pixels=new Texture2D(rt.width,rt.height,TextureFormat.RGBA32,false);try{RenderTexture.active=rt;pixels.ReadPixels(new Rect(0,0,rt.width,rt.height),0,0);pixels.Apply();if(SystemInfo.graphicsUVStartsAtTop){var rows=pixels.GetPixels32();int width=rt.width,height=rt.height;for(int y=0;y<height/2;y++)for(int x=0;x<width;x++){int a=y*width+x,z=(height-1-y)*width+x;var temp=rows[a];rows[a]=rows[z];rows[z]=temp;}pixels.SetPixels32(rows);pixels.Apply();}File.WriteAllBytes(Path.Combine(result.root,name+".png"),pixels.EncodeToPNG());}finally{RenderTexture.active=old;UnityEngine.Object.DestroyImmediate(pixels);}
            File.WriteAllText(Path.Combine(result.root,name+".json"),JsonUtility.ToJson(s,true));UiGeometrySnapshot.Write(Path.Combine(result.root,name+"-geometry.json"));result.captures.Add(name);Debug.Log("Visual snapshot "+name+"607x1280 images="+s.images.Count+" cards="+s.cards.Count);
        }
        static void VerifyHome()
        {
            var w=UnityEngine.Object.FindFirstObjectByType<BolumOdulleri>();var h=UnityEngine.Object.FindFirstObjectByType<HeroController>();int[] map={0,1,2,3,4,5,2,3,4,5};
            if(w.activeBolumler.Count(g=>g!=null)!=3||w.activeBolumler.Select(g=>g.GetInstanceID()).Distinct().Count()!=3)throw new InvalidOperationException("Home world must have exactly3 live distinct chunks");
            if(ES3.Load<int>("MainHeroNum",0)!=h.MainHeroNum||Enumerable.Range(0,10).Any(i=>w.characterSet[i].sprite!=h.currentMainHero.iconSet[map[i]]))throw new InvalidOperationException("Home character does not match saved Gears character10-part icon mapping");
            if(!TMPro.TMP_Settings.defaultSpriteAsset||TMPro.TMP_Settings.defaultSpriteAsset.name!="MeduSprite")throw new InvalidOperationException("Wrong default inline sprite atlas");
        }
        static void Click(string path)
        {var g=OriginalUiTestClick.Resolve(path);var b=g?g.GetComponent<UnityEngine.UI.Button>():null;if(!b||!b.isActiveAndEnabled||!b.IsInteractable())throw new InvalidOperationException("Original visible button unavailable: "+path);b.onClick.Invoke();}
        static void Tick()
        {
            if(finishing||string.IsNullOrEmpty(SessionState.GetString(Key,"")))return;
            try
            {
                if(EditorApplication.timeSinceStartup>deadline)throw new TimeoutException("Visual review actual GameView readiness");if(!EditorApplication.isPlaying||SceneManager.GetActiveScene().name!="Sahne")return;
                if(result==null){result=new Result{root=SessionState.GetString(Key,"")};ready=EditorApplication.timeSinceStartup+12;return;}if(result!=null&&phase==1&&Environment.GetEnvironmentVariable("LUCKYFORGE_VISUAL_WORLD_TICK_DIAG")=="1"&&(result.worldTrace.Count==0||result.worldTrace[result.worldTrace.Count-1].frame!=Time.frameCount)){var w=UnityEngine.Object.FindFirstObjectByType<BolumOdulleri>();result.worldTrace.Add(new WorldFrame{frame=Time.frameCount,dt=Time.deltaTime,cameraZ=w.cameraTransform.position.z,oldZ=(float)typeof(BolumOdulleri).GetField("oldpozcamera",B).GetValue(w),chunks=w.activeBolumler.Select(g=>g.transform.position.z).ToArray(),parentZ=w.activeBolumler.Select(g=>g.transform.parent.position.z).ToArray()});}if(EditorApplication.timeSinceStartup<ready)return;View.Repaint();
                var camera=UnityEngine.Object.FindFirstObjectByType<CameraHandler>();const string bottom="Canvases/BottomCanvas/SafeArea/";
                switch(phase)
                {
                    case 0:VerifyHome();Capture("home-min");camera.targetZ=camera.maxZ;ready=EditorApplication.timeSinceStartup+5;break;
                    case 1:Capture("home-top");if(Environment.GetEnvironmentVariable("LUCKYFORGE_VISUAL_WORLD_TICK_DIAG")=="1"){var diag=UnityEngine.Object.FindFirstObjectByType<BolumOdulleri>();typeof(BolumOdulleri).GetMethod("UpdateBolumPositions",B).Invoke(diag,null);Capture("home-top-after-direct-tick");phase=100;ready=EditorApplication.timeSinceStartup+2;return;}var world=UnityEngine.Object.FindFirstObjectByType<BolumOdulleri>();replacedWorld=world.activeBolumler.ToArray();world.BolumuYerlestir();camera.targetZ=camera.minZ;ready=EditorApplication.timeSinceStartup+5;break;
                    case 100:Capture("home-top-after-settled-tick");var settled=UnityEngine.Object.FindFirstObjectByType<BolumOdulleri>();replacedWorld=settled.activeBolumler.ToArray();settled.BolumuYerlestir();camera.targetZ=camera.minZ;ready=EditorApplication.timeSinceStartup+5;phase=1;break;
                    case 2:VerifyHome();if(replacedWorld.Any(g=>g!=null))throw new InvalidOperationException("Original world replacement did not destroy old chunks in PlayMode");if(Environment.GetEnvironmentVariable("LUCKYFORGE_VISUAL_HOME_ONLY")=="1"){Finish();break;}Click(bottom+"bottombtns/bottombtn (3)/onclick");ready=EditorApplication.timeSinceStartup+2;break;
                    case 3:Capture("weapons");Click(bottom+"bottombtns/bottombtn (1)/onclick");ready=EditorApplication.timeSinceStartup+2;break;
                    case 4:Capture("talents");Click(bottom+"bottombtns/bottombtn (3)/onclick");ready=EditorApplication.timeSinceStartup+2;break;
                    case 5:Click(bottom+"BottomPAGES/Pages/Weapons/skins/top/Summon");ready=EditorApplication.timeSinceStartup+2;break;
                    case 6:Capture("summon-page");Click("Canvases/GenelCanvas/SafeArea/GachaFindWeapon/pack/alt/satinal");ready=EditorApplication.timeSinceStartup+8;break;
                    case 7:Capture("summon-result");Finish();break;
                }
                phase++;
            }catch(Exception e){if(result==null)result=new Result{root=SessionState.GetString(Key,"")};result.errors.Add(e.ToString());Finish();}
        }
        static void Finish(){if(finishing)return;finishing=true;result.errors.AddRange(VisualReviewContext.errors);result.passed=result.errors.Count==0;result.width=Screen.width;result.height=Screen.height;File.WriteAllText(Path.Combine(result.root,"visual-review.json"),JsonUtility.ToJson(result,true));Debug.Log("Visual review passed="+result.passed+" root="+result.root);EditorApplication.isPlaying=false;}
        static void Mode(PlayModeStateChange state)
        {
            if(state!=PlayModeStateChange.EnteredEditMode)return;
            string root=SessionState.GetString(Key,"");if(string.IsNullOrEmpty(root)||!File.Exists(Path.Combine(root,"visual-review.json")))return;
            EditorApplication.delayCall+=()=>{var saved=JsonUtility.FromJson<Result>(File.ReadAllText(Path.Combine(root,"visual-review.json")));SessionState.EraseString(Key);Environment.SetEnvironmentVariable("LUCKYFORGE_VISUAL_REVIEW_ROOT",null);if(saved.passed&&Environment.GetEnvironmentVariable("LUCKYFORGE_VISUAL_BUILD_AFTER")=="1"){VerifiedVisualBuildWindows.RunBatch();return;}EditorApplication.Exit(saved.passed?0:1);};
        }
    }
}
