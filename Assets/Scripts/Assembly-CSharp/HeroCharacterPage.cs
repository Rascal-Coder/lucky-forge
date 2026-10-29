using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroCharacterPage : MonoBehaviour
{
	public TextMeshProUGUI headname;

	public Transform stars;

	public TextMeshProUGUI characterskill;

	public TextMeshProUGUI characterskillsub;

	public Image skillicon;

	public TextMeshProUGUI solstar;

	public TextMeshProUGUI sagstar;

	public TextMeshProUGUI suankiyuzde;

	public TextMeshProUGUI sonrakiyuzde;

	public TextMeshProUGUI starup;

	public TextMeshProUGUI coinfiyat;

	public TextMeshProUGUI herostonefiyat;

	public TextMeshProUGUI use;

	public TextMeshProUGUI satinalimfiyati;

	public Button satinalimbtn;

	public TextMeshProUGUI unlocktxt;

	public Button usebtn;

	public Button upgradebtn;

	public Image[] characterSet;

	public TextMeshProUGUI heroes;

	public HeroController heroController;

	public TextMeshProUGUI herostone;

	public InventoryGearUI inventoryGearUI;

	public ParticleSystem useeff;

	public Animator animUpg;

	public Animator animChar;

	public Animator animPage;

	private MainHero OneCikan;

	public BolumOdulleri bolumOdulleri;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnEnable()
	{
        // Original ARM64 recovery 0x221ed2c.
        herostone.text=Currencys.HeroStone.ToString();
        SetHero(heroController.MainHeroNum);
	}

	public void SetHero(int HeroNum)
	{
        // Original ARM64 recovery 0x221ee0c.
        OneCikan=heroController.mainHeroes[HeroNum];
        headname.text=OneCikan.HeroName;
        for(int i=0;i<7;i++)stars.GetChild(i).GetChild(0).gameObject.SetActive(i<OneCikan.Level);
        int[] map={0,1,2,3,4,5,2,3,4,5};
        for(int i=0;i<10;i++)characterSet[i].sprite=OneCikan.iconSet[map[i]];
        characterskill.text=Lang.Get.CharacterSkill;unlocktxt.text=Lang.Get.Unlock;use.text=Lang.Get.Choose;heroes.text=Lang.Get.Heroes;
        characterskillsub.text=OneCikan.heroSkillSubtitle();skillicon.sprite=OneCikan.heroSkillIcon;
        solstar.text=OneCikan.Level.ToString();sagstar.text=unchecked(OneCikan.Level+1).ToString();
        suankiyuzde.text=OneCikan.Yuzde().ToString()+"%";sonrakiyuzde.text=OneCikan.Yuzde(1).ToString()+"%";
        coinfiyat.text="<sprite=0>"+ShortScaleString.parseDouble(OneCikan.GoldCoinFiyati(),1,1000000d,false);
        herostonefiyat.text="<sprite=9>"+OneCikan.HeroStoneGelistirmeFiyati().ToString();
        satinalimfiyati.text="<sprite=1>"+OneCikan.SatinAlimCrystalFiyati.ToString();
        usebtn.gameObject.SetActive(OneCikan.Level>=1&&heroController.currentMainHero!=OneCikan);
        upgradebtn.gameObject.SetActive(OneCikan.Level>0);satinalimbtn.gameObject.SetActive(OneCikan.Level==0);
        upgradebtn.interactable=OneCikan.isUpgradeable();starup.text=OneCikan.isUpgradeable()?Lang.Get.StarUp:"MAX";
        herostone.text=Currencys.HeroStone.ToString();
        if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._yemek);
	}

	public void Upgrade()
	{
        // Original ARM64 recovery 0x221f7e4.
        OneCikan.LevelUp();SetHero(OneCikan.HeroNum);
        if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._upgrade2);
	}

	public void Upgraded()
	{
        // Original ARM64 recovery 0x221f8b4.
        if(animChar!=null)animChar.Play("Base Layer.heroopened",0,0f);
        if(animUpg!=null)animUpg.Play("Base Layer.talentshowanim",0,0f);
	}

	public void Use()
	{
        // Original ARM64 recovery 0x221f940.
        OneCikan.Use();SetHero(OneCikan.HeroNum);
        if(inventoryGearUI!=null)inventoryGearUI.HeroGoster();
        if(useeff!=null)useeff.Play();if(bolumOdulleri!=null)bolumOdulleri.CharChanged();
        if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._finded);
        if(inventoryGearUI!=null)inventoryGearUI.character_degisti=true;
	}

	public void SatinAl()
	{
        // Original ARM64 recovery 0x221fa5c.
        OneCikan.SatinAl();SetHero(OneCikan.HeroNum);
        if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._upgrade);
	}

	public void SatinAlindi()
	{
        // Original ARM64 recovery 0x221fb2c.
        if(animChar!=null)animChar.Play("Base Layer.heroopened",0,0f);
        if(animPage!=null)animPage.Play("Base Layer.Characterpagesatinalindi",0,0f);
        if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._collecting);
	}

	public void OpenClose()
	{
        // Original ARM64 recovery 0x221fc38.
        gameObject.SetActive(!gameObject.activeInHierarchy);
        if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._close);
	}
}
