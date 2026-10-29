using UnityEngine;

public class Currencys : MonoBehaviour
{
	private static int DataCrystal;

	private static bool SaveCrystal;

	private static float SaveCrystalTimer;

	private static double DataCoin;

	private static bool SaveCoin;

	private static float SaveCoinTimer;

	private static int DataTalentScroll;

	private static int DataHeroStone;

	private static int DataPetFood;

	private static bool SaveEnergy;

	private static float SaveEnergyTimer;

	private static int DataEnergy;

	private static int DataChestEquipment;

	private static int DataChestHeros;

	private static int DataChestMixed;

	private static int DataEventDice;

	private static int DataEventToken;

	private static int DataWeaponToken;

	private static int DataWallToken;

	private static int DataMistikToken;

	public static int[] GearScroll = new int[6];

	private static int[] DataGearScroll = new int[6];

	public static int Crystal { get; private set; }

	public static double Coin { get; private set; }

	public static int TalentScroll { get; private set; }

	public static int HeroStone { get; private set; }

	public static int PetFood { get; private set; }

	public static int Energy { get; private set; }

	public static int ChestEquipment { get; private set; }

	public static int ChestHeros { get; private set; }

	public static int ChestMixed { get; private set; }

	public static int EventDice { get; private set; }

	public static int EventToken { get; private set; }

	public static int Dungeon_1_Key { get; private set; }

	public static int Dungeon_2_Key { get; private set; }

	public static int Dungeon_3_Key { get; private set; }

	public static int Onyx { get; private set; }

	public static int WeaponToken { get; private set; }

	public static int WallToken { get; private set; }

	public static int MistikToken { get; private set; }

	private void Update()
	{
        // Native0x21ec698: three independent delayed saves; strict timer<0.
        if (SaveCrystal)
        {
            SaveCrystalTimer -= Time.deltaTime;
            if (SaveCrystalTimer < 0f)
            {
                ES3.Save<int>("Crystal",Crystal);
                ES3.Save<int>("DataCrystal",DataCrystal);
                SaveCrystal=false;
                SaveCrystalTimer=0;
            }
        }
        if (SaveCoin)
        {
            SaveCoinTimer -= Time.deltaTime;
            if (SaveCoinTimer < 0f)
            {
                ES3.Save<string>("Coin",Coin.ToString());
                ES3.Save<string>("DataCoin",DataCoin.ToString());
                SaveCoin=false;
                SaveCoinTimer=0;
            }
        }
        if (SaveEnergy)
        {
            SaveEnergyTimer -= Time.deltaTime;
            if (SaveEnergyTimer < 0f)
            {
                ES3.Save<int>("Energy",Energy);
                ES3.Save<int>("DataEnergy",DataEnergy);
                SaveEnergy=false;
                SaveEnergyTimer=0;
            }
        }
	}

	public static void AddCrystal(int amount, string Core, string Reason)
	{
        // Native 0x21e9808; online analytics intentionally omitted.
        Crystal += amount;
        DataCrystal += amount * 2;
        SaveCrystal = true;
        SaveCrystalTimer = 1f;
	}

	public static void CrystalFitle(int amount)
	{
        // Native 0x21ecae0; online analytics intentionally omitted.
        Crystal = amount;
        DataCrystal = amount * 2;
        SaveCrystal = true;
        SaveCrystalTimer = 1f;
	}

	public static bool SpendCrystal(int amount, string Core, string Reason)
	{
        // Native 0x21ecb80; online analytics intentionally omitted.
        if (DataCrystal != Crystal * 2) Crystal = DataCrystal / 2;
        if (!(Crystal >= amount)) return false;
        Crystal -= amount;
        DataCrystal -= amount * 2;
        ES3.Save<int>("Crystal", Crystal);
        ES3.Save<int>("DataCrystal", DataCrystal);
        return true;
	}

	public static void LoadStartCrystal()
	{
        Crystal = ES3.Load<int>("Crystal", 0); // store 0x21ed098
        DataCrystal = ES3.Load<int>("DataCrystal", 0); // store 0x21ed0b0
	}

