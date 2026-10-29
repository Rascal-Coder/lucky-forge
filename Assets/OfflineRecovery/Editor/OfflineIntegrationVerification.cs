using UnityEditor;
using UnityEngine;
namespace LuckyForge.Offline.Editor
{
    public static class OfflineIntegrationVerification
    {
        [System.Serializable] public sealed class ModuleReport {public string name;public bool passed;public int checks;public System.Collections.Generic.List<string> failures;}
        [System.Serializable] public sealed class VerificationReport {public bool passed=true;public int checks;public System.Collections.Generic.List<ModuleReport> modules=new System.Collections.Generic.List<ModuleReport>();}
        static void Record(VerificationReport report,string name,object result)
        {
            var module=JsonUtility.FromJson<ModuleReport>(JsonUtility.ToJson(result));module.name=name;
            report.modules.Add(module);report.passed &= module.passed;report.checks+=module.checks;
        }
        public static void RunTalentOnboardingBatch()
        {
            System.Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS","onboarding-talent");
            OfflineColdStartVerification.RunBatch();
        }
        public static void RunHomeOnboardingBatch()
        {
            System.Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS","onboarding-home");
            OfflineColdStartVerification.RunBatch();
        }
        public static void RunThirdGuideBatch()
        {
            if(!BattlePauseEntryVerification.RunChecks().passed){EditorApplication.Exit(1);return;}
            System.Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS","third-guide");
            OfflineColdStartVerification.RunBatch();
        }
        public static void RunLaterCampaignBatch()
        {
            System.Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS","later-campaign");
            OfflineColdStartVerification.RunBatch();
        }
        public static void RunLaterBattleBatch()
        {
            if(!LuckPageEntryVerification.RunChecks().passed){EditorApplication.Exit(1);return;}
            System.Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS","later-battle");
            OfflineColdStartVerification.RunBatch();
        }
        public static void RunHomeGrowthBatch()
        {
            System.Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS","home-growth");
            OfflineColdStartVerification.RunBatch();
        }
        public static void RunChecksBatch()
        {
            System.Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS","checks");
            RunBatch();
        }
        public static void RunResumeBatch()
        {
            System.Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS","resume");
            OfflineColdStartVerification.RunBatch();
        }
        public static void RunTutorialBatch()
        {
            System.Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS","tutorial");
            OfflineColdStartVerification.RunBatch();
        }
        public static void RunBatch()
        {
            VisualFixChecks.RunIntegrationBatch();
        }
        public static void RunWithWaveResult(WaveRewardLifecycleVerification.Result waveRewards, HomeWorldVerification.Result homeWorld=null)
        {
            if(EditorApplication.isPlayingOrWillChangePlaymode)throw new System.InvalidOperationException("Remaining integration checks require EditMode.");
            if(waveRewards==null||!waveRewards.playMode)throw new System.InvalidOperationException("An actual isolated Wave PlayMode result is required; Wave is never rerun in EditMode.");
            var persistence=OfflinePersistenceVerification.RunChecks();
            var merge=ForgeMergeVerification.RunChecks();
            var slots=SlotMachineVerification.RunChecks();
            var craft=CraftSellVerification.RunChecks();
            var rogue=RogueChoiceVerification.RunChecks();
            var equipment=EquipmentGrowthVerification.RunChecks();
            var upgrade=EquipmentUpgradeVerification.RunChecks();
            var talents=TalentLifecycleVerification.RunChecks();
            var home=HomeStageVerification.RunChecks();
            var heroWall=HeroWallLifecycleVerification.RunChecks();
            var unlock=UnlockGateVerification.RunChecks();
            var research=ResearchLifecycleVerification.RunChecks();
            var pets=PetLifecycleVerification.RunChecks();
            var luck=LuckPageEntryVerification.RunChecks();
            var daily=DailyTaskLifecycleVerification.RunChecks();
            var pause=BattlePauseEntryVerification.RunChecks();
            var damages=ResultDamageVerification.RunChecks();
            var achievements=AchievementLifecycleVerification.RunChecks();
            var homeForge=HomeForgeVerification.RunChecks();
            var localSettings=LocalSettingsVerification.RunChecks();
            var lifecycle=WelcomeLifecycleVerification.RunChecks();
            var growthNavigation=GrowthNavigationVerification.RunChecks();
            var mainLoop=MainLoopVerification.RunChecks();
            var cameraInput=CameraInputVerification.RunChecks();
            var pageNavigation=PageLocalNavigationVerification.RunChecks();
            var hourlyRewards=HourlyRewardVerification.RunChecks();
            var offlineRewards=OfflineRewardVerification.RunChecks();
            var dungeon=DungeonLifecycleVerification.RunChecks();
            var taskLocks=TaskLockVerification.RunChecks();
            var energyRights=EnergyRightsLocalVerification.RunChecks();
            var commanderMissions=CommanderMissionVerification.RunChecks();
            var weaponInformation=WeaponInformationVerification.RunChecks();
            var information=InfoPanelVerification.RunChecks();
            var report=new VerificationReport();
            if(homeWorld!=null)Record(report,"home-world",homeWorld);
            Record(report,"persistence",persistence);
            Record(report,"forge-merge",merge);
            Record(report,"slots",slots);
            Record(report,"craft-sell",craft);
            Record(report,"rogue-choice",rogue);
            Record(report,"equipment-growth",equipment);
            Record(report,"equipment-upgrade",upgrade);
            Record(report,"talents",talents);
            Record(report,"home-stage",home);
            Record(report,"hero-wall",heroWall);
            Record(report,"unlock-gates",unlock);
            Record(report,"research",research);
            Record(report,"pets",pets);
            Record(report,"lucky-page",luck);
            Record(report,"daily-tasks",daily);
            Record(report,"battle-pause",pause);
            Record(report,"result-damage",damages);
            Record(report,"achievements",achievements);
            Record(report,"home-forge",homeForge);
            Record(report,"local-settings",localSettings);
            Record(report,"wave-rewards",waveRewards);
            Record(report,"welcome-lifecycle",lifecycle);
            Record(report,"growth-navigation",growthNavigation);
            Record(report,"main-loop",mainLoop);
            Record(report,"camera-input",cameraInput);
            Record(report,"page-navigation",pageNavigation);
            Record(report,"hourly-rewards",hourlyRewards);
            Record(report,"offline-rewards",offlineRewards);
            Record(report,"dungeon",dungeon);
            Record(report,"task-locks",taskLocks);
            Record(report,"energy-rights",energyRights);
            Record(report,"commander-missions",commanderMissions);
            Record(report,"weapon-information",weaponInformation);
            Record(report,"information-panels",information);
            string folder=System.IO.Path.Combine(System.IO.Directory.GetParent(Application.dataPath).FullName,"Verification");
            System.IO.Directory.CreateDirectory(folder);
            System.IO.File.WriteAllText(System.IO.Path.Combine(folder,"integration-checks.json"),JsonUtility.ToJson(report,true));
            if(!report.passed)
            {
                Debug.LogError("Recovery integration checks failed: "+JsonUtility.ToJson(report));
                EditorApplication.Exit(1);return;
            }
            Debug.Log("Recovery integration checks PASS: "+report.checks);
            if(System.Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS")=="checks") {EditorApplication.Exit(0);return;}
            System.Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS","combat");
            OfflineColdStartVerification.RunBatch();
        }
    }
}
