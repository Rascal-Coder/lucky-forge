using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Recovered local startup from IL2CPP RVAs in startup/method-index.json.
// UI null guards and omission of SDK/audio callbacks are offline integration choices.
// Online entitlements are not granted and server services are not emulated.
public class LoadingPage : MonoBehaviour
{
    private string saveFile = "medupac.es3"; // .ctor RVA0x20070a0
    public TextMeshProUGUI _text;
    public TextMeshProUGUI _version;
    private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    private const string Numbers = "0123456789";
    private const string LettersAndNumbers = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    public static string GenerateRandomString(int length, bool includeNumbers = true)
    {
        // Original alphabet and length contract; random-provider implementation is local.
        string alphabet = includeNumbers ? LettersAndNumbers : Letters;
        char[] result = new char[length];
        for (int i = 0; i < result.Length; i++) result[i] = alphabet[UnityEngine.Random.Range(0, alphabet.Length)];
        return new string(result);
    }
    private void Awake()
    {
        MigrateOldSaveToCache();
        Screen.fullScreen = true;
    }
    private void MigrateOldSaveToCache()
    {
        // RVA0x2005124. Functional ES3 adapter supplies cache lifecycle semantics.
        var settings = new ES3Settings(saveFile, ES3.Location.File);
        if (ES3.FileExists(saveFile, settings)) ES3.CacheFile(saveFile, settings);
    }
    private IEnumerator Start()
    {
        // LoadingPage.<Start>d__7.MoveNext RVA0x20070fc.
        // All waits in this routine are fixed; no Firebase/PlayFab/login wait was observed.
        OfflineRuntimeProbe.RecordStartupCheckpoint("Loading.Start");
        yield return new WaitForSeconds(0.1f);
        GameManager.UserUniqueid = string.Empty;
        if (_text != null) _text.text = "Loading";
        if (_version != null) _version.text = "Lucky Forge v" + Application.version;
        yield return new WaitForSeconds(0.4f);
        if (!ES3.KeyExists("ilkgiris")) SetData();
        if (_text != null) _text.text = "Loading.";
        GameManager.tabletor1920 = IsTablet((float)Screen.width / Screen.height);
        if (!ES3.KeyExists("useronlineid"))
        {
            GameManager.UserOnlineUniqueid = GenerateRandomString(25, true);
            ES3.Save<string>("useronlineid", GameManager.UserOnlineUniqueid);
        }
        yield return new WaitForSeconds(0.4f);
        if (_text != null) _text.text = "Loading..";
        OfflineRuntimeProbe.RecordStartupCheckpoint("GetData.begin");
        GetData();
        OfflineRuntimeProbe.RecordStartupCheckpoint("GetData.end");
        GameManager.loadingfirst = true;
        GameManager.suankisurum = Application.version;
        yield return new WaitForSeconds(1f);
        if (_text != null) _text.text = "Loading.";
        yield return new WaitForSeconds(0.3f);
        if (_text != null) _text.text = "Loading";
        yield return new WaitForSeconds(1.5f);
        if (_text != null) _text.text = "Loading.";
        OfflineRuntimeProbe.RecordStartupCheckpoint("LoadAsync.begin");
        SceneManager.LoadSceneAsync("Sahne");
        OfflineRuntimeProbe.RecordStartupCheckpoint("LoadAsync.issued"); // original direct call RVA0x2007374
    }
    private void Update() { } // Original method is a native ret.
    private void SetData()
    {
        Diller();
        // Native save call 0x2005574
        ES3.Save<int>("ilkgiris", 1);
        // Native save call 0x20055a4
        ES3.Save<string>("Coin", "5");
        // Native save call 0x20055c4
        ES3.Save<string>("DataCoin", "10");
        // Native save call 0x2005614
        ES3.Save<int>("CurrentCommanderNum", 0);
        // Native save call 0x200562c
        ES3.Save<int>("Feedlendi", 0);
        // Native save call 0x2005644
        ES3.Save<int>("ilkcloudbilgisi", 0);
        // Native save call 0x20057b4
        ES3.Save<int>("GunlukHediyeDays", 0);
        // Native save call 0x2005864
        ES3.Save<int>("Promosyon", -1);
        // Native save call 0x200587c
        ES3.Save<int>("Bekleme_PromosyonMinDeger", 9);
        // Native save call 0x2005894
        ES3.Save<int>("PromosyonLastOdulint", 1);
        // Native save call 0x20058ac
        ES3.Save<int>("EarnerLastOdulint", 1);
        // Native save call 0x20058c4
        ES3.Save<float>("EarnBoosted", 1.0f);
        // Native save call 0x20058dc
        ES3.Save<float>("CookieKazanc", 0.0f);
        // Native save call 0x20058f4
        ES3.Save<int>("GorevSirasi", 0);
        // Native save call 0x200590c
        ES3.Save<int>("ToplananKristalSayisi", 0);
        // Native save call 0x2005924
        ES3.Save<int>("YapilanPromosyonSayisi", 0);
        // Native save call 0x200593c
        ES3.Save<int>("AcilmisToplamKutu", 0);
        // Native save call 0x2005954
        ES3.Save<int>("BankadaBirikenCrystal", 0);
        // Native save call 0x2005974
        ES3.Save<string>("OynadigiTumZamanSaniyesi", "1");
        // Native save call 0x200598c
        ES3.Save<int>("normalchestreklamhakki", 3);
        // Native save call 0x20059a4
        ES3.Save<int>("BulundugumBolum", 1);
        // Native save call 0x20059bc
        ES3.Save<bool>("GuideDone", false);
        // Native save call 0x20059d4
        ES3.Save<bool>("EfektOnOf", false);
        // Native save call 0x20059ec
        ES3.Save<bool>("TitresimOnOf", false);
        // Native save call 0x2005a04
        ES3.Save<bool>("MuzikOnOf", false);
        // Native save call 0x2005a1c
        ES3.Save<bool>("SetUserConsent", true);
        // Native save call 0x2005a34
        ES3.Save<bool>("NewUserTPNation", true);
        // Dynamic-key and clock expressions manually traced in RVA0x20055c8..0x200584c.
        ES3.Save<int>("CommanderHeroLv0", 1);
        ES3.Save<string>("ChestTimer", DateTime.UtcNow.ToString());
        ES3.Save<string>("EarnTimerPUS", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
        ES3.Save<string>("Bekleme_PromosyonTimerPus", DateTime.UtcNow.ToString());
        ES3.Save<string>("PromosyonTimer", DateTime.UtcNow.ToString());
        ES3.Save<string>("OneTimeOfferSaat", DateTime.UtcNow.ToString());
        ES3.Save<DateTime>("NewlastOfflineTime", DateTime.Now);
        ES3.Save<string>("GunlukLastRewardDate", DateTime.UtcNow.AddHours(-25).ToString());
        ES3.Save<long>("OrderCountdownStartTime", DateTime.UtcNow.AddMinutes(-10).Ticks);
    }
    private void GetData()
    {
        // Only verified key->native static-offset assignments are restored below.
        // Missing-key branches leave existing static initializers intact.
        // Load 0x20060b4 -> static store 0x2006104
        GameManager.Level = ES3.Load<int>("Seviye", 0);
        // Load 0x2006108 -> static store 0x2006120
        GameManager.EliteLevel = ES3.Load<int>("EliteLevel", 0);
        // Load 0x2006128 -> static store 0x2006140
        GameManager.LevelExp = ES3.Load<int>("SeviyeDeneyimPuani", 0);
        // Load 0x2006148 -> static store 0x2006188
        GunlukGorevler.KacinciGun = ES3.Load<int>("GorevKacinciGun", 1);
        // Load 0x200618c -> static store 0x20061ac
        GameManager.GorevTaskTamamlanan = ES3.Load<int>("GorevTaskTamamlanan", 0);
        // Load 0x20061b4 -> static store 0x20061d4
        GameManager.TimeScale = ES3.Load<float>("TimeScale", 1.0f);
        // Load 0x20061d8 -> static store 0x20061f0
        GameManager.NewUserTapNation = ES3.Load<bool>("NewUserTPNation", false);
        // Load 0x200620c -> static store 0x2006234
        if (ES3.KeyExists("DungeonLevels")) GameManager.DungeonLevels = ES3.Load<int[]>("DungeonLevels");
        // Load 0x2006278 -> static store 0x2006294
        GunlukWars.dailyWars = ES3.Load<int>("DailyWars", 0);
        // Load 0x20062a0 -> static store 0x20062e0
        GameManager.inapp_Boost_satisGelirX = ES3.Load<int>("inappBoostsatisGelirX", 1);
        // Load 0x20062e4 -> static store 0x2006300
        GameManager.inapp_Boost_talent2x = ES3.Load<int>("inappBoosttalent2x", 1);
        // Load 0x200630c -> static store 0x2006324
        GameManager.UnlockedTimeScale = ES3.Load<float>("UnlockedTimeScale", 2.0f);
        // Load 0x2006328 -> static store 0x2006340
        GameManager.DailyCrystalIncomeTotal = ES3.Load<int>("DailyCrystalIncomeTotal", 0);
        // Load 0x2006348 -> static store 0x2006360
        GameManager.DailyTalentIncomeTotal = ES3.Load<int>("DailyTalentIncomeTotal", 0);
        // Load 0x2006368 -> static store 0x200638c
        GameManager.SilverCoinIncomePurchased = ES3.Load<int>("SilverCoinIncomePurchased", 0);
        // Load 0x2006398 -> static store 0x20063bc
        GameManager.ArmyUnitsHits2X = ES3.Load<bool>("ArmyUnitsHits2X", false);
        // Load 0x20063c0 -> static store 0x20063dc
        GameManager.BestSurvive = ES3.Load<int>("BestSurvive", 0);
        // Load 0x20063e8 -> static store 0x2006404
        GameManager.BestSurviveElites = ES3.Load<int>("BestSurviveElites", 0);
        // Load 0x2006410 -> static store 0x200642c
        GameManager.ResearchSpeedUp = ES3.Load<int>("ResearchSpeedUp", 1);
        // Load 0x2006438 -> static store 0x2006454
        GameManager.KazancBooster = ES3.Load<float>("EarnBoosted", 1.0f);
        // Load 0x2006464 -> static store 0x2006484
        GameManager.CookieKazanc = ES3.Load<float>("CookieKazanc", 0.0f);
        // Load 0x2006488 -> static store 0x20064ac
        GameManager.PremiumPassMevcut = ES3.Load<bool>("PremiumPassMevcut", false);
        // Load 0x20064b0 -> static store 0x20064cc
        PassGame.GamePassSavedCycle = ES3.Load<int>("GamePassSavedCycleX", 0);
        // Load 0x20064d8 -> static store 0x20064f4
        PassGame.Level = ES3.Load<int>("PassLevel", 1);
        // Load 0x2006500 -> static store 0x200651c
        PassGame.Exp = ES3.Load<int>("PassExp", 0);
        // Load 0x2006528 -> static store 0x2006544
        GameManager.MaxGearSize = ES3.Load<int>("MaxGearSize", 1000);
        // Load 0x2006550 -> static store 0x200656c
        GameManager.NoAdsGameSpeed = ES3.Load<int>("NoAdsGameSpeed", 0);
        // Load 0x2006578 -> static store 0x20065d0
        TalentFinder.CurrentLevel = ES3.Load<int>("TalentChestLevel", 0);
        // Load 0x20065d4 -> static store 0x20065e8
        TalentFinder.CurrentExp = ES3.Load<int>("TalentChestCurrentExp", 0);
        // Load 0x2006608 -> static store 0x2006638
        if (ES3.KeyExists("totalPlayTimeMinutes")) AnalyticsTimeEvent.totalMinutes = ES3.Load<int>("totalPlayTimeMinutes");
        // Load 0x2006640 -> static store 0x2006678
        FindNewWeapons.CurrentLevel = ES3.Load<int>("WeaponChestLevel", 0);
        // Load 0x200667c -> static store 0x2006694
        FindNewWeapons.CurrentExp = ES3.Load<int>("WeaponChestCurrentExp", 0);
        // Load 0x200669c -> static store 0x20066ec
        ShopUi.coinParaReklamHakki = ES3.Load<int>("coinParaReklamHakki", 3);
        // Load 0x20066f0 -> static store 0x200673c
        GameManager.ViPGunlukDungeonKeyArtisi = ES3.Load<int>("ViPGunlukDungeonKeyArtisi", 0);
        // Load 0x2006744 -> static store 0x2006760
        GameManager.ViPSinirsizidle = ES3.Load<bool>("ViPSinirsizidle", false);
        // Load 0x2006764 -> static store 0x2006778
        RateEnabler.NeZamanSorayim = ES3.Load<int>("NeZamanSorayimRate", 0);
        // Load 0x20067cc -> static store 0x20067e8
        MenuGeneralSettings.CloseTextObjects = ES3.Load<bool>("CloseTextObjects", false);
        // Load 0x2006830 -> static store 0x2006858
        if (ES3.KeyExists("BilgiBulundu")) YeniButonAcildi.bulundu = ES3.Load<int[]>("BilgiBulundu");
        // Load 0x2006888 -> static store 0x20068b0
        if (ES3.KeyExists("useronlineid")) GameManager.UserOnlineUniqueid = ES3.Load<string>("useronlineid");
        // Load 0x20068d8 -> static store 0x20068fc
        if (ES3.KeyExists("Language")) GameManager.Language = ES3.Load<int>("Language");
        // Load 0x200694c -> static store 0x2006984
        GameManager.offlinepackkazanc = ES3.Load<float>("offlinepackkazanc", 1.0f);
        // Load 0x200698c -> static store 0x20069ac
        GameManager.offlinepacksaat = ES3.Load<float>("offlinepacksaat", 0.0f);
        // Load 0x20069b0 -> static store 0x20069cc
        GameManager.GuideDone = ES3.Load<bool>("GuideDone", false);
        // Load 0x20069f4 -> static store 0x2006a0c
        GameManager.BankadaBirikenCrystal = ES3.Load<int>("BankadaBirikenCrystal", 0);
        // Load 0x2006a14 -> static store 0x2006a2c
        GameManager.BulunduguBolum = ES3.Load<int>("BulundugumBolum", 0);
        // Load 0x2006a34 -> static store 0x2006a58
        GameManager.NameSettedOnCBS = ES3.Load<bool>("NameSettedOnCBS", false);
        // Load 0x2006a5c -> static store 0x2006a80
        MenuGeneralSettings.EfektOnOf = ES3.Load<bool>("EfektOnOf", false);
        // Load 0x2006a84 -> static store 0x2006aa8
        MenuGeneralSettings.TitresimOnOf = ES3.Load<bool>("TitresimOnOf", false);
        // Load 0x2006aac -> static store 0x2006ad0
        MenuGeneralSettings.MuzikOnOf = ES3.Load<bool>("MuzikOnOf", false);
        // Load 0x2006ad4 -> static store 0x2006af8
        MenuGeneralSettings.BildirimOnOf = ES3.Load<bool>("BildirimOnOf", false);
        // Load 0x2006afc -> static store 0x2006b0c
        MenuGeneralSettings.Optimization = ES3.Load<bool>("Optimization", false);
        // Load 0x2006b28 -> static store 0x2006b40
        GameManager.Rated = ES3.Load<int>("Feedlendi", 0);
        if (!ES3.KeyExists("totalPlayTimeMinutes")) AnalyticsTimeEvent.totalMinutes = 0;
        GameManager.agegectim = false;
        MenuGeneralSettings.Cloudacilmistir = ES3.KeyExists("Cloudacilmis");
        ES3.Save<int>("AppSessionCount", ES3.Load<int>("AppSessionCount", 0) + 1);
        if (!ES3.KeyExists("OneTimeOfferSaat")) ES3.Save<string>("OneTimeOfferSaat", DateTime.UtcNow.ToString());
        // These original currency entry points are restored by the same patch set.
        Currencys.LoadStartChestEquipment(); Currencys.LoadStartChestHeros(); Currencys.LoadStartChestMixed();
        Currencys.LoadStartCoin(); Currencys.LoadStartCrystal(); Currencys.LoadStartEnergy();
        Currencys.LoadStartTalentScrolle(); Currencys.LoadStartHeroStone(); Currencys.LoadStartDungeonKeys();
        Currencys.LoadStartWeaponToken(); Currencys.LoadStartGearScroll(); Currencys.LoadStartMistikToken();
        Currencys.LoadStartWallToken(); Currencys.LoadStartPetFood(); Currencys.LoadStartEventDice(); Currencys.LoadStartEventToken();
        Events();
        // Original NoAds migration only creates a speed-hours key; it does not grant purchase state.
        if (ES3.KeyExists("NoAds") && !ES3.KeyExists("AlinanExtraSpeedHour")) ES3.Save<int>("AlinanExtraSpeedHour", 10001);
    }
    private void Fixers() { } // Original native ret.
    private void Events()
    {
        // Partial: weekly reset/date parsing expressions require a separate restoration.
        // Verified scalar event assignments only; no new rewards are fabricated.
        MerdivenEventManager.MerdivenMateryali = ES3.Load<int>("MerdivenMateryali", 0); // 0x2006ef0
        MerdivenEventManager.MerdivenSeviyesi = ES3.Load<int>("MerdivenSeviyesi", 0); // 0x2006f10
        MerdivenEventManager.upgsayisi = ES3.Load<int>("MedivenEventExpSayisi", 0); // 0x2006f30
        MerdivenEventManager.OdulKacaKadarToplandi = ES3.Load<int>("MerdivenEventKacta", 0); // 0x2006f50
        MerdivenEventManager.MerdivenEventTamamlandi = ES3.Load<int>("MerdivenEventTamamlandi", 0); // 0x2006f6c

        // Original hourly timestamp dependency 0x2006f70..0x200703c; weekly data unchanged.
        if(ES3.KeyExists("saatlikOdulReset")){
            DateTime parsedHourly;
            if(!DateTime.TryParse(ES3.Load<string>("saatlikOdulReset",defaultValue:string.Empty),null,System.Globalization.DateTimeStyles.RoundtripKind,out parsedHourly))parsedHourly=DateTime.UtcNow;
            SaatlikHediye.lastLoginTime=parsedHourly;
        }else{
            ES3.Save<string>("saatlikOdulReset",DateTime.UtcNow.ToString());
            SaatlikHediye.lastLoginTime=DateTime.UtcNow;
        }
        SaatlikHediye.totalSecondsSpentInGame = ES3.Load<float>("saatlikOdulSaniyeToplam", 0.0f); // 0x2007074
    }
    private void Diller()
    {
        // Exact native SystemLanguage integer comparisons, RVA0x2005a58.
        int language;
        switch ((int)Application.systemLanguage)
        {
            case 34: language = 2; break;
            case 28: language = 3; break;
            case 22: language = 4; break;
            case 15: language = 5; break;
            case 30: language = 6; break;
            default: language = 0; break;
        }
        GameManager.Language = language; ES3.Save<int>("Language", language);
    }
    private bool IsTablet(float aspectRatio) { return aspectRatio > 0.55f; }
}