	public static void AddCoin(double amount, string Core, string Reason)
	{
        // Native 0x21e956c; online analytics intentionally omitted.
        Coin += amount;
        DataCoin += amount * 2;
        SaveCoin = true;
        SaveCoinTimer = 1f;
	}

	public static void CoinFitle(double amount)
	{
        // Native 0x21ed178; online analytics intentionally omitted.
        Coin = amount;
        DataCoin = amount * 2;
        SaveCoin = true;
        SaveCoinTimer = 1f;
	}

	public static bool SpendCoin(double amount, string Core, string Reason)
	{
        // Native 0x21ed220; online analytics intentionally omitted.
        if (DataCoin != Coin * 2) Coin = DataCoin / 2;
        if (!(Coin >= amount)) return false;
        Coin -= amount;
        DataCoin -= amount * 2;
        ES3.Save<string>("Coin", Coin.ToString());
        ES3.Save<string>("DataCoin", DataCoin.ToString());
        return true;
	}

	public static void LoadStartCoin()
	{
        // RVA0x21ed678: original stores Coin/DataCoin as strings, parsed using Double.Parse.
        Coin = double.Parse(ES3.Load<string>("Coin"));
        DataCoin = double.Parse(ES3.Load<string>("DataCoin"));
	}

	public static void AddTalentScroll(int amount, string Core, string Reason)
	{
        // Native 0x21ed838; online analytics intentionally omitted.
        TalentScroll += amount;
        DataTalentScroll += amount * 2;
        ES3.Save<int>("TalentScroll", TalentScroll);
        ES3.Save<int>("DataTalentScroll", DataTalentScroll);
	}

	public static void TalentScrollFitle(int amount)
	{
        // Native 0x21edb54; online analytics intentionally omitted.
        TalentScroll = amount;
        DataTalentScroll = amount * 2;
        ES3.Save<int>("TalentScroll", TalentScroll);
        ES3.Save<int>("DataTalentScroll", DataTalentScroll);
	}

	public static bool SpendTalentScroll(int amount, string Core, string Reason)
	{
        // Native 0x21edc80; online analytics intentionally omitted.
        if (DataTalentScroll != TalentScroll * 2) TalentScroll = DataTalentScroll / 2;
        if (!(TalentScroll >= amount)) return false;
        TalentScroll -= amount;
        DataTalentScroll -= amount * 2;
        ES3.Save<int>("TalentScroll", TalentScroll);
        ES3.Save<int>("DataTalentScroll", DataTalentScroll);
        return true;
	}

	public static void LoadStartTalentScrolle()
	{
        TalentScroll = ES3.Load<int>("TalentScroll", 0); // store 0x21ee170
        DataTalentScroll = ES3.Load<int>("DataTalentScroll", 0); // store 0x21ee188
	}

	public static void AddHeroStone(int amount, string Core, string Reason)
	{
        // Native 0x21ee248; online analytics intentionally omitted.
        HeroStone += amount;
        DataHeroStone += amount * 2;
        ES3.Save<int>("HeroStone", HeroStone);
        ES3.Save<int>("DataHeroStone", DataHeroStone);
	}

	public static void HeroStoneFitle(int amount)
	{
        // Native 0x21ee564; online analytics intentionally omitted.
        HeroStone = amount;
        DataHeroStone = amount * 2;
        ES3.Save<int>("HeroStone", HeroStone);
        ES3.Save<int>("DataHeroStone", DataHeroStone);
	}

	public static bool SpendHeroStone(int amount, string Core, string Reason)
	{
        // Native 0x21ee690; online analytics intentionally omitted.
        if (DataHeroStone != HeroStone * 2) HeroStone = DataHeroStone / 2;
        if (!(HeroStone >= amount)) return false;
        HeroStone -= amount;
        DataHeroStone -= amount * 2;
        ES3.Save<int>("HeroStone", HeroStone);
        ES3.Save<int>("DataHeroStone", DataHeroStone);
        return true;
	}

