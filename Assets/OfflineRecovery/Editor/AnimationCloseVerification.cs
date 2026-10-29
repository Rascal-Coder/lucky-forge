using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public static class AnimationCloseVerification
{
    const string Pending="LuckyForge.Offline.VerifyOriginalAnimationClose";
    [Serializable]public sealed class Result{public bool passed;public int checks;public bool playMode;public List<string> failures=new List<string>();}
    static AnimationCloseVerification(){EditorApplication.playModeStateChanged+=OnPlayState;}
    static void OnPlayState(PlayModeStateChange state){if(state==PlayModeStateChange.EnteredPlayMode&&SessionState.GetBool(Pending,false))EditorApplication.delayCall+=RunAndExit;}
    static void Check(Result r,bool ok,string label){r.checks++;if(!ok)r.failures.Add(label);}
    static Transform EnsurePath(Transform root,string path){var current=root;foreach(var segment in path.Split(new[]{'/'},StringSplitOptions.RemoveEmptyEntries)){var next=current.Find(segment);if(!next){var g=new GameObject(segment,typeof(RectTransform));g.transform.SetParent(current,false);next=g.transform;}current=next;}return current;}
    public static Result RunChecks()
    {
        var r=new Result{playMode=Application.isPlaying};GameObject root=null,other=null;float oldScale=Time.timeScale;
        try{
            Check(r,Application.isPlaying,"real animation-event dispatch requires PlayMode; use RunBatch to enter an isolated empty scene");if(!Application.isPlaying)return Finish(r);
            var clip=AssetDatabase.LoadAssetAtPath<AnimationClip>("Assets/AnimationClip/Lowchanceanim.anim");var controller=AssetDatabase.LoadAssetAtPath<AnimatorController>("Assets/AnimatorController/LowChance.controller");Check(r,clip&&controller,"original exported Lowchanceanim clip and LowChance controller exist");if(!clip||!controller)return Finish(r);
            var events=AnimationUtility.GetAnimationEvents(clip);bool originalEvent=false;foreach(var e in events)if(e.functionName=="ForAnim"&&Mathf.Abs(e.time-1.6333333f)<.00001f)originalEvent=true;Check(r,originalEvent&&Mathf.Abs(clip.length-1.6333333f)<.0001f,"actual original end-event ForAnim at1.6333333 seconds");
            var state=controller.layers[0].stateMachine.defaultState;Check(r,state&&state.name=="Lowchanceanim"&&state.motion==clip,"actual original default Animator state uses that same clip");
            root=new GameObject("OriginalLowChanceEvent",typeof(RectTransform));root.SetActive(false);root.AddComponent<FalseDestroyLater>();
            foreach(var binding in AnimationUtility.GetCurveBindings(clip)){
                var node=EnsurePath(root.transform,binding.path);if(binding.type==typeof(GameObject)||binding.type==typeof(Transform)||binding.type==typeof(RectTransform))continue;
                if(typeof(Component).IsAssignableFrom(binding.type)&&!node.GetComponent(binding.type))node.gameObject.AddComponent(binding.type);
            }
            var animator=root.AddComponent<Animator>();animator.runtimeAnimatorController=controller;animator.updateMode=AnimatorUpdateMode.UnscaledTime;animator.cullingMode=AnimatorCullingMode.AlwaysAnimate;root.SetActive(true);animator.Rebind();Time.timeScale=0f;animator.Play("Base Layer.Lowchanceanim",0,0f);animator.Update(.001f);
            var back=root.transform.Find("back")as RectTransform;Check(r,root.activeSelf&&back&&back.sizeDelta.x<0,"original clip begins collapsed while object remains active");
            animator.Update(.5f);Check(r,root.activeSelf&&Mathf.Abs(back.sizeDelta.x-1600.5f)<.2f,"original mask expands to native1600.5 without edited UI geometry");
            animator.Update(.9f);Check(r,root.activeSelf,"original object is still visible before its end event");animator.Update(.3f);Check(r,!root.activeSelf&&root,"actual original event dispatch invokes restored ForAnim and deactivates without destroying");
            root.SetActive(true);animator.Play("Base Layer.Lowchanceanim",0,0f);animator.Update(.001f);bool reopened=root.activeSelf;animator.Update(1.7f);Check(r,reopened&&!root.activeSelf,"repeated original activation closes through the event again");
            other=new GameObject("DirectOriginalForAnim");var component=other.AddComponent<FalseDestroyLater>();component.destroy=true;component.falseit=false;component.second=100;component.ForAnim();Check(r,other&&!other.activeSelf,"original ForAnim is unconditional deactivation regardless of unrelated timer/destroy flags");
        }catch(Exception ex){r.failures.Add(ex.ToString());}
        finally{Time.timeScale=oldScale;if(root)UnityEngine.Object.DestroyImmediate(root);if(other)UnityEngine.Object.DestroyImmediate(other);}
        return Finish(r);
    }
    static Result Finish(Result r){r.passed=r.failures.Count==0;var folder=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification");Directory.CreateDirectory(folder);File.WriteAllText(Path.Combine(folder,"animation-close.json"),JsonUtility.ToJson(r,true));return r;}
    static void RunAndExit(){if(!SessionState.GetBool(Pending,false))return;SessionState.SetBool(Pending,false);var r=RunChecks();Debug.Log(JsonUtility.ToJson(r));EditorApplication.Exit(r.passed?0:1);}
    public static void RunBatch(){SessionState.SetBool(Pending,true);if(Application.isPlaying){EditorApplication.delayCall+=RunAndExit;return;}EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);EditorApplication.EnterPlaymode();}
}
