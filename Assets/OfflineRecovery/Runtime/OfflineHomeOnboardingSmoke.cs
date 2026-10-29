using System.Collections;
using System.Linq;
using UnityEngine;

// Exercises real serialized home-guide controls. No guide-state writes, page
// activation, balance grants, or direct replacement of the game's callbacks.
public static class OfflineHomeOnboardingSmoke
{
    const string Bottom="Canvases/BottomCanvas/SafeArea/";
    const string Weapons=Bottom+"BottomPAGES/Pages/Weapons/";
    const string Find="Canvases/GenelCanvas/SafeArea/GachaFindWeapon/";
    static GameObject Action(int state,GuideManagerRPG guide)
    {
        switch(state)
        {
            case 0:case 1: return OriginalUiTestClick.Resolve("GuideManager/Canvas/Safe/guidebtnilk");
            case 2:return OriginalUiTestClick.Resolve(Bottom+"bottombtns/bottombtn (3)/onclick");
            case 552:return OriginalUiTestClick.Resolve(Weapons+"skins/top/Summon");
            case 553:return OriginalUiTestClick.Resolve(Find+"pack/alt/satinal");
            case 554:return OriginalUiTestClick.Resolve(Find+"alt (2)/Close (1)");
            case 555:
                if(guide.CommanderOneCikanPage.activeInHierarchy)return OriginalUiTestClick.Resolve("GuideManager/Canvas/Safe/guidebtnilk");
                var card=Object.FindObjectsByType<HeroUpgradeSkinTek>(FindObjectsSortMode.None).FirstOrDefault(c=>c.commander==guide.commonArrow);
                return card?card.gameObject:null;
            case 556:return OriginalUiTestClick.Resolve(Weapons+"SkinOneCikanPage/items/Stats/upgradebtnsarea/btn (4)");
            case 557:return OriginalUiTestClick.Resolve(Weapons+"SkinOneCikanPage/items/Close (1)");
            case 558:return OriginalUiTestClick.Resolve(Bottom+"bottombtns/bottombtn (2)/onclick");
        }
        return null;
    }
    public static IEnumerator Run(OfflineRuntimeProbe.Result result,string root)
    {
        var guide=Object.FindFirstObjectByType<GuideManagerRPG>();
        if(!guide){result.errors.Add("Original home guide is absent after earned first victory.");yield break;}
        float end=Time.realtimeSinceStartup+150f,lastClick=-100f;
        int lastState=int.MinValue;string lastBlocked="";
        while(Time.realtimeSinceStartup<end && result.errors.Count==0)
        {
            int state=guide.GuideNum;
            if(state!=lastState){result.homeStates.Add(state+"; t="+Time.realtimeSinceStartup+"; token="+Currencys.WeaponToken+"; coin="+Currencys.Coin);Debug.Log("Recovery home guide "+result.homeStates[result.homeStates.Count-1]);lastState=state;}
            if(state==7 && BottomPages.bottompageopennum==2)
            {
                result.homeTutorialCompleted=guide.commonArrow.Level>=2;
                result.weaponLevelAfter=guide.commonArrow.Level;
                yield return new WaitForSecondsRealtime(2f);break;
            }
            if(Time.realtimeSinceStartup-lastClick>=0.8f)
            {
                var control=Action(state,guide);
                string blocked;
                if(OriginalUiTestClick.Try(control,out blocked))
                {result.tutorialActions.Add("Original home UI pointer sequence at "+state+": "+control.name);lastClick=Time.realtimeSinceStartup;}
                else if(blocked!=lastBlocked)
                {lastBlocked=blocked;result.homeUiBlocks.Add(state+": "+blocked);Debug.Log("Recovery home UI blocked "+state+": "+blocked);}
            }
            yield return new WaitForSecondsRealtime(.2f);
        }
        RuntimeRecoveryRender.Capture(System.IO.Path.Combine(root,"home-onboarding-render.png"));
        if(!result.homeTutorialCompleted)result.errors.Add("Original first home onboarding did not reach state7 through visible serialized UI callbacks.");
    }

    public static IEnumerator RunTalent(OfflineRuntimeProbe.Result result,string root)
    {
        var guide=Object.FindFirstObjectByType<GuideManagerRPG>();
        if(!guide){result.errors.Add("Original continuing home guide is absent after second victory.");yield break;}
        float end=Time.realtimeSinceStartup+140f,lastClick=-100f;
        int lastState=-1;string previousBlocked="";
        while(Time.realtimeSinceStartup<end && result.errors.Count==0)
        {
            int state=guide.GuideNum;
            if(state!=lastState){result.homeStates.Add("talent "+state+"; t="+Time.realtimeSinceStartup+"; scroll="+Currencys.TalentScroll);Debug.Log("Recovery talent guide "+result.homeStates[result.homeStates.Count-1]);lastState=state;if(state==688 && BottomPages.bottompageopennum==1)RuntimeRecoveryRender.Capture(System.IO.Path.Combine(root,"talent-equipped-render.png"));}
            if(state==688 && BottomPages.bottompageopennum==2)
            {
                result.talentTutorialCompleted=TalentManager.Kullaniliyor!=null && TalentManager.Kullaniliyor.Length>2 && TalentManager.Kullaniliyor[2];
                yield return new WaitForSecondsRealtime(2f);break;
            }
            if(Time.realtimeSinceStartup-lastClick>=.8f)
            {
                GameObject control=null;
                if(state==200 || state==551)control=OriginalUiTestClick.Resolve("GuideManager/Canvas/Safe/guidebtnilk");
                else if(state==8)control=OriginalUiTestClick.Resolve(Bottom+"bottombtns/bottombtn (1)/onclick");
                else if(state==10)control=OriginalUiTestClick.Resolve(Bottom+"BottomPAGES/Pages/Talents/alt (1)/satinal");
                else if(state==550)
                {
                    control=OriginalUiTestClick.Resolve(Bottom+"BottomPAGES/Pages/Talents/TalentAc/Seamless/kapatvetekraral/Close (2)");
                    if(!control || !control.activeInHierarchy)control=OriginalUiTestClick.Resolve(Bottom+"BottomPAGES/Pages/Talents/List/ScrollRect/mask/List/Content/Bolge1/talent (2)");
                }
                else if(state==688)control=OriginalUiTestClick.Resolve(Bottom+"bottombtns/bottombtn (2)/onclick");
                string blocked;
                if(OriginalUiTestClick.Try(control,out blocked)){result.tutorialActions.Add("Original talent UI pointer sequence at "+state+": "+control.name);lastClick=Time.realtimeSinceStartup;}
                else if(blocked!=previousBlocked){previousBlocked=blocked;result.homeUiBlocks.Add("talent "+state+": "+blocked);Debug.Log("Recovery talent UI blocked "+state+": "+blocked);}
            }
            yield return new WaitForSecondsRealtime(.2f);
        }
        RuntimeRecoveryRender.Capture(System.IO.Path.Combine(root,"talent-onboarding-render.png"));
        if(!result.talentTutorialCompleted)result.errors.Add("Original second home onboarding did not equip earned talent2 and return to battle through visible serialized UI.");
    }
}