	public static void LoadStartHeroStone()
	{
        HeroStone = ES3.Load<int>("HeroStone", 0); // store 0x21eeb80
        DataHeroStone = ES3.Load<int>("DataHeroStone", 0); // store 0x21eeb98
	}

	public static void AddPetFood(int amount, string Core, string Reason)
	{
        // Native 0x21eec58; online analytics intentionally omitted.
        PetFood += amount;
        DataPetFood += amount * 2;
        ES3.Save<int>("PetFood", PetFood);
        ES3.Save<int>("DataPetFood", DataPetFood);
	}

	public static void PetFoodFitle(int amount)
	{
        // Native 0x21eef74; online analytics intentionally omitted.
        PetFood = amount;
        DataPetFood = amount * 2;
        ES3.Save<int>("PetFood", PetFood);
        ES3.Save<int>("DataPetFood", DataPetFood);
	}

	public static bool SpendPetFood(int amount, string Core, string Reason)
	{
        // Native 0x21ef0a0; online analytics intentionally omitted.
        if (DataPetFood != PetFood * 2) PetFood = DataPetFood / 2;
        if (!(PetFood >= amount)) return false;
        PetFood -= amount;
        DataPetFood -= amount * 2;
        ES3.Save<int>("PetFood", PetFood);
        ES3.Save<int>("DataPetFood", DataPetFood);
        return true;
	}

	public static void LoadStartPetFood()
	{
        PetFood = ES3.Load<int>("PetFood", 0); // store 0x21ef590
        DataPetFood = ES3.Load<int>("DataPetFood", 0); // store 0x21ef5a8
	}

	public static int MaxEnergy()
	{
        // Native0x21ef5b4: PlayerData static+8 -> ClanPerksData instance+0x48.
        return 70 + PlayerData.clanPerksDatam.MaxEnergy;
	}

	public static void AddEnergy(int amount, string Core, string Reason)
	{
        // Native 0x21ef6d0; online analytics intentionally omitted.
        Energy += amount;
        DataEnergy += amount * 2;
        SaveEnergy = true;
        SaveEnergyTimer = 1f;
	}

	public static void EnergyFitle(int amount)
	{
        // Native 0x21ef968; online analytics intentionally omitted.
        Energy = amount;
        DataEnergy = amount * 2;
        ES3.Save<int>("Energy", Energy);
        ES3.Save<int>("DataEnergy", DataEnergy);
	}

	public static bool SpendEnergy(int amount, string Core, string Reason)
	{
        // Native 0x21efa98; online analytics intentionally omitted.
        if (DataEnergy != Energy * 2) Energy = DataEnergy / 2;
        if (!(Energy >= amount)) return false;
        Energy -= amount;
        DataEnergy -= amount * 2;
        ES3.Save<int>("Energy", Energy);
        ES3.Save<int>("DataEnergy", DataEnergy);
        return true;
	}

	public static void LoadStartEnergy()
	{
        Energy = ES3.Load<int>("Energy", 0); // store 0x21eff74
        DataEnergy = ES3.Load<int>("DataEnergy", 0); // store 0x21eff8c
	}

	public static void AddChestEquipment(int amount, string Core, string Reason)
	{
        // Native 0x21f004c; online analytics intentionally omitted.
        ChestEquipment += amount;
        DataChestEquipment += amount * 2;
        ES3.Save<int>("ChestEquipment", ChestEquipment);
        ES3.Save<int>("DataChestEquipment", DataChestEquipment);
	}

	public static void ChestEquipmentFitle(int amount)
	{
        // Native 0x21f0368; online analytics intentionally omitted.
        ChestEquipment = amount;
        DataChestEquipment = amount * 2;
        ES3.Save<int>("ChestEquipment", ChestEquipment);
        ES3.Save<int>("DataChestEquipment", DataChestEquipment);
	}

