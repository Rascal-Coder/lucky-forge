using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyForge.Offline.Editor
{
    // Isolated real Editor objects + the rebuild's actual ES3/OfflineKeyStore.
    // Never invoke in a playing session or concurrently with another verification root.
    public static class PetLifecycleVerification
    {
        [Serializable] public sealed class Result
        {
            public bool passed;
            public int checks;
            public string testRoot, saveFile;
            public List<string> failures = new List<string>();
            public List<string> limitations = new List<string>();
            public List<string> observations = new List<string>();
        }
        static void Check(Result r, bool condition, string label)
        { r.checks++; if (!condition) r.failures.Add(label); }
        static GameObject Child(Transform parent, string name)
        {
            var g = new GameObject(name, typeof(RectTransform));
            g.SetActive(false); g.transform.SetParent(parent, false); return g;
        }
        static T Add<T>(Transform parent, string name) where T : Component
        { return Child(parent, name).AddComponent<T>(); }
        static object Call(object obj, string name, params object[] args)
        {
            return obj.GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Invoke(obj, args);
        }
        static void FlushAndForget()
        {
            var disk = new ES3Settings("medupac.es3", ES3.Location.File);
            ES3.StoreCachedFile("medupac.es3", disk);
            OfflineKeyStore.ResetMemoryForVerification();
            ES3.CacheFile("medupac.es3", disk);
        }
        static float R4(double value) { return BitConverter.ToSingle(BitConverter.GetBytes((float)value), 0); }
        static long NativeBinary32Damage(Pet pet, long health)
        {
            // ARM64 scvtf/fmul/fadd/fmul/fdiv are each single precision. This is
            // an independent explicit rounding oracle, not a replacement game method.
            float levelTerm = R4((double)pet.Level * (double)0.1f);
            float percent = R4((double)pet.BaslangicAtk + (double)levelTerm);
            float product = R4((double)percent * (double)R4((double)health));
            float divided = R4((double)product / 100.0);
            return unchecked((long)divided + 10L);
        }
        static PetPage MakePage(Transform root, HeroController hero, RuntimeAnimatorController controller)
        {
            var page = Add<PetPage>(root, "PetPage"); page.enabled = false;
            foreach (var f in typeof(PetPage).GetFields(BindingFlags.Instance | BindingFlags.Public))
            {
                if (f.FieldType == typeof(TextMeshProUGUI)) f.SetValue(page, Add<TextMeshProUGUI>(page.transform, f.Name));
                else if (f.FieldType == typeof(Button)) f.SetValue(page, Add<Button>(page.transform, f.Name));
            }
            page.stars = Child(page.transform, "Stars").transform;
            for (int i = 0; i < 7; i++) Child(Child(page.stars, "Star" + i).transform, "Filled");
            page.characterSet = Child(page.transform, "Preview").transform;
            for (int i = 0; i < 9; i++) Child(page.characterSet, "Pet" + i);
            page.eventileeldeedilirobj = Child(page.transform, "OwnershipGate").transform;
            page.sliderexp = Add<Slider>(page.transform, "XP");
            page.useeff = Add<ParticleSystem>(page.transform, "UseParticle");
            page.animUpg = Add<Animator>(page.transform, "UpgradeAnimator");
            page.animUpg.runtimeAnimatorController = AssetDatabase.LoadAssetAtPath<RuntimeAnimatorController>("Assets/AnimatorController/TalentShow.controller");
            page.inventoryGearUI = Add<InventoryGearUI>(root, "InventoryGearUI");
            page.inventoryGearUI.enabled = false;
            page.heroController = hero; return page;
        }
        static void OriginalPetData(Pet[] pets)
        {
            // Replaced by prepare_editor_fixture.py with exact original level1 values.
            // Original level1 Pet component 89570
            pets[0].PetName = "Rocky";
            pets[0].Num = 0;
            pets[0].BaslangicAtkSpeed = 1.0f;
            pets[0].BaslangicAtk = 2.0f;
            pets[0].StartLevel = 0;
            pets[0].Level = 0;
            pets[0].LevelExp = 0;
            pets[0].MaxLevel = 7;
            pets[0].BaslangicExp = 0;
            pets[0].DegerSonu = "%";
            pets[0].ProjectileName = "pet0projectile";
            pets[0].BonusLevel = new int[] {0,10,15,20,25,30,35,40,45};
            pets[0].SetPetStone = new int[] {50,100,250,700,1200,2000,3500,5000};
            // Original level1 Pet component 88625
            pets[1].PetName = "Mysto";
            pets[1].Num = 1;
            pets[1].BaslangicAtkSpeed = 1.2000000476837158f;
            pets[1].BaslangicAtk = 1.600000023841858f;
            pets[1].StartLevel = 0;
            pets[1].Level = 0;
            pets[1].LevelExp = 0;
            pets[1].MaxLevel = 7;
            pets[1].BaslangicExp = 0;
            pets[1].DegerSonu = "%";
            pets[1].ProjectileName = "pet1projectile";
            pets[1].BonusLevel = new int[] {0,10,15,20,25,30,35,40,45};
            pets[1].SetPetStone = new int[] {50,100,250,700,1200,2000,3500,5000};
            // Original level1 Pet component 91074
            pets[2].PetName = "Nimbus";
            pets[2].Num = 2;
            pets[2].BaslangicAtkSpeed = 1.399999976158142f;
            pets[2].BaslangicAtk = 1.5f;
            pets[2].StartLevel = 0;
            pets[2].Level = 0;
            pets[2].LevelExp = 0;
            pets[2].MaxLevel = 7;
            pets[2].BaslangicExp = 0;
            pets[2].DegerSonu = "%";
            pets[2].ProjectileName = "pet2projectile";
            pets[2].BonusLevel = new int[] {0,10,15,20,25,30,35,40,45};
            pets[2].SetPetStone = new int[] {50,100,250,700,1200,2000,3500,5000};
            // Original level1 Pet component 91763
            pets[3].PetName = "Twinkle";
            pets[3].Num = 3;
            pets[3].BaslangicAtkSpeed = 1.2000000476837158f;
            pets[3].BaslangicAtk = 1.2999999523162842f;
            pets[3].StartLevel = 0;
            pets[3].Level = 0;
            pets[3].LevelExp = 0;
            pets[3].MaxLevel = 7;
            pets[3].BaslangicExp = 0;
            pets[3].DegerSonu = "%";
            pets[3].ProjectileName = "pet3projectile";
            pets[3].BonusLevel = new int[] {0,10,15,20,25,30,35,40,45};
            pets[3].SetPetStone = new int[] {50,100,250,700,1200,2000,3500,5000};
            // Original level1 Pet component 88543
            pets[4].PetName = "Shade";
            pets[4].Num = 4;
            pets[4].BaslangicAtkSpeed = 2.0f;
            pets[4].BaslangicAtk = 1.0f;
            pets[4].StartLevel = 0;
            pets[4].Level = 0;
            pets[4].LevelExp = 0;
            pets[4].MaxLevel = 7;
            pets[4].BaslangicExp = 0;
            pets[4].DegerSonu = "%";
            pets[4].ProjectileName = "pet4projectile";
            pets[4].BonusLevel = new int[] {0,10,15,20,25,30,35,40,45};
            pets[4].SetPetStone = new int[] {50,100,250,700,1200,2000,3500,5000};
            // Original level1 Pet component 85883
            pets[5].PetName = "Blaze";
            pets[5].Num = 5;
            pets[5].BaslangicAtkSpeed = 1.5f;
            pets[5].BaslangicAtk = 1.399999976158142f;
            pets[5].StartLevel = 0;
            pets[5].Level = 0;
            pets[5].LevelExp = 0;
            pets[5].MaxLevel = 7;
            pets[5].BaslangicExp = 0;
            pets[5].DegerSonu = "%";
            pets[5].ProjectileName = "pet5projectile";
            pets[5].BonusLevel = new int[] {0,10,15,20,25,30,35,40,45};
            pets[5].SetPetStone = new int[] {50,100,250,700,1200,2000,3500,5000};
            // Original level1 Pet component 86595
            pets[6].PetName = "Cherri";
            pets[6].Num = 6;
            pets[6].BaslangicAtkSpeed = 1.0f;
            pets[6].BaslangicAtk = 2.200000047683716f;
            pets[6].StartLevel = 0;
            pets[6].Level = 0;
            pets[6].LevelExp = 0;
            pets[6].MaxLevel = 7;
            pets[6].BaslangicExp = 0;
            pets[6].DegerSonu = "%";
            pets[6].ProjectileName = "pet6projectile";
            pets[6].BonusLevel = new int[] {0,10,15,20,25,30,35,40,45};
            pets[6].SetPetStone = new int[] {50,100,250,700,1200,2000,3500,5000};
            // Original level1 Pet component 93736
            pets[7].PetName = "Gloop";
            pets[7].Num = 7;
            pets[7].BaslangicAtkSpeed = 1.2999999523162842f;
            pets[7].BaslangicAtk = 2.5f;
            pets[7].StartLevel = 0;
            pets[7].Level = 0;
            pets[7].LevelExp = 0;
            pets[7].MaxLevel = 7;
            pets[7].BaslangicExp = 0;
            pets[7].DegerSonu = "%";
            pets[7].ProjectileName = "pet7projectile";
            pets[7].BonusLevel = new int[] {0,10,15,20,25,30,35,40,45};
            pets[7].SetPetStone = new int[] {50,100,250,700,1200,2000,3500,5000};
            // Original level1 Pet component 90714
            pets[8].PetName = "Dingy";
            pets[8].Num = 8;
            pets[8].BaslangicAtkSpeed = 1.100000023841858f;
            pets[8].BaslangicAtk = 1.2999999523162842f;
            pets[8].StartLevel = 0;
            pets[8].Level = 0;
            pets[8].LevelExp = 0;
            pets[8].MaxLevel = 7;
            pets[8].BaslangicExp = 0;
            pets[8].DegerSonu = "%";
            pets[8].ProjectileName = "pet8projectile";
            pets[8].BonusLevel = new int[] {0,10,15,20,25,30,35,40,45};
            pets[8].SetPetStone = new int[] {50,100,250,700,1200,2000,3500,5000};
        }
        public static void Run()
        {
            var r = RunChecks(Environment.GetEnvironmentVariable("LUCKYFORGE_PET_CHECK_ROOT"));
            if (!r.passed) throw new InvalidOperationException("PetLifecycleVerification failed; see " + r.testRoot);
        }
        public static Result RunChecks(string suppliedRoot = null)
        {
            var r = new Result { testRoot = Path.GetFullPath(string.IsNullOrEmpty(suppliedRoot)
                ? Path.Combine(Path.GetTempPath(), "LuckyForgePetChecks", Guid.NewGuid().ToString("N")) : suppliedRoot) };
            if (EditorApplication.isPlayingOrWillChangePlaymode)
            { r.failures.Add("Requires a dedicated non-playing Editor; verification root is process-global."); return r; }
            if (Directory.Exists(r.testRoot) && Directory.GetFileSystemEntries(r.testRoot).Length != 0)
            { r.failures.Add("Verification root must be empty; existing files are never deleted."); return r; }
            Directory.CreateDirectory(r.testRoot);
            var statics = new Dictionary<FieldInfo, object>();
            foreach (var type in new[] { typeof(Currencys), typeof(Lang), typeof(GameManager) })
                foreach (var f in type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                    if (!f.IsLiteral && !f.IsInitOnly) statics[f] = f.GetValue(null);
            var oldSound = SoundManager.instance;
            var oldRandom = UnityEngine.Random.state;
            var oldRoot = typeof(OfflineKeyStore).GetField("verificationRoot", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null) as string;
            var root = new GameObject("PetLifecycleVerification"); root.SetActive(false);
            OfflineKeyStore.SetVerificationRoot(r.testRoot);
            try
            {
                GameManager.Language = 0; Lang.currentLang = null;
                SoundManager.instance = Add<SoundManager>(root.transform, "ActualSoundManager");
                SoundManager.instance.enabled = false;
                var controller = AssetDatabase.LoadAssetAtPath<RuntimeAnimatorController>("Assets/AnimatorController/pet.controller");
                var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>("Assets/AnimationClip/PetAnimsAtk.anim");
                Check(r, controller != null && clip != null, "Original pet controller and attack clip load via AssetDatabase");
                bool motion = false, evt = false;
                if (controller != null && clip != null)
                    foreach (var c in controller.animationClips) if (c == clip) motion = true;
                if (clip != null)
                    foreach (var e in AnimationUtility.GetAnimationEvents(clip))
                        if (e.functionName == "Attack" && Mathf.Abs(e.time - .8f) < .00001f) evt = true;
                Check(r, motion && evt, "Real original controller references clip with Attack at0.8 seconds");

                var hero = Add<HeroController>(root.transform, "HeroController"); hero.enabled = false;
                hero.canvasJobs = Add<CanvasJobs>(root.transform, "CanvasJobs"); hero.canvasJobs.enabled = false;
                hero.canvasJobs.golyokbasictxt = Add<TextMeshProUGUI>(root.transform, "MissingResourcesText");
                hero.canvasJobs.goldyokbasic = Child(root.transform, "MissingResources");
                hero.battleinpetparent = Child(root.transform, "BattlePets").transform;
                var page = MakePage(root.transform, hero, controller);
                hero.Pets = new Pet[9];
                for (int i = 0; i < 9; i++)
                {
                    hero.Pets[i] = Add<Pet>(hero.battleinpetparent, "Pet" + i);
                    hero.Pets[i].enabled = false;
                    hero.Pets[i].heroController = hero; hero.Pets[i].petPage = page;
                    hero.Pets[i].petatkanim = hero.Pets[i].gameObject.AddComponent<Animator>();
                    hero.Pets[i].petatkanim.runtimeAnimatorController = controller;
                    hero.Pets[i].skillparticle = Add<ParticleSystem>(hero.Pets[i].transform, "SkillParticle");
                }
                OriginalPetData(hero.Pets);
                hero.LoadPetLevels();
                hero.currentMainPet = ES3.Load<int>("currentMainPet", -1); hero.LoadPets();
                bool locked = true, inactive = true;
                foreach (var p in hero.Pets) { locked &= p.Level == 0 && p.LevelExp == 0; inactive &= !p.gameObject.activeSelf; }
                Check(r, locked && inactive && hero.currentMainPet == -1, "Clean actual ES3 load has nine locked pets and no selection");
                var pet = hero.Pets[0];
                pet.Use();
                Check(r, hero.currentMainPet == -1 && !ES3.KeyExists("currentMainPet"), "Locked Use cannot write selection");
                Call(page, "OnEnable");
                Check(r, pet.Level == 0 && hero.currentMainPet == -1 && !page.usebtn.gameObject.activeSelf
                    && !page.upgradebtn.gameObject.activeSelf && page.eventileeldeedilirobj.gameObject.activeSelf,
                    "Actual page preview does not grant or select locked pet");

                pet.AddKartExp(1);
                Check(r, pet.Level == 1 && pet.LevelExp == 1 && ES3.Load<int>("PetLevel0") == 1
                    && ES3.Load<int>("PetExp0") == 1, "Reward receiver unlocks exactly one pet and saves typed level/XP keys");
                Currencys.PetFoodFitle(100);
                pet.LevelUp();
                Check(r, pet.Level == 1 && pet.LevelExp == 1 && Currencys.PetFood == 100
                    && hero.canvasJobs.goldyokbasic.activeSelf, "Actual insufficient-XP branch retains level, XP and food");
                pet.AddKartExp(1); Currencys.PetFoodFitle(99); hero.canvasJobs.goldyokbasic.SetActive(false);
                pet.LevelUp();
                Check(r, pet.Level == 1 && pet.LevelExp == 2 && Currencys.PetFood == 99
                    && hero.canvasJobs.goldyokbasic.activeSelf, "Actual insufficient-food branch rejects original100-price upgrade");
                Currencys.PetFoodFitle(100); page.SetHero(0); page.Upgrade();
                Check(r, pet.Level == 2 && pet.LevelExp == 0 && Currencys.PetFood == 0,
                    "Actual page callback accepts exact100 food, spends and upgrades1to2");
                Check(r, ES3.Load<int>("PetLevel0") == 2 && ES3.Load<int>("PetExp0") == 0
                    && ES3.Load<int>("PetFood") == 0 && ES3.Load<int>("DataPetFood") == 0,
                    "Actual growth/currency services write matching level, XP, food and integrity values");
                page.Use();
                bool oneActive = hero.Pets[0].gameObject.activeSelf;
                for (int i = 1; i < 9; i++) oneActive &= !hero.Pets[i].gameObject.activeSelf;
                Check(r, hero.currentMainPet == 0 && ES3.Load<int>("currentMainPet") == 0 && oneActive,
                    "Actual page selection activates only owned pet and persists currentMainPet");
                Check(r, page.inventoryGearUI.pet_degisti && !page.usebtn.gameObject.activeSelf,
                    "Actual selection marks inventory refresh and hides selected-use button");

                // This is an explicit fixture reward, isolated from user/progression saves.
                pet.AddKartExp(4); Currencys.PetFoodFitle(250); page.Upgrade();
                Check(r, pet.Level == 3 && pet.LevelExp == 0 && Currencys.PetFood == 0,
                    "Next actual tier consumes4 XP and250 food");
                Currencys.PetFoodFitle(73); // Test-only explicit fixture balance; never touches user saves.
                FlushAndForget(); r.saveFile = OfflineKeyStore.PathFor();
                Check(r, File.Exists(r.saveFile) && new FileInfo(r.saveFile).Length > 0,
                    "Actual OfflineKeyStore persisted a physical isolated save file");
                foreach (var p in hero.Pets) { p.Level = -99; p.LevelExp = -99; }
                hero.LoadPetLevels(); Currencys.PetFoodFitle(0);
                // Forget the rewritten zero-food cache, then read the already persisted file.
                OfflineKeyStore.ResetMemoryForVerification(); ES3.CacheFile("medupac.es3", new ES3Settings("medupac.es3", ES3.Location.File));
                Currencys.LoadStartPetFood(); hero.currentMainPet = ES3.Load<int>("currentMainPet", -1); hero.LoadPets();
                Check(r, pet.Level == 3 && pet.LevelExp == 0 && hero.currentMainPet == 0 && Currencys.PetFood == 73,
                    "Pet.LoadData and actual currency load restore values after file flush/cache reset");
                bool untouched = true; for (int i = 1; i < 9; i++) untouched &= hero.Pets[i].Level == 0 && hero.Pets[i].LevelExp == 0;
                Check(r, untouched && !ES3.KeyExists("PetLevel1"), "Unrewarded pets remain locked after disk reload");

                var war = Add<WarController>(root.transform, "ActualWar"); war.enabled = false;
                var pool = Add<PoolObject>(root.transform, "ActualPool"); pool.enabled = false; pool.warController = war;
                pool.pools = new List<PoolObject.Pool>(); pool.SkillProjectilePools = new List<SkillProjectilePool>();
                var prototype = Add<Projectile>(root.transform, "FixtureProjectilePrototype"); prototype.enabled = false;
                prototype.poolObjects = pool; prototype.warController = war; prototype.rotation = false;
                pool.Projectilepools = new List<ProjectilePool> { new ProjectilePool { tag = pet.ProjectileName, prefab = prototype, size = 2 } };
                pool.ActivatePool(); war.objectPool = pool; pet.warController = war;
                var enemy = Add<Enemy>(root.transform, "ActualEnemy"); enemy.enabled = false;
                enemy.unitData = Add<UnitDatas>(root.transform, "ActualUnitData"); enemy.unitData.enabled = false;
                enemy.unitData.MaxHealth = 50000; enemy.unitData.health = 10000;
                pet.NextAttackType = 2; pet.NextAttackEffectPower = 2f; pet.NextAttackEffectSecond = 3f;
                var queues = (Dictionary<string, Queue<Projectile>>)typeof(PoolObject)
                    .GetField("ProjectilePoolDictionary", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(pool);
                // Read the actual queue head before each call instead of identifying a
                // shot by activeSelf while its fixture parent is inactiveInHierarchy.
                Projectile first = queues[pet.ProjectileName].Peek();
                int firstCount = queues[pet.ProjectileName].Count;
                Call(pet, "ShootArrow", enemy);
                long inlineExpected = unchecked((long)((pet.BaslangicAtk + pet.Level * .1f) * 10000f / 100f)) + 10L;
                long expected = NativeBinary32Damage(pet, enemy.unitData.health);
                float percentLocal = pet.BaslangicAtk + pet.Level * .1f;
                long expectedLocal = unchecked((long)(percentLocal * (float)enemy.unitData.health / 100f)) + 10L;
                r.observations.Add("Basic shot actual=" + (first == null ? "missing" : first.attackDamage.ToString())
                    + " inlineExpected=" + inlineExpected + " percentLocalExpected=" + expectedLocal
                    + " ARM64Binary32Expected=" + NativeBinary32Damage(pet, enemy.unitData.health)
                    + " level=" + pet.Level + " baseAtk=" + pet.BaslangicAtk.ToString("R")
                    + " percentLocal=" + percentLocal.ToString("R") + " health=" + enemy.unitData.health
                    + " targetMatches=" + (first != null && first.targetPosition == enemy.transform)
                    + " instance=" + first.GetInstanceID() + " queueBefore=" + firstCount + " queueAfter=" + queues[pet.ProjectileName].Count);
                Check(r, first != null && first.attackDamage == expected && first.targetPosition == enemy.transform,
                    "Actual PoolObject and Projectile receive current-health percentage plus10");
                Check(r, first != null && first.effectType == 2 && first.effectPower == 2f && first.effectSecond == 3f
                    && !first.anaKaraterVurdu, "Actual projectile receives pet effect and non-main-hero attribution");
                enemy.guildboss = true;
                Projectile second = queues[pet.ProjectileName].Peek();
                int secondCount = queues[pet.ProjectileName].Count;
                Call(pet, "ShootArrow", enemy);
                long inlineGuild = unchecked((long)((pet.BaslangicAtk + pet.Level * .1f) * 50000f / 100f)) + 10L;
                long expectedGuild = NativeBinary32Damage(pet, 50000L);
                long expectedGuildLocal = unchecked((long)(percentLocal * 50000f / 100f)) + 10L;
                r.observations.Add("Guild shot actual=" + (second == null ? "missing" : second.attackDamage.ToString())
                    + " inlineExpected=" + inlineGuild + " percentLocalExpected=" + expectedGuildLocal
                    + " ARM64Binary32Expected=" + NativeBinary32Damage(pet, 50000L)
                    + " targetMatches=" + (second != null && second.targetPosition == enemy.transform)
                    + " instance=" + second.GetInstanceID() + " queueBefore=" + secondCount + " queueAfter=" + queues[pet.ProjectileName].Count);
                Check(r, second != null && second.attackDamage == expectedGuild,
                    "Actual guildboss path uses fixed50000 rather than current health");
                r.observations.Add("Attack fields tested on real inactive Unity objects using actual PoolObject.SpawnProjectile and Projectile.Launch; no mocked project services.");
                r.limitations.Add("Edit-mode fixture does not advance scene frames, play attack animations, schedule coroutines, or test physics collision/effect application. It reads the original clip's actual animation events.");
                r.limitations.Add("Animator.Play and ParticleSystem.Play on inactive fixture objects may issue Unity warnings; this fixture asserts data/service behavior, not rendered animation.");
                r.limitations.Add("ES3 calls use the rebuild's actual OfflineKeyStore JSON backend, not the original commercial ES3 encrypted format. No user save is modified.");
            }
            catch (Exception ex) { r.failures.Add(ex.ToString()); }
            finally
            {
                UnityEngine.Object.DestroyImmediate(root);
                foreach (var f in statics) f.Key.SetValue(null, f.Value);
                SoundManager.instance = oldSound; UnityEngine.Random.state = oldRandom;
                OfflineKeyStore.SetVerificationRoot(oldRoot);
            }
            r.passed = r.failures.Count == 0;
            File.WriteAllText(Path.Combine(r.testRoot, "pet-editor-results.json"), JsonUtility.ToJson(r, true));
            Debug.Log("PetLifecycleVerification checks=" + r.checks + " passed=" + r.passed + " root=" + r.testRoot);
            return r;
        }
    }
}
