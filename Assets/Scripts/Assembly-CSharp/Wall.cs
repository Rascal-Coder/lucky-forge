using UnityEngine;

public class Wall : MonoBehaviour
{
	public HeroController heroController;

	public WallPage wallPage;

	public string WallName;

	public int Num;

	public int StartLevel;

	public int Level;

	public int LevelExp;

	public int MaxLevel = 30;

	public int BaslangicExp;

	public string DegerSonu = "%";

	public int[] BonusLevel = new int[]{0,2,4,8,12,20,30,50,70};

	public int[] SetWallStone = new int[]{50,100,250,700,1200,2000,3500,5000};

	private int[] LevelMaxList = new int[]{2,2,4,8,12,18,36,72};

	public int Bonus(int lvlarti = 0)
	{
        // Recovered from original ARM64 0x2050710.
        return BonusLevel[Level + lvlarti];
	}

	public int LevelExpMax()
	{
        // Original ARM64 recovery 0x2050748.
        return LevelMaxList[Level];
	}

	public void AddKartExp(int kart = 1)
	{
        // Original ARM64 recovery 0x205077c.
        ilkKezAlindi();LevelExp=unchecked(LevelExp+kart);
        ES3.Save<int>("WallExp"+Num.ToString(),LevelExp);
	}

	public bool isUpgradeable()
	{
        // Original ARM64 recovery 0x20508b0.
        return Level<7;
	}

	public string SkillSubtitle()
	{
        // Original ARM64 recovery 0x20508c0.
        return Lang.MainWallSkillSub(Num,Bonus());
	}

	public void LevelUp()
	{
        // Original ARM64 recovery 0x2050934.
        if(SetWallStone[Level]>Currencys.WallToken||LevelExp<LevelExpMax())
        {if(heroController.canvasJobs!=null)heroController.canvasJobs.OpenGoldYok(-1);return;}
        if(Level>6)return;
        if(SetWallStone[Level]<=Currencys.WallToken&&LevelExp>=LevelExpMax())
        {
         Currencys.SpendWallToken(SetWallStone[Level],"Meta","WallUpgrade");
         int required=LevelExpMax();Level=unchecked(Level+1);LevelExp=unchecked(LevelExp-required);
         ES3.Save<int>("WallLevel"+Num.ToString(),Level);
         if(Level>=MaxLevel){Level=MaxLevel;LevelExp=0;}
         ES3.Save<int>("WallExp"+Num.ToString(),LevelExp);
         if(wallPage!=null)wallPage.Upgraded();
        }
	}

	public void LoadData()
	{
        // Recovered from original ARM64 0x2050c60.
        Level = ES3.Load<int>("WallLevel" + Num.ToString(), defaultValue: StartLevel);
        LevelExp = ES3.Load<int>("WallExp" + Num.ToString(), defaultValue: BaslangicExp);
	}

	private void ilkKezAlindi()
	{
        // Original ARM64 recovery 0x2050818.
        if(Level!=0)return;
        Level=1;ES3.Save<int>("WallLevel"+Num.ToString(),Level);
	}

	public void Use()
	{
        // Original ARM64 recovery 0x2050d30.
        if(Level==0)return;
        heroController.currentMainWall=Num;ES3.Save<int>("currentMainWall",Num);heroController.LoadWalls();
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