	public static bool SpendChestEquipment(int amount)
	{
        // Native 0x21f0494; online analytics intentionally omitted.
        if (DataChestEquipment != ChestEquipment * 2) ChestEquipment = DataChestEquipment / 2;
        if (!(ChestEquipment >= amount)) return false;
        ChestEquipment -= amount;
        DataChestEquipment -= amount * 2;
        ES3.Save<int>("ChestEquipment", ChestEquipment);
        ES3.Save<int>("DataChestEquipment", DataChestEquipment);
        return true;
	}

	public static void LoadStartChestEquipment()
	{
        ChestEquipment = ES3.Load<int>("ChestEquipment", 0); // store 0x21f07e4
        DataChestEquipment = ES3.Load<int>("DataChestEquipment", 0); // store 0x21f07fc
	}

	public static void AddChestHeros(int amount)
	{
        // Native 0x21f08bc; online analytics intentionally omitted.
        ChestHeros += amount;
        DataChestHeros += amount * 2;
        ES3.Save<int>("ChestHeros", ChestHeros);
        ES3.Save<int>("DataChestHeros", DataChestHeros);
	}

	public static void ChestHerosFitle(int amount)
	{
        // Native 0x21f0a24; online analytics intentionally omitted.
        ChestHeros = amount;
        DataChestHeros = amount * 2;
        ES3.Save<int>("ChestHeros", ChestHeros);
        ES3.Save<int>("DataChestHeros", DataChestHeros);
	}

	public static bool SpendChestHeros(int amount)
	{
        // Native 0x21f0b50; online analytics intentionally omitted.
        if (DataChestHeros != ChestHeros * 2) ChestHeros = DataChestHeros / 2;
        if (!(ChestHeros >= amount)) return false;
        ChestHeros -= amount;
        DataChestHeros -= amount * 2;
        ES3.Save<int>("ChestHeros", ChestHeros);
        ES3.Save<int>("DataChestHeros", DataChestHeros);
        return true;
	}

	public static void LoadStartChestHeros()
	{
        ChestHeros = ES3.Load<int>("ChestHeros", 0); // store 0x21f0ea0
        DataChestHeros = ES3.Load<int>("DataChestHeros", 0); // store 0x21f0eb8
	}

	public static void AddChestMixed(int amount)
	{
        // Native 0x21f0f78; online analytics intentionally omitted.
        ChestMixed += amount;
        DataChestMixed += amount * 2;
        ES3.Save<int>("ChestMixed", ChestMixed);
        ES3.Save<int>("DataChestMixed", DataChestMixed);
	}

	public static void ChestMixedFitle(int amount)
	{
        // Native 0x21f10e0; online analytics intentionally omitted.
        ChestMixed = amount;
        DataChestMixed = amount * 2;
        ES3.Save<int>("ChestMixed", ChestMixed);
        ES3.Save<int>("DataChestMixed", DataChestMixed);
	}

	public static bool SpendChestMixed(int amount)
	{
        // Native 0x21f120c; online analytics intentionally omitted.
        if (DataChestMixed != ChestMixed * 2) ChestMixed = DataChestMixed / 2;
        if (!(ChestMixed >= amount)) return false;
        ChestMixed -= amount;
        DataChestMixed -= amount * 2;
        ES3.Save<int>("ChestMixed", ChestMixed);
        ES3.Save<int>("DataChestMixed", DataChestMixed);
        return true;
	}

	public static void LoadStartChestMixed()
	{
        ChestMixed = ES3.Load<int>("ChestMixed", 0); // store 0x21f155c
        DataChestMixed = ES3.Load<int>("DataChestMixed", 0); // store 0x21f1574
	}

	public static void AddEventDice(int amount, string Core, string Reason)
	{
        // Native 0x21f1634; online analytics intentionally omitted.
        EventDice += amount;
        DataEventDice += amount * 2;
        ES3.Save<int>("EventDice", EventDice);
        ES3.Save<int>("DataEventDice", DataEventDice);
	}

	public static void EventDiceFitle(int amount)
	{
        // Native 0x21f1950; online analytics intentionally omitted.
        EventDice = amount;
        DataEventDice = amount * 2;
        ES3.Save<int>("EventDice", EventDice);
        ES3.Save<int>("DataEventDice", DataEventDice);
	}

