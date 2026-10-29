using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Opt-in isolated-profile test. Only existing UI callbacks; no balance, guide,
// inventory, damage, wave or clock injection.
public static class OfflineLaterBattleSmoke
{
    static bool Click(GameObject obj)
    {
        if(!obj || !obj.activeInHierarchy)return false;
        var button=obj.GetComponent<Button>()??obj.GetComponentInChildren<Button>();
        if(!button || !button.interactable || !button.enabled)return false;
        button.onClick.Invoke();return true;
    }
    public static IEnumerator Run(OfflineRuntimeProbe.Result result,string root)
    {
        bool third=System.Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS")=="third-guide";
        bool campaign=System.Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS")=="later-campaign";
        int startLevel=GameManager.Level;
        if(startLevel!=(third?2:1)){result.errors.Add("Later-battle smoke requires an actually earned profile at the matching level.");yield break;}
        var transition=Object.FindFirstObjectByType<GecisControl>();
        if(!transition){result.errors.Add("Missing home battle entry callback.");yield break;}
        int energy=Currencys.Energy;
        transition.SavasaGitSiege();
        float entryEnd=Time.realtimeSinceStartup+12f;
        while(!GecisControl.savastayim && Time.realtimeSinceStartup<entryEnd)yield return null;
        if(!GecisControl.savastayim){result.errors.Add("Ordinary Start callback failed to enter next battle.");yield break;}
        if(Currencys.Energy!=energy-5)result.errors.Add("Normal battle entry did not debit original5 Energy.");
        yield return new WaitForSecondsRealtime(1f);
        var guide=Object.FindFirstObjectByType<GuideinsideWar>();
        var ui=Object.FindFirstObjectByType<SlotMachineUI>();
        if(!guide || !ui){result.errors.Add("Missing later-battle UI/guide.");yield break;}
        var war=ui.warController;
        float end=Time.realtimeSinceStartup+(campaign?300f:155f),lastClick=-100f;
        int lastState=-1;
        while(Time.realtimeSinceStartup<end && result.errors.Count==0)
        {
            int state=guide.GuideNum;
            if(state!=lastState){string record=state+"; t="+Time.realtimeSinceStartup+"; silver="+war.Silver+"; token="+war.token+"; count="+ui.commanderSpawner.currentCommanderCount;result.tutorialStates.Add(record);Debug.Log("Recovery later-guide state "+record);lastState=state;}
            result.peakEnemies=Mathf.Max(result.peakEnemies,Object.FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length);
            result.peakCommanders=Mathf.Max(result.peakCommanders,Object.FindObjectsByType<Commander>(FindObjectsSortMode.None).Length);
            result.maxEnemyKills=Mathf.Max(result.maxEnemyKills,war.KesilenDusmanSayisi);
            if(!third && state==102 && !result.tutorialCompleted){result.tutorialCompleted=true;if(!campaign){yield return new WaitForSecondsRealtime(3f);break;}}
            if(third && state==31)
            {
                result.tutorialCompleted=war.SummonedMysticSayisi>=1 && ui.commanderSpawner.activeCommanders.Exists(c=>c!=null && (int)c.Rarity==4);
                if(!result.tutorialCompleted)result.errors.Add("Third guide closed without actual summoned Mystic.");
                if(Currencys.Energy!=70)result.errors.Add("Original third-guide energy reward did not occur.");
                yield return new WaitForSecondsRealtime(4f);break;
            }
            if(Time.realtimeSinceStartup-lastClick>=0.8f)
            {
                bool acted=false;
                if(guide.roguleLike.gameObject.activeInHierarchy && guide.roguleLike.SelectedSkills.Count>0){guide.roguleLike.SkillSecildi(0);acted=true;result.tutorialActions.Add("Choose available skill");}
                else if(third && state==29 && !guide.mysticPage.activeInHierarchy){acted=Click(guide.mistikbtn);if(acted)result.tutorialActions.Add("Open original Mystic button");}
                else if(third && state==30 && guide.mysticPage.activeInHierarchy)
                {
                    var mystic=Object.FindFirstObjectByType<MistikInGameUI>();
                    if(mystic && mystic.craftBtn.interactable){mystic.CraftMystic();acted=true;result.tutorialActions.Add("Original guided Mystic craft callback");}
                }
                else if(state==22 && !guide.LuckySpinPage.activeInHierarchy){acted=Click(guide.luckbtn);if(acted)result.tutorialActions.Add("Open original Lucky Spin button");}
                else if(state==23 && guide.spinForWeaponRare.spinbtn.interactable && !guide.spinForWeaponRare.spining){guide.spinForWeaponRare.SpinButtonPressed();acted=true;result.tutorialActions.Add("Rare forge callback");}
                else if(state==24 && guide.spinForWeaponEpic.spinbtn.interactable && !guide.spinForWeaponEpic.spining){guide.spinForWeaponEpic.SpinButtonPressed();acted=true;result.tutorialActions.Add("Epic forge callback");}
                else if(state==25 && guide.spinWeaponLegendArrow.activeInHierarchy && guide.spinForWeaponLegend.spinbtn.interactable && !guide.spinForWeaponLegend.spining){guide.spinForWeaponLegend.SpinButtonPressed();acted=true;result.tutorialActions.Add("Legendary forge callback");}
                else if(state==25 && guide.spin3luclose.activeInHierarchy){acted=Click(guide.spin3luclose);if(acted)result.tutorialActions.Add("Close completed original three-forge panel");}
                else if(guide.yaziEkrani.activeInHierarchy){guide.YaziKapatDevam();acted=true;result.tutorialActions.Add("Continue dialogue at "+state);}
                else if(!guide.LuckySpinPage.activeInHierarchy && !guide.mysticPage.activeInHierarchy && !ui.slotMachine.spining && ui.btn.interactable && !ui.commanderSpawner.IsFull() && war.Silver>=ui.slotMachine.SpinFiyat())
                {ui.Spin();acted=true;result.tutorialActions.Add("Ordinary spin at "+state);}
                if(acted)lastClick=Time.realtimeSinceStartup;
            }
            if(war.youWonPage.activeInHierarchy)
            {
                if(!campaign)break;
                result.battleWon=(bool)typeof(WarController).GetField("won",System.Reflection.BindingFlags.Instance|System.Reflection.BindingFlags.NonPublic).GetValue(war);
                if(!result.battleWon)break;
                yield return new WaitForSecondsRealtime(1.1f);
                RuntimeRecoveryRender.Capture(System.IO.Path.Combine(root,"second-victory-render.png"));
                war.CollectWon(1);result.tutorialActions.Add("Collect ordinary1x second-stage reward");
                float homeDeadline=Time.realtimeSinceStartup+12f;
                while(GecisControl.savastayim && Time.realtimeSinceStartup<homeDeadline)yield return null;
                result.victoryCollected=!GecisControl.savastayim && GameManager.Level==startLevel+1;
                break;
            }
            yield return new WaitForSecondsRealtime(0.15f);
        }
        if(!result.tutorialCompleted)result.errors.Add("Later-battle guide did not complete its original final state within bounded actual play.");
        if(campaign && !result.victoryCollected)result.errors.Add("Second-stage campaign did not complete ordinary victory collection within bounded actual play.");
        RuntimeMaterialSnapshot.Write(System.IO.Path.Combine(root,"later-battle-materials.json"));
        RuntimeRecoveryRender.Capture(System.IO.Path.Combine(root,"later-battle-render.png"));
    }
}
