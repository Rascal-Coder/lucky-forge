using UnityEngine;

public class MainHero : MonoBehaviour
{
	public HeroController heroController;

	public int HeroNum;

	public int Level;

	public string HeroName;

	public Sprite[] iconSet;

	public int SatinAlimCrystalFiyati;

	public double[] SetGold;

	public int[] SetHeroStone;

	public int[] YuzdeDurum;

	public Sprite heroSkillIcon;

	public HeroCharacterPage heroCharacterPage;

	public int HeroStoneGelistirmeFiyati()
	{
        // Recovered from original ARM64 0x20082ec.
        return SetHeroStone[Level];
	}

	public double GoldCoinFiyati()
	{
        // Recovered from original ARM64 0x2008320.
        return SetGold[Level];
	}

	public int Yuzde(int next = 0, int ustyazi = 0)
	{
        // Recovered from original ARM64 0x2008354.
        return YuzdeDurum[Level + next + (ustyazi == 1 && Level == 0 ? 1 : 0)];
	}

	public string heroSkillSubtitle()
	{
        // Original ARM64 recovery 0x2008398.
        return Lang.MainHeroSkillSub(HeroNum,Yuzde(0,1));
	}

	private void Start()
	{
        // Recovered from original ARM64 0x2008410.
        Level = ES3.Load<int>("MainHeroLevel" + HeroNum.ToString(), defaultValue: HeroNum == 0 ? 1 : 0);
	}

	public bool isUpgradeable()
	{
        // Recovered from original ARM64 0x20084a8.
        return Level < 7;
	}

	public void LevelUp()
	{
        // Recovered from original ARM64 0x20084b8.
        if (GoldCoinFiyati() > Currencys.Coin || HeroStoneGelistirmeFiyati() > Currencys.HeroStone)
        {
            if (heroController.canvasJobs != null) heroController.canvasJobs.OpenGoldYok(-1);
            return;
        }
        if (Level > 6) return;
        if (GoldCoinFiyati() <= Currencys.Coin && HeroStoneGelistirmeFiyati() <= Currencys.HeroStone)
        {
            Currencys.SpendHeroStone(HeroStoneGelistirmeFiyati(), "Meta", "HeroUpgrade");
            Currencys.SpendCoin(GoldCoinFiyati(), "Meta", "HeroUpgrade");
            Level++;
            ES3.Save<int>("MainHeroLevel" + HeroNum.ToString(), Level);
            if (heroCharacterPage != null) heroCharacterPage.Upgraded();
        }
	}

	public void SatinAl()
	{
        // Recovered from original ARM64 0x20087b8.
        if (SatinAlimCrystalFiyati > Currencys.Crystal)
        {
            if (heroController.canvasJobs != null) heroController.canvasJobs.OpenGoldYok(-1);
            return;
        }
        if (Level != 0) return;
        if (SatinAlimCrystalFiyati <= Currencys.Crystal)
        {
            Currencys.SpendCrystal(SatinAlimCrystalFiyati, "Meta", "HeroUnlock");
            Level++;
            ES3.Save<int>("MainHeroLevel" + HeroNum.ToString(), Level);
            if (heroCharacterPage != null) heroCharacterPage.SatinAlindi();
        }
	}

	public void Use()
	{
        // Recovered from original ARM64 0x20089a4.
        if (Level == 0) return;
        heroController.MainHeroNum = HeroNum;
        heroController.currentMainHero = heroController.mainHeroes[HeroNum];
        ES3.Save<int>("MainHeroNum", HeroNum);
	}

	private void Update()
	{
	}
}