	public static bool SpendEventDice(int amount, string Core, string Reason)
	{
        // Native 0x21f1a7c; online analytics intentionally omitted.
        if (DataEventDice != EventDice * 2) EventDice = DataEventDice / 2;
        if (!(EventDice >= amount)) return false;
        EventDice -= amount;
        DataEventDice -= amount * 2;
        ES3.Save<int>("EventDice", EventDice);
        ES3.Save<int>("DataEventDice", DataEventDice);
        return true;
	}

	public static void LoadStartEventDice()
	{
        EventDice = ES3.Load<int>("EventDice", 0); // store 0x21f1f6c
        DataEventDice = ES3.Load<int>("DataEventDice", 0); // store 0x21f1f84
	}

	public static void AddEventToken(int amount, string Core, string Reason)
	{
        // Native 0x21f2044; online analytics intentionally omitted.
        EventToken += amount;
        DataEventToken += amount * 2;
        ES3.Save<int>("EventToken", EventToken);
        ES3.Save<int>("DataEventToken", DataEventToken);
	}

	public static void EventTokenFitle(int amount)
	{
        // Native 0x21f2360; online analytics intentionally omitted.
        EventToken = amount;
        DataEventToken = amount * 2;
        ES3.Save<int>("EventToken", EventToken);
        ES3.Save<int>("DataEventToken", DataEventToken);
	}

	public static bool SpendEventToken(int amount, string Core, string Reason)
	{
        // Native 0x21f248c; online analytics intentionally omitted.
        if (DataEventToken != EventToken * 2) EventToken = DataEventToken / 2;
        if (!(EventToken >= amount)) return false;
        EventToken -= amount;
        DataEventToken -= amount * 2;
        ES3.Save<int>("EventToken", EventToken);
        ES3.Save<int>("DataEventToken", DataEventToken);
        return true;
	}

	public static void LoadStartEventToken()
	{
        EventToken = ES3.Load<int>("EventToken", 0); // store 0x21f297c
        DataEventToken = ES3.Load<int>("DataEventToken", 0); // store 0x21f2994
	}

	public static void AddDungeon_1_Key(int amount, string Core, string Reason)
	{
        // Native 0x21f2a54; online analytics intentionally omitted.
        Dungeon_1_Key += amount;
        ES3.Save<int>("Dungeon_1_Key", Dungeon_1_Key);
	}

	public static void Dungeon_1_KeyFitle(int amount)
	{
        // Native 0x21f2d3c; online analytics intentionally omitted.
        Dungeon_1_Key = amount;
        ES3.Save<int>("Dungeon_1_Key", Dungeon_1_Key);
	}

	public static bool SpendDungeon_1_Key(int amount, string Core, string Reason)
	{
        // Native 0x21f2e30; online analytics intentionally omitted.
        if (!(Dungeon_1_Key >= amount)) return false;
        Dungeon_1_Key -= amount;
        ES3.Save<int>("Dungeon_1_Key", Dungeon_1_Key);
        return true;
	}

	public static void AddDungeon_2_Key(int amount, string Core, string Reason)
	{
        // Native 0x21f3218; online analytics intentionally omitted.
        Dungeon_2_Key += amount;
        ES3.Save<int>("Dungeon_2_Key", Dungeon_2_Key);
	}

	public static void Dungeon_2_KeyFitle(int amount)
	{
        // Native 0x21f3500; online analytics intentionally omitted.
        Dungeon_2_Key = amount;
        ES3.Save<int>("Dungeon_2_Key", Dungeon_2_Key);
	}

	public static bool SpendDungeon_2_Key(int amount, string Core, string Reason)
	{
        // Native 0x21f35f4; online analytics intentionally omitted.
        if (!(Dungeon_2_Key >= amount)) return false;
        Dungeon_2_Key -= amount;
        ES3.Save<int>("Dungeon_2_Key", Dungeon_2_Key);
        return true;
	}

