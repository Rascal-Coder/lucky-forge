using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;

// Explicit diagnostic only. The chapter assignments below are synthetic test
// inputs in an independent profile; they are not earned campaign progression.
public static class HomeWorldSweepSmoke
{
    [Serializable] public sealed class Tile
    {
        public int id;public string name;public Vector3 position;public bool activeSelf,activeInHierarchy;
        public int rendererCount,enabledRendererCount,visibleRendererCount;
        public Bounds allRendererBounds,activeRendererBounds;public RendererEvidence[] largestRenderers;
    }
    [Serializable] public sealed class RendererEvidence
    {
        public string name,sprite,shader;public bool active,enabled,visible;public int sortingOrder;public Bounds bounds;public Rect projectedBounds;
    }
    [Serializable] public sealed class State
    {
        public int frame;public float real,timeScale,minZ,maxZ,targetZ,oldCamera,timerCamera;
        public Vector3 cameraHandlerPosition,worldCameraPosition,viewCameraPosition,viewCameraEuler;
        public float aspect,orthographicSize,fieldOfView;public bool orthographic;public Rect pixelRect;
        public int[] originalNativeIndices;public Tile[] tiles;public int[] placementCloneIds;
    }
    [Serializable] public sealed class Endpoint
    {
        public string name,screenshot;public bool screenshotWritten,stationaryBeforeValidation,wrapperWasAlreadyStable,reusedOnlyOriginalThree;
        public int screenshotRequestFrame,screenshotCompleteFrame;public State atScreenshot,beforeValidation,afterValidation;
    }
    [Serializable] public sealed class Chapter
    {
        public int internalLevel,displayLevel,templateIndex,templateId;public string templateName;
        public int[] createdIds;public Endpoint max,returnMin;
    }
    [Serializable] public sealed class FileEvidence{public string path,sha256;public long bytes;}
    [Serializable] public sealed class Baseline{public string sourceRoot,sourceProbeSha256;public bool actualBaselinePassed;public int initialLevel;public FileEvidence[] files;}
    [Serializable] public sealed class Report
    {
        public bool passed,explicitProbeOnly,restoredInitialChapter,baselineSourceProbeAvailable,baselineSourceProbeVerified;public int checks,initialLevel,initialBestSurvive,templates;
        public string baselineManifest,baselineManifestSha256,baselineSource,scope="Synthetic chapter inputs0..17 in an isolated copy of Current10Profile. No victory/claim/settlement or resource grants. Screenshots precede validation wrapper calls; actual camera/source projection and min/max unchanged. PASS is structural convergence, not an assertion that every rendered pixel is nonblack; review screenshot candidates separately.";
        public List<string> failures=new List<string>();public List<Chapter> chapters=new List<Chapter>();
        public List<string> unityErrors=new List<string>();public FileEvidence[] profileBefore,profileAfter;
    }
    sealed class Context
    {
        public OfflineRuntimeProbe.Result main;public string root,profile;public Report report=new Report();
        public BolumOdulleri world;public CanvasJobs canvas;public int oldLevel,oldBest,oldWorldBest;public bool oldElite;public float oldCameraZ;
    }
    static readonly BindingFlags Fields=BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic;
    static T Read<T>(object target,string name)=>(T)target.GetType().GetField(name,Fields).GetValue(target);
    static void Check(Context c,bool ok,string label){c.report.checks++;if(!ok){c.report.failures.Add(label);c.main.errors.Add("home-world-sweep: "+label);}}
    static string Digest(string path){using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-","").ToLowerInvariant();}
    static FileEvidence[] Files(string root)=>Directory.Exists(root)?Directory.GetFiles(root,"*",SearchOption.AllDirectories).OrderBy(p=>p).Select(p=>new FileEvidence{path=p.Substring(root.Length).TrimStart(Path.DirectorySeparatorChar,Path.AltDirectorySeparatorChar),bytes=new FileInfo(p).Length,sha256=Digest(p)}).ToArray():Array.Empty<FileEvidence>();
    public static IEnumerator Run(OfflineRuntimeProbe.Result result,string root)
    {
        var c=new Context{main=result,root=Path.GetFullPath(root)};c.profile=Path.Combine(c.root,"Profile");
        string requested=Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ROOT");
        c.report.explicitProbeOnly=!string.IsNullOrEmpty(requested)&&Path.GetFullPath(requested)==c.root&&Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS")=="home-world-sweep";
        if(!c.report.explicitProbeOnly){result.errors.Add("HomeWorldSweepSmoke requires explicit matching probe root/actions; no scene/save access performed.");yield break;}
        IEnumerator body=Execute(c);
        try {
            while(true){bool more=false;try{more=body.MoveNext();}catch(Exception e){Check(c,false,e.ToString());}if(!more)break;yield return body.Current;}
        } finally {
            try {
                if(c.world&&!c.report.restoredInitialChapter)RestoreInitial(c);
                c.report.profileAfter=Files(c.profile);
            }catch(Exception e){Check(c,false,"Restore/report failure: "+e);}
            c.report.unityErrors=new List<string>(result.errors);c.report.passed=c.report.failures.Count==0&&result.errors.Count==0&&c.report.chapters.Count==18&&c.report.restoredInitialChapter;
            result.homeWorldSweepCompleted=c.report.passed;result.homeWorldSweepChecks=c.report.checks;
            Directory.CreateDirectory(c.root);File.WriteAllText(Path.Combine(c.root,"world-sweep.json"),JsonUtility.ToJson(c.report,true));
        }
    }
    static IEnumerator Execute(Context c)
    {
        c.report.baselineManifest=Path.Combine(c.root,"world-sweep-baseline.json");
        Check(c,File.Exists(c.report.baselineManifest)&&Directory.Exists(c.profile),"Explicit Current10 baseline manifest and independent Profile must be prepared before launch.");if(c.report.failures.Count>0)yield break;
        var baseline=JsonUtility.FromJson<Baseline>(File.ReadAllText(c.report.baselineManifest));c.report.baselineManifestSha256=Digest(c.report.baselineManifest);c.report.baselineSource=baseline.sourceRoot;
        Check(c,baseline.actualBaselinePassed&&baseline.initialLevel==2&&GameManager.Level==baseline.initialLevel,"Actual successful Level2 baseline is loaded before synthetic inputs.");if(c.report.failures.Count>0)yield break;
        string sourceProbe=string.IsNullOrEmpty(baseline.sourceRoot)?"":Path.Combine(baseline.sourceRoot,"runtime-probe.json");c.report.baselineSourceProbeAvailable=File.Exists(sourceProbe);
        if(c.report.baselineSourceProbeAvailable){var original=JsonUtility.FromJson<OfflineRuntimeProbe.Result>(File.ReadAllText(sourceProbe));c.report.baselineSourceProbeVerified=Digest(sourceProbe)==baseline.sourceProbeSha256&&original.passed&&original.level==2&&!original.inBattle&&original.errors!=null&&original.errors.Count==0;Check(c,c.report.baselineSourceProbeVerified,"Available original baseline probe matches recorded SHA256 and actual successful Level2/home/zero-error result.");if(c.report.failures.Count>0)yield break;}
        string verificationRoot=(string)typeof(OfflineKeyStore).GetField("verificationRoot",BindingFlags.Static|BindingFlags.NonPublic).GetValue(null);
        Check(c,!string.IsNullOrEmpty(verificationRoot)&&Path.GetFullPath(verificationRoot)==Path.GetFullPath(c.profile),"Probe uses only its independent Profile, never the existing player save.");if(c.report.failures.Count>0)yield break;
        c.report.profileBefore=Files(c.profile);
        var world=UnityEngine.Object.FindObjectsByType<BolumOdulleri>(FindObjectsInactive.Include,FindObjectsSortMode.None).FirstOrDefault(w=>w.gameObject.scene.name=="Sahne");
        Check(c,world&&world.gameObject.activeInHierarchy&&world.enabled,"Original Sahne world is active; real Update must perform automatic convergence.");if(!world)yield break;
        var canvas=world.canvasJobs;Check(c,canvas&&world.cameraHandler&&world.cameraTransform&&world.cameraHandler.camera,"Original world/camera/CanvasJobs references exist.");if(!canvas||!world.cameraHandler||!world.cameraTransform||!world.cameraHandler.camera)yield break;
        c.world=world;c.canvas=canvas;c.oldLevel=GameManager.Level;c.oldBest=GameManager.BestSurvive;c.oldElite=GameManager.EliteON;c.oldWorldBest=world.bestSurvive;c.oldCameraZ=world.cameraHandler.transform.position.z;
        c.report.initialLevel=c.oldLevel;c.report.initialBestSurvive=c.oldBest;c.report.templates=world.Bolumler.childCount;
        Check(c,c.report.templates==16,"Original scene contains all16 template children.");Check(c,!GecisControl.savastayim&&Time.timeScale>0,"Sweep begins on actual home with positive timeScale; it does not force time/projection.");if(c.report.failures.Count>0)yield break;
        for(int level=0;level<18;level++) {
            GameManager.Level=level;GameManager.BestSurvive=0;GameManager.EliteON=false;world.bestSurvive=0;
            // Synthetic chapter input only: do not call OnEnable, settlement, claims or battle win paths.
            world.BolumuYerlestir();world.UpdateMaxZForCurrentLevel();world.UpdateCharacterPosition();canvas.UpdateStageInfos();
            var template=world.Bolumler.GetChild(level%world.Bolumler.childCount);
            var row=new Chapter{internalLevel=level,displayLevel=level+1,templateIndex=level%world.Bolumler.childCount,templateId=template.gameObject.GetInstanceID(),templateName=template.name};c.report.chapters.Add(row);
            world.cameraHandler.SetTargetZDirect(world.cameraHandler.minZ);yield return Frames(8);
            row.createdIds=Ids(world.activeBolumler);
            Check(c,row.createdIds.Length==3&&row.createdIds.Distinct().Count()==3&&world.activeBolumler.All(g=>g.name==template.name+"(Clone)"),"Level"+level+" instantiates only original selected template in3 distinct slots.");
            world.cameraHandler.SetTargetZDirect(world.cameraHandler.maxZ);yield return Frames(12);
            row.max=new Endpoint{name="max",screenshot=Path.Combine(c.root,"world-level-"+level.ToString("D2")+"-max.png")};
            yield return CaptureThenValidate(c,row,row.max,true);
            world.cameraHandler.SetTargetZDirect(world.cameraHandler.minZ);yield return Frames(10);
            row.returnMin=new Endpoint{name="return-min",screenshot=""};
            Validate(c,row,row.returnMin);Check(c,Mathf.Abs(world.cameraHandler.transform.position.z-world.cameraHandler.minZ)<.0001f,"Level"+level+" immediate return reaches original minZ.");
        }
        RestoreInitial(c);yield return Frames(8);
    }
    static void RestoreInitial(Context c)
    {
        GameManager.Level=c.oldLevel;GameManager.BestSurvive=c.oldBest;GameManager.EliteON=c.oldElite;c.world.bestSurvive=c.oldWorldBest;c.world.BolumuYerlestir();c.world.UpdateMaxZForCurrentLevel();c.world.UpdateCharacterPosition();c.canvas.UpdateStageInfos();c.world.cameraHandler.SetTargetZDirect(c.oldCameraZ);c.report.restoredInitialChapter=GameManager.Level==c.oldLevel;
    }
    static IEnumerator Frames(int count){for(int i=0;i<count;i++)yield return null;}
    static int[] Ids(IEnumerable<GameObject> items)=>items.Where(g=>g).Select(g=>g.GetInstanceID()).OrderBy(id=>id).ToArray();
    static Rect Project(Camera camera,Bounds b)
    {
        float x0=float.PositiveInfinity,y0=float.PositiveInfinity,x1=float.NegativeInfinity,y1=float.NegativeInfinity;
        for(int i=0;i<8;i++){var p=camera.WorldToScreenPoint(b.center+Vector3.Scale(b.extents,new Vector3((i&1)==0?-1:1,(i&2)==0?-1:1,(i&4)==0?-1:1)));if(p.z<=0)continue;x0=Mathf.Min(x0,p.x);x1=Mathf.Max(x1,p.x);y0=Mathf.Min(y0,p.y);y1=Mathf.Max(y1,p.y);}
        return float.IsInfinity(x0)?new Rect():Rect.MinMaxRect(x0,y0,x1,y1);
    }
    static Tile TileState(GameObject go,Camera camera)
    {
        if(!go)return new Tile{name="null"};var rs=go.GetComponentsInChildren<SpriteRenderer>(true);var active=rs.Where(r=>r.enabled&&r.gameObject.activeInHierarchy).ToArray();Bounds all=new Bounds(go.transform.position,Vector3.zero),visible=all;
        if(rs.Length>0){all=rs[0].bounds;foreach(var r in rs.Skip(1))all.Encapsulate(r.bounds);}if(active.Length>0){visible=active[0].bounds;foreach(var r in active.Skip(1))visible.Encapsulate(r.bounds);}
        return new Tile{id=go.GetInstanceID(),name=go.name,position=go.transform.position,activeSelf=go.activeSelf,activeInHierarchy=go.activeInHierarchy,rendererCount=rs.Length,enabledRendererCount=active.Length,visibleRendererCount=rs.Count(r=>r.isVisible),allRendererBounds=all,activeRendererBounds=visible,largestRenderers=rs.OrderByDescending(r=>r.bounds.size.sqrMagnitude).Take(8).Select(r=>new RendererEvidence{name=r.name,sprite=r.sprite?r.sprite.name:"null",shader=r.sharedMaterial&&r.sharedMaterial.shader?r.sharedMaterial.shader.name:"null",active=r.gameObject.activeInHierarchy,enabled=r.enabled,visible=r.isVisible,sortingOrder=r.sortingOrder,bounds=r.bounds,projectedBounds=Project(camera,r.bounds)}).ToArray()};
    }
    static State Snapshot(BolumOdulleri w)
    {
        var camera=w.cameraHandler.camera;var clones=new List<GameObject>();foreach(var placement in w.YerlesecekYerler)for(int i=0;i<placement.childCount;i++){var go=placement.GetChild(i).gameObject;if(go.name.EndsWith("(Clone)",StringComparison.Ordinal))clones.Add(go);}
        return new State{frame=Time.frameCount,real=Time.realtimeSinceStartup,timeScale=Time.timeScale,minZ=w.cameraHandler.minZ,maxZ=w.cameraHandler.maxZ,targetZ=w.cameraHandler.targetZ,oldCamera=Read<float>(w,"oldpozcamera"),timerCamera=Read<float>(w,"timercamera"),cameraHandlerPosition=w.cameraHandler.transform.position,worldCameraPosition=w.cameraTransform.position,viewCameraPosition=camera.transform.position,viewCameraEuler=camera.transform.eulerAngles,aspect=camera.aspect,orthographic=camera.orthographic,orthographicSize=camera.orthographicSize,fieldOfView=camera.fieldOfView,pixelRect=camera.pixelRect,originalNativeIndices=(int[])Read<int[]>(w,"activeBolumIndices").Clone(),tiles=w.activeBolumler.Select(g=>TileState(g,camera)).ToArray(),placementCloneIds=Ids(clones)};
    }
    static bool Same(State a,State b)
    {
        if(a.tiles.Length!=b.tiles.Length)return false;
        for(int i=0;i<a.tiles.Length;i++)if(a.tiles[i].id!=b.tiles[i].id||!a.tiles[i].position.Equals(b.tiles[i].position)||a.tiles[i].activeSelf!=b.tiles[i].activeSelf)return false;
        return a.placementCloneIds.SequenceEqual(b.placementCloneIds);
    }
    static IEnumerator CaptureThenValidate(Context c,Chapter row,Endpoint endpoint,bool max)
    {
        endpoint.atScreenshot=Snapshot(c.world);endpoint.screenshotRequestFrame=Time.frameCount;bool requested=true;
        if(File.Exists(endpoint.screenshot)){Check(c,false,"Refusing a stale max screenshot: prepare a fresh independent sweep root before rerunning.");yield break;}
        try{ScreenCapture.CaptureScreenshot(endpoint.screenshot);}catch(Exception e){Check(c,false,"Native screenshot request failed: "+e);requested=false;}
        if(requested){float end=Time.realtimeSinceStartup+8f;while(Time.realtimeSinceStartup<end&&!File.Exists(endpoint.screenshot))yield return null;yield return null;endpoint.screenshotCompleteFrame=Time.frameCount;endpoint.screenshotWritten=File.Exists(endpoint.screenshot)&&new FileInfo(endpoint.screenshot).Length>64;Check(c,endpoint.screenshotWritten,"Level"+row.internalLevel+" actual screen max screenshot written before validation call.");}
        Validate(c,row,endpoint);
        Check(c,Mathf.Abs(c.world.cameraHandler.transform.position.z-c.world.cameraHandler.maxZ)<.0001f,"Level"+row.internalLevel+" max screenshot uses original maxZ endpoint.");
    }
    static void Validate(Context c,Chapter row,Endpoint endpoint)
    {
        endpoint.beforeValidation=Snapshot(c.world);if(endpoint.atScreenshot==null)endpoint.atScreenshot=endpoint.beforeValidation;
        endpoint.stationaryBeforeValidation=Same(endpoint.atScreenshot,endpoint.beforeValidation);
        Check(c,endpoint.stationaryBeforeValidation,"Level"+row.internalLevel+" "+endpoint.name+" world remains stationary between settled render and validation.");
        typeof(BolumOdulleri).GetMethod("UpdateBolumPositions",Fields).Invoke(c.world,null);
        endpoint.afterValidation=Snapshot(c.world);endpoint.wrapperWasAlreadyStable=Same(endpoint.beforeValidation,endpoint.afterValidation);
        Check(c,endpoint.wrapperWasAlreadyStable,"Level"+row.internalLevel+" "+endpoint.name+" real Update already converged: one verification wrapper call must change nothing.");
        endpoint.reusedOnlyOriginalThree=Ids(c.world.activeBolumler).SequenceEqual(row.createdIds)&&endpoint.beforeValidation.placementCloneIds.SequenceEqual(row.createdIds)&&endpoint.afterValidation.placementCloneIds.SequenceEqual(row.createdIds);
        Check(c,endpoint.reusedOnlyOriginalThree,"Level"+row.internalLevel+" "+endpoint.name+" endpoint scroll reuses exact same3 clones with no additional template roots.");
        Check(c,endpoint.beforeValidation.tiles.Length==3&&endpoint.beforeValidation.tiles.All(t=>t.id!=0),"Level"+row.internalLevel+" "+endpoint.name+" has all3 real tile references.");
    }
}
