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
    // Run in a non-playing editor/batch process. Files stay in the supplied or temporary test directory.
    // Calls the actual recovered game classes and actual ES3 adapter, without substituting services.
    public static class TalentLifecycleVerification
    {
        [Serializable] public sealed class Result
        {
            public bool passed;
            public int checks;
            public string testRoot;
            public string saveFile;
            public List<string> failures = new List<string>();
        }

        static void Check(Result r, bool ok, string label) { r.checks++; if (!ok) r.failures.Add(label); }
        static void Call(object obj, string method) { obj.GetType().GetMethod(method, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).Invoke(obj, null); }
        static GameObject Child(Transform parent, string name)
        {
            var obj = new GameObject(name, typeof(RectTransform));
            obj.SetActive(false);
            obj.transform.SetParent(parent, false);
            return obj;
        }
        static T Add<T>(Transform parent, string name) where T : Component { return Child(parent, name).AddComponent<T>(); }
        static void FillUi(MonoBehaviour component)
        {
            foreach (var field in component.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                if (field.FieldType == typeof(GameObject)) field.SetValue(component, Child(component.transform, field.Name));
                else if (field.FieldType == typeof(TextMeshProUGUI)) field.SetValue(component, Add<TextMeshProUGUI>(component.transform, field.Name));
                else if (field.FieldType == typeof(Image)) field.SetValue(component, Add<Image>(component.transform, field.Name));
                else if (field.FieldType == typeof(Button)) field.SetValue(component, Add<Button>(component.transform, field.Name));
                else if (field.FieldType == typeof(Slider)) field.SetValue(component, Add<Slider>(component.transform, field.Name));
                else if (field.FieldType == typeof(RectTransform)) field.SetValue(component, (RectTransform)Child(component.transform, field.Name).transform);
            }
        }
        static TalentManager Fixture(Transform parent)
        {
            var owner = Add<TalentManager>(parent, "TalentManager");
            var ui = Add<TalentsUiManager>(parent, "TalentsUiManager");
            var finder = Add<TalentFinder>(parent, "TalentFinder");
            FillUi(ui);
            owner.talentsUiManager = ui;
            owner.rarityColorspublic = new[] { new Color32(10,20,30,255), new Color32(40,50,60,255), new Color32(70,80,90,255), new Color32(100,110,120,255) };
            ui.talentManager = owner; ui.talentFinder = finder;
            finder.talentManager = owner; finder.talentsUiManager = ui;
            ui.talentIcons = new Sprite[22];
            ui.RarityColorCode = new[] { "#0A141E", "#28323C", "#46505A", "#646E78" };
            ui.summonx = new[] { Add<TextMeshProUGUI>(ui.transform,"summon1"), Add<TextMeshProUGUI>(ui.transform,"summon10") };
            ui.summonprice = new[] { Add<TextMeshProUGUI>(ui.transform,"price1"), Add<TextMeshProUGUI>(ui.transform,"price10") };
            ui.summonbtns = new[] { Add<Button>(ui.transform,"summonButton1"), Add<Button>(ui.transform,"summonButton10") };
            ui._talentUis = new TalentTekliUi[22];
            for (int i = 0; i < 22; i++)
            {
                var row = Add<TalentTekliUi>(ui.transform, "Talent" + i); FillUi(row);
                row.talentsUiManager = ui; row.talentNum = i; ui._talentUis[i] = row;
            }
            ui.choosenTalentUis = new ChosenTalentUi[7];
            for (int i = 0; i < 7; i++)
            {
                var slot = Add<ChosenTalentUi>(ui.transform, "Chosen" + i); FillUi(slot);
                slot.talentsUiManager = ui; slot.mynum = i; ui.choosenTalentUis[i] = slot;
                if (i > 0) ui.choosenTalentUis[i - 1].bendensonraki = slot;
            }
            return owner;
        }
        static void FlushAndReload()
        {
            var disk = new ES3Settings("medupac.es3", ES3.Location.File);
            ES3.StoreCachedFile("medupac.es3", disk);
            OfflineKeyStore.ResetMemoryForVerification();
            ES3.CacheFile("medupac.es3", disk);
        }

        public static Result RunChecks(string suppliedRoot = null)
        {
            var r = new Result { testRoot = Path.GetFullPath(suppliedRoot ?? Path.Combine(Path.GetTempPath(), "LuckyForgeTalentChecks", Guid.NewGuid().ToString("N"))) };
            if (EditorApplication.isPlayingOrWillChangePlaymode)
            {
                r.failures.Add("RunChecks requires a non-playing editor; active gameplay/cache is not touched.");
                return r;
            }
            Directory.CreateDirectory(r.testRoot);
            var originalFlags = TalentManager.Kullaniliyor;
            var originalColors = TalentManager.RarityColors;
            var originalStats = PlayerData.TalentStats;
            var originalLanguage = GameManager.Language;
            var originalNewUser = GameManager.NewUserTapNation;
            var originalLang = Lang.currentLang;
            var originalSound = SoundManager.instance;
            int originalChestLevel = TalentFinder.CurrentLevel, originalChestExp = TalentFinder.CurrentExp;
            var originalCurrencies = new Dictionary<FieldInfo, object>();
            foreach (var field in typeof(Currencys).GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                if (!field.IsLiteral && !field.IsInitOnly) originalCurrencies[field] = field.GetValue(null);
            var root = new GameObject("TalentLifecycleVerification"); root.SetActive(false);
            OfflineKeyStore.SetVerificationRoot(r.testRoot);
            try
            {
                TalentManager.Kullaniliyor = new bool[40]; PlayerData.TalentStats = new PlayerData.TalentData();
                GameManager.Language = 0; GameManager.NewUserTapNation = true; SoundManager.instance = null;
                TalentFinder.CurrentLevel = 1; TalentFinder.CurrentExp = 1;
                var manager = Fixture(root.transform); var ui = manager.talentsUiManager;
                Call(manager, "Awake"); Call(manager, "Start");
                foreach (var slot in ui.choosenTalentUis) Call(slot, "Start");
                foreach (var row in ui._talentUis) Call(row, "Start");
                Check(r, manager.TalentsList.Count == 22 && manager.TalentsList[2].TargetStat == "BossDecreaseHealth", "actual native22 records initialized and bound");
                Check(r, ui.ChoosenlarAlinmis[0] && !ui.ChoosenlarAlinmis[1], "actual first free slot only");
                var talent = manager.TalentsList[2]; talent.AddExp();
                ui._talentUis[2].OneCikar();
                Check(r, TalentManager.Kullaniliyor[2] && ui.choosenTalentUis[0].choosenTalent == talent && PlayerData.TalentStats.BossDecreaseHealth == 3f, "actual OneCikar/Secildi equips and applies3 percent");
                Currencys.CoinFitle(15000.0); ui._talentUis[2].OneCikar();
                Check(r, ui._talentShowObj.activeSelf && ui._name.text == Lang.GetTalentName(2) && ui._talentSubtitle.text == Lang.Get.talent3subname, "equipped row actual details and original subtitle");
                Check(r, ui.Fiyat() == 15000.0 && !ui._upgBtn.interactable, "original level1 Common price15000 and exp gate");
                ui.UpgradeTalent();
                Check(r, talent.Level == 1 && Currencys.Coin == 15000.0, "insufficient exp cannot charge or upgrade");
                talent.AddExp(); talent.AddExp(); Currencys.CoinFitle(14999.0); ui.ShowTalent(talent);
                Check(r, ui.arrowonecikan.activeSelf && !ui._upgBtn.interactable, "exp arrow independent of unaffordable upgrade button");
                ui.UpgradeTalent();
                Check(r, talent.Level == 1 && Currencys.Coin == 14999.0, "one coin short cannot upgrade");
                Currencys.CoinFitle(15000.0); ui.UpgradeTalent();
                Check(r, talent.Level == 2 && talent.CurrentExp == 0 && Currencys.Coin == 0.0 && PlayerData.TalentStats.BossDecreaseHealth == 6f, "actual SpendCoin deducts15000 / consumes3exp / applies6 percent");
                Check(r, ES3.Load<string>("Coin") == "0" && ES3.Load<string>("DataCoin") == "0", "actual currency adapter saves public/mirror balance");
                Check(r, ui._simdikiveri.text == "6%" && ui._sonrakiveri.text == "9%" && ui._upgradePrice.text == "<sprite=0>" + ShortScaleString.parseDouble(30000), "actual detail text refresh and next price");
                var before = manager.TalentsList;
                FlushAndReload(); r.saveFile = OfflineKeyStore.PathFor();
                manager.TalentsList = new List<Talent>(); manager.LoadTalents();
                Check(r, File.Exists(r.saveFile) && !ReferenceEquals(before, manager.TalentsList) && !ReferenceEquals(talent, manager.TalentsList[2]), "List<Talent> persisted to isolated disk and deserialized into new instances");
                var loaded = manager.TalentsList[2];
                Check(r, manager.TalentsList.Count == 22 && loaded.Num == 2 && loaded.TargetStat == "BossDecreaseHealth" && loaded.Level == 2 && loaded.CurrentExp == 0 && loaded.EffectValue == 3f && loaded.BaseEffectValue == 0f && loaded.MaxLevel == 10 && loaded.Rarity == RarityTalent.Common, "actual ES3 List<Talent> restores every original field");
                TalentManager.Kullaniliyor = ES3.Load<bool[]>("KullanilanTalentlar");
                PlayerData.TalentStats = new PlayerData.TalentData(); manager.DatalariUilaraGir();
                ui.choosenTalentUis[0].choosenTalent = null; ui.LoadChoosenlar(); manager.ApplyTalents();
                Check(r, ui.choosenTalentUis[0].choosenTalent == loaded && TalentManager.Kullaniliyor[2] && PlayerData.TalentStats.BossDecreaseHealth == 6f, "disk restored selected talent reference and ApplyTalents6 percent");
                ui.choosenTalentUis[0].OnClickedthis();
                Check(r, !TalentManager.Kullaniliyor[2] && ui.choosenTalentUis[0].choosenTalent == null && PlayerData.TalentStats.BossDecreaseHealth == 0f && ui.choosenTalentUis[0].plusicon.activeSelf, "actual remove clears flag/effect/visuals");
                FlushAndReload();
                Check(r, !ES3.Load<bool[]>("KullanilanTalentlar")[2] && ES3.Load<List<Talent>>("PlayerTalentsX")[2].Level == 2, "removed choice persists while owned upgrade remains");
                var paid = ui.choosenTalentUis[1]; paid.kristalfiyat = 137; // Fixture-only arbitrary field proves no hidden fixed/free cost.
                Currencys.CrystalFitle(136); paid.OnClickedthis();
                Check(r, !ui.ChoosenlarAlinmis[1] && Currencys.Crystal == 136, "one crystal short cannot unlock paid slot");
                Currencys.CrystalFitle(137); paid.OnClickedthis();
                Check(r, ui.ChoosenlarAlinmis[1] && Currencys.Crystal == 0 && !paid.lockedicon.activeSelf && paid.openedicon.activeSelf && ui.choosenTalentUis[2].gameObject.activeSelf, "actual paid slot consumes serialized fixture cost and opens next slot");
                paid.OnClickedthis();
                Check(r, ui.ChoosenlarAlinmis[1] && Currencys.Crystal == 0, "empty owned slot not bought twice");
                FlushAndReload();
                Check(r, ES3.Load<bool[]>("choosentalentalinmisX")[1] && ES3.Load<int>("Crystal") == 0 && ES3.Load<int>("DataCrystal") == 0, "paid slot and crystal mirror survive real adapter disk roundtrip");
                ui.choosenTalentUis[0].Secildi(loaded); var gold = manager.TalentsList[0]; gold.AddExp(); ui._talentUis[0].OneCikar(); manager.SaveTalents();
                Check(r, paid.choosenTalent == gold && TalentManager.Kullaniliyor[0] && TalentManager.Kullaniliyor[2] && PlayerData.TalentStats.GoldIncome == 1.1f, "purchased second slot equips another owned talent and applies original effect");
                ui.choosenTalentUis[0].OnClickedthis();
                Check(r, !TalentManager.Kullaniliyor[2] && TalentManager.Kullaniliyor[0] && PlayerData.TalentStats.BossDecreaseHealth == 0f && PlayerData.TalentStats.GoldIncome == 1.1f, "unequipping one keeps other selected effect");
                FlushAndReload();
                Check(r, !ES3.Load<bool[]>("KullanilanTalentlar")[2] && ES3.Load<bool[]>("KullanilanTalentlar")[0] && ES3.Load<List<Talent>>("PlayerTalentsX")[0].Level == 1, "final owned/upgraded/equipped state survives third disk reload");
            }
            catch (Exception ex) { r.failures.Add(ex.ToString()); }
            finally
            {
                TalentManager.Kullaniliyor = originalFlags; TalentManager.RarityColors = originalColors; PlayerData.TalentStats = originalStats;
                GameManager.Language = originalLanguage; GameManager.NewUserTapNation = originalNewUser; Lang.currentLang = originalLang; SoundManager.instance = originalSound;
                TalentFinder.CurrentLevel = originalChestLevel; TalentFinder.CurrentExp = originalChestExp;
                foreach (var entry in originalCurrencies) entry.Key.SetValue(null, entry.Value);
                OfflineKeyStore.SetVerificationRoot(null); UnityEngine.Object.DestroyImmediate(root);
            }
            r.passed = r.failures.Count == 0;
            File.WriteAllText(Path.Combine(r.testRoot, "talent-lifecycle-results.json"), JsonUtility.ToJson(r, true));
            Debug.Log("Actual Unity/ES3 talent lifecycle: " + r.checks + " checks, " + r.failures.Count + " failures; " + r.testRoot);
            return r;
        }
        public static void RunBatch() { EditorApplication.Exit(RunChecks().passed ? 0 : 1); }
    }
}
