using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WallPage : MonoBehaviour
{
	public TextMeshProUGUI headname;

	public Transform stars;

	public TextMeshProUGUI characterskill;

	public TextMeshProUGUI characterskillsub;

	public TextMeshProUGUI solstar;

	public TextMeshProUGUI sagstar;

	public TextMeshProUGUI suankiyuzde;

	public TextMeshProUGUI sonrakiyuzde;

	public TextMeshProUGUI starup;

	public TextMeshProUGUI expfiyat;

	public TextMeshProUGUI walltokenfiyat;

	public TextMeshProUGUI use;

	public TextMeshProUGUI eventileeldedilir;

	public Button usebtn;

	public Button upgradebtn;

	public Transform eventileeldeedilirobj;

	public Transform characterSet;

	public TextMeshProUGUI heroes;

	public HeroController heroController;

	public TextMeshProUGUI wallstone;

	public ParticleSystem useeff;

	public Animator animUpg;

	public Slider sliderexp;

	public TextMeshProUGUI sliderexpadet;

	private Wall OneCikan;

	public InventoryGearUI inventoryGearUI;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnEnable()
	{
        // Original ARM64 recovery 0x2050f18.
        SetHero(heroController.currentMainWall);wallstone.text=Currencys.WallToken.ToString();
	}

	public void SetHero(int HeroNum)
	{
        // Original ARM64 recovery 0x2050ff8.
        OneCikan=heroController.Walls[HeroNum];headname.text=OneCikan.WallName;
        for(int i=0;i<7;i++)stars.GetChild(i).GetChild(0).gameObject.SetActive(i<OneCikan.Level);
        for(int i=0;i<characterSet.childCount;i++)characterSet.GetChild(i).gameObject.SetActive(i==HeroNum);
        characterskill.text=Lang.Get.WallSkill_new;use.text=Lang.Get.Choose;heroes.text=Lang.Get.Walls_new;
        characterskillsub.text=OneCikan.SkillSubtitle();solstar.text=OneCikan.Level.ToString();sagstar.text=unchecked(OneCikan.Level+1).ToString();
        suankiyuzde.text=OneCikan.Bonus().ToString()+OneCikan.DegerSonu;sonrakiyuzde.text=OneCikan.Bonus(1).ToString()+OneCikan.DegerSonu;
        expfiyat.text="<sprite=6>"+OneCikan.LevelExp.ToString()+"/"+OneCikan.LevelExpMax().ToString();
        walltokenfiyat.text="<sprite=17>"+OneCikan.SetWallStone[OneCikan.Level].ToString();eventileeldedilir.text=Lang.Get.EventIleEldeEdilir_new;
        sliderexp.maxValue=OneCikan.LevelExpMax();sliderexp.value=OneCikan.LevelExp;sliderexpadet.text=OneCikan.LevelExp.ToString()+"/"+OneCikan.LevelExpMax().ToString();
        usebtn.gameObject.SetActive(OneCikan.Level>=1&&heroController.currentMainWall!=HeroNum);upgradebtn.gameObject.SetActive(OneCikan.Level>0);eventileeldeedilirobj.gameObject.SetActive(OneCikan.Level==0);
        upgradebtn.interactable=OneCikan.Level<7;starup.text=OneCikan.Level<=6?Lang.Get.StarUp:"MAX";wallstone.text=Currencys.WallToken.ToString();
        if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._yemek);
	}

	public void Upgrade()
	{
        // Original ARM64 recovery 0x20517dc.
        OneCikan.LevelUp();SetHero(OneCikan.Num);
        if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._upgrade2);
	}

	public void Upgraded()
	{
        // Original ARM64 recovery 0x2050c04.
        if(animUpg!=null)animUpg.Play("Base Layer.talentshowanim",0,0f);
	}

	public void Use()
	{
        // Original ARM64 recovery 0x20518a8.
        OneCikan.Use();SetHero(OneCikan.Num);if(useeff!=null)useeff.Play();
        if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._finded);
        if(inventoryGearUI!=null)inventoryGearUI.wall_degisti=true;
	}

	public void SatinAlindi()
	{
        // Original ARM64 recovery 0x20519a0.
        if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._collecting);
	}

	public void OpenClose()
	{
        // Original ARM64 recovery 0x2051a48.
        gameObject.SetActive(!gameObject.activeInHierarchy);
        if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._close);
	}
}
