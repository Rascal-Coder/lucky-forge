using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftAndSell : MonoBehaviour
{
	private InventorySlot slot;

	private Commander ilkcommander;

	public TextMeshProUGUI sell;

	public TextMeshProUGUI sellprice;

	public TextMeshProUGUI merge;

	public Sprite[] coins;

	public Button mergebtn;

	public GameObject sellbtn;

	public GameObject[] sellbtnarrows;

	public float closetimer;

	private float[] satisfiyati = new float[]{30f,1f,2f,3f,4f};

	public WarController warController;

	private float opentimer;

	[Header("Info")]
	public GameObject InfoObj;

	public TextMeshProUGUI isim;

	public TextMeshProUGUI tipi;

	public TextMeshProUGUI cdpassive;

	public Image icon;

	public Image raritycolor;

	public Transform chooserskill;

	public TextMeshProUGUI atk;

	public TextMeshProUGUI artanAtk;

	public TextMeshProUGUI atkspeed;

	public TextMeshProUGUI critchance;

	public TextMeshProUGUI critdamage;

	public TextMeshProUGUI skilltitle;

	public TextMeshProUGUI skillsubtitle;

	public TextMeshProUGUI levelT;

	public Transform skillIconContent;

	public ParticleSystem sellparticle;

	public bool readytoopen()
	{
		// Native RVA0x21e5168. InventorySlot separately checks warController.pageAcik.
		return warController && warController.CastleHp >= 1L && warController.craftandsellopentimer >= 0.2f && !gameObject.activeInHierarchy;
	}

	private void OnEnable()
	{
		closetimer=0f;
		if(sellbtn) sellbtn.SetActive(GameManager.GuideDone);
		if(sellbtnarrows!=null) for(int i=0;i<System.Math.Min(2,sellbtnarrows.Length);i++) if(sellbtnarrows[i]) sellbtnarrows[i].SetActive(GameManager.GuideDone);
	}

	private void Start()
	{
		if(sell) sell.text=Lang.Get.sell;
	}

	private void Update()
	{
		closetimer+=Time.deltaTime;
		if(warController && warController.pageAcik) { closetimer=1f;Closeit(); }
	}

	public void OpenCraftSell(InventorySlot slotkim)
	{
		// Native RVA0x21e542c; preserves the original open/toggle checks and reset order.
		slot=slotkim;
		if(!slot || slot.commanders==null || slot.commanders.Count==0 || !warController || warController.CastleHp<1L || warController.craftandsellopentimer<0.2f || gameObject.activeInHierarchy) {
		    gameObject.SetActive(false);return;
		}
		closetimer=0f;warController.craftandsellopentimer=0f;
		gameObject.SetActive(true);transform.position=slot.transform.position;
		var first=slot.commanders[0];
		if(mergebtn) mergebtn.interactable=slot.commanders.Count==3 && first.Rarity!=WeaponRarity.Legendary;
		if(merge) merge.text=first.Rarity==WeaponRarity.Legendary || first.Rarity==WeaponRarity.Mystic ? "Max" : Lang.Get.merge;
		if(sellprice) {
		    int rarity=(int)slot.rarity;
		    sellprice.text=(rarity==0 ? "<sprite=\"MeduSprite\" index=7>" : "<sprite=\"MeduSprite3\" index=7>") + ((int)satisfiyati[rarity]).ToString();
		}
		OpenInfo();
	}

	public void Closeit()
	{
		// Native RVA0x21e5390: the timer gates only the main panel; info/range close unconditionally.
		if(closetimer>0.1f) gameObject.SetActive(false);
		if(InfoObj) InfoObj.SetActive(false);
		if(chooserskill) chooserskill.gameObject.SetActive(false);
		if(warController && warController.range) warController.range.gameObject.SetActive(false);
	}

	public void Sell()
	{
		// Native RVA0x21e5bc8. Requires the separately recovered InventorySlot.SellCommander.
		if(!slot || slot.commanders==null || slot.commanders.Count==0 || !warController) return;
		int rarity=(int)slot.rarity;
		if(rarity==0) warController.AddSilver(satisfiyati[0]);
		else warController.Addtoken((int)satisfiyati[rarity]);
		slot.SellCommander(coins[rarity==0?0:1]);
		if(mergebtn) mergebtn.interactable=slot.commanders.Count==3 && slot.commanders[0].Rarity!=WeaponRarity.Legendary;
		if(slot.commanders.Count>0) {if(sellparticle) sellparticle.Play();}
		else Closeit();
	}

	public void Merge()
	{
		// Native RVA0x21e5d48. InventorySlot owns all three-unit consumption and resulting rarity.
		if(!slot || !warController) return;
		SoundManager.TitretStatic();
		warController.craftandsellopentimer=0f;
		closetimer=1f;Closeit();
		slot.MergeCommanders();
	}

	private void OpenInfo()
	{
		// Native RVA0x21e57cc. Display uses sourceCommander, as in the original implementation.
		if(warController && warController.range) warController.range.gameObject.SetActive(true);
		if(InfoObj) InfoObj.SetActive(true);
		ilkcommander=slot.commanders[0].sourceCommander;
		if(!ilkcommander) return; // Missing recovery reference must not block opening/merging the real slot.
		if(isim) isim.text=ilkcommander.HeroName;
		if(tipi) tipi.text=ilkcommander.typetxt();
		if(icon && ilkcommander.icon) icon.sprite=ilkcommander.icon.sprite;
		if(raritycolor && warController.heroController) raritycolor.color=warController.heroController.rarityColors[(int)ilkcommander.Rarity];
		if(atk) atk.text=ilkcommander.ATK(true,0).ToString();
		if(atkspeed) atkspeed.text=ilkcommander.AtkSpeed().ToString();
		if(critchance) critchance.text=ilkcommander.CritChance().ToString()+"%";
		if(critdamage) critdamage.text=ilkcommander.CritMultipler().ToString()+"%";
		if(artanAtk) artanAtk.text="+"+ilkcommander.ATKBonusRogueLike(ilkcommander.ATK(true,0)).ToString();
		if(levelT) levelT.text=Lang.Get.lv+ilkcommander.Level;
		SkillSet();OpenSkillText(0);
	}

	private void SkillSet()
	{
		// Original ARM64 0x21e5d8c.
		var skills=ilkcommander.commanderSkills.skill;
		for(int i=0;i<skillIconContent.childCount;i++)
		{
		    var row=skillIconContent.GetChild(i);
		    if(i<skills.skillName.Length)
		    {
		        row.GetChild(0).GetChild(0).GetComponent<Image>().sprite=skills.skillicon[i];
		        row.gameObject.SetActive(true);
		        row.GetChild(1).gameObject.SetActive(skills.requiredLevel[i]>ilkcommander.Level);
		    }
		    else row.GetChild(1).gameObject.SetActive(false);
		}
	}

	public void OpenSkillText(int who)
	{
		// Original ARM64 0x21e5f9c.
		chooserskill.gameObject.SetActive(true);
		chooserskill.position=skillIconContent.GetChild(who).transform.position;
		var skills=ilkcommander.commanderSkills.skill;
		if(skills.requiredLevel[who]>ilkcommander.Level)
		    cdpassive.text=Lang.Get.seviye+" "+skills.requiredLevel[who].ToString()+" "+Lang.Get.required;
		else if(who!=0) cdpassive.text=Lang.Get.passive;
		else if(skills.cooldown>0f) cdpassive.text=Lang.Get.CD+": "+skills.cooldown.ToString("0.0")+" "+Lang.Get.saniyeuzun;
		else cdpassive.text=Lang.Get.Luck;
		skilltitle.text=ilkcommander.commanderSkills.activeSkills.NameT(who);
		skillsubtitle.text=ilkcommander.commanderSkills.activeSkills.SubtitleT(who);
	}
}
