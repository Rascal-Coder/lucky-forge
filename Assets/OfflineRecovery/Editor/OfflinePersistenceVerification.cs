using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

namespace LuckyForge.Offline.Editor
{
    public static class OfflinePersistenceVerification
    {
        [Serializable] public sealed class Result { public bool passed; public int checks; public string testRoot; public List<string> failures = new List<string>(); }
        [Serializable] private sealed class Payload { public long amount; public DateTime when; public List<int> levels; public string label; }
        [Serializable] private sealed class References { public UnityEngine.Object known; public UnityEngine.Object missing; }
        private sealed class VerificationAsset : ScriptableObject { public int value; }
        private static void Check(Result r, bool success, string name) { r.checks++; if (!success) r.failures.Add(name); }

        public static Result RunChecks(string suppliedRoot = null)
        {
            string root = suppliedRoot ?? Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Verification", "PersistenceTests", Guid.NewGuid().ToString("N"));
            var r = new Result { testRoot = Path.GetFullPath(root) };
            Directory.CreateDirectory(r.testRoot);
            OfflineKeyStore.SetVerificationRoot(r.testRoot);
            var cache = new ES3Settings("cache-check.es3", ES3.Location.Cache);
            var disk = new ES3Settings("disk-check.es3", ES3.Location.File);
            try
            {
                Check(r, ES3Settings.defaultSettings.path == "medupac.es3" && ES3Settings.defaultSettings.location == ES3.Location.Cache, "shipped default file/cache location");
                ES3.Save<string>("Coin", "5");
                Check(r, ES3.KeyExists("Coin") && ES3.Load<string>("Coin") == "5", "exact startup Save<T>/KeyExists/Load<T> overloads");
                Check(r, ES3.Load<int>("MissingStartupKey", 37) == 37, "exact startup fallback overload");
                ES3.StoreCachedFile("medupac.es3", new ES3Settings("medupac.es3", ES3.Location.File));
                OfflineKeyStore.ResetMemoryForVerification();
                Check(r, ES3.FileExists("medupac.es3", new ES3Settings("medupac.es3", ES3.Location.File)), "exact startup FileExists explicit File settings");
                ES3.CacheFile("medupac.es3", new ES3Settings("medupac.es3", ES3.Location.File));
                Check(r, ES3.Load<string>("Coin") == "5", "exact startup CacheFile overload reload");

                ES3.Save("cached", 11, cache);
                Check(r, !File.Exists(OfflineKeyStore.PathFor(null, cache)) && ES3.Load<int>("cached", cache) == 11, "cache write stays in memory until flush");
                ES3.StoreCachedFile(cache.path, cache);
                OfflineKeyStore.ResetMemoryForVerification();
                Check(r, ES3.Load<int>("cached", cache) == 11, "cache flush survives reset/reload");

                var data = new Payload { amount = 1234567890123456789L, when = new DateTime(638700000001234567L, DateTimeKind.Utc), levels = new List<int> {1, 4, 9}, label = "离线数据" };
                ES3.Save("dto", data, disk);
                ES3.Save("bool", true, disk);
                ES3.Save<string>("null", null, disk);
                ES3.Save("empty", new List<int>(), disk);
                OfflineKeyStore.ResetMemoryForVerification();
                var loaded = ES3.Load<Payload>("dto", disk);
                Check(r, loaded.amount == data.amount && loaded.when.Ticks == data.when.Ticks && loaded.when.Kind == DateTimeKind.Utc && loaded.levels.Count == 3 && loaded.label == data.label, "custom DTO/Int64/UTC/list/unicode roundtrip");
                Check(r, ES3.Load<bool>("bool", disk) && ES3.Load<string>("null", defaultValue: "fallback", settings: disk) == null && ES3.Load<List<int>>("empty", disk).Count == 0, "bool/null/empty collection roundtrip");
                bool missingThrows = false;
                try { ES3.Load<int>("no-default", disk); } catch (KeyNotFoundException) { missingThrows = true; }
                Check(r, missingThrows, "missing required key throws rather than silently granting default");
                var into = new Payload { amount = -1, levels = new List<int> {99} };
                ES3.LoadInto("dto", into, disk);
                Check(r, into.amount == data.amount && into.levels.Count == 3 && into.levels[0] == 1, "LoadInto replaces prior collection values");

                var known = ScriptableObject.CreateInstance<VerificationAsset>();
                var unregistered = ScriptableObject.CreateInstance<VerificationAsset>();
                known.name = "known"; unregistered.name = "known";
                OfflineAssetReferenceCatalog.Register("verification-guid:11400000", known);
                ES3.Save("references", new References {known = known, missing = unregistered}, disk);
                OfflineKeyStore.ResetMemoryForVerification();
                var references = ES3.Load<References>("references", disk);
                Check(r, references.known == known && references.missing == null, "stable asset identity and no name-based guessing");
                UnityEngine.Object.DestroyImmediate(known); UnityEngine.Object.DestroyImmediate(unregistered);

                var recovery = new ES3Settings("backup-check.es3", ES3.Location.File);
                ES3.Save("value", 1, recovery);
                ES3.Save("value", 2, recovery);
                string recoveryPath = OfflineKeyStore.PathFor(null, recovery);
                Check(r, File.Exists(recoveryPath + ".bak"), "previous verified generation backup exists");
                var tampered = JObject.Parse(File.ReadAllText(recoveryPath));
                tampered["payload"] = "{}";
                File.WriteAllText(recoveryPath, tampered.ToString());
                OfflineKeyStore.ResetMemoryForVerification();
                Check(r, ES3.Load<int>("value", recovery) == 1, "checksum mismatch falls back to last valid backup");
                ES3.Save("value", 3, recovery);
                OfflineKeyStore.ResetMemoryForVerification();
                Check(r, ES3.Load<int>("value", recovery) == 3, "write after recovery keeps valid state");
                File.WriteAllText(recoveryPath + ".tmp", "interrupted pending write");
                OfflineKeyStore.ResetMemoryForVerification();
                Check(r, ES3.Load<int>("value", recovery) == 3, "interrupted temp file cannot replace committed primary");
                File.Delete(recoveryPath);
                OfflineKeyStore.ResetMemoryForVerification();
                Check(r, ES3.Load<int>("value", recovery) == 1, "missing primary recovers remaining verified backup");

                ES3.DeleteKey("bool", disk);
                Check(r, !ES3.KeyExists("bool", disk) && Array.IndexOf(ES3.GetKeys(disk), "dto") >= 0, "delete key and key enumeration");
                ES3.DeleteFile(recovery);
                Check(r, !ES3.FileExists(recovery) && !File.Exists(recoveryPath + ".bak"), "delete only selected isolated file and backup");
                r.passed = r.failures.Count == 0;
            }
            catch (Exception ex) { r.failures.Add(ex.ToString()); r.passed = false; }
            finally { OfflineKeyStore.SetVerificationRoot(null); }
            File.WriteAllText(Path.Combine(r.testRoot, "results.json"), JsonUtility.ToJson(r, true));
            string verification = Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Verification");
            Directory.CreateDirectory(verification);
            File.WriteAllText(Path.Combine(verification, "offline-persistence.json"), JsonUtility.ToJson(r, true));
            Debug.Log("Offline persistence checks: " + r.checks + ", failures: " + r.failures.Count);
            return r;
        }

        public static void RunBatch() { EditorApplication.Exit(RunChecks().passed ? 0 : 1); }
    }
}
