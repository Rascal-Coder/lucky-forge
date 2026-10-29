using System;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace LuckyForge.Offline.Editor
{
    [InitializeOnLoad]
    public static class OfflineColdStartVerification
    {
        private const string Key = "LuckyForgeRecovery.ColdStartRoot";
        private static double deadline;
        static OfflineColdStartVerification()
        {
            if (string.IsNullOrEmpty(SessionState.GetString(Key, ""))) return;
            EditorApplication.playModeStateChanged += OnMode;
            EditorApplication.update += Monitor;
            deadline = EditorApplication.timeSinceStartup + ((Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS")=="later-campaign" || (Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS")=="onboarding-home" || Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS")=="onboarding-talent"))?900:((Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS")=="tutorial" || (Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS")=="later-battle" || Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS")=="third-guide"))?360:180));
            EditorApplication.delayCall += CheckCompletion;
        }
        public static void RunBatch()
        {
            string root = Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Verification", "ColdStart", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(root);
            string resume=Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_RESUME_SOURCE");
            if(!string.IsNullOrEmpty(resume))
            {
                string allowed=Path.GetFullPath(Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification"))+Path.DirectorySeparatorChar;
                string source=Path.GetFullPath(resume);
                if(!source.StartsWith(allowed,StringComparison.OrdinalIgnoreCase))throw new InvalidOperationException("Resume fixture must come from this project's Verification folder.");
                var expected=JsonUtility.FromJson<OfflineRuntimeProbe.Result>(File.ReadAllText(Path.Combine(source,"runtime-probe.json")));
                if(!expected.passed || !(expected.victoryCollected || expected.weaponUpgradeCompleted))throw new InvalidOperationException("Resume fixture must be a passed campaign or permanent-growth profile.");
                string targetProfile=Path.Combine(root,"Profile");Directory.CreateDirectory(targetProfile);
                foreach(string file in Directory.GetFiles(Path.Combine(source,"Profile")))File.Copy(file,Path.Combine(targetProfile,Path.GetFileName(file)),false);
                Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_EXPECT_LEVEL",expected.level.ToString());
                Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_EXPECT_COIN",expected.coin.ToString(System.Globalization.CultureInfo.InvariantCulture));
                Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_EXPECT_WEAPON_LEVEL",expected.weaponUpgradeCompleted?expected.weaponLevelAfter.ToString():null);
            }
            SessionState.SetString(Key, root);
            Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ROOT", root);
            EditorApplication.playModeStateChanged -= OnMode;
            EditorApplication.playModeStateChanged += OnMode;
            EditorApplication.update -= Monitor;
            EditorApplication.update += Monitor;
            deadline = EditorApplication.timeSinceStartup + ((Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS")=="later-campaign" || (Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS")=="onboarding-home" || Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS")=="onboarding-talent"))?900:((Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS")=="tutorial" || (Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS")=="later-battle" || Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS")=="third-guide"))?360:180));
            EditorSceneManager.OpenScene("Assets/Scenes/Loading.unity", OpenSceneMode.Single);
            EditorApplication.isPlaying = true;
        }
        private static void OnMode(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.EnteredEditMode) EditorApplication.delayCall += CheckCompletion;
        }
        private static void CheckCompletion()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode) return;
            string root = SessionState.GetString(Key, "");
            if (string.IsNullOrEmpty(root)) return;
            string report = Path.Combine(root, "runtime-probe.json");
            if (!File.Exists(report)) return;
            var result = JsonUtility.FromJson<OfflineRuntimeProbe.Result>(File.ReadAllText(report));
            File.Copy(report, Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Verification", "cold-start-latest.json"), true);
            SessionState.EraseString(Key);
            Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ROOT", null);
            EditorApplication.Exit(result.passed ? 0 : 1);
        }
        private static void Monitor()
        {
            if (EditorApplication.timeSinceStartup <= deadline) return;
            Debug.LogError("Offline cold-start verification timed out; see the current Unity log.");
            SessionState.EraseString(Key);
            Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ROOT", null);
            EditorApplication.Exit(2);
        }
    }
}
