using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyForge.Offline.Editor
{
    public static class ResultDamageVerification
    {
        [Serializable] public sealed class OriginalRowShape { public string name; public OriginalRowShape[] children; }
        // Embedded by bind_scene_fixture.py from independently parsed original Sahne.unity.
        const string OriginalRowJson = "{\"name\":\"damage\",\"children\":[{\"name\":\"raritycolor\",\"children\":[{\"name\":\"mask\",\"children\":[{\"name\":\"icon\",\"children\":[]}]}]},{\"name\":\"name\",\"children\":[]},{\"name\":\"total\",\"children\":[]},{\"name\":\"dps\",\"children\":[]}]}";
        [Serializable] public sealed class Result
        {
            public bool passed; public int checks; public string outputDirectory;
            public List<string> failures = new List<string>();
            public List<string> limitations = new List<string>();
        }
        static void Check(Result r, bool condition, string label) { r.checks++; if (!condition) r.failures.Add(label); }
        static GameObject Child(Transform parent, string name)
        {
            var g = new GameObject(name, typeof(RectTransform)); g.SetActive(false); g.transform.SetParent(parent, false); return g;
        }
        static T Add<T>(Transform parent, string name) where T : Component { return Child(parent, name).AddComponent<T>(); }
        static Transform BuildOriginalRow(Transform parent, OriginalRowShape shape)
        {
            var node = Child(parent, shape.name).transform;
            if (shape.name == "raritycolor" || shape.name == "icon") node.gameObject.AddComponent<Image>();
            if (shape.name == "name" || shape.name == "total" || shape.name == "dps")
                node.gameObject.AddComponent<TextMeshProUGUI>().text = shape.name == "name" ? "Silver spoone" : shape.name == "total" ? "500.5M" : "129,250";
            if (shape.children != null) foreach (var child in shape.children) BuildOriginalRow(node, child);
            return node;
        }
        static Transform Content(Transform parent, string name, int count)
        {
            var content = Child(parent, name).transform;
            for (int i = 0; i < count; i++)
            {
                // The factory imports independent original names/order/leaf depths;
                // it does not reproduce the candidate's numeric lookup expression.
                var row = BuildOriginalRow(content, JsonUtility.FromJson<OriginalRowShape>(OriginalRowJson));
                row.gameObject.SetActive(true);
            }
            return content;
        }
        static string Text(Transform content, int row, int field) { return content.GetChild(row).GetChild(field).GetComponent<TextMeshProUGUI>().text; }
        static object Call(object obj, string name, params object[] args)
        { return obj.GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Invoke(obj, args); }
        public static void Run()
        {
            var result = RunChecks(Environment.GetEnvironmentVariable("LUCKYFORGE_DAMAGE_CHECK_ROOT"));
            if (!result.passed) throw new InvalidOperationException("ResultDamageVerification failed; see " + result.outputDirectory);
        }
        public static Result RunChecks(string suppliedRoot = null)
        {
            var r = new Result { outputDirectory = Path.GetFullPath(string.IsNullOrEmpty(suppliedRoot)
                ? Path.Combine(Path.GetTempPath(), "LuckyForgeDamageChecks", Guid.NewGuid().ToString("N")) : suppliedRoot) };
            if (EditorApplication.isPlayingOrWillChangePlaymode) { r.failures.Add("Requires non-playing isolated Editor."); return r; }
            Directory.CreateDirectory(r.outputDirectory);
            var oldCulture = CultureInfo.CurrentCulture;
            var oldGear = PlayerData.KiyafetData; var oldFortune = PlayerData.dailyFortune;
            bool oldCloseText = MenuGeneralSettings.CloseTextObjects; var oldRandom = UnityEngine.Random.state;
            var root = new GameObject("ResultDamageVerification"); root.SetActive(false);
            var objects = new List<UnityEngine.Object>();
            double coinBefore = Currencys.Coin; int foodBefore = Currencys.PetFood;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
                var war = Add<WarController>(root.transform, "WarController"); war.enabled = false;
                var hero = Add<HeroController>(root.transform, "HeroController"); hero.enabled = false; war.heroController = hero;
                hero.HeroCommanders = new List<Commander>();
                hero.rarityColors = new[] { Color.white, Color.green, Color.blue, Color.yellow, Color.magenta };
                var texture = new Texture2D(2, 2); objects.Add(texture);
                for (int i = 0; i < 12; i++)
                {
                    var commander = Add<Commander>(root.transform, "Commander" + i); commander.enabled = false;
                    commander.HeroNum = i; commander.HeroName = "Hero" + i; commander.Rarity = (WeaponRarity)(i % 5);
                    commander.icon = Add<SpriteRenderer>(commander.transform, "Sprite");
                    commander.icon.sprite = Sprite.Create(texture, new Rect(0, 0, 2, 2), new Vector2(.5f, .5f));
                    objects.Add(commander.icon.sprite); hero.HeroCommanders.Add(commander);
                }
                var content = Content(root.transform, "FinalContent", 10); war.final_weaponcontent = content;
                var firstRow = content.GetChild(0); var firstIcon = firstRow.GetChild(0).GetChild(0).GetChild(0);
                war.WarTimerSecond = 10f; war.TotalUiDamages = new double[12];
                war.TotalUiDamages[2] = 2500000.0; war.TotalUiDamages[9] = 2500000.0; war.TotalUiDamages[5] = 100.0;
                war.ShowSortedDamages(content);
                Check(r, Text(content, 0, 1) == "Hero2" && Text(content, 1, 1) == "Hero9" && Text(content, 2, 1) == "Hero5",
                    "Actual original-index damage sorting descends with stable tie order");
                Check(r, Text(content, 0, 2) == "2.5 M" && Text(content, 1, 2) == "2.5 M" && Text(content, 2, 2) == "100",
                    "Actual total damage replaces serialized placeholder with original short-scale format");
                Check(r, Text(content, 0, 3) == "250,000" && Text(content, 2, 3) == "10",
                    "Actual DPS divides totals by original WarTimerSecond10 and formats result");
                Check(r, firstRow.GetChild(0).GetComponent<Image>().color == hero.rarityColors[2], "Actual row rarity color comes from matching Commander");
                Check(r, firstIcon.GetComponent<Image>().sprite == hero.HeroCommanders[2].icon.sprite, "Actual nested original icon path receives matching sprite");
                bool active = true; for (int i = 0; i < 10; i++) active &= content.GetChild(i).gameObject.activeSelf == (i < 3);
                Check(r, active, "Only the three nonzero contributors remain visible");
                Check(r, content.childCount == 10 && content.GetChild(0) == firstRow && firstRow.GetChild(0).GetChild(0).GetChild(0) == firstIcon,
                    "Original rows and hierarchy reused without instantiate/destroy/layout mutation");
                Check(r, war.TotalUiDamages[2] == 2500000.0 && war.TotalUiDamages[9] == 2500000.0 && war.TotalUiDamages[5] == 100.0,
                    "Statistics display does not alter battle damage counters");

                Array.Clear(war.TotalUiDamages, 0, war.TotalUiDamages.Length); war.TotalUiDamages[1] = 80.0;
                war.ShowSortedDamages(content);
                Check(r, Text(content, 0, 1) == "Hero1" && Text(content, 0, 2) == "80" && Text(content, 0, 3) == "8",
                    "Repeated display updates existing first row with new battle values");
                bool staleHidden = true; for (int i = 1; i < 10; i++) staleHidden &= !content.GetChild(i).gameObject.activeSelf;
                Check(r, staleHidden, "Repeated display hides previous contributors rather than leaving placeholder rows");
                Array.Clear(war.TotalUiDamages, 0, war.TotalUiDamages.Length); war.ShowSortedDamages(content);
                bool allHidden = true; for (int i = 0; i < 10; i++) allHidden &= !content.GetChild(i).gameObject.activeSelf;
                Check(r, allHidden, "Zero damage shows no rows");

                for (int i = 0; i < 12; i++) war.TotalUiDamages[i] = i + 1;
                war.WarTimerSecond = 1f; war.ShowSortedDamages(content);
                bool topTen = true;
                for (int i = 0; i < 10; i++) topTen &= content.GetChild(i).gameObject.activeSelf
                    && Text(content, i, 1) == "Hero" + (11 - i) && Text(content, i, 2) == (12 - i).ToString(CultureInfo.InvariantCulture);
                Check(r, topTen && content.childCount == 10, "Twelve actual contributors reuse only original top10 rows");

                Array.Clear(war.TotalUiDamages, 0, war.TotalUiDamages.Length);
                war.TotalUiDamages[0] = -20; war.TotalUiDamages[1] = 50; war.TotalUiDamages[2] = -10;
                war.ShowSortedDamages(content);
                Check(r, Text(content, 0, 1) == "Hero1" && Text(content, 1, 1) == "Hero2" && Text(content, 2, 1) == "Hero0",
                    "Native predicate is nonzero, including negative values, rather than an invented positive-only filter");

                var menu = Content(root.transform, "MenuContent", 3); war.menu_weaponcontent = menu;
                Array.Clear(war.TotalUiDamages, 0, war.TotalUiDamages.Length); war.TotalUiDamages[7] = 70;
                war.ShowSortedDamages(menu);
                Check(r, menu.childCount == 3 && Text(menu, 0, 1) == "Hero7" && !menu.GetChild(1).gameObject.activeSelf && !menu.GetChild(2).gameObject.activeSelf,
                    "Same original method fills a separate content and safely hides available unused rows");
                Check(r, Text(content, 0, 1) == "Hero1", "Displaying menu content does not rewrite final content");
                Check(r, Currencys.Coin == coinBefore && Currencys.PetFood == foodBefore,
                    "Damage presentation has no currency or reward side effect");

                var emptyWar = Add<WarController>(root.transform, "EmptyPauseFixture"); emptyWar.enabled = false;
                emptyWar.TotalUiDamages = new double[0]; emptyWar.heroController = null;
                var emptyContent = Content(root.transform, "EmptyPauseContent", 0); emptyWar.ShowSortedDamages(emptyContent);
                Check(r, emptyContent.childCount == 0 && emptyWar.heroController == null,
                    "Original empty statistics/empty content path requires no hero references and suits pause fixture");

                // Exercise the actual existing production methods, not a synthetic counter update.
                MenuGeneralSettings.CloseTextObjects = true;
                PlayerData.KiyafetData = new PlayerData.NewKiyafetData(); PlayerData.dailyFortune = new PlayerData.DailyFortune();
                Array.Clear(war.TotalUiDamages, 0, war.TotalUiDamages.Length); war.WarTimerSecond = 10f;
                var pool = Add<PoolObject>(root.transform, "ActualProjectilePool"); pool.enabled = false; pool.warController = war;
                pool.pools = new List<PoolObject.Pool>(); pool.SkillProjectilePools = new List<SkillProjectilePool>();
                var prefab = Add<Projectile>(root.transform, "ActualProjectilePrototype"); prefab.enabled = false;
                prefab.warController = war; prefab.poolObjects = pool; prefab.rotation = false;
                pool.Projectilepools = new List<ProjectilePool> { new ProjectilePool { tag = "result-fixture", prefab = prefab, size = 2 } };
                pool.ActivatePool(); war.objectPool = pool;
                var enemy = Add<Enemy>(root.transform, "ActualEnemy"); enemy.enabled = false; enemy.warController = war;
                enemy.unitData = Add<UnitDatas>(root.transform, "ActualUnitData"); enemy.unitData.enabled = false;
                enemy.unitData.health = enemy.unitData.MaxHealth = 10000;
                var queues = (Dictionary<string, Queue<Projectile>>)typeof(PoolObject)
                    .GetField("ProjectilePoolDictionary", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(pool);
                var commander1 = hero.HeroCommanders[1]; commander1.warController = war;
                commander1.projectilePivot = Child(commander1.transform, "Pivot").transform;
                commander1.ProjectileName = "result-fixture"; commander1.attack = 120; commander1.critchance = -1f;
                var shot = queues[commander1.ProjectileName].Peek(); Call(commander1, "ShootArrow", enemy);
                Check(r, shot.atanCommanderNum == 1 && shot.attackDamage == 120 && shot.targetPosition == enemy.transform,
                    "Existing real Commander.ShootArrow preserves HeroNum attribution and attack in actual pooled projectile");
                shot._HedefEnemiyse = enemy; Call(shot, "DealDamage");
                Check(r, enemy.unitData.health == 9880 && war.TotalUiDamages[1] == 120.0,
                    "Existing real Projectile.DealDamage and Enemy.TakeDamage apply damage and produce120 UI counter");
                war.ShowSortedDamages(content);
                Check(r, Text(content, 0, 1) == "Hero1" && Text(content, 0, 2) == "120" && Text(content, 0, 3) == "12",
                    "Actual attack-produced counter reaches the displayed weapon total and DPS");
                var commander2 = hero.HeroCommanders[4]; commander2.warController = war;
                commander2.projectilePivot = Child(commander2.transform, "Pivot").transform;
                commander2.ProjectileName = "result-fixture"; commander2.attack = 200; commander2.critchance = -1f;
                var shot2 = queues[commander2.ProjectileName].Peek(); Call(commander2, "ShootArrow", enemy);
                shot2._HedefEnemiyse = enemy; Call(shot2, "DealDamage"); war.ShowSortedDamages(content);
                Check(r, enemy.unitData.health == 9680 && war.TotalUiDamages[4] == 200.0 && war.TotalUiDamages[1] == 120.0,
                    "Second real weapon damage remains separately attributed");
                Check(r, Text(content, 0, 1) == "Hero4" && Text(content, 1, 1) == "Hero1"
                    && Text(content, 0, 2) == "200" && Text(content, 0, 3) == "20",
                    "Results sort and populate actual two-weapon damage production");
                Check(r, Currencys.Coin == coinBefore && Currencys.PetFood == foodBefore && !enemy.dead,
                    "Nonlethal production fixture does not invoke death rewards or change currency");
                r.limitations.Add("Actual Unity component/service execution in Edit mode; no mock UI or formatter. Does not play a battle or screenshot the rendered result.");
                r.limitations.Add("Uses actual current reconstructed ShortScaleString; explicit expected strings use invariant-culture test cases. Does not alter formatting/localization implementation.");
                r.limitations.Add("Matches original prebuilt-row contract: at least as many rows as visible nonzero contributors up to10; no new undersized-row or zero-duration fallback added.");
            }
            catch (Exception ex) { r.failures.Add(ex.ToString()); }
            finally
            {
                UnityEngine.Object.DestroyImmediate(root);
                foreach (var obj in objects) if (obj != null) UnityEngine.Object.DestroyImmediate(obj);
                CultureInfo.CurrentCulture = oldCulture;
                PlayerData.KiyafetData = oldGear; PlayerData.dailyFortune = oldFortune;
                MenuGeneralSettings.CloseTextObjects = oldCloseText; UnityEngine.Random.state = oldRandom;
            }
            r.passed = r.failures.Count == 0;
            File.WriteAllText(Path.Combine(r.outputDirectory, "damage-editor-results.json"), JsonUtility.ToJson(r, true));
            Debug.Log("ResultDamageVerification checks=" + r.checks + " passed=" + r.passed + " root=" + r.outputDirectory);
            return r;
        }
    }
}
