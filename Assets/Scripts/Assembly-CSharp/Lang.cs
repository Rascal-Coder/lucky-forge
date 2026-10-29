public abstract class Lang
{
	public static Lang currentLang;

	public static int YuzdeSkillHero;

	public static int YuzdeSkillWall;

	public static int YuzdeSkillPet;

	public static long WeaponSkillHasar;

	public static int HeroSkillBonusDamage;

	public static int Ozel_GorevUpgradeDeger;

	public static string Ozel_Gorevisim;

	public static int Ozel_GorevNum;

	public static string[] dataDiamondUpgradeStat;

	public static int GorevGelistir;

	public static int TaskKacLazim;

	public static float RuneKacArtiyor;

	public static float AccecoryKacArtiyor;

	public static Lang Get
    {
        get
        {
            // Native RVA0x223a85c, GameManager.Language static offset0x24.
            // Native constructs a new instance on every call except Language7/8.
            switch (GameManager.Language)
            {
                case 1: currentLang = new LangKR(); break;
                case 2: currentLang = new LangES(); break;
                case 3: currentLang = new LangPR(); break;
                case 4: currentLang = new LangJP(); break;
                case 5: currentLang = new LangGR(); break;
                case 6: currentLang = new LangRU(); break;
                case 7:
                case 8: break;
                default: currentLang = new LangEN(); break;
            }
            return currentLang;
        }
    }

	public abstract string Menutitle { get; }

	public abstract string Menusubtitle { get; }

	public abstract string ayarlarbulut { get; }

	public abstract string muzik { get; }

	public abstract string sesler { get; }

	public abstract string bildirim { get; }

	public abstract string bulutakaydet { get; }

	public abstract string diller { get; }

	public abstract string yardimiletisim { get; }

	public abstract string destek { get; }

	public abstract string privacy { get; }

	public abstract string rateus { get; }

	public abstract string website { get; }

	public abstract string instagram { get; }

	public abstract string youtube { get; }

	public abstract string rateustitle { get; }

	public abstract string rateusbtntext { get; }

	public abstract string loading { get; }

	public abstract string moving { get; }

	public abstract string yeni { get; }

	public abstract string onayla { get; }

	public abstract string Permanenttitle { get; }

	public abstract string bankafull { get; }

	public abstract string open { get; }

	public abstract string upgradetitle { get; }

	public abstract string banka { get; }

	public abstract string hizligelistirme { get; }

	public abstract string gelistir { get; }

	public abstract string profit { get; }

	public abstract string seviye { get; }

	public abstract string itemsec { get; }

	public abstract string itemsecildi { get; }

	public abstract string Bonuslar { get; }

	public abstract string allprofit { get; }

	public abstract string Ekstraozellikler { get; }

	public abstract string none { get; }

	public abstract string giyiliyor { get; }

	public abstract string kalite_common { get; }

	public abstract string kalite_rare { get; }

	public abstract string kalite_epic { get; }

	public abstract string kalite_legendery { get; }

	public abstract string verititle { get; }

	public abstract string verisubtitle { get; }

	public abstract string verisubtitle2 { get; }

	public abstract string veriyiindir { get; }

	public abstract string verigunceltitle { get; }

	public abstract string veriguncelsubtitle { get; }

	public abstract string inappthanks { get; }

	public abstract string inappkutular { get; }

	public abstract string inappnoads { get; }

	public abstract string inappreklamlarisil { get; }

	public abstract string inappreklamsubtitle { get; }

	public abstract string dakikam { get; }

	public abstract string dakikaminute { get; }

	public abstract string inappkristaltitle { get; }

	public abstract string offlinetitle { get; }

	public abstract string offlinesubtitle { get; }

	public abstract string saats { get; }

	public abstract string saatsaat { get; }

	public abstract string reklamkristaltext { get; }

	public abstract string reklamizle { get; }

	public abstract string agegectimsubtitle { get; }

	public abstract string kaynakyoktitle { get; }

	public abstract string kaynakyokbtn { get; }

	public abstract string saatlikkazanc { get; }

	public abstract string sec { get; }

	public abstract string beklenenkazanc { get; }

	public abstract string guncellemetitle { get; }

	public abstract string guncellemesubtitle { get; }

	public abstract string onetimeofferadstitle { get; }

	public abstract string onetimeofferadssubtitle { get; }

	public abstract string onetimeofferads24 { get; }

	public abstract string bitti { get; }

	public abstract string eldeet { get; }

	public abstract string kullan { get; }

	public abstract string birak { get; }

	public abstract string kullaniliyor { get; }

	public abstract string dakika10 { get; }

	public abstract string kisaltmasaat { get; }

	public abstract string kisaltmasaniye { get; }

	public abstract string kisaltmadakika { get; }

	public abstract string oduller { get; }

	public abstract string baslat { get; }

	public abstract string satinal { get; }

	public abstract string Gec { get; }

	public abstract string kurek { get; }

	public abstract string reklam_noads { get; }

	public abstract string kristal { get; }

	public abstract string hayirtesekkurler { get; }

	public abstract string teklif { get; }

	public abstract string market { get; }

	public abstract string ilerlemedurumu { get; }

	public abstract string topla { get; }

	public abstract string iptal { get; }

	public abstract string kabulet { get; }

	public abstract string teklifal { get; }

	public abstract string _titlehead { get; }

	public abstract string _vippakettitle { get; }

	public abstract string _noadssubtitle { get; }

	public abstract string satinalindi { get; }

	public abstract string _elmaskasasititle { get; }

	public abstract string _elmaskasasisubtitle { get; }

	public abstract string _elmaskasasibottomsubtitle { get; }

	public abstract string izle { get; }

	public abstract string al { get; }

	public abstract string GELiSTiR { get; }

	public abstract string suresi { get; }

	public abstract string gelir { get; }

	public abstract string evrim { get; }

	public abstract string yeniurun { get; }

	public abstract string kur { get; }

	public abstract string lv { get; }

	public abstract string bolgesi { get; }

	public abstract string kazanc { get; }

	public abstract string gunlukoduller { get; }

	public abstract string gun { get; }

	public abstract string KULLANBUYUK { get; }

	public abstract string Ozellik { get; }

	public abstract string levelup { get; }

	public abstract string kaynakyokmini { get; }

	public abstract string oyunukapatma { get; }

	public abstract string starterpacktitle { get; }

	public abstract string git { get; }

	public abstract string onetimeoffer { get; }

	public abstract string onetimeoffersub { get; }

	public abstract string endsin { get; }

	public abstract string startsin { get; }

	public abstract string kisaltmagun { get; }

	public abstract string bonus_2xtitle { get; }

	public abstract string bonus_2xsubtitle { get; }

	public abstract string _onlinetitle { get; }

	public abstract string _daily_subtitle { get; }

	public abstract string merdiventitle { get; }

	public abstract string _kaynakyokrozet { get; }

	public abstract string free { get; }

	public abstract string _varsaHeroinfo { get; }

	public abstract string _odulalindi { get; }

	public abstract string merdiven_kaynakyok1 { get; }

	public abstract string merdiven_kaynakyok2 { get; }

	public abstract string merdiven_kaynakyok3 { get; }

	public abstract string join { get; }

	public abstract string joined { get; }

	public abstract string _vipkalici { get; }

	public abstract string unlimited { get; }

	public abstract string total { get; }

	public abstract string reputation { get; }

	public abstract string isimbelirle { get; }

	public abstract string tamamdir { get; }

	public abstract string _kapat { get; }

	public abstract string ready { get; }

	public abstract string _Getdouble { get; }

	public abstract string reklamtakviyesi { get; }

	public abstract string _x2subtitle { get; }

	public abstract string _maksimum12saat { get; }

	public abstract string _taviye2x { get; }

	public abstract string income { get; }

	public abstract string gelistirmeyedevamet { get; }

	public abstract string extracashsub { get; }

	public abstract string yatirimal { get; }

	public abstract string skillpuanikazanildi { get; }

	public abstract string yenigorevtamamlandi { get; }

	public abstract string seviyeatlandi { get; }

	public abstract string rare { get; }

	public abstract string epic { get; }

	public abstract string legend { get; }

	public abstract string odulal { get; }

	public abstract string skilltreetitle { get; }

	public abstract string skilltreesub { get; }

	public abstract string skilltreealready { get; }

	public abstract string skilltreesiradan { get; }

	public abstract string skillpoint { get; }

	public abstract string kalite { get; }

	public abstract string tapdamage { get; }

	public abstract string kapasite { get; }

	public abstract string levelreq { get; }

	public abstract string kazanckucuk { get; }

	public abstract string done { get; }

	public abstract string power { get; }

	public abstract string tiklamagucu { get; }

	public abstract string guncelakapasite { get; }

	public abstract string profitbonus { get; }

	public abstract string uretimgucu { get; }

	public abstract string kapasitebuyuk { get; }

	public abstract string waiting { get; }

	public abstract string instant { get; }

	public abstract string hizi { get; }

	public abstract string suresikucuk { get; }

	public abstract string sandikbuyuk { get; }

	public abstract string resetin { get; }

	public abstract string reward { get; }

	public abstract string LevelUp { get; }

	public abstract string SkillExp { get; }

	public abstract string Crystal { get; }

	public abstract string chest { get; }

	public abstract string adet { get; }

	public abstract string resetsoon { get; }

	public abstract string quality { get; }

	public abstract string low { get; }

	public abstract string high { get; }

	public abstract string extrareward { get; }

	public abstract string task { get; }

	public abstract string maden { get; }

	public abstract string saniyeuzun { get; }

	public abstract string info { get; }

	public abstract string slot { get; }

	public abstract string taptocontinue { get; }

	public abstract string Dungeon { get; }

	public abstract string Collected { get; }

	public abstract string pit { get; }

	public abstract string dungeonkey { get; }

	public abstract string refilldungeonkey { get; }

	public abstract string x2xtapdamage { get; }

	public abstract string merdivencollect { get; }

	public abstract string _noadspermanent { get; }

	public abstract string yukaridon { get; }

	public abstract string instanrefill { get; }

	public abstract string weeklydigs { get; }

	public abstract string NameName { get; }

	public abstract string weeklyrewards { get; }

	public abstract string egerkazarsan { get; }

	public abstract string taskkactamamlamalisin { get; }

	public abstract string tamamlandi { get; }

	public abstract string forged { get; }

	public abstract string forgeready { get; }

	public abstract string successrate { get; }

	public abstract string forgerune { get; }

	public abstract string SUCCESS { get; }

	public abstract string FAiL { get; }

	public abstract string mitrilyok { get; }

	public abstract string ruhkazanci { get; }

	public abstract string Mithril { get; }

	public abstract string AutoSummon { get; }

	public abstract string Stop { get; }

	public abstract string offlinepacktitle { get; }

	public abstract string offlinepacksubtitle { get; }

	public abstract string permanent2xtitle { get; }

	public abstract string permanent2xsubtitle { get; }

	public abstract string mitril2xtitle { get; }

	public abstract string mitril2xsubtitle { get; }

	public abstract string _youwon { get; }

	public abstract string _weeklyrewards { get; }

	public abstract string _odulunuzhesabiniza { get; }

	public abstract string _damagepersecond { get; }

	public abstract string surummevcut { get; }

	public abstract string surumsubtitle { get; }

	public abstract string updateit { get; }

	public abstract string haloweenbilgi1 { get; }

	public abstract string haloweenbilgi2 { get; }

	public abstract string haloweenbilgi3 { get; }

	public abstract string passtitle { get; }

	public abstract string halloweenunlock { get; }

	public abstract string passname { get; }

	public abstract string premium { get; }

	public abstract string event1 { get; }

	public abstract string olympiainfo1 { get; }

	public abstract string olympiainfo2 { get; }

	public abstract string olympiainfo3 { get; }

	public abstract string olympiainfo4 { get; }

	public abstract string olympiapass { get; }

	public abstract string Rarity_bronze { get; }

	public abstract string Rarity_silver { get; }

	public abstract string Rarity_gold { get; }

	public abstract string DailyRuneTitle { get; }

	public abstract string DailyCrystalTitle { get; }

	public abstract string DailyChestTitle { get; }

	public abstract string _btnsbottominapp1 { get; }

	public abstract string _btnsbottominapp2 { get; }

	public abstract string _btnsbottominapp3 { get; }

	public abstract string Coin { get; }

	public abstract string Statistics { get; }

	public abstract string kalansure { get; }

	public abstract string _passname { get; }

	public abstract string required { get; }

	public abstract string completepasssub { get; }

	public abstract string GETPREMIUM { get; }

	public abstract string Rewards { get; }

	public abstract string Missions { get; }

	public abstract string elmasyok { get; }

	public abstract string BUYTORCH { get; }

	public abstract string No { get; }

	public abstract string Claim { get; }

	public abstract string refreshin { get; }

	public abstract string _bottomTexts1 { get; }

	public abstract string _bottomTexts2 { get; }

	public abstract string _bottomTexts3 { get; }

	public abstract string _bottomTexts4 { get; }

	public abstract string _bottomTexts5 { get; }

	public abstract string Start { get; }

	public abstract string MerdivenSub { get; }

	public abstract string Trophies { get; }

	public abstract string joinandget50 { get; }

	public abstract string joindiscord { get; }

	public abstract string dailyloginbuyuk { get; }

	public abstract string dailylogineventsub { get; }

	public abstract string EVENTS { get; }

	public abstract string dailyloginkucuk { get; }

	public abstract string cavekucuk { get; }

	public abstract string enter { get; }

	public abstract string diamondgodkucuk { get; }

	public abstract string common { get; }

	public abstract string uncommon { get; }

	public abstract string super { get; }

	public abstract string dungeonrefill { get; }

	public abstract string ownedeff { get; }

	public abstract string equippedeff { get; }

	public abstract string equip { get; }

	public abstract string enhance { get; }

	public abstract string totalowned { get; }

	public abstract string enhanceall { get; }

	public abstract string summongear { get; }

	public abstract string dropchancesbyg { get; }

	public abstract string summoningincrease { get; }

	public abstract string equipped { get; }

	public abstract string gear { get; }

	public abstract string gunlukGorevTitle { get; }

	public abstract string inProgress { get; }

	public abstract string gunlukGorev1 { get; }

	public abstract string gunlukGorev2 { get; }

	public abstract string gunlukGorev3 { get; }

	public abstract string gunlukGorev4 { get; }

	public abstract string gunlukGorev5 { get; }

	public abstract string gunlukGorev6 { get; }

	public abstract string gunlukGorev7 { get; }

	public abstract string gunlukGorev8 { get; }

	public abstract string gunlukGorev9 { get; }

	public abstract string gunlukGorev10 { get; }

	public abstract string gunlukGorev11 { get; }

	public abstract string gunlukGorev12 { get; }

	public abstract string gunlukGorev13 { get; }

	public abstract string gunlukGorev14 { get; }

	public abstract string gunlukGorev15 { get; }

	public abstract string gunlukGorev16 { get; }

	public abstract string gunlukGorev17 { get; }

	public abstract string receivedaily { get; }

	public abstract string receiveafter { get; }

	public abstract string logineveryday { get; }

	public abstract string equipment_ring { get; }

	public abstract string equipment_amulet { get; }

	public abstract string equipment_shield { get; }

	public abstract string equipment_cape { get; }

	public abstract string equipment_weapon { get; }

	public abstract string value { get; }

	public abstract string noadspack { get; }

	public abstract string viptitle { get; }

	public abstract string vipodul1 { get; }

	public abstract string vipodul2 { get; }

	public abstract string destektitle { get; }

	public abstract string destekodul1 { get; }

	public abstract string congratsgain { get; }

	public abstract string hero { get; }

	public abstract string Attack { get; }

	public abstract string Health { get; }

	public abstract string CastleDef { get; }

	public abstract string HeroATK { get; }

	public abstract string Siege { get; }

	public abstract string BestSurvive { get; }

	public abstract string dailygorevler { get; }

	public abstract string gamespass { get; }

	public abstract string merdivenevent { get; }

	public abstract string spinevent { get; }

	public abstract string income2x { get; }

	public abstract string leaderboardtxt { get; }

	public abstract string sevendayevent { get; }

	public abstract string dailyrewards { get; }

	public abstract string starterpack { get; }

	public abstract string piggybank { get; }

	public abstract string startit { get; }

	public abstract string dungeontxt { get; }

	public abstract string goldyoktxt { get; }

	public abstract string battlepass { get; }

	public abstract string troops { get; }

	public abstract string warrior { get; }

	public abstract string striker { get; }

	public abstract string ranger { get; }

	public abstract string castle { get; }

	public abstract string talent { get; }

	public abstract string talenteffect { get; }

	public abstract string summon { get; }

	public abstract string contin { get; }

	public abstract string exit { get; }

	public abstract string paused { get; }

	public abstract string siegerewards { get; }

	public abstract string goldcoin { get; }

	public abstract string talentscroll { get; }

	public abstract string leadercoin { get; }

	public abstract string silverincome { get; }

	public abstract string dungeonlevelup { get; }

	public abstract string letstryagain { get; }

	public abstract string bosscoming { get; }

	public abstract string herokilled { get; }

	public abstract string wave { get; }

	public abstract string newwave { get; }

	public abstract string finalwavecom { get; }

	public abstract string victory { get; }

	public abstract string lose { get; }

	public abstract string dungeoncleared { get; }

	public abstract string dungeonfailed { get; }

	public abstract string dungeonkeys { get; }

	public abstract string sweepprevius { get; }

	public abstract string challange { get; }

	public abstract string sweepsucces { get; }

	public abstract string chooseaskill { get; }

	public abstract string reroll { get; }

	public abstract string obtainhero { get; }

	public abstract string pack { get; }

	public abstract string luckywheel { get; }

	public abstract string spin { get; }

	public abstract string freespin { get; }

	public abstract string claimyourspin { get; }

	public abstract string talent1name { get; }

	public abstract string talent2name { get; }

	public abstract string talent3name { get; }

	public abstract string talent4name { get; }

	public abstract string talent5name { get; }

	public abstract string talent6name { get; }

	public abstract string talent7name { get; }

	public abstract string talent8name { get; }

	public abstract string talent9name { get; }

	public abstract string talent10name { get; }

	public abstract string talent11name { get; }

	public abstract string talent12name { get; }

	public abstract string talent13name { get; }

	public abstract string talent14name { get; }

	public abstract string talent15name { get; }

	public abstract string talent16name { get; }

	public abstract string talent17name { get; }

	public abstract string talent18name { get; }

	public abstract string talent19name { get; }

	public abstract string talent20name { get; }

	public abstract string talent21name { get; }

	public abstract string talent22name { get; }

	public abstract string talent1subname { get; }

	public abstract string talent2subname { get; }

	public abstract string talent3subname { get; }

	public abstract string talent4subname { get; }

	public abstract string talent5subname { get; }

	public abstract string talent6subname { get; }

	public abstract string talent7subname { get; }

	public abstract string talent8subname { get; }

	public abstract string talent9subname { get; }

	public abstract string talent10subname { get; }

	public abstract string talent11subname { get; }

	public abstract string talent12subname { get; }

	public abstract string talent13subname { get; }

	public abstract string talent14subname { get; }

	public abstract string talent15subname { get; }

	public abstract string talent16subname { get; }

	public abstract string talent17subname { get; }

	public abstract string talent18subname { get; }

	public abstract string talent19subname { get; }

	public abstract string talent20subname { get; }

	public abstract string talent21subname { get; }

	public abstract string talent22subname { get; }

	public abstract string dungeon1 { get; }

	public abstract string dungeon2 { get; }

	public abstract string dungeon3 { get; }

	public abstract string dungeon1sub { get; }

	public abstract string dungeon2sub { get; }

	public abstract string dungeon3sub { get; }

	public abstract string atkspeed { get; }

	public abstract string everywavec { get; }

	public abstract string warriorunitsatk { get; }

	public abstract string strikerunitsatk { get; }

	public abstract string rangerunitsatk { get; }

	public abstract string goldcoinincome { get; }

	public abstract string atk { get; }

	public abstract string hp { get; }

	public abstract string cd { get; }

	public abstract string skilldamage { get; }

	public abstract string heros { get; }

	public abstract string armyunits { get; }

	public abstract string tier { get; }

	public abstract string nofify1 { get; }

	public abstract string nofify2 { get; }

	public abstract string nofify3 { get; }

	public abstract string nofify4 { get; }

	public abstract string nofify5 { get; }

	public abstract string nofify6 { get; }

	public abstract string info1 { get; }

	public abstract string info2 { get; }

	public abstract string info3 { get; }

	public abstract string info4 { get; }

	public abstract string info5 { get; }

	public abstract string info6 { get; }

	public abstract string info7 { get; }

	public abstract string info8 { get; }

	public abstract string info9 { get; }

	public abstract string info10 { get; }

	public abstract string info11 { get; }

	public abstract string info12 { get; }

	public abstract string info13 { get; }

	public abstract string info14 { get; }

	public abstract string info15 { get; }

	public abstract string info16 { get; }

	public abstract string info17 { get; }

	public abstract string info18 { get; }

	public abstract string info19 { get; }

	public abstract string info20 { get; }

	public abstract string info21 { get; }

	public abstract string info22 { get; }

	public abstract string info23 { get; }

	public abstract string info24 { get; }

	public abstract string info25 { get; }

	public abstract string info26 { get; }

	public abstract string info27 { get; }

	public abstract string owned { get; }

	public abstract string nextwar { get; }

	public abstract string nextwaravaliable { get; }

	public abstract string dailywars { get; }

	public abstract string dailywarsguide1 { get; }

	public abstract string dailywarsguide2 { get; }

	public abstract string dailywarsguide3 { get; }

	public abstract string dailywarsguide4 { get; }

	public abstract string dailywarsguide5 { get; }

	public abstract string dailywarlose { get; }

	public abstract string dailywarwin { get; }

	public abstract string activateorb { get; }

	public abstract string bounce { get; }

	public abstract string damage { get; }

	public abstract string shock { get; }

	public abstract string Aspeed { get; }

	public abstract string target { get; }

	public abstract string effect { get; }

	public abstract string area { get; }

	public abstract string slow { get; }

	public abstract string range { get; }

	public abstract string ResearchName1 { get; }

	public abstract string ResearchName2 { get; }

	public abstract string ResearchName3 { get; }

	public abstract string ResearchName4 { get; }

	public abstract string ResearchName5 { get; }

	public abstract string ResearchName6 { get; }

	public abstract string ResearchName7 { get; }

	public abstract string ResearchName8 { get; }

	public abstract string arastirmatamamlandi { get; }

	public abstract string yenibirarastirma { get; }

	public abstract string finishnow { get; }

	public abstract string openlab { get; }

	public abstract string unlock { get; }

	public abstract string noads { get; }

	public abstract string starter { get; }

	public abstract string adbonus { get; }

	public abstract string day14 { get; }

	public abstract string talents { get; }

	public abstract string shipperk { get; }

	public abstract string upgrades { get; }

	public abstract string vippack { get; }

	public abstract string milestonetier { get; }

	public abstract string totalbonus { get; }

	public abstract string goldbonuses { get; }

	public abstract string inactive { get; }

	public abstract string boss { get; }

	public abstract string highestwave { get; }

	public abstract string skillexpincome { get; }

	public abstract string elementalorbattack { get; }

	public abstract string unlockx2speed { get; }

	public abstract string battle { get; }

	public abstract string totalgoldbonuses { get; }

	public abstract string Research { get; }

	public abstract string attackupgs { get; }

	public abstract string defenseupgs { get; }

	public abstract string incomeupgs { get; }

	public abstract string activetalents { get; }

	public abstract string inventory { get; }

	public abstract string currrentlevel { get; }

	public abstract string maxlevel { get; }

	public abstract string labaratuar { get; }

	public abstract string Members { get; }

	public abstract string Perks { get; }

	public abstract string Tasks { get; }

	public abstract string Requests { get; }

	public abstract string Disband { get; }

	public abstract string Quit { get; }

	public abstract string perkstitle { get; }

	public abstract string perkssubtitle { get; }

	public abstract string perketki { get; }

	public abstract string loginsucc { get; }

	public abstract string logingiveinfo { get; }

	public abstract string guildperk { get; }

	public abstract string guild { get; }

	public abstract string notcomplete { get; }

	public abstract string complete { get; }

	public abstract string guildexp { get; }

	public abstract string clanakatki { get; }

	public abstract string accept { get; }

	public abstract string decline { get; }

	public abstract string expires { get; }

	public abstract string setnickname { get; }

	public abstract string confirm { get; }

	public abstract string chooseavatar { get; }

	public abstract string guildcreate { get; }

	public abstract string guildname { get; }

	public abstract string guilddescript { get; }

	public abstract string guildcanyoujoin { get; }

	public abstract string background { get; }

	public abstract string foreground { get; }

	public abstract string emblem { get; }

	public abstract string createguild { get; }

	public abstract string search { get; }

	public abstract string searchaguild { get; }

	public abstract string apply { get; }

	public abstract string joiny { get; }

	public abstract string okay { get; }

	public abstract string yes { get; }

	public abstract string no { get; }

	public abstract string skillsecmi { get; }

	public abstract string eniyiguilds { get; }

	public abstract string best5guild { get; }

	public abstract string weaponname1 { get; }

	public abstract string weaponname2 { get; }

	public abstract string weaponname3 { get; }

	public abstract string weaponname4 { get; }

	public abstract string weaponname5 { get; }

	public abstract string weaponname6 { get; }

	public abstract string weaponname7 { get; }

	public abstract string weaponname8 { get; }

	public abstract string weaponname9 { get; }

	public abstract string weaponname10 { get; }

	public abstract string weaponname11 { get; }

	public abstract string weaponname12 { get; }

	public abstract string weaponname13 { get; }

	public abstract string weaponname14 { get; }

	public abstract string weaponname15 { get; }

	public abstract string weaponname16 { get; }

	public abstract string weaponname17 { get; }

	public abstract string weaponname18 { get; }

	public abstract string weaponname19 { get; }

	public abstract string weaponname20 { get; }

	public abstract string weaponname21 { get; }

	public abstract string weaponname22 { get; }

	public abstract string weaponname23 { get; }

	public abstract string weaponname24 { get; }

	public abstract string weaponname25 { get; }

	public abstract string weaponname26 { get; }

	public abstract string weaponname27 { get; }

	public abstract string weaponname28 { get; }

	public abstract string weaponname29 { get; }

	public abstract string weaponname30 { get; }

	public abstract string weaponname31 { get; }

	public abstract string weaponname32 { get; }

	public abstract string weaponname33 { get; }

	public abstract string weaponname34 { get; }

	public abstract string mystic { get; }

	public abstract string requiredweapon { get; }

	public abstract string craft { get; }

	public abstract string Head { get; }

	public abstract string Chest { get; }

	public abstract string Leg { get; }

	public abstract string Boot { get; }

	public abstract string Ring { get; }

	public abstract string Necklace { get; }

	public abstract string heroskill1 { get; }

	public abstract string heroskill2 { get; }

	public abstract string heroskill3 { get; }

	public abstract string heroskill4 { get; }

	public abstract string heroskill5 { get; }

	public abstract string heroskill6 { get; }

	public abstract string wallskill1 { get; }

	public abstract string wallskill2 { get; }

	public abstract string wallskill3 { get; }

	public abstract string wallskill4 { get; }

	public abstract string wallskill5 { get; }

	public abstract string wallskill6 { get; }

	public abstract string wallskill7 { get; }

	public abstract string wallskill8 { get; }

	public abstract string petskill1 { get; }

	public abstract string petskill2 { get; }

	public abstract string petskill3 { get; }

	public abstract string petskill4 { get; }

	public abstract string petskill5 { get; }

	public abstract string petskill6 { get; }

	public abstract string petskill7 { get; }

	public abstract string petskill8 { get; }

	public abstract string petskill9 { get; }

	public abstract string weaponskillsub1 { get; }

	public abstract string weaponskillsub2 { get; }

	public abstract string weaponskillsub3 { get; }

	public abstract string weaponskillsub4 { get; }

	public abstract string weaponskillsub5 { get; }

	public abstract string weaponskillsub6 { get; }

	public abstract string weaponskillsub7 { get; }

	public abstract string weaponskillsub8 { get; }

	public abstract string weaponskillsub9 { get; }

	public abstract string weaponskillsub10 { get; }

	public abstract string weaponskillsub11 { get; }

	public abstract string weaponskillsub12 { get; }

	public abstract string weaponskillsub13 { get; }

	public abstract string weaponskillsub14 { get; }

	public abstract string weaponskillsub15 { get; }

	public abstract string weaponskillsub16 { get; }

	public abstract string weaponskillsub17 { get; }

	public abstract string weaponskillsub18 { get; }

	public abstract string weaponskillsub19 { get; }

	public abstract string weaponskillsub20 { get; }

	public abstract string weaponskillsub21 { get; }

	public abstract string weaponskillsub22 { get; }

	public abstract string weaponskillsub23 { get; }

	public abstract string weaponskillsub24 { get; }

	public abstract string weaponskillsub25 { get; }

	public abstract string weaponskillsub26 { get; }

	public abstract string weaponskillsub27 { get; }

	public abstract string weaponskillsub28 { get; }

	public abstract string weaponskillsub29 { get; }

	public abstract string weaponskillsub30 { get; }

	public abstract string weaponskillsub31 { get; }

	public abstract string weaponskillsub32 { get; }

	public abstract string weaponskillsub33 { get; }

	public abstract string weaponskillsub34 { get; }

	public abstract string weaponskillsub35 { get; }

	public abstract string weaponskillsub36 { get; }

	public abstract string weaponskillsub37 { get; }

	public abstract string weaponskillsub38 { get; }

	public abstract string weaponskillsub39 { get; }

	public abstract string weaponskillsub40 { get; }

	public abstract string weaponskillsub41 { get; }

	public abstract string weaponskillsub42 { get; }

	public abstract string weaponskillsub43 { get; }

	public abstract string weaponskillsub44 { get; }

	public abstract string weaponskillsub45 { get; }

	public abstract string weaponskillsub46 { get; }

	public abstract string weaponskillsub47 { get; }

	public abstract string weaponskillsub48 { get; }

	public abstract string weaponskillsub49 { get; }

	public abstract string weaponskillsub50 { get; }

	public abstract string weaponskillsub51 { get; }

	public abstract string weaponskillsub52 { get; }

	public abstract string weaponskillsub53 { get; }

	public abstract string weaponskillsub54 { get; }

	public abstract string weaponskillsub55 { get; }

	public abstract string weaponskillsub56 { get; }

	public abstract string weaponskillsub57 { get; }

	public abstract string weaponskillsub58 { get; }

	public abstract string weaponskillsub59 { get; }

	public abstract string weaponskillsub60 { get; }

	public abstract string weaponskillsub61 { get; }

	public abstract string weaponskillsub62 { get; }

	public abstract string weaponskillsub63 { get; }

	public abstract string weaponskillsub64 { get; }

	public abstract string weaponskillsub65 { get; }

	public abstract string weaponskillsуб66 { get; }

	public abstract string weaponskillsуб67 { get; }

	public abstract string weaponskillsуб68 { get; }

	public abstract string weaponskillsуб69 { get; }

	public abstract string weaponskilltitle1 { get; }

	public abstract string weaponskilltitle2 { get; }

	public abstract string weaponskilltitle3 { get; }

	public abstract string weaponskilltitle4 { get; }

	public abstract string weaponskilltitle5 { get; }

	public abstract string weaponskilltitle6 { get; }

	public abstract string weaponskilltitle7 { get; }

	public abstract string weaponskilltitle8 { get; }

	public abstract string weaponskilltitle9 { get; }

	public abstract string weaponskilltitle10 { get; }

	public abstract string weaponskilltitle11 { get; }

	public abstract string weaponskilltitle12 { get; }

	public abstract string weaponskilltitle13 { get; }

	public abstract string weaponskilltitle14 { get; }

	public abstract string weaponskilltitle15 { get; }

	public abstract string weaponskilltitle16 { get; }

	public abstract string weaponskilltitle17 { get; }

	public abstract string weaponskilltitle18 { get; }

	public abstract string weaponskilltitle19 { get; }

	public abstract string weaponskilltitle20 { get; }

	public abstract string weaponskilltitle21 { get; }

	public abstract string weaponskilltitle22 { get; }

	public abstract string weaponskilltitle23 { get; }

	public abstract string weaponskilltitle24 { get; }

	public abstract string weaponskilltitle25 { get; }

	public abstract string weaponskilltitle26 { get; }

	public abstract string weaponskilltitle27 { get; }

	public abstract string weaponskilltitle28 { get; }

	public abstract string weaponskilltitle29 { get; }

	public abstract string weaponskilltitle30 { get; }

	public abstract string weaponskilltitle31 { get; }

	public abstract string weaponskilltitle32 { get; }

	public abstract string weaponskilltitle33 { get; }

	public abstract string weaponskilltitle34 { get; }

	public abstract string weaponskilltitle35 { get; }

	public abstract string weaponskilltitle36 { get; }

	public abstract string weaponskilltitle37 { get; }

	public abstract string weaponskilltitle38 { get; }

	public abstract string weaponskilltitle39 { get; }

	public abstract string weaponskilltitle40 { get; }

	public abstract string weaponskilltitle41 { get; }

	public abstract string weaponskilltitle42 { get; }

	public abstract string weaponskilltitle43 { get; }

	public abstract string weaponskilltitle44 { get; }

	public abstract string weaponskilltitle45 { get; }

	public abstract string weaponskilltitle46 { get; }

	public abstract string weaponskilltitle47 { get; }

	public abstract string weaponskilltitle48 { get; }

	public abstract string weaponskilltitle49 { get; }

	public abstract string weaponskilltitle50 { get; }

	public abstract string weaponskilltitle51 { get; }

	public abstract string weaponskilltitle52 { get; }

	public abstract string weaponskilltitle53 { get; }

	public abstract string weaponskilltitle54 { get; }

	public abstract string weaponskilltitle55 { get; }

	public abstract string weaponskilltitle56 { get; }

	public abstract string weaponskilltitle57 { get; }

	public abstract string weaponskilltitle58 { get; }

	public abstract string weaponskilltitle59 { get; }

	public abstract string weaponskilltitle60 { get; }

	public abstract string weaponskilltitle61 { get; }

	public abstract string weaponskilltitle62 { get; }

	public abstract string weaponskilltitle63 { get; }

	public abstract string weaponskilltitle64 { get; }

	public abstract string weaponskilltitle65 { get; }

	public abstract string weaponskilltitle66 { get; }

	public abstract string weaponskilltitle67 { get; }

	public abstract string weaponskilltitle68 { get; }

	public abstract string weaponskilltitle69 { get; }

	public abstract string CritChance { get; }

	public abstract string AttackSpeed { get; }

	public abstract string CritDamage { get; }

	public abstract string CommonAttackArtisi { get; }

	public abstract string RareAttackArtisi { get; }

	public abstract string EpicAttackArtisi { get; }

	public abstract string LegendAttackArtisi { get; }

	public abstract string MistikAttackArtisi { get; }

	public abstract string AxeAttackArtisi { get; }

	public abstract string BowAttackArtisi { get; }

	public abstract string WandAttackArtisi { get; }

	public abstract string SwordAttackArtisi { get; }

	public abstract string MaceAttackArtisi { get; }

	public abstract string AxeCritChanceArtisi { get; }

	public abstract string BowCritChanceArtisi { get; }

	public abstract string WandCritChanceArtisi { get; }

	public abstract string SwordCritChanceArtisi { get; }

	public abstract string MaceCritChanceArtisi { get; }

	public abstract string AxeCritDamageArtisi { get; }

	public abstract string BowCritDamageArtisi { get; }

	public abstract string WandCritDamageArtisi { get; }

	public abstract string SwordCritDamageArtisi { get; }

	public abstract string MaceCritDamageArtisi { get; }

	public abstract string AxeATKSpeedArtisi { get; }

	public abstract string BowATKSpeedArtisi { get; }

	public abstract string WandATKSpeedArtisi { get; }

	public abstract string SwordATKSpeedArtisi { get; }

	public abstract string MaceATKSpeedArtisi { get; }

	public abstract string CastleHpArtisi { get; }

	public abstract string AlevHasariArtisi { get; }

	public abstract string PoisonHasariArtisi { get; }

	public abstract string StunOlanDusmanlarSaldiriArtisi { get; }

	public abstract string SavasBasindaFreeCoin { get; }

	public abstract string Tier2CommonAtk { get; }

	public abstract string RareAtkIncrease { get; }

	public abstract string EpicAtkIncrease { get; }

	public abstract string LegendaryAtkIncrease { get; }

	public abstract string LegendaryMysticAtkIncrease { get; }

	public abstract string MysticAtkIncrease { get; }

	public abstract string ObtainSummonTokens { get; }

	public abstract string IncreaseSpinRarity { get; }

	public abstract string HealCastleHp { get; }

	public abstract string SummonCommonWeapon { get; }

	public abstract string SummonRareWeapon { get; }

	public abstract string SummonEpicWeapon { get; }

	public abstract string SummonLegendaryWeapon { get; }

	public abstract string CommonAndRareAtkIncrease { get; }

	public abstract string guide1 { get; }

	public abstract string guide2 { get; }

	public abstract string guide3 { get; }

	public abstract string guide4 { get; }

	public abstract string guide5 { get; }

	public abstract string guide6 { get; }

	public abstract string destroyed { get; }

	public abstract string gamespeed { get; }

	public abstract string gamespeedAD { get; }

	public abstract string Youwon { get; }

	public abstract string Defeat { get; }

	public abstract string inWarGuide1 { get; }

	public abstract string inWarGuide2 { get; }

	public abstract string inWarGuide3 { get; }

	public abstract string inWarGuide4 { get; }

	public abstract string inWarGuide5 { get; }

	public abstract string inWarGuide6 { get; }

	public abstract string inWarGuide7 { get; }

	public abstract string inWarGuide8 { get; }

	public abstract string inWarGuide9 { get; }

	public abstract string inWarGuide10 { get; }

	public abstract string NotEnoughGold { get; }

	public abstract string NotEnoughGearScroll { get; }

	public abstract string NotEnoughTalentScroll { get; }

	public abstract string NotEnoughWeaponToken { get; }

	public abstract string NotEnoughCrystals { get; }

	public abstract string NotEnoughResources { get; }

	public abstract string Chance { get; }

	public abstract string boostTitle1 { get; }

	public abstract string boostTitle2 { get; }

	public abstract string boostTitle3 { get; }

	public abstract string boostTitle4 { get; }

	public abstract string boostTitle5 { get; }

	public abstract string boostTitle6 { get; }

	public abstract string boostTitle7 { get; }

	public abstract string boostTitle8 { get; }

	public abstract string boostTitle9 { get; }

	public abstract string boostTitle10 { get; }

	public abstract string isafantastic { get; }

	public abstract string craftnow { get; }

	public abstract string typeAxe { get; }

	public abstract string typeBow { get; }

	public abstract string typeWand { get; }

	public abstract string typeSword { get; }

	public abstract string typeMace { get; }

	public abstract string typeSpecial { get; }

	public abstract string typeUnknown { get; }

	public abstract string merge { get; }

	public abstract string sell { get; }

	public abstract string passive { get; }

	public abstract string CD { get; }

	public abstract string Luck { get; }

	public abstract string Fail { get; }

	public abstract string attemptsremain { get; }

	public abstract string inventoryfull { get; }

	public abstract string limit { get; }

	public abstract string levelPacks { get; }

	public abstract string dailyShop { get; }

	public abstract string mysticPacks { get; }

	public abstract string lifetimePacks { get; }

	public abstract string bundles { get; }

	public abstract string coinShop { get; }

	public abstract string crystalShop { get; }

	public abstract string RewardsCollected { get; }

	public abstract string EarnRandomGearScroll { get; }

	public abstract string EarnEnergyAndCrystal { get; }

	public abstract string EarnRandomCurrencies { get; }

	public abstract string ChancesLeft { get; }

	public abstract string RewardLevel { get; }

	public abstract string IdleRewardsTitle { get; }

	public abstract string IdleRewardsSubtitle { get; }

	public abstract string GetCollectedOffline { get; }

	public abstract string GetIdle { get; }

	public abstract string OfflineRewards { get; }

	public abstract string RewardsClaimed { get; }

	public abstract string vipsinirsiz { get; }

	public abstract string soldout { get; }

	public abstract string ironingot { get; }

	public abstract string freeroll { get; }

	public abstract string roll { get; }

	public abstract string mystictoken { get; }

	public abstract string cooldown { get; }

	public abstract string stats { get; }

	public abstract string perks { get; }

	public abstract string spinit { get; }

	public abstract string spinning { get; }

	public abstract string spintokenyok { get; }

	public abstract string CharacterSkill { get; }

	public abstract string Unlock { get; }

	public abstract string Choose { get; }

	public abstract string Heroes { get; }

	public abstract string StarUp { get; }

	public abstract string ByRarity { get; }

	public abstract string ByLevel { get; }

	public abstract string Summon { get; }

	public abstract string Blacksmith { get; }

	public abstract string Weapons { get; }

	public abstract string ChooseGearToMerge { get; }

	public abstract string MergeSuccess { get; }

	public abstract string AutoMergeSuccess { get; }

	public abstract string MyGears { get; }

	public abstract string AutoMerge { get; }

	public abstract string MergeDescription { get; }

	public abstract string RequiredText { get; }

	public abstract string ReadyToMerge { get; }

	public abstract string RarityIncrease { get; }

	public abstract string GearBonusLevelIncrease { get; }

	public abstract string Characters { get; }

	public abstract string GearLevelLabel { get; }

	public abstract string GearTypeLabel { get; }

	public abstract string EquippedBasicBonusLabel { get; }

	public abstract string EquippedBasicBonusValueFormat { get; }

	public abstract string EquippedRarityPerksLabel { get; }

	public abstract string UpgradeEffectLabel { get; }

	public abstract string UpgradeEffectValueFormat { get; }

	public abstract string Equip { get; }

	public abstract string Unequip { get; }

	public abstract string notowned { get; }

	public abstract string starterher { get; }

	public abstract string Energy { get; }

	public abstract string GetEnergy { get; }

	public abstract string chooseaweapon { get; }

	public abstract string gagchadescription { get; }

	public abstract string forge { get; }

	public abstract string crystalspending { get; }

	public abstract string crystalspendingsub { get; }

	public abstract string drawn { get; }

	public abstract string skipAnimation { get; }

	public abstract string emeraldSpinInfo { get; }

	public abstract string drawX1 { get; }

	public abstract string drawX10 { get; }

	public abstract string chances1 { get; }

	public abstract string chances2 { get; }

	public abstract string pathOfEmeralds { get; }

	public abstract string dailyDraws { get; }

	public abstract string weeklyContent { get; }

	public abstract string exchangeOffice { get; }

	public abstract string eventInfoTitle { get; }

	public abstract string eventInfo1 { get; }

	public abstract string eventInfo2 { get; }

	public abstract string eventInfo3 { get; }

	public abstract string eventInfo4 { get; }

	public abstract string roadToFinals { get; }

	public abstract string roadToFinalsDesc { get; }

	public abstract string exclusive { get; }

	public abstract string deals { get; }

	public abstract string dicePack { get; }

	public abstract string adDicePack { get; }

	public abstract string collections { get; }

	public abstract string AllDamageArtisiFlat_Title { get; }

	public abstract string EnemyDecreaseHealth_Title { get; }

	public abstract string HP_Title { get; }

	public abstract string CommonAttackArtisi_Title { get; }

	public abstract string RareAttackArtisi_Title { get; }

	public abstract string EpicAttackArtisi_Title { get; }

	public abstract string LegendAttackArtisi_Title { get; }

	public abstract string MistikAttackArtisi_Title { get; }

	public abstract string AxeAttackArtisi_Title { get; }

	public abstract string BowAttackArtisi_Title { get; }

	public abstract string WandAttackArtisi_Title { get; }

	public abstract string SwordAttackArtisi_Title { get; }

	public abstract string MaceAttackArtisi_Title { get; }

	public abstract string AxeCritChanceArtisi_Title { get; }

	public abstract string BowCritChanceArtisi_Title { get; }

	public abstract string WandCritChanceArtisi_Title { get; }

	public abstract string SwordCritChanceArtisi_Title { get; }

	public abstract string MaceCritChanceArtisi_Title { get; }

	public abstract string AxeCritDamageArtisi_Title { get; }

	public abstract string BowCritDamageArtisi_Title { get; }

	public abstract string WandCritDamageArtisi_Title { get; }

	public abstract string SwordCritDamageArtisi_Title { get; }

	public abstract string MaceCritDamageArtisi_Title { get; }

	public abstract string Miss_new { get; }

	public abstract string Chef_new { get; }

	public abstract string SummonChef_new { get; }

	public abstract string ChefComing_new { get; }

	public abstract string HeadExchange_new { get; }

	public abstract string ExchangeTitleRandomPet_new { get; }

	public abstract string ExchangeTitleRandomWall_new { get; }

	public abstract string ExchangeTitlePetFood_new { get; }

	public abstract string ExchangeTitleWallHammer_new { get; }

	public abstract string ExchangeTitleRareGear_new { get; }

	public abstract string ExchangeTitleEpicGear_new { get; }

	public abstract string ExchangeTitleLegendGear_new { get; }

	public abstract string CollectionHead_new { get; }

	public abstract string pets_new { get; }

	public abstract string pets { get; }

	public abstract string EventIleEldeEdilir_new { get; }

	public abstract string WallSkill_new { get; }

	public abstract string Walls_new { get; }

	public abstract string Collections_new { get; }

	public abstract string weaponname35 { get; }

	public abstract string weaponname36 { get; }

	public abstract string weaponname37 { get; }

	public abstract string weaponname38 { get; }

	public abstract string weaponskilltitle70 { get; }

	public abstract string weaponskilltitle71 { get; }

	public abstract string weaponskilltitle72 { get; }

	public abstract string weaponskilltitle73 { get; }

	public abstract string weaponskilltitle74 { get; }

	public abstract string weaponskilltitle75 { get; }

	public abstract string weaponskilltitle76 { get; }

	public abstract string weaponskilltitle77 { get; }

	public abstract string weaponskilltitle78 { get; }

	public abstract string weaponskilltitle79 { get; }

	public abstract string weaponskilltitle80 { get; }

	public abstract string weaponskilltitle81 { get; }

	public abstract string weaponskillsub70 { get; }

	public abstract string weaponskillsub71 { get; }

	public abstract string weaponskillsub72 { get; }

	public abstract string weaponskillsub73 { get; }

	public abstract string weaponskillsub74 { get; }

	public abstract string weaponskillsub75 { get; }

	public abstract string weaponskillsub76 { get; }

	public abstract string weaponskillsub77 { get; }

	public abstract string weaponskillsub78 { get; }

	public abstract string weaponskillsub79 { get; }

	public abstract string weaponskillsub80 { get; }

	public abstract string weaponskillsub81 { get; }

	public abstract string gearfull { get; }

	public abstract string nextbattlereadyin { get; }

	public abstract string locked { get; }

	public abstract string MaxEnergy { get; }

	public abstract string CastleWallsHP { get; }

	public abstract string StartingSilver { get; }

	public abstract string SpawnMistik { get; }

	public abstract string GuildBoss1 { get; }

	public abstract string GuildBoss2 { get; }

	public abstract string GuildBoss3 { get; }

	public abstract string GuildBoss4 { get; }

	public abstract string GuildBossDamageDealtTxt { get; }

	public abstract string GuildBossObjCompleted { get; }

	public abstract string DonationDailyLimit { get; }

	public abstract string DonationTitle { get; }

	public abstract string DonationSub { get; }

	public abstract string DonateBtnUstu { get; }

	public abstract string BossRaid { get; }

	public abstract string DailyLimit { get; }

	public abstract string TitleRaid { get; }

	public abstract string SubTitleRaid { get; }

	public abstract string StartChallenge { get; }

	public abstract string Chat { get; }

	public abstract string Unlocked { get; }

	public abstract string DailyFortune { get; }

	public abstract string DailyFortunesub { get; }

	public abstract string Todaysfortune { get; }

	public abstract string seewhatfate { get; }

	public abstract string FortuneCase0 { get; }

	public abstract string FortuneCase1 { get; }

	public abstract string FortuneCase2 { get; }

	public abstract string FortuneCase3 { get; }

	public abstract string FortuneCase4 { get; }

	public abstract string FortuneCase5 { get; }

	public abstract string FortuneCase6 { get; }

	public abstract string FortuneCase7 { get; }

	public abstract string FortuneCase8 { get; }

	public abstract string FortuneCase9 { get; }

	public abstract string Send { get; }

	public abstract string MenuWeapon { get; }

	public abstract string MenuTotalDamage { get; }

	public abstract string FinalWeapon { get; }

	public abstract string FinalTotalDamage { get; }

	public abstract string ChatKural1 { get; }

	public abstract string ChatKural2 { get; }

	public abstract string ChatKural3 { get; }

	public abstract string ChatKural4 { get; }

	public abstract string ChatKural5 { get; }

	public abstract string ChatKural6 { get; }

	public abstract string ChatKural7 { get; }

	public abstract string ChatKural8 { get; }

	public abstract string Chatagevertificate { get; }

	public abstract string Chatagevertificatesub { get; }

	public abstract string iagree { get; }

	public abstract string donotagree { get; }

	public abstract string Elite { get; }

	public abstract string Normal { get; }

	public abstract string Forgeweapons { get; }

	public abstract string Skip { get; }

	public abstract string youcanforge { get; }

	public abstract string forgecompleted { get; }

	public abstract string freeforge { get; }

	public abstract string chefnameStr0 { get; }

	public abstract string chefnameStr1 { get; }

	public abstract string chefnameStr2 { get; }

	public abstract string chefnameStr3 { get; }

	public abstract string chefnameStr4 { get; }

	public abstract string chefnameStr5 { get; }

	public abstract string chefnameStr6 { get; }

	public abstract string chefnameStr7 { get; }

	public abstract string chefnameStrDefault { get; }

	public abstract string itemDesc27 { get; }

	public abstract string itemDesc28 { get; }

	public abstract string newmistik { get; }

	public abstract string mysticBladeOffer { get; }

	public abstract string gorevtamamlandi { get; }

	public abstract string forgeyoktitle { get; }

	public abstract string forgeyoksubtitle { get; }

	public abstract string forgeyokgo { get; }

	public abstract string bestsurvive { get; }

	public abstract string golyokbasictxt { get; }

	public abstract string missionStr0 { get; }

	public abstract string missionStr1 { get; }

	public abstract string missionStr2 { get; }

	public abstract string missionStr3 { get; }

	public abstract string missionStr4 { get; }

	public abstract string missionStr5 { get; }

	public abstract string missionStr6 { get; }

	public abstract string missionStr7 { get; }

	public abstract string missionStr8 { get; }

	public abstract string missionStr9 { get; }

	public abstract string missionStr10 { get; }

	public abstract string missionStr11 { get; }

	public abstract string missionStr12 { get; }

	public abstract string missionStr13 { get; }

	public abstract string missionStr14 { get; }

	public abstract string missionStr15 { get; }

	public abstract string missionStr16 { get; }

	public abstract string missionStr17 { get; }

	public abstract string missionStr18 { get; }

	public abstract string missionStr19 { get; }

	public abstract string missionStr20 { get; }

	public abstract string missionStr21 { get; }

	public abstract string missionStr22 { get; }

	public abstract string missionStr23 { get; }

	public abstract string missionStr24 { get; }

	public abstract string missionStr25 { get; }

	public abstract string missionStr26 { get; }

	public abstract string missionStr27 { get; }

	public abstract string missionStr28 { get; }

	public abstract string missionStr29 { get; }

	public abstract string missionStr30 { get; }

	public abstract string missionStr31 { get; }

	public abstract string missionStrDefault { get; }

	public abstract string titleMYS { get; }

	public abstract string afterpurchase { get; }

	public abstract string oncetext { get; }

	public abstract string resetButton { get; }

	public abstract string resetTitle { get; }

	public abstract string refundText { get; }

	public abstract string detailtitle { get; }

	public abstract string detail1 { get; }

	public abstract string detail2 { get; }

	public abstract string detailmisticLevel { get; }

	public abstract string detailCost { get; }

	public abstract string obtained { get; }

	public abstract string risePackTitle { get; }

	public abstract string risePackValue { get; }

	public abstract string mission17 { get; }

	public abstract string mission18 { get; }

	public abstract string mission19 { get; }

	public abstract string challengeTitle { get; }

	public abstract string challengeSubtitle { get; }

	public abstract string challengeButton { get; }

	public abstract string missionsTab { get; }

	public abstract string challengesTab { get; }

	public abstract string SteelVanguard { get; }

	public abstract string FirstLightUnit { get; }

	public abstract string SilentExecution { get; }

	public abstract string OmegaStrike { get; }

	public abstract string EtherealCircle { get; }

	public abstract string ArcaneTrio { get; }

	public abstract string CrimsonPatrol { get; }

	public abstract string IronPhalanx { get; }

	public abstract string CelestialLegion { get; }

	public abstract string TwilightCovenant { get; }

	public abstract string SpectralAlliance { get; }

	public abstract string ShadowfrontSquad { get; }

	public abstract string RadiantBattalion { get; }

	public abstract string NovaDivision { get; }

	public abstract string LevelUpTxt { get; }

	public abstract string LevelUpSub { get; }

	public abstract string SkillsAndStats_new { get; }

	public abstract string LevelingPerks_new { get; }

	public abstract string MysticalWeaponsAreMorePowerful_new { get; }

	public abstract string WeveCraftedEnoughCommonSwords_new { get; }

	public abstract string PreciousIron_new { get; }

	public abstract string Speed24h_new { get; }

	public abstract string Speed72h_new { get; }

	public abstract string SpeedForever_new { get; }

	public abstract string BattleSpeedInc_new { get; }

	public abstract string ObtainPlasmaShardAxe_new { get; }

	public abstract string forgeweaponstitle { get; }

	public abstract string forgeweaponssub { get; }

	public abstract string gearguide1 { get; }

	public abstract string gearguide2 { get; }

	public abstract string gearguide3 { get; }

	public abstract string gearguide4 { get; }

	public static string RarityNames(int Num)
	{
		return null;
	}

	public static string ItemGearType(int Num)
	{
		return null;
	}

	public static string ItemGearName(int Num)
	{
		return null;
	}

	public static string chefnameStr(int chefNum)
	{
        // Original ARM64 recovery 0x223fb94.
        switch(chefNum){
        case 0:return Get.chefnameStr0;
        case 1:return Get.chefnameStr1;
        case 2:return Get.chefnameStr2;
        case 3:return Get.chefnameStr3;
        case 4:return Get.chefnameStr4;
        case 5:return Get.chefnameStr5;
        case 6:return Get.chefnameStr6;
        case 7:return Get.chefnameStr7;
        default:return Get.chefnameStrDefault;
        }
	}

	public static string MainHeroSkillSub(int Num, int Yuzde)
	{
        // Original ARM64 recovery 0x223fd50.
        YuzdeSkillHero=Yuzde;
        switch(Num){case 0:return Get.heroskill1;case 1:return Get.heroskill2;case 2:return Get.heroskill3;case 3:return Get.heroskill4;case 4:return Get.heroskill5;case 5:return Get.heroskill6;default:return "Unknown";}
	}

	public static string MainWallSkillSub(int Num, int Yuzde)
	{
        // Original ARM64 recovery 0x223feec.
        YuzdeSkillWall=Yuzde;
        switch(Num){case 0:return Get.wallskill1;case 1:return Get.wallskill2;case 2:return Get.wallskill3;case 3:return Get.wallskill4;case 4:return Get.wallskill5;case 5:return Get.wallskill6;case 6:return Get.wallskill7;case 7:return Get.wallskill8;default:return "Unknown";}
	}

	public static string MainPetSkillSub(int Num, int Yuzde)
	{
		// Offline recovery candidate; native RVA 0x22400f0.
		YuzdeSkillPet = Yuzde;
		switch (Num)
		{
		 case 0: return Get.petskill1;
		 case 1: return Get.petskill2;
		 case 2: return Get.petskill3;
		 case 3: return Get.petskill4;
		 case 4: return Get.petskill5;
		 case 5: return Get.petskill6;
		 case 6: return Get.petskill7;
		 case 7: return Get.petskill8;
		 case 8: return Get.petskill9;
		 default: return "Unknown";
		}
	}

	public static string GorevTitle(string Num)
	{
		return null;
	}

	public static string CollectionsTitles(string Num)
	{
		// Native RVA0x22409f4. Original 23 string-equality cases and empty fallback.
		switch(Num){
		case "MistikAttackArtisi":return Get.MistikAttackArtisi_Title;
		case "AllDamageArtisiFlat":return Get.AllDamageArtisiFlat_Title;
		case "SwordAttackArtisi":return Get.SwordAttackArtisi_Title;
		case "RareAttackArtisi":return Get.RareAttackArtisi_Title;
		case "LegendAttackArtisi":return Get.LegendAttackArtisi_Title;
		case "MaceAttackArtisi":return Get.MaceAttackArtisi_Title;
		case "HP":return Get.HP_Title;
		case "BowCritChanceArtisi":return Get.BowCritChanceArtisi_Title;
		case "AxeCritDamageArtisi":return Get.AxeCritDamageArtisi_Title;
		case "WandAttackArtisi":return Get.WandAttackArtisi_Title;
		case "SwordCritChanceArtisi":return Get.SwordCritChanceArtisi_Title;
		case "AxeAttackArtisi":return Get.AxeAttackArtisi_Title;
		case "SwordCritDamageArtisi":return Get.SwordCritDamageArtisi_Title;
		case "BowAttackArtisi":return Get.BowAttackArtisi_Title;
		case "WandCritDamageArtisi":return Get.WandCritDamageArtisi_Title;
		case "MaceCritDamageArtisi":return Get.MaceCritDamageArtisi_Title;
		case "BowCritDamageArtisi":return Get.BowCritDamageArtisi_Title;
		case "EpicAttackArtisi":return Get.EpicAttackArtisi_Title;
		case "CommonAttackArtisi":return Get.CommonAttackArtisi_Title;
		case "EnemyDecreaseHealth":return Get.EnemyDecreaseHealth_Title;
		case "MaceCritChanceArtisi":return Get.MaceCritChanceArtisi_Title;
		case "WandCritChanceArtisi":return Get.WandCritChanceArtisi_Title;
		case "AxeCritChanceArtisi":return Get.AxeCritChanceArtisi_Title;
		default:return "";
		}
	}

	public static string WeaponSkillSubtitles(string Num)
	{
        // Original ARM64 0x2241424.
        switch (Num) {
        case "Mistik5A": return Get.weaponskillsub42;
        case "Mistik6": return Get.weaponskillsub44;
        case "WandCommon": return Get.weaponskillsub25;
        case "Mistik16A": return Get.weaponskillsub74;
        case "WandRare": return Get.weaponskillsub26;
        case "Mistik10B": return Get.weaponskillsub58;
        case "SwordLegend2": return Get.weaponskillsub24;
        case "WandEpic2": return Get.weaponskillsub28;
        case "Mistik14A": return Get.weaponskillsуб68;
        case "Mistik2": return Get.weaponskillsub34;
        case "AxeCommon": return Get.weaponskillsub7;
        case "Mistik4A": return Get.weaponskillsub39;
        case "ArrowLegend": return Get.weaponskillsub5;
        case "SwordEpic": return Get.weaponskillsub21;
        case "Mistik13": return Get.weaponskillsub65;
        case "Mistik15B": return Get.weaponskillsub72;
        case "ArrowEpic": return Get.weaponskillsub3;
        case "Mistik1": return Get.weaponskillsub31;
        case "MaceEpic2": return Get.weaponskillsub16;
        case "SwordRare": return Get.weaponskillsub20;
        case "ArrowRare": return Get.weaponskillsub2;
        case "Mistik13A": return Get.weaponskillsуб66;
        case "Mistik14": return Get.weaponskillsуб67;
        case "AxeRare": return Get.weaponskillsub8;
        case "Mistik14B": return Get.weaponskillsуб69;
        case "WandLegend2": return Get.weaponskillsub30;
        case "Mistik16": return Get.weaponskillsub73;
        case "Mistik12B": return Get.weaponskillsub64;
        case "MaceCommon": return Get.weaponskillsub13;
        case "Mistik8B": return Get.weaponskillsub52;
        case "Mistik5": return Get.weaponskillsub41;
        case "MaceEpic": return Get.weaponskillsub15;
        case "Mistik5B": return Get.weaponskillsub43;
        case "Mistik11": return Get.weaponskillsub59;
        case "WandLegend": return Get.weaponskillsub29;
        case "Mistik16B": return Get.weaponskillsub75;
        case "Mistik1A": return Get.weaponskillsub32;
        case "SwordCommon": return Get.weaponskillsub19;
        case "Mistik9": return Get.weaponskillsub53;
        case "Mistik18B": return Get.weaponskillsub81;
        case "MaceRare": return Get.weaponskillsub14;
        case "MaceLegend": return Get.weaponskillsub17;
        case "SwordLegend": return Get.weaponskillsub23;
        case "MaceLegend2": return Get.weaponskillsub18;
        case "SwordEpic2": return Get.weaponskillsub22;
        case "WandEpic": return Get.weaponskillsub27;
        case "Mistik17B": return Get.weaponskillsub78;
        case "Mistik9A": return Get.weaponskillsub54;
        case "Mistik11A": return Get.weaponskillsub60;
        case "Mistik7": return Get.weaponskillsub47;
        case "ArrowEpic2": return Get.weaponskillsub4;
        case "Mistik7B": return Get.weaponskillsub49;
        case "Mistik6A": return Get.weaponskillsub45;
        case "AxeLegend": return Get.weaponskillsub11;
        case "Mistik17A": return Get.weaponskillsub77;
        case "Mistik3A": return Get.weaponskillsub37;
        case "ArrowCommon": return Get.weaponskillsub1;
        case "Mistik3": return Get.weaponskillsub36;
        case "Mistik8": return Get.weaponskillsub50;
        case "Mistik4B": return Get.weaponskillsub40;
        case "AxeEpic2": return Get.weaponskillsub10;
        case "Mistik8A": return Get.weaponskillsub51;
        case "Mistik12": return Get.weaponskillsub62;
        case "Mistik15A": return Get.weaponskillsub71;
        case "Mistik9B": return Get.weaponskillsub55;
        case "Mistik11B": return Get.weaponskillsub61;
        case "Mistik10": return Get.weaponskillsub56;
        case "AxeLegend2": return Get.weaponskillsub12;
        case "Mistik7A": return Get.weaponskillsub48;
        case "Mistik6B": return Get.weaponskillsub46;
        case "Mistik18": return Get.weaponskillsub79;
        case "Mistik15": return Get.weaponskillsub70;
        case "Mistik12A": return Get.weaponskillsub63;
        case "Mistik1B": return Get.weaponskillsub33;
        case "Mistik10A": return Get.weaponskillsub57;
        case "Mistik17": return Get.weaponskillsub76;
        case "Mistik18A": return Get.weaponskillsub80;
        case "ArrowLegend2": return Get.weaponskillsub6;
        case "Mistik2A": return Get.weaponskillsub35;
        case "Mistik4": return Get.weaponskillsub38;
        case "AxeEpic": return Get.weaponskillsub9;
        default: return "Unknown";
        }
	}

	public static string GetInfoBilgi(int Num)
	{
        // Original ARM64 0x2243764.
        switch(Num)
        {
        case 0:return Get.info1;
        case 1:return Get.info2;
        case 2:return Get.info3;
        case 3:return Get.info4;
        case 4:return Get.info5;
        case 5:return Get.info6;
        case 6:return Get.info7;
        case 7:return Get.info8;
        case 8:return Get.info9;
        case 9:return Get.info10;
        case 10:return Get.info11;
        case 11:return Get.info12;
        case 12:return Get.info13;
        case 13:return Get.info14;
        case 14:return Get.info15;
        case 15:return Get.info16;
        case 16:return Get.info17;
        case 17:return Get.info18;
        case 18:return Get.info19;
        case 19:return Get.info20;
        case 20:return Get.info21;
        case 21:return Get.info22;
        case 22:return Get.info23;
        case 23:return Get.info24;
        case 24:return Get.info25;
        case 25:return Get.info26;
        case 26:return Get.info27;
        case 27:return Get.itemDesc27;
        case 28:return Get.itemDesc28;
        default:return "Unknown";
        }
	}

	public static string GetTalentName(int key)
	{
        // Original ARM64 recovery 0x2243d54.
        switch(key)
        {
        case 0: return Get.talent1name;
        case 1: return Get.talent2name;
        case 2: return Get.talent3name;
        case 3: return Get.talent4name;
        case 4: return Get.talent5name;
        case 5: return Get.talent6name;
        case 6: return Get.talent7name;
        case 7: return Get.talent8name;
        case 8: return Get.talent9name;
        case 9: return Get.talent10name;
        case 10: return Get.talent11name;
        case 11: return Get.talent12name;
        case 12: return Get.talent13name;
        case 13: return Get.talent14name;
        case 14: return Get.talent15name;
        case 15: return Get.talent16name;
        case 16: return Get.talent17name;
        case 17: return Get.talent18name;
        case 18: return Get.talent19name;
        case 19: return Get.talent20name;
        case 20: return Get.talent21name;
        case 21: return Get.talent22name;
        default: return "Talent";
        }
	}

	public static string GetTalentSubtitle(int key)
	{
        // Original ARM64 recovery 0x22441f4.
        switch(key)
        {
        case 0: return Get.talent1subname;
        case 1: return Get.talent2subname;
        case 2: return Get.talent3subname;
        case 3: return Get.talent4subname;
        case 4: return Get.talent5subname;
        case 5: return Get.talent6subname;
        case 6: return Get.talent7subname;
        case 7: return Get.talent8subname;
        case 8: return Get.talent9subname;
        case 9: return Get.talent10subname;
        case 10: return Get.talent11subname;
        case 11: return Get.talent12subname;
        case 12: return Get.talent13subname;
        case 13: return Get.talent14subname;
        case 14: return Get.talent15subname;
        case 15: return Get.talent16subname;
        case 16: return Get.talent17subname;
        case 17: return Get.talent18subname;
        case 18: return Get.talent19subname;
        case 19: return Get.talent20subname;
        case 20: return Get.talent21subname;
        case 21: return Get.talent22subname;
        default: return "Talent";
        }
	}

	public static string GetIWeaponNames(int key)
	{
        // Original ARM64 0x2244694.
        switch (key) {
        case 0: return Get.weaponname1;
        case 1: return Get.weaponname2;
        case 2: return Get.weaponname3;
        case 3: return Get.weaponname4;
        case 4: return Get.weaponname5;
        case 5: return Get.weaponname6;
        case 6: return Get.weaponname7;
        case 7: return Get.weaponname8;
        case 8: return Get.weaponname9;
        case 9: return Get.weaponname10;
        case 10: return Get.weaponname11;
        case 11: return Get.weaponname12;
        case 12: return Get.weaponname13;
        case 13: return Get.weaponname14;
        case 14: return Get.weaponname15;
        case 15: return Get.weaponname16;
        case 16: return Get.weaponname17;
        case 17: return Get.weaponname18;
        case 18: return Get.weaponname19;
        case 19: return Get.weaponname20;
        case 20: return Get.weaponname21;
        case 21: return Get.weaponname22;
        case 22: return Get.weaponname23;
        case 23: return Get.weaponname24;
        case 24: return Get.weaponname25;
        case 25: return Get.weaponname26;
        case 26: return Get.weaponname27;
        case 27: return Get.weaponname28;
        case 28: return Get.weaponname29;
        case 29: return Get.weaponname30;
        case 30: return Get.weaponname31;
        case 31: return Get.weaponname32;
        case 32: return Get.weaponname33;
        case 33: return Get.weaponname34;
        case 34: return Get.weaponname35;
        case 35: return Get.weaponname36;
        case 36: return Get.weaponname37;
        case 37: return Get.weaponname38;
        default: return "Talent";
        }
	}

	public static string GetDungeonNames(int key)
	{
		// Offline recovery candidate; native RVA 0x2244e34.
		switch(key)
		{
		 case 0:return Get.dungeon1;
		 case 1:return Get.dungeon2;
		 case 2:return Get.dungeon3;
		 default:return "Unknown";
		}
	}

	public static string GetDungeonSubtitles(int key)
	{
		// Offline recovery candidate; native RVA 0x2244f34.
		switch(key)
		{
		 case 0:return Get.dungeon1sub;
		 case 1:return Get.dungeon2sub;
		 case 2:return Get.dungeon3sub;
		 default:return "Unknown";
		}
	}

	public static string GetHeroPerks(string key)
	{
        // Original ARM64 recovery 0x2245034.
        switch(key){
         case "WallHp":return Get.CastleWallsHP;
         case "AxeAttack":return Get.AxeAttackArtisi_Title;
         case "ATK":return Get.Attack;
         case "StartCoin":return Get.StartingSilver;
         case "MaceAttack":return Get.MaceAttackArtisi_Title;
         case "LegendAttack":return Get.LegendAttackArtisi_Title;
         case "WarIncome":return Get.goldcoinincome;
         case "MaxEnergy":return Get.MaxEnergy;
         case "CommonAttack":return Get.CommonAttackArtisi_Title;
         case "RareAttack":return Get.RareAttackArtisi_Title;
         case "CritChance":return Get.CritChance;
         case "EpicAttack":return Get.EpicAttackArtisi_Title;
         case "WandAttack":return Get.WandAttackArtisi_Title;
         case "CritDamage":return Get.CritDamage;
         case "ArrowAttack":return Get.BowAttackArtisi_Title;
         case "SwordAttack":return Get.SwordAttackArtisi_Title;
         case "MysticAttack":return Get.MistikAttackArtisi_Title;
         case "AttackSpeed":return Get.AttackSpeed;
         default:return "Unknown.";
        }
	}

	public static string GetGearPerks(string key, int value)
	{
		return null;
	}

	public static string WeaponSkillTitle(string Num)
	{
        // Original ARM64 recovery 0x22465f8.
        switch(Num){
         case "Mistik12ATitle":return Get.weaponskilltitle63;
         case "AxeEpicTitle":return Get.weaponskilltitle9;
         case "Mistik10BTitle":return Get.weaponskilltitle58;
         case "Mistik7Title":return Get.weaponskilltitle47;
         case "WandLegendTitle":return Get.weaponskilltitle29;
         case "SwordLegendTitle":return Get.weaponskilltitle23;
         case "Mistik5ATitle":return Get.weaponskilltitle42;
         case "Mistik14BTitle":return Get.weaponskilltitle69;
         case "MaceEpicTitle":return Get.weaponskilltitle15;
         case "Mistik10Title":return Get.weaponskilltitle56;
         case "ArrowLegend2Title":return Get.weaponskilltitle6;
         case "Mistik12Title":return Get.weaponskilltitle62;
         case "Mistik4Title":return Get.weaponskilltitle38;
         case "Mistik6ATitle":return Get.weaponskilltitle45;
         case "Mistik18ATitle":return Get.weaponskilltitle80;
         case "Mistik8Title":return Get.weaponskilltitle50;
         case "Mistik15ATitle":return Get.weaponskilltitle71;
         case "SwordCommonTitle":return Get.weaponskilltitle19;
         case "MaceRareTitle":return Get.weaponskilltitle14;
         case "SwordLegend2Title":return Get.weaponskilltitle24;
         case "Mistik7ATitle":return Get.weaponskilltitle48;
         case "ArrowRareTitle":return Get.weaponskilltitle2;
         case "Mistik7BTitle":return Get.weaponskilltitle49;
         case "Mistik16Title":return Get.weaponskilltitle73;
         case "ArrowEpic2Title":return Get.weaponskilltitle4;
         case "WandEpicTitle":return Get.weaponskilltitle27;
         case "Mistik15BTitle":return Get.weaponskilltitle72;
         case "MaceCommonTitle":return Get.weaponskilltitle13;
         case "SwordRareTitle":return Get.weaponskilltitle20;
         case "WandRareTitle":return Get.weaponskilltitle26;
         case "Mistik11ATitle":return Get.weaponskilltitle60;
         case "AxeEpic2Title":return Get.weaponskilltitle10;
         case "Mistik5BTitle":return Get.weaponskilltitle43;
         case "Mistik5Title":return Get.weaponskilltitle41;
         case "Mistik8BTitle":return Get.weaponskilltitle52;
         case "Mistik13Title":return Get.weaponskilltitle65;
         case "Mistik1Title":return Get.weaponskilltitle31;
         case "Mistik6BTitle":return Get.weaponskilltitle46;
         case "Mistik1ATitle":return Get.weaponskilltitle32;
         case "Mistik16ATitle":return Get.weaponskilltitle74;
         case "SwordEpicTitle":return Get.weaponskilltitle21;
         case "Mistik11Title":return Get.weaponskilltitle59;
         case "Mistik1BTitle":return Get.weaponskilltitle33;
         case "AxeLegend2Title":return Get.weaponskilltitle12;
         case "Mistik18Title":return Get.weaponskilltitle79;
         case "Mistik16BTitle":return Get.weaponskilltitle75;
         case "Mistik3ATitle":return Get.weaponskilltitle37;
         case "Mistik3Title":return Get.weaponskilltitle36;
         case "Mistik9BTitle":return Get.weaponskilltitle55;
         case "Mistik13ATitle":return Get.weaponskilltitle66;
         case "Mistik12BTitle":return Get.weaponskilltitle64;
         case "Mistik9ATitle":return Get.weaponskilltitle54;
         case "Mistik6Title":return Get.weaponskilltitle44;
         case "Mistik4BTitle":return Get.weaponskilltitle40;
         case "ArrowCommonTitle":return Get.weaponskilltitle1;
         case "ArrowLegendTitle":return Get.weaponskilltitle5;
         case "MaceLegendTitle":return Get.weaponskilltitle17;
         case "MaceLegend2Title":return Get.weaponskilltitle18;
         case "Mistik17Title":return Get.weaponskilltitle76;
         case "MaceEpic2Title":return Get.weaponskilltitle16;
         case "Mistik17ATitle":return Get.weaponskilltitle77;
         case "Mistik14Title":return Get.weaponskilltitle67;
         case "Mistik18BTitle":return Get.weaponskilltitle81;
         case "AxeLegendTitle":return Get.weaponskilltitle11;
         case "Mistik8ATitle":return Get.weaponskilltitle51;
         case "Mistik17BTitle":return Get.weaponskilltitle78;
         case "Mistik2Title":return Get.weaponskilltitle34;
         case "AxeRareTitle":return Get.weaponskilltitle8;
         case "WandLegend2Title":return Get.weaponskilltitle30;
         case "Mistik9Title":return Get.weaponskilltitle53;
         case "WandEpic2Title":return Get.weaponskilltitle28;
         case "Mistik4ATitle":return Get.weaponskilltitle39;
         case "SwordEpic2Title":return Get.weaponskilltitle22;
         case "ArrowEpicTitle":return Get.weaponskilltitle3;
         case "AxeCommonTitle":return Get.weaponskilltitle7;
         case "Mistik14ATitle":return Get.weaponskilltitle68;
         case "Mistik2ATitle":return Get.weaponskilltitle35;
         case "Mistik10ATitle":return Get.weaponskilltitle57;
         case "Mistik15Title":return Get.weaponskilltitle70;
         case "WandCommonTitle":return Get.weaponskilltitle25;
         case "Mistik11BTitle":return Get.weaponskilltitle61;
         default:return "Unknown";
        }
	}
}
