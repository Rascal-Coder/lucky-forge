using System.Collections;
using System.Linq;
using UnityEngine;

// Isolated runtime test, using existing navigation/card/upgrade callbacks and actual saved funds.
public static class OfflineHomeGrowthSmoke
{
    public static IEnumerator Run(OfflineRuntimeProbe.Result result,string root)
    {
        var bottom=Object.FindFirstObjectByType<BottomPages>();
        if(bottom==null){result.errors.Add("No active home navigation.");yield break;}
        bottom.OpenPage(3);
        yield return new WaitForSecondsRealtime(1f);
        var card=Object.FindObjectsByType<HeroUpgradeSkinTek>(FindObjectsSortMode.None).FirstOrDefault(c=>c.commander!=null && c.commander.HeroNum==0);
        if(card==null){result.errors.Add("No active original weapon0 card on forge page.");yield break;}
        card.OpenIt();
        yield return new WaitForSecondsRealtime(0.5f);
        var commander=card.commander;
        result.weaponLevelBefore=commander.Level;
        double before=Currencys.Coin;
        double price=commander.UpgradePrice();
        if(!commander.isUpgradeable()){result.errors.Add("Original weapon0 remains ineligible after its native tutorial XP setup.");yield break;}
        RuntimeRecoveryRender.Capture(System.IO.Path.Combine(root,"weapon-before-upgrade-render.png"));
        card.heroUpgradeUI.UpgradeHero();
        yield return new WaitForSecondsRealtime(1.5f);
        result.weaponLevelAfter=commander.Level;
        result.weaponUpgradeSpent=before-Currencys.Coin;
        result.weaponUpgradeCompleted=result.weaponLevelAfter==result.weaponLevelBefore+1 && result.weaponUpgradeSpent==price;
        RuntimeRecoveryRender.Capture(System.IO.Path.Combine(root,"weapon-after-upgrade-render.png"));
        if(!result.weaponUpgradeCompleted)result.errors.Add("Native home upgrade did not consume its original price and advance one permanent level.");
    }
}