	public static void AddDungeon_3_Key(int amount, string Core, string Reason)
	{
        // Native 0x21f39dc; online analytics intentionally omitted.
        Dungeon_3_Key += amount;
        ES3.Save<int>("Dungeon_3_Key", Dungeon_3_Key);
	}

	public static void Dungeon_3_KeyFitle(int amount)
	{
        // Native 0x21f3cc4; online analytics intentionally omitted.
        Dungeon_3_Key = amount;
        ES3.Save<int>("Dungeon_3_Key", Dungeon_3_Key);
	}

	public static bool SpendDungeon_3_Key(int amount, string Core, string Reason)
	{
        // Native 0x21f3db8; online analytics intentionally omitted.
        if (!(Dungeon_3_Key >= amount)) return false;
        Dungeon_3_Key -= amount;
        ES3.Save<int>("Dungeon_3_Key", Dungeon_3_Key);
        return true;
	}

	public static void LoadStartDungeonKeys()
	{
        Dungeon_1_Key = ES3.Load<int>("Dungeon_1_Key", 0); // store 0x21f41d4
        Dungeon_2_Key = ES3.Load<int>("Dungeon_2_Key", 0); // store 0x21f422c
        Dungeon_3_Key = ES3.Load<int>("Dungeon_3_Key", 0); // store 0x21f4274
	}

	public static void AddWeaponToken(int amount, string Core, string Reason)
	{
        // Native 0x21f43ec; online analytics intentionally omitted.
        WeaponToken += amount;
        DataWeaponToken += amount * 2;
        ES3.Save<int>("WeaponToken", WeaponToken);
        ES3.Save<int>("DataWeaponToken", DataWeaponToken);
	}

	public static void WeaponTokenFitle(int amount)
	{
        // Native 0x21f4708; online analytics intentionally omitted.
        WeaponToken = amount;
        DataWeaponToken = amount * 2;
        ES3.Save<int>("WeaponToken", WeaponToken);
        ES3.Save<int>("DataWeaponToken", DataWeaponToken);
	}

	public static bool SpendWeaponToken(int amount, string Core, string Reason)
	{
        // Native 0x21f4834; online analytics intentionally omitted.
        if (DataWeaponToken != WeaponToken * 2) WeaponToken = DataWeaponToken / 2;
        if (!(WeaponToken >= amount)) return false;
        WeaponToken -= amount;
        DataWeaponToken -= amount * 2;
        ES3.Save<int>("WeaponToken", WeaponToken);
        ES3.Save<int>("DataWeaponToken", DataWeaponToken);
        return true;
	}

	public static void LoadStartWeaponToken()
	{
        WeaponToken = ES3.Load<int>("WeaponToken", 0); // store 0x21f4d60
        DataWeaponToken = ES3.Load<int>("DataWeaponToken", 0); // store 0x21f4d78
	}

	public static void AddWallToken(int amount, string Core, string Reason)
	{
        // Native 0x21f4e38; online analytics intentionally omitted.
        WallToken += amount;
        DataWallToken += amount * 2;
        ES3.Save<int>("WallToken", WallToken);
        ES3.Save<int>("DataWallToken", DataWallToken);
	}

	public static void WallTokenFitle(int amount)
	{
        // Native 0x21f5154; online analytics intentionally omitted.
        WallToken = amount;
        DataWallToken = amount * 2;
        ES3.Save<int>("WallToken", WallToken);
        ES3.Save<int>("DataWallToken", DataWallToken);
	}

	public static bool SpendWallToken(int amount, string Core, string Reason)
	{
        // Native 0x21f5280; online analytics intentionally omitted.
        if (DataWallToken != WallToken * 2) WallToken = DataWallToken / 2;
        if (!(WallToken >= amount)) return false;
        WallToken -= amount;
        DataWallToken -= amount * 2;
        ES3.Save<int>("WallToken", WallToken);
        ES3.Save<int>("DataWallToken", DataWallToken);
        return true;
	}

