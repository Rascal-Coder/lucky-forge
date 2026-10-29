using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PetPage : MonoBehaviour
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

	public TextMeshProUGUI damagetxt;

	public TextMeshProUGUI damagekac;

	public TextMeshProUGUI atkspeedtxt;

	public TextMeshProUGUI atkspeedkac;

	public InventoryGearUI inventoryGearUI;

	private Pet OneCikan;

	private void Start()
	{
		// Offline recovery candidate; native RVA 0x2021b18.
		damagetxt.text = Lang.Get.damage;
		atkspeedtxt.text = Lang.Get.cooldown;
	}

	private void Update()
	{
	}

	private void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x2021be4.
		wallstone.text = Currencys.PetFood.ToString();
		SetHero(Mathf.Max(heroController.currentMainPet,0));
	}

	public void SetHero(int HeroNum)
	{
		// Offline recovery candidate; native RVA 0x2021cc8.
		OneCikan = heroController.Pets[HeroNum];
		headname.text = OneCikan.PetName;
		for (int i=0; i<7; i++) stars.GetChild(i).GetChild(0).gameObject.SetActive(OneCikan.Level > i);
		for (int i=0; i<characterSet.childCount; i++) characterSet.GetChild(i).gameObject.SetActive(i == HeroNum);
		characterskill.text = Lang.Get.pets_new;
		use.text = Lang.Get.Choose;
		heroes.text = Lang.Get.pets;
		characterskillsub.text = OneCikan.SkillSubtitle();
		solstar.text = OneCikan.Level.ToString();
		sagstar.text = unchecked(OneCikan.Level+1).ToString();
		suankiyuzde.text = OneCikan.Bonus(0).ToString() + OneCikan.DegerSonu;
		sonrakiyuzde.text = OneCikan.Bonus(1).ToString() + OneCikan.DegerSonu;
		expfiyat.text = "<sprite=6>" + OneCikan.LevelExp.ToString() + "/" + OneCikan.LevelExpMax().ToString();
		walltokenfiyat.text = "<sprite=18>" + OneCikan.SetPetStone[OneCikan.Level].ToString();
		eventileeldedilir.text = Lang.Get.EventIleEldeEdilir_new;
		sliderexp.maxValue = OneCikan.LevelExpMax();
		sliderexp.value = OneCikan.LevelExp;
		sliderexpadet.text = OneCikan.LevelExp.ToString() + "/" + OneCikan.LevelExpMax().ToString();
		atkspeedkac.text = OneCikan.ShowAtkSpeed().ToString("0.0") + "/" + Lang.Get.kisaltmasaniye;
		damagekac.text = OneCikan.PetAtk().ToString() + "%";
		usebtn.gameObject.SetActive(OneCikan.Level >= 1 && heroController.currentMainPet != HeroNum);
		upgradebtn.gameObject.SetActive(OneCikan.Level > 0);
		eventileeldeedilirobj.gameObject.SetActive(OneCikan.Level == 0);
		upgradebtn.interactable = OneCikan.Level < 7;
		starup.text = OneCikan.Level <= 6 ? Lang.Get.StarUp : "MAX";
		wallstone.text = Currencys.PetFood.ToString();
		SoundManager.instance.RandomizeSfx(SoundManager._yemek);
	}

	public void Upgrade()
	{
		// Offline recovery candidate; native RVA 0x20225a0.
		OneCikan.LevelUp();
		SetHero(OneCikan.Num);
		SoundManager.instance.RandomizeSfx(SoundManager._upgrade2);
	}

	public void Upgraded()
	{
		// Offline recovery candidate; native RVA 0x2020590.
		animUpg.Play("Base Layer.talentshowanim",0,0f);
	}

	public void Use()
	{
		// Offline recovery candidate; native RVA 0x202266c.
		OneCikan.Use();
		SetHero(OneCikan.Num);
		useeff.Play();
		SoundManager.instance.RandomizeSfx(SoundManager._finded);
		inventoryGearUI.pet_degisti = true;
	}

	public void SatinAlindi()
	{
		// Offline recovery candidate; native RVA 0x2022764.
		SoundManager.instance.RandomizeSfx(SoundManager._collecting);
	}

	public void OpenClose()
	{
		// Offline recovery candidate; native RVA 0x202280c.
		gameObject.SetActive(!gameObject.activeInHierarchy);
		SoundManager.instance.RandomizeSfx(SoundManager._close);
	}
}
