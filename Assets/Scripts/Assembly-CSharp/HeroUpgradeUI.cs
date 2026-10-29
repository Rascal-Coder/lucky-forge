using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroUpgradeUI : MonoBehaviour
{
	public class PerkOrSkill
	{
		public int level;

		public string name;

		public float value;

		public bool isSkill;

		public PerkOrSkill(int level, string name, float value, bool isSkill)
		{
		// Offline recovery candidate; native RVA 0x2224e60.
		this.level = level;
		this.name = name;
		this.value = value;
		this.isSkill = isSkill;
	}
	}

	public Sprite[] skillIcons;

	public GameManager gameManager;

	public HeroController heroController;

	public Image backgroundImg;

	public Image[] backgroundImgColors;

	public Vector3[] backgroundImgPos;

	public TextMeshProUGUI heroname;

	public TextMeshProUGUI rarity;

	public TextMeshProUGUI type;

	public Image[] rarityColor;

	public TextMeshProUGUI herolevel;

	public Slider adetslider;

	public TextMeshProUGUI adetkac;

	public GameObject sliderUpArrow;

	public TextMeshProUGUI heroatk;

	public TextMeshProUGUI heroatkspeed;

	public TextMeshProUGUI herocrit;

	public TextMeshProUGUI herocritdmg;

	public TextMeshProUGUI heroatktxt;

	public TextMeshProUGUI heroatkspeedtxt;

	public TextMeshProUGUI herocrittxt;

	public TextMeshProUGUI herocritdmgtxt;

	public Image heroParenticon;

	public TextMeshProUGUI upgradetxt;

	public TextMeshProUGUI skilsraritytxt;

	public TextMeshProUGUI levelingperkstxt;

	public Commander OneCikanCommander;

	public Button upgBtn;

	public Button crystalileAlBtn;

	public TextMeshProUGUI crystalilealfiyat;

	public Button starterPackileAlBtn;

	public TextMeshProUGUI starterilealfiyat;

	public Button dailyWarileAlBtn;

	public TextMeshProUGUI dailyWarileAlBtnfiyat;

	public Button inappileAlBtn;

	public TextMeshProUGUI inappileAlBtnfiyat;

	public TextMeshProUGUI attackPowerKacArtiyor;

	public HeroUpgradeSkinTek _skinTekUI;

	public Transform perksContent;

	private int SonBakilanCommander = -1;

	public GameObject[] insidePages;

	public Image[] bottomBtns;

	public TextMeshProUGUI statstxt;

	public TextMeshProUGUI perkstxt;

	public Transform bottombtnlight;

	public EquipmentUiGeneral equipmentUi;

	public Animator _animUpg;

	public BottomPages bottomPages;

	public OneTimeOffer onetimeoffer;

	public GunlukWars _gunlukWars;

	public DungeonUi _dungeonUi;

	public TextMeshProUGUI mistikCoinTotal;

	public TextMeshProUGUI mistikCoinFiyat;

	public TextMeshProUGUI upgradepricetxt;

	[Header("Arrows")]
	public GameObject[] SagSolArrows;

	public KarakterlerGenelUI karakterlerGenelUI;

	[Header("skills")]
	public Transform skillContent;

	public Transform skillInfo;

	public TextMeshProUGUI skilltitle;

	public TextMeshProUGUI skillsubtitle;

	public TextMeshProUGUI levelreqareaCD;

	public Transform mergeVarsa;

	public GameObject favorite;

	public GameObject favoriteStar;

	public TextMeshProUGUI newskillunlocked;

	public Image newskillunlockedicon;

	public GameObject newskillunlockedobj;

	public FalseDestroyLater newskillfalser;

	private bool upgradeyapildi;

	public int acilantransformsbling;

	public GameObject buttonReset;

	public MistikResetUi mistikResetUi;

	public GameObject forgenoresourcesOBJ;

	private int MistikCoinPrice()
	{
		// Offline recovery candidate; native RVA 0x2222608.
		return heroController.MistikRequirement[OneCikanCommander.Level];
	}

	public void Favoriteit()
	{
		// Offline recovery candidate; native RVA 0x222264c.
		OneCikanCommander.Favorite();
		favoriteStar.gameObject.SetActive(OneCikanCommander.MyFavorite);
		_skinTekUI.UpdateData();
	}

	private void Start()
	{
		// Offline recovery candidate; native RVA 0x22226a0.
		upgradetxt.text = Lang.Get.gelistir;
		heroatkspeedtxt.text = Lang.Get.atkspeed;
		heroatktxt.text = Lang.Get.Attack;
		herocrittxt.text = Lang.Get.CritChance;
		herocritdmgtxt.text = Lang.Get.CritDamage;
		statstxt.text = Lang.Get.stats;
		perkstxt.text = Lang.Get.perks;
		skilsraritytxt.text = Lang.Get.SkillsAndStats_new;
		levelingperkstxt.text = Lang.Get.LevelingPerks_new;
	}

	private void MergeAlaniHazirla()
	{
		// Offline recovery candidate; native RVA 0x222290c.
		if ((int)OneCikanCommander.Rarity != 4) { mergeVarsa.gameObject.SetActive(false); return; }
		mergeVarsa.gameObject.SetActive(true);
		for (int i = 0; i < 4; i++) {
		    if (i < OneCikanCommander.RequiredCommander.Count) {
		        Commander required = OneCikanCommander.RequiredCommander[i];
		        Transform child = mergeVarsa.GetChild(i);
		        mergeVarsa.GetChild(i).gameObject.SetActive(true);
		        mergeVarsa.GetChild(i).GetChild(1).GetComponent<Image>().sprite = required.icon.sprite;
		        child.GetComponent<Image>().color = heroController.rarityColors[(int)required.Rarity];
		    } else mergeVarsa.GetChild(i).gameObject.SetActive(false);
		}
		mergeVarsa.GetChild(4).GetChild(1).GetComponent<Image>().sprite = OneCikanCommander.icon.sprite;
	}

	public void OpenInsidePage(int who)
	{
		// Offline recovery candidate; native RVA 0x2222bac.
		for (int i = 0; i < insidePages.Length; i++) {
		    insidePages[i].SetActive(i == who);
		    if (i == who) {
		        bottombtnlight.position = bottomBtns[who].transform.position;
		        bottomBtns[who].color = new Color(0.8980392217636108f, 0.7882353067398071f, 0.6313725709915161f, 1f);
		    } else bottomBtns[i].color = new Color(0.42352941632270813f, 0.2823529541492462f, 0.21960784494876862f, 1f);
		}
		skillInfo.gameObject.SetActive(false);
	}

	private void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x2222d68.
		OpenInsidePage(0);
		if (OneCikanCommander != null) {
		    if (OneCikanCommander.Level == 0 && OneCikanCommander.StarterPackile && ES3.KeyExists("StarterPack")) OneCikanCommander.AlindiDailyGift();
		    if (OneCikanCommander.Level == 1 && OneCikanCommander.HeroNum == 0 && OneCikanCommander.LevelExp <= 4) {
		        OneCikanCommander.LevelExp = 5;
		        DataUpdateOneCikan();
		    }
		}
	}

	private void OnDisable()
	{
		// Offline recovery candidate; native RVA 0x2222e70.
		// Original single RET.
	}

	public void OpenMistikReset()
	{
	}

	public void DataUpdateOneCikan()
	{
		// Offline recovery candidate; native RVA 0x22213f8.
		buttonReset.SetActive(OneCikanCommander.Level >= 2 && OneCikanCommander.IsMystic && GameManager.Level > 1);
		newskillunlockedobj.SetActive(false);
		skillInfo.gameObject.SetActive(false);
		newskillfalser.timer = 0f;
		favorite.SetActive(OneCikanCommander.IsMystic && OneCikanCommander.Level > 0);
		favoriteStar.SetActive(OneCikanCommander.MyFavorite);
		heroParenticon.sprite = OneCikanCommander.icon.sprite;
		heroname.text = OneCikanCommander.HeroName;
		herolevel.text = Lang.Get.lv + " " + OneCikanCommander.Level.ToString();
		adetkac.text = OneCikanCommander.LevelExp.ToString() + "/" + OneCikanCommander.LevelExpMax().ToString();
		adetslider.maxValue = OneCikanCommander.LevelExpMax();
		adetslider.value = OneCikanCommander.LevelExp;
		adetslider.gameObject.SetActive(!OneCikanCommander.IsMystic);
		int typeIndex = OneCikanCommander.IsMystic ? 5 : (int)OneCikanCommander.Type;
		backgroundImg.sprite = heroController.typeBackgrounds[typeIndex];
		backgroundImg.rectTransform.anchoredPosition = backgroundImgPos[typeIndex];
		foreach (Image image in backgroundImgColors) image.color = heroController.typeBackgroundColors[typeIndex];
		SkillSet();
		rarity.text = OneCikanCommander.raritytxt();
		type.text = OneCikanCommander.typetxt();
		rarityColor[0].color = heroController.rarityColors[(int)OneCikanCommander.Rarity];
		rarityColor[1].color = heroController.rarityColors[(int)OneCikanCommander.Rarity];
		sliderUpArrow.SetActive(OneCikanCommander.LevelExp >= OneCikanCommander.LevelExpMax());
		OneCikanCommander.CalculateBonuses();
		PerksData();
		heroatk.text = ShortScaleString.parseDouble(OneCikanCommander.ATK(false, 0), 1, 1000000.0, false);
		heroatkspeed.text = OneCikanCommander.AtkSpeed().ToString("0.0");
		herocrit.text = OneCikanCommander.CritChance().ToString("0.0") + "%";
		herocritdmg.text = OneCikanCommander.CritMultipler().ToString("0.0") + "%";
		skillInfo.gameObject.SetActive(false);
		upgradepricetxt.text = OneCikanCommander.Level < OneCikanCommander.MaxLevel ? "<sprite=0>" + OneCikanCommander.UpgradePrice().ToString() : "MAX";
		if (OneCikanCommander.IsMystic) upgBtn.interactable = Currencys.Coin >= OneCikanCommander.UpgradePrice() && OneCikanCommander.Level < OneCikanCommander.MaxLevel && MistikCoinPrice() <= Currencys.MistikToken;
		else upgBtn.interactable = Currencys.Coin >= OneCikanCommander.UpgradePrice() && OneCikanCommander.Level < OneCikanCommander.MaxLevel && OneCikanCommander.LevelExp >= OneCikanCommander.LevelExpMax() && OneCikanCommander.Level != 0;
		if (upgBtn.interactable && OneCikanCommander.Level >= 1) {
		    attackPowerKacArtiyor.text = "+" + ShortScaleString.parseDouble(unchecked(OneCikanCommander.ATK(false, 1) - OneCikanCommander.ATK(false, 0)), 1, 1000000.0, false) + " " + Lang.Get.Attack;
		    attackPowerKacArtiyor.gameObject.SetActive(true);
		} else attackPowerKacArtiyor.gameObject.SetActive(false);
		crystalileAlBtn.interactable = Currencys.Crystal >= OneCikanCommander.CrystalPrice;
		if (OneCikanCommander.Level != 0) {
		    upgBtn.gameObject.SetActive(true);
		    crystalileAlBtn.gameObject.SetActive(false);
		    starterPackileAlBtn.gameObject.SetActive(false);
		    inappileAlBtn.gameObject.SetActive(false);
		    dailyWarileAlBtn.gameObject.SetActive(false);
		} else {
		    crystalileAlBtn.gameObject.SetActive(OneCikanCommander.CrystalPrice >= 1 && !OneCikanCommander.StarterPackile && !OneCikanCommander.DailyWarile && GameManager.Level > 2);
		    starterPackileAlBtn.gameObject.SetActive(OneCikanCommander.StarterPackile && GameManager.Level > 2);
		    inappileAlBtn.gameObject.SetActive(OneCikanCommander.inappile && GameManager.Level > 2);
		    dailyWarileAlBtn.gameObject.SetActive(OneCikanCommander.DailyWarile && GameManager.Level > 16);
		    crystalilealfiyat.text = "<sprite=1>" + OneCikanCommander.CrystalPrice.ToString();
		    starterilealfiyat.text = Lang.Get.obtainhero;
		    inappileAlBtnfiyat.text = Lang.Get.obtainhero;
		    dailyWarileAlBtnfiyat.text = Lang.Get.obtainhero;
		    upgBtn.gameObject.SetActive(false);
		}
		mistikCoinFiyat.transform.parent.gameObject.SetActive(OneCikanCommander.IsMystic);
		mistikCoinTotal.transform.parent.gameObject.SetActive(OneCikanCommander.IsMystic);
		mistikCoinFiyat.text = "<sprite=12>" + MistikCoinPrice().ToString();
		MergeAlaniHazirla();
		_skinTekUI.UpdateData();
		mistikCoinTotal.text = Currencys.MistikToken.ToString();
		SagSolArrows[0].SetActive(karakterlerGenelUI.content.childCount != acilantransformsbling + 1 && GameManager.GuideDone && !GuideManagerRPG.guidedevamediyor);
		SagSolArrows[1].SetActive(acilantransformsbling != 0 && GameManager.GuideDone && !GuideManagerRPG.guidedevamediyor);
	}

	private void SkillSet()
	{
		// Offline recovery candidate; native RVA 0x2222f34.
		for (int i = 0; i < skillContent.childCount; i++) {
		    if (i < OneCikanCommander.commanderSkills.skill.skillName.Length) {
		        skillContent.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>().sprite = OneCikanCommander.commanderSkills.skill.skillicon[i];
		        skillContent.GetChild(i).gameObject.SetActive(true);
		        skillContent.GetChild(i).GetChild(1).gameObject.SetActive(OneCikanCommander.commanderSkills.skill.requiredLevel[i] > OneCikanCommander.Level);
		    } else skillContent.GetChild(i).GetChild(1).gameObject.SetActive(false);
		}
	}

	public void CloseskillText()
	{
		// Offline recovery candidate; native RVA 0x2223df0.
		skillInfo.gameObject.SetActive(false);
	}

	public void OpenSkillText(int who)
	{
		// Offline recovery candidate; native RVA 0x2223e1c.
		Skill skill = OneCikanCommander.commanderSkills.skill;
		if (skill.requiredLevel[who] > OneCikanCommander.Level) levelreqareaCD.text = Lang.Get.seviye + " " + skill.requiredLevel[who].ToString() + " " + Lang.Get.required;
		else if (who == 0 && skill.cooldown != 0f) levelreqareaCD.text = Lang.Get.cooldown + ": " + skill.cooldown.ToString("0.0") + " " + Lang.Get.saniyeuzun;
		else levelreqareaCD.text = Lang.Get.passive;
		skilltitle.text = OneCikanCommander.commanderSkills.activeSkills.NameT(who);
		skillsubtitle.text = OneCikanCommander.commanderSkills.activeSkills.SubtitleT(who);
		skillInfo.position = skillContent.GetChild(who).transform.position;
		skillInfo.gameObject.SetActive(!skillInfo.gameObject.activeInHierarchy);
	}

	public void UpgradeHero()
	{
		// Offline recovery candidate; native RVA 0x22242dc.
		upgradeyapildi = true;
		int oldLevel = OneCikanCommander.Level;
		bool mystic = OneCikanCommander.IsMystic;
		if (mystic) {
		    if (!(Currencys.Coin >= OneCikanCommander.UpgradePrice()) || OneCikanCommander.Level >= OneCikanCommander.MaxLevel || MistikCoinPrice() > Currencys.MistikToken) return;
		    Currencys.SpendCoin(OneCikanCommander.UpgradePrice(), "Meta", "WeaponUpgrade");
		    Currencys.SpendMistikToken(MistikCoinPrice(), "Meta", "WeaponUpgrade");
		    OneCikanCommander.MistikLevelUp();
		} else {
		    if (!(Currencys.Coin >= OneCikanCommander.UpgradePrice()) || OneCikanCommander.Level == 0 || OneCikanCommander.Level >= OneCikanCommander.MaxLevel) return;
		    Currencys.SpendCoin(OneCikanCommander.UpgradePrice(), "Meta", "WeaponUpgrade");
		    OneCikanCommander.LevelArttir();
		}
		int newLevel = OneCikanCommander.Level;
		DataUpdateOneCikan();
		gameManager.ShowDPS();
		_animUpg.Play("Base Layer.SkinUpgradeAnim", 0, 0f);
		GunlukGorevler.UpdateTaskProgressK(mystic ? 5 : 4, 1);
		ClanTaskLocal.ClanTaskPointEkle(7, 1);
		for (int i = 0; i < OneCikanCommander.commanderSkills.skill.requiredLevel.Length; i++) {
		    int required = OneCikanCommander.commanderSkills.skill.requiredLevel[i];
		    if (required > oldLevel && required <= newLevel) ShowNewSkillUnlocked(OneCikanCommander.commanderSkills.activeSkills.NameT(i), i);
		}
		if (mystic) SoundManager.instance.AmbienceEffectSfx(new[] { SoundManager.levelup });
		SoundManager.instance.CashSound(new[] { SoundManager.herostone });
	}

	public void ObtainWithCrystal()
	{
	}

	public void ObtainWithStarterPack()
	{
	}

	public void ObtainWithDailyWars()
	{
	}

	public void ObtainWithinapp()
	{
	}

	private void ShowNewSkillUnlocked(string skillName, int index)
	{
		// Offline recovery candidate; native RVA 0x22248e8.
		newskillunlockedobj.SetActive(true);
		newskillunlocked.text = skillName + " " + Lang.Get.Unlocked + "!";
		newskillunlockedicon.sprite = OneCikanCommander.commanderSkills.skill.skillicon[index];
		SoundManager.instance.RandomizeSfx(new[] { SoundManager._meteorduser });
	}

	public void Close(bool buyuk = false)
	{
		// Offline recovery candidate; native RVA 0x2224cc0.
		if (buyuk && GameManager.Level < 4) return;
		if (upgradeyapildi) heroController.karakterlerUi.Guncelle();
		gameObject.SetActive(false);
		SoundManager.instance.RandomizeSfx(new[] { SoundManager._close });
	}

	private void PerksData()
	{
		// Offline recovery candidate; native RVA 0x2223144.
		for (int i = 0; i < perksContent.childCount; i++) perksContent.GetChild(i).gameObject.SetActive(false);
		var entries = new System.Collections.Generic.List<PerkOrSkill>();
		foreach (Perk perk in OneCikanCommander.perks) entries.Add(new PerkOrSkill(perk.level, Lang.GetHeroPerks(perk.stat), perk.value, false));
		foreach (SkillInstance instance in OneCikanCommander.commanderSkills.skillInstances) {
		    for (int i = 0; i < instance.skill.requiredLevel.Length; i++) entries.Add(new PerkOrSkill(instance.skill.requiredLevel[i], Lang.Get.unlock + ": " + instance.NameT(i), 0f, true));
		}
		entries.Sort((a, b) => a.level.CompareTo(b.level));
		int row = 0;
		foreach (PerkOrSkill entry in entries) {
		    GameObject item = perksContent.GetChild(row).gameObject;
		    item.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = Lang.Get.lv + entry.level.ToString();
		    TextMeshProUGUI label = item.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
		    label.text = entry.name + (!entry.isSkill && entry.value > 0f ? string.Format(" +{0}%", entry.value) : "");
		    if (entry.isSkill) label.color = new Color(223f, 255f, 0f, 255f);
		    item.GetComponent<CanvasGroup>();
		    Image image = item.GetComponent<Image>();
		    if (OneCikanCommander.Level < entry.level) {
		        item.transform.GetChild(2).gameObject.SetActive(false);
		        item.transform.GetChild(3).gameObject.SetActive(true);
		        image.color = new Color(0.32156863808631897f, 0.27450981736183167f, 0.2666666805744171f, 1f);
		    } else {
		        item.transform.GetChild(2).gameObject.SetActive(true);
		        item.transform.GetChild(3).gameObject.SetActive(false);
		        image.color = new Color(0.7019608020782471f, 0.7843137383460999f, 0.12156862765550613f, 1f);
		    }
		    item.SetActive(true);
		    row++;
		}
		SonBakilanCommander = OneCikanCommander.HeroNum;
	}

	public void SagaSolaGit(int val)
	{
		// Offline recovery candidate; native RVA 0x2224ebc.
		acilantransformsbling = Mathf.Min(Mathf.Max(unchecked(acilantransformsbling + val), 0), karakterlerGenelUI.content.childCount - 1);
		karakterlerGenelUI.content.GetChild(acilantransformsbling).GetComponent<HeroUpgradeSkinTek>().OpenIt();
		SoundManager.instance.RandomizeSfx(new[] { SoundManager._click });
	}

	public void ForgeClose()
	{
		// Offline recovery candidate; native RVA 0x2224fe0.
		forgenoresourcesOBJ.SetActive(false);
		SoundManager.instance.RandomizeSfx(new[] { SoundManager._click });
	}

	public void GoForge()
	{
		// Offline recovery candidate; native RVA 0x22250a0.
		forgenoresourcesOBJ.SetActive(false);
		SoundManager.instance.RandomizeSfx(new[] { SoundManager._click });
		Close(false);
		karakterlerGenelUI.goSummon();
	}

	public void OpenForgeResources()
	{
		// Offline recovery candidate; native RVA 0x2225184.
		if (OneCikanCommander.IsMystic) return;
		if (OneCikanCommander.LevelExp < OneCikanCommander.LevelExpMax()) {
		    forgenoresourcesOBJ.SetActive(true);
		    SoundManager.instance.RandomizeSfx(new[] { SoundManager._click });
		} else if (Currencys.Coin < OneCikanCommander.UpgradePrice()) gameManager.canvasJobs.OpenGoldYok(0);
	}
}
