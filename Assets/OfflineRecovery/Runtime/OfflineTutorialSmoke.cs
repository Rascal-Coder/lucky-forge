using System.Collections;
using System.Linq;
using System.Reflection;
using UnityEngine;

// Test-only driver: calls existing UI handlers in an isolated profile. Never grants resources,
// writes guide state, changes wave indices, increases damage, or skips cost conditions.
public static class OfflineTutorialSmoke
{
    public static IEnumerator Run(OfflineRuntimeProbe.Result result,string root)
    {
        var ui=Object.FindFirstObjectByType<SlotMachineUI>();
        var guide=Object.FindFirstObjectByType<GuideinsideWar>();
        if(ui==null || guide==null) {result.errors.Add("Missing active first-battle UI/guide.");yield break;}
        var war=ui.warController;
        float end=Time.realtimeSinceStartup+240f;
        float lastClick=-100f;
        int lastState=int.MinValue;
        bool collected=false;
        while(Time.realtimeSinceStartup<end)
        {
            if(result.errors.Count>0) break;
            int state=guide.GuideNum;
            if(state!=lastState)
            {
                result.tutorialStates.Add(state+"; t="+Time.realtimeSinceStartup+"; silver="+war.Silver+"; count="+ui.commanderSpawner.currentCommanderCount);
                Debug.Log("Recovery tutorial state "+result.tutorialStates[result.tutorialStates.Count-1]);
                lastState=state;
            }
            result.peakCommanders=Mathf.Max(result.peakCommanders,Object.FindObjectsByType<Commander>(FindObjectsSortMode.None).Length);
            result.peakEnemies=Mathf.Max(result.peakEnemies,Object.FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length);
            result.maxEnemyKills=Mathf.Max(result.maxEnemyKills,war.KesilenDusmanSayisi);
            result.tutorialCompleted |= state>=20;
            if(Time.realtimeSinceStartup-lastClick>=0.8f)
            {
                bool acted=false;
                if(guide.roguleLike.gameObject.activeInHierarchy && guide.roguleLike.SelectedSkills.Count>0)
                {guide.roguleLike.SkillSecildi(0);result.tutorialActions.Add("Choose first available skill");acted=true;}
                else if(state==9 && !guide.craftSell.gameObject.activeInHierarchy)
                {
                    var full=ui.commanderSpawner.inventorySlots.FirstOrDefault(s=>s.IsFull());
                    if(full!=null && guide.craftSell.readytoopen())
                    {
                        typeof(InventorySlot).GetMethod("OnMouseUp",BindingFlags.Instance|BindingFlags.NonPublic).Invoke(full,null);
                        result.tutorialActions.Add("Open full weapon slot");acted=true;
                    }
                }
                else if(state==10 && guide.craftSell.gameObject.activeInHierarchy && guide.craftSell.mergebtn.interactable)
                {guide.craftSell.Merge();result.tutorialActions.Add("Merge weapons through original callback");acted=true;}
                else if(guide.yaziEkrani.activeInHierarchy)
                {guide.YaziKapatDevam();result.tutorialActions.Add("Continue battle dialogue at "+state);acted=true;}
                else if(!ui.slotMachine.spining && ui.btn.interactable && !ui.commanderSpawner.IsFull() && guide.spinArrow.activeInHierarchy)
                {ui.Spin();result.tutorialActions.Add("Spin at "+state);acted=true;}
                else if(state>=20 && !ui.slotMachine.spining && ui.btn.interactable && !ui.commanderSpawner.IsFull() && !war.youWonPage.activeInHierarchy)
                {ui.Spin();result.tutorialActions.Add("Ordinary post-guide spin");acted=true;}
                if(acted)lastClick=Time.realtimeSinceStartup;
            }
            if(war.youWonPage.activeInHierarchy && !collected)
            {
                bool won=(bool)typeof(WarController).GetField("won",BindingFlags.Instance|BindingFlags.NonPublic).GetValue(war);
                result.battleWon=won;
                if(!won)break;
                yield return new WaitForSecondsRealtime(1.1f);
                RuntimeMaterialSnapshot.Write(System.IO.Path.Combine(root,"victory-materials.json"));
                RuntimeRecoveryRender.Capture(System.IO.Path.Combine(root,"first-victory-render.png"));
                war.CollectWon(1);collected=true;result.tutorialActions.Add("Collect ordinary1x victory rewards");
            }
            if(collected && !GecisControl.savastayim && GameManager.Level>=1)
            {
                yield return new WaitForSecondsRealtime(1f);
                result.victoryCollected=true;
                break;
            }
            yield return new WaitForSecondsRealtime(0.2f);
        }
        if(!result.tutorialCompleted)result.errors.Add("First-battle guide did not reach state20 within the bounded runtime test.");
        if(!result.victoryCollected)result.errors.Add("First battle did not complete ordinary victory collection within the bounded runtime test.");
    }
}
