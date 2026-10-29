using System.IO;
using UnityEngine;

// Opt-in probe helper only. Dismisses earned presentation through its actual
// visible original button, after naturally waiting for the source animations.
public sealed class OriginalRewardPopupSmoke:MonoBehaviour
{
    OfflineRuntimeProbe.Result result;string root;CurrencyCollectedUi seen;float firstSeen,lastAttempt,nextScan;
    public static void Install(GameObject owner,OfflineRuntimeProbe.Result report,string folder)
    {var p=owner.AddComponent<OriginalRewardPopupSmoke>();p.result=report;p.root=folder;}
    void Update()
    {
        if(result==null)return;
        if(Time.realtimeSinceStartup<nextScan)return;nextScan=Time.realtimeSinceStartup+.15f;
        var popup=FindFirstObjectByType<CurrencyCollectedUi>();
        if(!popup || !popup.gameObject.activeInHierarchy){seen=null;return;}
        if(seen!=popup){seen=popup;firstSeen=Time.realtimeSinceStartup;lastAttempt=-100f;}
        if(Time.realtimeSinceStartup-firstSeen<2.8f||Time.realtimeSinceStartup-lastAttempt<.4f)return;
        lastAttempt=Time.realtimeSinceStartup;
        if(result.rewardPopupsClosed==0)RuntimeRecoveryRender.Capture(Path.Combine(root,"earned-reward-popup-render.png"));
        double coin=Currencys.Coin;int energy=Currencys.Energy,crystal=Currencys.Crystal,talent=Currencys.TalentScroll;
        string blocked;
        if(!OriginalUiTestClick.Try(popup.gameObject,out blocked))return;
        if(Currencys.Coin!=coin||Currencys.Energy!=energy||Currencys.Crystal!=crystal||Currencys.TalentScroll!=talent)
            result.errors.Add("Original presentation close unexpectedly changed earned balances.");
        if(!popup.gameObject.activeInHierarchy){result.rewardPopupsClosed++;result.tutorialActions.Add("Close earned original CurrencyCollected popup through visible serialized pointer callback; balances unchanged.");seen=null;}
    }
}
