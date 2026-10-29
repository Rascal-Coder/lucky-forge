using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
	[Header("Commanders")]
	public List<Commander> HeroCommanders;

	public Color[] rarityColors;

	public Sprite[] typeBackgrounds;

	public Color[] typeBackgroundColors;

	public KarakterlerGenelUI karakterlerUi;

	public float[] AtkArtislari = new float[] { 0.10000000149011612f, 0.15000000596046448f, 0.20000000298023224f, 0.30000001192092896f, 0.5f }; // Original constructor 0x222082c.

	public double[] CommonUpgradePrice = new double[] { 20.0d, 200.0d, 500.0d, 800.0d, 1100.0d, 1400.0d, 1700.0d, 2000.0d, 2400.0d, 2800.0d, 3200.0d, 3700.0d, 4500.0d, 5500.0d, 6500.0d, 7500.0d, 8500.0d, 10000.0d, 11500.0d, 13000.0d, 14500.0d, 16000.0d, 18000.0d, 20000.0d, 22000.0d, 25000.0d, 28000.0d, 32000.0d, 40000.0d, 50000.0d, 55000.0d }; // Original constructor 0x222082c.

	public double[] RareUpgradePrice = new double[] { 50.0d, 250.0d, 600.0d, 1200.0d, 1800.0d, 2400.0d, 3000.0d, 3800.0d, 4600.0d, 5400.0d, 6200.0d, 7000.0d, 8000.0d, 9000.0d, 10000.0d, 12000.0d, 14000.0d, 16000.0d, 20000.0d, 24000.0d, 30000.0d, 34000.0d, 40000.0d, 46000.0d, 52000.0d, 60000.0d, 70000.0d, 80000.0d, 90000.0d, 100000.0d, 150000.0d }; // Original constructor 0x222082c.

	public double[] EpicUpgradePrice = new double[] { 150.0d, 400.0d, 1000.0d, 2000.0d, 3000.0d, 5000.0d, 8000.0d, 12000.0d, 15000.0d, 20000.0d, 25000.0d, 30000.0d, 39000.0d, 48000.0d, 58000.0d, 68000.0d, 80000.0d, 90000.0d, 100000.0d, 120000.0d, 140000.0d, 160000.0d, 200000.0d, 240000.0d, 280000.0d, 340000.0d, 420000.0d, 550000.0d, 700000.0d, 850000.0d, 1000000.0d }; // Original constructor 0x222082c.

	public double[] LegendUpgradePrice = new double[] { 500.0d, 1000.0d, 3000.0d, 6000.0d, 10000.0d, 15000.0d, 25000.0d, 30000.0d, 35000.0d, 40000.0d, 45000.0d, 50000.0d, 60000.0d, 75000.0d, 85000.0d, 100000.0d, 120000.0d, 140000.0d, 160000.0d, 220000.0d, 280000.0d, 340000.0d, 400000.0d, 500000.0d, 600000.0d, 700000.0d, 800000.0d, 950000.0d, 1200000.0d, 1500000.0d, 1800000.0d }; // Original constructor 0x222082c.

	public double[] MistikUpgradePrice = new double[] { 0.0d, 5000.0d, 10000.0d, 15000.0d, 25000.0d, 50000.0d, 80000.0d, 110000.0d, 150000.0d, 190000.0d, 250000.0d, 300000.0d, 400000.0d, 500000.0d, 600000.0d, 750000.0d, 900000.0d, 1200000.0d, 1500000.0d, 1800000.0d, 2200000.0d, 3000000.0d, 4000000.0d, 5000000.0d, 6000000.0d, 8000000.0d, 10000000.0d, 14000000.0d, 20000000.0d, 30000000.0d, 40000000.0d }; // Original constructor 0x222082c.

	public int[] MistikRequirement = new int[] { 0, 10, 30, 50, 80, 100, 120, 140, 160, 180, 200, 240, 270, 300, 340, 380, 420, 460, 500, 550, 600, 650, 700, 750, 800, 850, 900, 1000, 1200, 1500, 2000 }; // Original constructor 0x222082c.

	[Header("MainHeros")]
	public MainHero[] mainHeroes;

	public MainHero currentMainHero;

	public int MainHeroNum;

	public CommanderSpawner commanderSpawner;

	public WarController warController;

	public CanvasJobs canvasJobs;

	[Header("Wall")]
	public int currentMainWall;

	public Wall[] Walls;

	public Transform castleinwallparent;

	public Transform battleinwallparent;

	[Header("Pet")]
	public int currentMainPet;

	public Pet[] Pets;

	public Transform battleinpetparent;

	private void Start()
	{
        // Recovered from original ARM64 0x221fd2c.
        LoadLevels();
        LoadLevelsWalls();
        LoadPetLevels();
        if (karakterlerUi != null) karakterlerUi.Cloneit();
        MainHeroNum = ES3.Load<int>("MainHeroNum", defaultValue: 0);
        currentMainWall = ES3.Load<int>("currentMainWall", defaultValue: 0);
        currentMainHero = mainHeroes[MainHeroNum];
        LoadWalls();
        currentMainPet = ES3.Load<int>("currentMainPet", defaultValue: -1);
        LoadPets();
	}

	private void Update()
	{
	}

	public void LoadWalls()
	{
        // Recovered from original ARM64 0x221ffa8.
        if (battleinwallparent == null) return;
        for (int i = 0; i < battleinwallparent.childCount; i++)
        {
            bool selected = i == currentMainWall;
            if (castleinwallparent != null && i < castleinwallparent.childCount) castleinwallparent.GetChild(i).gameObject.SetActive(selected);
            battleinwallparent.GetChild(i).gameObject.SetActive(selected);
        }
	}

	public void LoadPets()
	{
        // Recovered from original ARM64 0x22200b0.
        if (battleinpetparent == null) return;
        for (int i = 0; i < battleinpetparent.childCount; i++) battleinpetparent.GetChild(i).gameObject.SetActive(i == currentMainPet);
	}

	public void LoadLevels()
	{
        // Recovered from original ARM64 0x221fe5c.
        if (HeroCommanders == null) return;
        for (int i = 0; i < HeroCommanders.Count; i++) if (HeroCommanders[i] != null) HeroCommanders[i].LoadData();
	}

	public void LoadLevelsWalls()
	{
        // Recovered from original ARM64 0x221fee8.
        if (Walls == null) return;
        for (int i = 0; i < Walls.Length; i++) if (Walls[i] != null) Walls[i].LoadData();
	}

	public void LoadPetLevels()
	{
        // Recovered from original ARM64 0x221ff48.
        if (Pets == null) return;
        for (int i = 0; i < Pets.Length; i++) if (Pets[i] != null) Pets[i].LoadData();
	}

	public void MainHeroSkillActivate(int ActivateNum, int LuckySpinRarity = 1)
	{
        // Recovered from original ARM64 0x222015c.
        PlayerData.mainHeroBonus.HerMistikYuzdeBonusu = 0f;
        PlayerData.mainHeroBonus.SavasSonuGanimetArtisi = 0f;
        if (MainHeroNum != ActivateNum) return;
        switch (ActivateNum)
        {
            case 0:
                PlayerData.mainHeroBonus.HerMistikYuzdeBonusu = currentMainHero.Yuzde() * commanderSpawner.GetCurrentMysticCommanderCount();
                break;
            case 1:
                if ((float)UnityEngine.Random.Range(0, 100) <= (float)currentMainHero.Yuzde()) warController.AddSilver(1f);
                break;
            case 2:
                if ((float)UnityEngine.Random.Range(0, 100) <= (float)currentMainHero.Yuzde()) warController.AddSilver(warController.slotMachine.SpinFiyat());
                break;
            case 3:
                if ((float)UnityEngine.Random.Range(0, 100) <= (float)currentMainHero.Yuzde())
                {
                    int amount = System.Math.Max(System.Math.Min(warController.slotMachine.SpinFiyat() / 3, 1000), 20);
                    warController.AddSilver(amount * LuckySpinRarity);
                }
                break;
            case 4:
                if ((float)UnityEngine.Random.Range(0, 100) <= (float)currentMainHero.Yuzde()) warController.Addtoken(2);
                break;
            case 5:
                PlayerData.mainHeroBonus.SavasSonuGanimetArtisi = currentMainHero.Yuzde();
                break;
        }
	}

	public void WallBonusAyarla()
	{
        // Recovered from original ARM64 0x22204c8.
        var bonus = PlayerData.mainWallEffect;
        bonus.KaleRegen = 0; bonus.HealthDusurYuzde = 0; bonus.DusmanlarShockSaniye = 0; bonus.SpinFiyatiDusur = 0;
        bonus.KaleHpArttir = 0; bonus.GoldCoinKazanimArttir = 0; bonus.DusmanlarIskaGecer = 0; bonus.DusmanlarDahaFazlaHasarYer = 0;
        if (currentMainWall < 0 || currentMainWall > 7) return;
        int value = Walls[currentMainWall].Bonus();
        switch (currentMainWall)
        {
            case 0: bonus.KaleHpArttir = value; break;
            case 1: bonus.SpinFiyatiDusur = value; break;
            case 2: bonus.DusmanlarShockSaniye = value; break;
            case 3: bonus.HealthDusurYuzde = value; break;
            case 4: bonus.DusmanlarIskaGecer = value; break;
            case 5: bonus.GoldCoinKazanimArttir = value; break;
            case 6: bonus.KaleRegen = value; break;
            case 7: bonus.DusmanlarDahaFazlaHasarYer = value; break;
        }
	}
}