	public static void LoadStartWallToken()
	{
        WallToken = ES3.Load<int>("WallToken", 0); // store 0x21f5770
        DataWallToken = ES3.Load<int>("DataWallToken", 0); // store 0x21f5788
	}

	public static void AddMistikToken(int amount, string Core, string Reason)
	{
        // Native 0x21f5848; online analytics intentionally omitted.
        MistikToken += amount;
        DataMistikToken += amount * 2;
        ES3.Save<int>("MistikToken", MistikToken);
        ES3.Save<int>("DataMistikToken", DataMistikToken);
	}

	public static void MistikTokenFitle(int amount)
	{
        // Native 0x21f5b98; online analytics intentionally omitted.
        MistikToken = amount;
        DataMistikToken = amount * 2;
        ES3.Save<int>("MistikToken", MistikToken);
        ES3.Save<int>("DataMistikToken", DataMistikToken);
	}

	public static bool SpendMistikToken(int amount, string Core, string Reason)
	{
        // Native 0x21f5cc4; online analytics intentionally omitted.
        if (DataMistikToken != MistikToken * 2) MistikToken = DataMistikToken / 2;
        if (!(MistikToken >= amount)) return false;
        MistikToken -= amount;
        DataMistikToken -= amount * 2;
        ES3.Save<int>("MistikToken", MistikToken);
        ES3.Save<int>("DataMistikToken", DataMistikToken);
        return true;
	}

	public static void LoadStartMistikToken()
	{
        MistikToken = ES3.Load<int>("MistikToken", 0); // store 0x21f61b4
        DataMistikToken = ES3.Load<int>("DataMistikToken", 0); // store 0x21f61cc
	}

	public static void AddGearScroll(int index, int amount, string Core, string Reason)
	{
        // Native 0x21f61d8; analytics omitted.
        if (index < 0) return;
        // Recovery guard extends the native negative-index check to missing assets.
        if (GearScroll == null || DataGearScroll == null || index>=GearScroll.Length || index>=DataGearScroll.Length) return;
        GearScroll[index] += amount;
        ES3.Save<int>(string.Format("GearScroll{0}",index+1),GearScroll[index]);
        DataGearScroll[index] += amount*2;
        ES3.Save<int>(string.Format("DataGearScroll{0}",index+1),DataGearScroll[index]);
	}

	public static void FitleGearScroll(int index, int amount)
	{
        // Native 0x21f6570; analytics omitted.
        if (index < 0) return;
        if (GearScroll == null || DataGearScroll == null || index>=GearScroll.Length || index>=DataGearScroll.Length) return;
        GearScroll[index]=amount;
        DataGearScroll[index]=amount*2;
        ES3.Save<int>(string.Format("GearScroll{0}",index+1),GearScroll[index]);
        ES3.Save<int>(string.Format("DataGearScroll{0}",index+1),DataGearScroll[index]);
	}

	public static bool SpendGearScroll(int index, int amount, string Core, string Reason)
	{
        // Native 0x21f6730; analytics omitted.
        if (index < 0) return false;
        if (GearScroll == null || DataGearScroll == null || index>=GearScroll.Length || index>=DataGearScroll.Length) return false;
        if (DataGearScroll[index] != GearScroll[index]*2) GearScroll[index]=DataGearScroll[index]/2;
        if (GearScroll[index] < amount) return false;
        GearScroll[index]-=amount;
        ES3.Save<int>(string.Format("GearScroll{0}",index+1),GearScroll[index]);
        DataGearScroll[index]-=amount*2;
        ES3.Save<int>(string.Format("DataGearScroll{0}",index+1),DataGearScroll[index]);
        return true;
	}

	public static void LoadStartGearScroll()
	{
        // RVA0x21f6ba4: six entries, save key suffixes 1..6 map to array indexes0..5.
        for (int i = 0; i < 6; i++)
        {
            GearScroll[i] = ES3.Load<int>("GearScroll" + (i + 1), 0);
            DataGearScroll[i] = ES3.Load<int>("DataGearScroll" + (i + 1), 0);
        }
	}

	private static bool IsValid(int index)
	{
		return false;
	}
}
