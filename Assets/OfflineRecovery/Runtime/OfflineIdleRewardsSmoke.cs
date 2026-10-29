using System;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// Opt-in end-to-end check. Only elapsed real play time and original visible
// controls; never changes wallclock, resources, unlock flags, or player state.
public static class OfflineIdleRewardsSmoke
{
    static IEnumerator Click(GameObject control, Action<bool> done)
    {
        float end=Time.realtimeSinceStartup+12f;
        while(Time.realtimeSinceStartup<end)
        {
            string blocked;
            if(OriginalUiTestClick.Try(control,out blocked)){done(true);yield break;}
            yield return new WaitForSecondsRealtime(.2f);
        }
        done(false);
    }
    public static IEnumerator Run(OfflineRuntimeProbe.Result result,string root)
    {
        var manager=UnityEngine.Object.FindObjectsByType<NewOfflineRewards>(FindObjectsInactive.Include,FindObjectsSortMode.None).FirstOrDefault();
        if(!manager){result.errors.Add("Original idle reward manager missing.");yield break;}
        if(GameManager.NewUserTapNation && GameManager.Level<6)
        {
            var entry=Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g=>g.scene.IsValid()&&g.scene.isLoaded&&g.name=="idleRewards"&&g.transform.parent&&g.transform.parent.name=="LeftButtonsNew");
            var gate=UnityEngine.Object.FindObjectsByType<KademeliAcilimLevel>(FindObjectsInactive.Include,FindObjectsSortMode.None).FirstOrDefault(g=>g.buttonsWithLevels.Any(p=>p.obje==entry&&p.requiredLevel==6&&!p.butonlu));
            result.idleGateVerified=entry&&gate&&!entry.activeSelf;
            result.tutorialActions.Add("Original idleRewards new-user rawLevel6 gate checked at earnedLevel"+GameManager.Level+"; entry hidden as native, no forced opening or reward claim.");
            if(!result.idleGateVerified)result.errors.Add("Original rawLevel6 idle entry gate/configuration did not remain closed below its native threshold.");
            yield break;
        }
        bool clicked=false;
        yield return Click(OriginalUiTestClick.Resolve("Canvases/BottomCanvas/SafeArea/YukariBolge/LeftButtonsNew/idleRewards"),ok=>clicked=ok);
        if(!clicked || !manager.gameObject.activeInHierarchy){result.errors.Add("Original visible idle reward entry could not be opened.");yield break;}
        yield return new WaitForSecondsRealtime(1f);
        RuntimeRecoveryRender.Capture(Path.Combine(root,"idle-preview-render.png"));
        if(!manager.collectButton.interactable){result.errors.Add("Normal idle claim was unavailable after naturally elapsed full onboarding play time.");yield break;}
        int[] visible=manager.rewardTexts.Select(t=>int.Parse(t.text)).ToArray();
        double coin=Currencys.Coin;int talent=Currencys.TalentScroll,weapon=Currencys.WeaponToken;
        int[] scrolls=(int[])Currencys.GearScroll.Clone();
        DateTime stamp=ES3.Load<DateTime>("NewlastOfflineTime");
        clicked=false;yield return Click(manager.collectButton.gameObject,ok=>clicked=ok);
        yield return new WaitForSecondsRealtime(.8f);
        bool amounts=Currencys.Coin==coin+visible[0]&&Currencys.TalentScroll==talent+visible[1]&&Currencys.WeaponToken==weapon+visible[2];
        for(int i=0;i<6;i++)amounts &= Currencys.GearScroll[i]==scrolls[i]+visible[i+3];
        result.idleRewardsClaimed=clicked&&amounts&&manager.popUpObj.activeInHierarchy&&!manager.collectButton.interactable&&ES3.Load<DateTime>("NewlastOfflineTime")>stamp;
        result.tutorialActions.Add("Original visible idle1x claim after naturally elapsed play: "+visible[0]+"Coin, "+visible[1]+"TalentScroll, "+visible[2]+"WeaponToken.");
        RuntimeRecoveryRender.Capture(Path.Combine(root,"idle-claimed-render.png"));
        if(!result.idleRewardsClaimed){result.errors.Add("Original idle1x result failed visible preview/delta/timestamp/duplicate-button checks.");yield break;}
        clicked=false;yield return Click(manager.popUpObj,ok=>clicked=ok);
        if(!clicked || manager.popUpObj.activeInHierarchy){result.errors.Add("Original idle reward popup did not close through its visible button.");yield break;}
        yield return new WaitForSecondsRealtime(.8f);
        var close=manager.GetComponentsInChildren<Button>(true).FirstOrDefault(b=>b.onClick.GetPersistentEventCount()>0&&Enumerable.Range(0,b.onClick.GetPersistentEventCount()).Any(i=>b.onClick.GetPersistentTarget(i)==manager&&b.onClick.GetPersistentMethodName(i)=="OpenClose"));
        clicked=false;yield return Click(close?close.gameObject:null,ok=>clicked=ok);
        if(!clicked || manager.gameObject.activeInHierarchy)result.errors.Add("Original idle page did not close through its visible serialized button.");
    }
}
