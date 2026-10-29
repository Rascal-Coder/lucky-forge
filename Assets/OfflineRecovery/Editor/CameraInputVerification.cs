using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace LuckyForge.Offline.Editor
{
    public static class CameraInputVerification
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
        const BindingFlags B=BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic;
        static void Check(Result r,bool yes,string message)
        {r.checks++;if(!yes)r.failures.Add(message);}
        static void Call(CameraHandler c,string method,params object[] args)
        {typeof(CameraHandler).GetMethod(method,B).Invoke(c,args);}
        static Vector3 World(CameraHandler c,Vector3 mouse,float z)
        {return (Vector3)typeof(CameraHandler).GetMethod("GetWorldPointAtZ",B).Invoke(c,new object[]{mouse,z});}
        static void Set(CameraHandler c,string field,object value)
        {typeof(CameraHandler).GetField(field,B).SetValue(c,value);}
        static bool Get(CameraHandler c,string field)
        {return (bool)typeof(CameraHandler).GetField(field,B).GetValue(c);}
        static bool Near(float a,float b){return Mathf.Abs(a-b)<.0001f;}
        static void Drag(CameraHandler c,Vector3 mouse,float startZ,float worldDeltaY,float screenDelta)
        {
            var now=World(c,mouse,c.transform.position.z);
            Set(c,"dragStartScreenPos",mouse+new Vector3(screenDelta,0,0));
            Set(c,"dragStartWorldPos",now-new Vector3(0,worldDeltaY,0));
            Set(c,"dragStartZ",startZ);Set(c,"dragStarted",true);Set(c,"isDragging",false);
        }
        public static Result RunChecks()
        {
            var r=new Result{testRoot=Path.Combine(Path.GetTempPath(),"LuckyForgeCameraInputChecks",Guid.NewGuid().ToString("N"))};Directory.CreateDirectory(r.testRoot);
            if(EditorApplication.isPlayingOrWillChangePlaymode)
            {r.failures.Add("Use dedicated non-playing Editor, no active input event.");return r;}
            bool oldBattle=GecisControl.savastayim,oldGuide=GameManager.guidecamera;
            var mainTags=new List<GameObject>();GameObject root=null;
            try
            {
                if(Input.GetMouseButtonDown(0)||Input.GetMouseButtonUp(0))throw new InvalidOperationException("Dedicated quiet input frame required.");
                foreach(var cam in Resources.FindObjectsOfTypeAll<Camera>())
                    if(cam.gameObject.scene.IsValid() && cam.gameObject.scene.isLoaded && cam.CompareTag("MainCamera"))
                    {mainTags.Add(cam.gameObject);cam.gameObject.tag="Untagged";}
                root=new GameObject("CameraInputVerification");root.SetActive(false);root.tag="MainCamera";
                var camera=root.AddComponent<Camera>();var c=root.AddComponent<CameraHandler>();c.enabled=false;c.camera=camera;
                // Exact independent original Sahne GO5843 values; no original scene write.
                c.minZ=-230f;c.maxZ=194.3f;c.smoothSpeed=7.5f;c.dragMultiplier=2.2f;c.dragThreshold=4f;
                root.transform.position=new Vector3(0f,271f,-250.3f);
                root.transform.rotation=new Quaternion(0.42261827f,0f,0f,0.9063079f);
                camera.nearClipPlane=.01f;camera.farClipPlane=449.86f;camera.fieldOfView=19f;
                root.SetActive(true);Call(c,"Start");
                GecisControl.savastayim=false;GameManager.guidecamera=false;
                Check(r,Camera.main==camera,"Real Camera.main resolves isolated actual Unity camera");
                Check(r,camera.orthographic && Near(camera.orthographicSize,71.2f) && c.targetZ==-230f && c.transform.position.z==-230f,"Existing Start preserves original home projection and map minimum");
                Vector3 original=c.transform.position;
                c.SetTargetZDirect(1e6f);Check(r,Near(c.targetZ,194.3f)&&Near(c.transform.position.z,194.3f),"Direct chapter target clamps upper map boundary");
                c.SetTargetZDirect(-1e6f);Check(r,c.targetZ==-230f&&c.transform.position.z==-230f,"Direct chapter target clamps lower map boundary");
                c.SetTargetZDirect(0f);Check(r,c.targetZ==0f&&c.transform.position.z==0f&&c.transform.position.x==original.x&&c.transform.position.y==original.y,"Direct target retains original camera X/Y");
                var mouse=Input.mousePosition;
                var expectedScreen=new Vector3(mouse.x,mouse.y,camera.WorldToScreenPoint(new Vector3(0,0,c.transform.position.z)).z);
                Check(r,(World(c,mouse,c.transform.position.z)-camera.ScreenToWorldPoint(expectedScreen)).sqrMagnitude<1e-8f,"Actual helper uses Camera.main depth projection and ScreenToWorldPoint");
                root.tag="Untagged";Check(r,World(c,mouse,0)==Vector3.zero,"Original no-main-camera fallback returns Vector3.zero");root.tag="MainCamera";
                // Deliberately supply legal drag start state. The implementation still
                // reads real legacy Input.mousePosition and actual Unity projection.
                // This is not a fabricated OS Down/Up event and is reported as such.
                Drag(c,mouse,0f,1f,4f);Call(c,"Update");
                Check(r,!Get(c,"isDragging")&&!c.draggingInfo&&c.targetZ==0f,"Exactly4pixels does not cross strict native drag threshold");
                Drag(c,mouse,0f,1f,5f);Call(c,"Update");
                Check(r,Get(c,"isDragging")&&c.draggingInfo&&Near(c.targetZ,-2.2f),"Actual Update crosses5pixels and maps worldY1 to targetZ-2.2");
                c.SetTargetZDirect(0);Drag(c,mouse,0f,-2f,5f);Call(c,"Update");
                Check(r,Near(c.targetZ,4.4f),"Reverse world drag maps worldY-2 to targetZ+4.4");
                c.SetTargetZDirect(0);Drag(c,mouse,0f,1e6f,5f);Call(c,"Update");
                Check(r,c.targetZ==-230f,"Actual drag clamps at original minZ");
                c.SetTargetZDirect(0);Drag(c,mouse,0f,-1e6f,5f);Call(c,"Update");
                Check(r,Near(c.targetZ,194.3f),"Actual reverse drag clamps at original maxZ");
                c.SetTargetZDirect(0);Drag(c,mouse,0f,2f,5f);c.draggingInfo=false;
                GecisControl.savastayim=true;Call(c,"Update");
                Check(r,c.targetZ==0f && !Get(c,"isDragging")&&!c.draggingInfo,"Battle gate preserves position and pending drag state");
                GecisControl.savastayim=false;GameManager.guidecamera=true;Call(c,"Update");
                Check(r,c.targetZ==0f && !Get(c,"isDragging")&&!c.draggingInfo,"Guide camera gate preserves pending drag state");
                GameManager.guidecamera=false;Call(c,"Update");
                Check(r,Near(c.targetZ,-4.4f)&&c.draggingInfo,"Releasing guide gate resumes original pending drag");
                c.SetTargetZDirect(0);Set(c,"isDragging",false);Set(c,"dragStarted",false);c.targetZ=100f;
                float t=Mathf.Clamp01(Time.deltaTime*7.5f);Call(c,"Update");
                Check(r,Near(c.transform.position.z,100f*t)&&!c.draggingInfo,"Existing Update uses clamped real deltaTime smoothing and publishes non-drag state");
                c.GameIn();Check(r,!camera.orthographic && Near(camera.fieldOfView,19f)&&c.targetZ==-255f&&c.transform.position.z==-255f,"Preserved battle transition remains-255 perspective19");
                Call(c,"Start");Check(r,camera.orthographic&&c.targetZ==-230f,"Existing home reset restores map range after battle transition");
                r.observations.Add("All six CameraHandler methods were already restored and matched original ARM64. No runtime source or scene changes required.");
                r.observations.Add("Checks invoke actual CameraHandler.Update, Unity legacy Input.mousePosition, Camera projection and Time.deltaTime; legal initial drag states are set by reflection for isolation.");
                r.limitations.Add("Does not inject or verify physical OS mouse Down/Up, touch compatibility, EventSystem blocking, rendered map visibility or clicking chapter rewards. No input adapter was added.");
            }
            catch(Exception e){r.failures.Add(e.ToString());}
            finally
            {
                if(root!=null)UnityEngine.Object.DestroyImmediate(root);
                foreach(var o in mainTags)if(o!=null)o.tag="MainCamera";
                GecisControl.savastayim=oldBattle;GameManager.guidecamera=oldGuide;
                r.passed=r.failures.Count==0;File.WriteAllText(Path.Combine(r.testRoot,"camera-input-results.json"),JsonUtility.ToJson(r,true));
                Debug.Log("CameraInput checks="+r.checks+" passed="+r.passed+" result="+r.testRoot);
            }
            return r;
        }
    }
}
