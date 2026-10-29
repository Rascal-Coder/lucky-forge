using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

// Development-only opt-in probe. A normal launch does not create it or alter the save root.
public sealed class OfflineRuntimeProbe : MonoBehaviour
{
    [Serializable] public sealed class Result
    {
        public bool passed;
        public string probeActions;
        public string finalScene;
        public int level;
        public double coin;
        public double dataCoin;
        public long castleHealth;
        public int energy;
        public bool inBattle;
        public int activeEnemies;
        public int activeCommanders;
        public int peakCommanders;
        public int peakEnemies;
        public bool firstSpinAttempted;
        public bool firstSpinCompleted;
        public bool secondSpinAttempted;
        public bool damagedEnemySeen;
        public int maxEnemyKills;
        public int peakProjectiles;
        public List<string> commanderDiagnostics = new List<string>();
        public bool tutorialCompleted;
        public bool homeTutorialCompleted;
        public bool homeWorldSweepCompleted;
        public int homeWorldSweepChecks;
        public bool talentTutorialCompleted;
        public bool idleRewardsClaimed;
        public bool idleGateVerified;
        public int rewardPopupsClosed;
        public List<string> homeStates=new List<string>();
        public List<string> homeUiBlocks=new List<string>();
        public bool battleWon;
        public bool victoryCollected;
        public List<string> tutorialStates = new List<string>();
        public List<string> tutorialActions = new List<string>();
        public bool weaponUpgradeCompleted;
        public int weaponLevelBefore;
        public int weaponLevelAfter;
        public double weaponUpgradeSpent;
        public List<string> canvasDiagnostics = new List<string>();
        public List<string> spawnerDiagnostics = new List<string>();
        public bool poolStarted;
        public bool loadingCleared;
        public float timeScale;
        public float scaledTime;
        public int frames;
        public List<string> startupCheckpoints = new List<string>();
        public List<string> poolDiagnostics = new List<string>();
        public List<string> scenes = new List<string>();
        public List<string> errors = new List<string>();
    }
    private string root;
    private static OfflineRuntimeProbe current;
    private Result result = new Result();
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        string requested = Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ROOT");
        if (string.IsNullOrEmpty(requested)) return;
        var go = new GameObject("OfflineRecoveryRuntimeProbe");
        DontDestroyOnLoad(go);
        var probe = go.AddComponent<OfflineRuntimeProbe>();
        current = probe;
        probe.root = Path.GetFullPath(requested);
        Directory.CreateDirectory(probe.root);
        OfflineKeyStore.SetVerificationRoot(Path.Combine(probe.root, "Profile"));
        Application.logMessageReceived += probe.OnLog;
        SceneManager.sceneLoaded += probe.OnScene;
    }
    private void OnScene(Scene scene, LoadSceneMode mode) { result.scenes.Add(scene.name); }
    public static void RecordStartupCheckpoint(string name)
    {
        if (current == null) return;
        current.result.startupCheckpoints.Add(name + "; real=" + Time.realtimeSinceStartup + "; scaled=" + Time.time + "; scale=" + Time.timeScale + "; frame=" + Time.frameCount);
    }
    private void OnLog(string condition, string stack, LogType type)
    {
        if ((type == LogType.Exception || type == LogType.Error || type == LogType.Assert) && result.errors.Count < 100)
            result.errors.Add(condition + "\n" + stack);
    }
    private IEnumerator Start()
    {
        float deadline = Time.realtimeSinceStartup + 120f;
        while (SceneManager.GetActiveScene().name != "Sahne" && Time.realtimeSinceStartup < deadline) yield return null;
        if (SceneManager.GetActiveScene().name == "Sahne")
        {
            float waitUntil = Time.realtimeSinceStartup + 6f;
            while (Time.realtimeSinceStartup < waitUntil) yield return null;
            string actions=Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS");
            result.probeActions=actions;
            if(actions=="tutorial"||actions=="onboarding-home"||actions=="onboarding-talent"||actions=="later-campaign"||actions=="third-guide")OriginalRewardPopupSmoke.Install(gameObject,result,root);
            if(actions=="manual-input" || actions=="manual-input-windowed" || actions=="serialized-input")
            {
                if(actions=="manual-input-windowed")Screen.SetResolution(405,720,FullScreenMode.Windowed);
                SlotClickInputDiagnostics.Install(Path.Combine(root,"input-events.json"));
                if(actions=="serialized-input")SlotClickInputDiagnostics.ExecuteSerializedClick(FindFirstObjectByType<SlotMachineUI>(),Path.Combine(root,"serialized-click.json"));
                float manualEnd=Time.realtimeSinceStartup+(actions=="serialized-input"?5f:300f),firstCommander=-1f;
                while(Time.realtimeSinceStartup<manualEnd)
                {
                    result.peakCommanders=Math.Max(result.peakCommanders,FindObjectsByType<Commander>(FindObjectsSortMode.None).Length);
                    if(result.peakCommanders>0 && firstCommander<0f)firstCommander=Time.realtimeSinceStartup;
                    if(firstCommander>=0f && Time.realtimeSinceStartup-firstCommander>10f)break;
                    yield return new WaitForSecondsRealtime(.2f);
                }
                result.firstSpinCompleted=result.peakCommanders>0;
            }
            if(actions=="tutorial" || actions=="onboarding-home" || actions=="onboarding-talent") yield return OfflineTutorialSmoke.Run(result,root);
            if((actions=="onboarding-home" || actions=="onboarding-talent") && result.victoryCollected)yield return OfflineHomeOnboardingSmoke.Run(result,root);
            if(actions=="onboarding-talent" && result.homeTutorialCompleted && result.errors.Count==0)
            {
                result.tutorialCompleted=false;result.battleWon=false;result.victoryCollected=false;
                Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS","later-campaign");
                try{yield return OfflineLaterBattleSmoke.Run(result,root);}
                finally{Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS",actions);}
                if(result.victoryCollected && result.errors.Count==0)yield return OfflineHomeOnboardingSmoke.RunTalent(result,root);
                if(result.talentTutorialCompleted && result.errors.Count==0)yield return OfflineIdleRewardsSmoke.Run(result,root);
            }
            if(actions=="later-battle" || actions=="later-campaign" || actions=="third-guide") yield return OfflineLaterBattleSmoke.Run(result,root);
            if(actions=="home-growth") yield return OfflineHomeGrowthSmoke.Run(result,root);
            if(actions=="home-world-sweep") yield return HomeWorldSweepSmoke.Run(result,root);
            if (actions == "first-spin" || actions == "combat")
            {
                var ui = FindFirstObjectByType<SlotMachineUI>();
                if (ui == null) result.errors.Add("No active SlotMachineUI; cannot test actual spin callback.");
                else
                {
                    result.firstSpinAttempted = true;
                    ui.Spin();
                    float spinStarted=Time.realtimeSinceStartup;
                    float spinDeadline=spinStarted+20f;
                    while(Time.realtimeSinceStartup<spinDeadline)
                    {
                        int commanders=FindObjectsByType<Commander>(FindObjectsSortMode.None).Length;
                        int enemies=FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
                        result.peakCommanders=Math.Max(result.peakCommanders,commanders);
                        result.peakEnemies=Math.Max(result.peakEnemies,enemies);
                        result.peakProjectiles=Math.Max(result.peakProjectiles,FindObjectsByType<Projectile>(FindObjectsSortMode.None).Length);
                        result.maxEnemyKills=Math.Max(result.maxEnemyKills,ui.warController.KesilenDusmanSayisi);
                        foreach(var enemy in FindObjectsByType<Enemy>(FindObjectsSortMode.None))
                            if(enemy.unitData.health<enemy.unitData.MaxHealth) result.damagedEnemySeen=true;
                        if(actions=="combat" && !result.secondSpinAttempted && commanders>0 && Time.realtimeSinceStartup>spinStarted+1f && !ui.slotMachine.spining)
                        { result.secondSpinAttempted=true; ui.Spin(); }
                        yield return new WaitForSecondsRealtime(0.25f);
                    }
                    result.firstSpinCompleted=result.peakCommanders>0;
                }
            }
        }
        result.finalScene = SceneManager.GetActiveScene().name;
        result.level = GameManager.Level;
        result.coin = Currencys.Coin;
        result.dataCoin = Convert.ToDouble(typeof(Currencys).GetField("DataCoin", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null));
        result.castleHealth = PlayerData.PlayerStats == null ? 0 : PlayerData.PlayerStats.HP(0);
        result.energy = Currencys.Energy;
        result.inBattle = GecisControl.savastayim;
        result.activeEnemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        result.activeCommanders = FindObjectsByType<Commander>(FindObjectsSortMode.None).Length;
        foreach(var commander in FindObjectsByType<Commander>(FindObjectsSortMode.None))
            result.commanderDiagnostics.Add(commander.name+"; level="+commander.Level+"; attack="+commander.attack+"; speed="+commander.attackspeed+"; position="+commander.transform.position);
        foreach (var spawner in FindObjectsByType<CommanderSpawner>(FindObjectsInactive.Include, FindObjectsSortMode.None))
            foreach (var field in typeof(CommanderSpawner).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                if (field.FieldType.Name.Contains("Dictionary"))
                    result.spawnerDiagnostics.Add(spawner.name + ": " + field.Name + "=" + (field.GetValue(spawner)==null?"null":"initialized"));
        result.loadingCleared = !GameManager.loading;
        result.timeScale = Time.timeScale;
        result.scaledTime = Time.time;
        result.frames = Time.frameCount;
        foreach(var canvas in FindObjectsByType<Canvas>(FindObjectsInactive.Include,FindObjectsSortMode.None))
            if(canvas.isRootCanvas && (canvas.renderMode!=RenderMode.WorldSpace || canvas.gameObject.activeInHierarchy))
            {
                var rect=(RectTransform)canvas.transform;
                var graphics=canvas.GetComponentsInChildren<UnityEngine.UI.Graphic>();
                int culled=0; foreach(var graphic in graphics) if(graphic.canvasRenderer.cull) culled++;
                result.canvasDiagnostics.Add(canvas.name+"; active="+canvas.gameObject.activeInHierarchy+"; enabled="+canvas.enabled+"; mode="+canvas.renderMode+"; layer="+canvas.gameObject.layer+"; camera="+(canvas.worldCamera==null?"null":canvas.worldCamera.name+"/"+canvas.worldCamera.enabled)+"; rect="+rect.rect+"; localScale="+rect.localScale+"; lossyScale="+rect.lossyScale+"; pixelRect="+canvas.pixelRect+"; scaleFactor="+canvas.scaleFactor+"; plane="+canvas.planeDistance+"; graphics="+graphics.Length+"; culled="+culled);
            }
        foreach (var pool in FindObjectsByType<PoolObject>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            var field = typeof(PoolObject).GetField("started", BindingFlags.NonPublic | BindingFlags.Instance);
            bool started = field != null && (bool)field.GetValue(pool);
            result.poolStarted |= started;
            result.poolDiagnostics.Add(pool.name + "; active=" + pool.gameObject.activeInHierarchy + "; initialized=" + started);
        }
        result.passed = result.finalScene == "Sahne" && result.coin == 5d && result.dataCoin == 10d && result.level == 0 && result.castleHealth == 500 && result.poolStarted && result.loadingCleared && result.errors.Count == 0;
        string requestedActions=Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS");
        if(requestedActions=="first-spin" || requestedActions=="combat" || requestedActions=="manual-input" || requestedActions=="manual-input-windowed" || requestedActions=="serialized-input") result.passed &= result.firstSpinCompleted;
        if(requestedActions=="combat") result.passed &= result.peakEnemies>0 && (result.damagedEnemySeen || result.maxEnemyKills>0);
        if(requestedActions=="tutorial") result.passed=result.finalScene=="Sahne" && result.tutorialCompleted && result.victoryCollected && result.level>=1 && result.coin>5d && result.dataCoin==result.coin*2d && result.poolStarted && result.errors.Count==0;
        if(requestedActions=="third-guide") result.passed=result.finalScene=="Sahne" && result.tutorialCompleted && result.level==2 && result.inBattle && result.poolStarted && result.errors.Count==0;
        if(requestedActions=="later-campaign") result.passed=result.finalScene=="Sahne" && result.tutorialCompleted && result.victoryCollected && result.battleWon && result.level==2 && !result.inBattle && result.poolStarted && result.errors.Count==0;
        if(requestedActions=="later-battle") result.passed=result.finalScene=="Sahne" && result.tutorialCompleted && result.level==1 && result.inBattle && result.peakEnemies>0 && result.peakCommanders>0 && result.errors.Count==0;
        if(requestedActions=="onboarding-talent")result.passed=result.finalScene=="Sahne" && result.homeTutorialCompleted && result.talentTutorialCompleted && (result.idleRewardsClaimed || result.idleGateVerified) && result.victoryCollected && result.level==2 && result.errors.Count==0;
        if(requestedActions=="onboarding-home")result.passed=result.finalScene=="Sahne" && result.victoryCollected && result.homeTutorialCompleted && result.level==1 && result.weaponLevelAfter>=2 && result.errors.Count==0;
        if(requestedActions=="resume") result.passed=result.finalScene=="Sahne" && result.level==int.Parse(Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_EXPECT_LEVEL")) && result.coin==double.Parse(Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_EXPECT_COIN"),System.Globalization.CultureInfo.InvariantCulture) && result.dataCoin==result.coin*2d && !result.inBattle && result.poolStarted && result.errors.Count==0;
        if(requestedActions=="home-growth") result.passed=result.finalScene=="Sahne" && result.weaponUpgradeCompleted && result.level==int.Parse(Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_EXPECT_LEVEL")) && result.coin==double.Parse(Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_EXPECT_COIN"),System.Globalization.CultureInfo.InvariantCulture)-result.weaponUpgradeSpent && result.dataCoin==result.coin*2d && result.errors.Count==0;
        if(requestedActions=="home-world-sweep") result.passed=result.finalScene=="Sahne" && result.homeWorldSweepCompleted && !result.inBattle && result.poolStarted && result.errors.Count==0;
        string expectedWeapon=Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_EXPECT_WEAPON_LEVEL");
        if(requestedActions=="resume" && !string.IsNullOrEmpty(expectedWeapon))
        {
            var hero=FindFirstObjectByType<HeroController>();
            var original=hero==null?null:hero.HeroCommanders.Find(c=>c!=null && c.HeroNum==0);
            result.weaponLevelAfter=original==null?-1:original.Level;
            result.passed &= result.weaponLevelAfter==int.Parse(expectedWeapon);
        }
        RuntimeMaterialSnapshot.Write(Path.Combine(root,"runtime-materials.json"));
        ScreenCapture.CaptureScreenshot(Path.Combine(root, "runtime-main.png"));
        RuntimeRecoveryRender.Capture(Path.Combine(root, "runtime-scene-render.png"));
        float captureDeadline = Time.realtimeSinceStartup + 2f;
        while (Time.realtimeSinceStartup < captureDeadline) yield return null;
        OfflineKeyStore.FlushAll();
        File.WriteAllText(Path.Combine(root, "runtime-probe.json"), JsonUtility.ToJson(result, true));
        Debug.Log("Offline cold-start probe: " + (result.passed ? "PASS" : "FAIL") + ", errors=" + result.errors.Count);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(result.passed ? 0 : 1);
#endif
    }
    private void OnDestroy()
    {
        if (current == this) current = null;
        Application.logMessageReceived -= OnLog;
        SceneManager.sceneLoaded -= OnScene;
    }
}
