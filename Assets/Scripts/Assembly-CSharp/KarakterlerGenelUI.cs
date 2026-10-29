using System.Linq;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KarakterlerGenelUI : MonoBehaviour
{
	public HeroController heroController;

	public HeroUpgradeSkinTek cloneObj;

	public Transform content;

	public BottomPages bottom;

	public GameObject summonPage;

	public RectTransform rect;

	private Dictionary<Commander, HeroUpgradeSkinTek> commanderToUI = new Dictionary<Commander, HeroUpgradeSkinTek>();

	private List<Commander> currentCommanders = new List<Commander>();

	private bool isRarityAscending = true;

	private bool isTypeAscending = true;

	public TextMeshProUGUI bylevel;

	public TextMeshProUGUI byrarity;

	public TextMeshProUGUI summon;

	public TextMeshProUGUI blacksmith;

	public TextMeshProUGUI weapons;

	public TextMeshProUGUI adet;

	public TextMeshProUGUI weapontokenadet;

	public bool forcerarityle;

	public Commander plasmashard;

	[Header("Rarity Arrows")]
	public GameObject rarityArrowUp;

	public GameObject rarityArrowDown;

	[Header("Level Arrows")]
	public GameObject typeArrowUp;

	public GameObject typeArrowDown;

	private void Start()
	{
		// Offline recovery candidate; native RVA 0x223de68.
		byrarity.text = Lang.Get.ByRarity;
		bylevel.text = Lang.Get.ByLevel;
		summon.text = Lang.Get.forge;
		blacksmith.text = Lang.Get.Blacksmith;
		weapons.text = Lang.Get.Weapons;
	}

	private void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x223dfd0.
		if (forcerarityle) { ForceForGuide(); forcerarityle = false; }
		if (ES3.KeyExists("Plasmaburstalindi") && plasmashard.Level == 0) plasmashard.AlindiDailyGift();
		rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, 0f);
		adetver();
		Guncelle();
		// Original analytics-only NewDesignEvent omitted by the offline adapter.
	}

	public void Cloneit()
	{
		// Offline recovery candidate; native RVA 0x223e728.
		currentCommanders = new List<Commander>(heroController.HeroCommanders);
		foreach (Commander commander in currentCommanders) {
		    HeroUpgradeSkinTek item = Instantiate(cloneObj, content);
		    item.transform.localScale = new Vector3(0.77f, 0.77f, 0.77f);
		    item.commander = commander;
		    item.icon.sprite = commander.icon.sprite;
		    item.gameObject.SetActive(true);
		    commanderToUI.Add(commander, item);
		}
		SortByRarity();
		SortByRarity();
	}

	public void Guncelle()
	{
		// Offline recovery candidate; native RVA 0x223e50c.
		weapontokenadet.text = "<sprite=8><color=#DFFFFF>" + Currencys.WeaponToken.ToString() + "</color>/50";
		foreach (HeroUpgradeSkinTek item in commanderToUI.Values) item.UpdateData();
	}

	public void SortByRarity()
	{
		// Offline recovery candidate; native RVA 0x223ea3c.
		isRarityAscending = !isRarityAscending;
		List<Commander> sorted = isRarityAscending
		    ? currentCommanders.OrderBy(c => c.Level == 0).ThenBy(c => c.Rarity).ToList()
		    : currentCommanders.OrderBy(c => c.Level == 0).ThenByDescending(c => c.Rarity).ToList();
		ApplySorting(sorted);
		UpdateArrowIcons("rarity");
	}

	public void ForceForGuide()
	{
		// Offline recovery candidate; native RVA 0x223e17c.
		ApplySorting(currentCommanders.OrderBy(c => c.Level == 0).ThenBy(c => c.Rarity).ToList());
	}

	public void ForceSortingGuide2()
	{
		// Offline recovery candidate; native RVA 0x223efb4.
		ApplySorting(currentCommanders.OrderBy(c => c.Level == 0).ThenByDescending(c => c.Rarity).ToList());
	}

	public void SortByLvl()
	{
		// Offline recovery candidate; native RVA 0x223f1a0.
		isTypeAscending = !isTypeAscending;
		ApplySorting(isTypeAscending ? currentCommanders.OrderBy(c => c.Level).ToList() : currentCommanders.OrderByDescending(c => c.Level).ToList());
		UpdateArrowIcons("level");
	}

	private void ApplySorting(List<Commander> sortedList)
	{
		// Offline recovery candidate; native RVA 0x223eda4.
		for (int i = 0; i < sortedList.Count; i++) commanderToUI[sortedList[i]].transform.SetSiblingIndex(i);
	}

	public void adetver()
	{
		// Offline recovery candidate; native RVA 0x223e368.
		adet.text = heroController.HeroCommanders.Count(c => c != null && c.Level > 0).ToString() + "/" + heroController.HeroCommanders.Count.ToString();
	}

	private void UpdateArrowIcons(string criteria)
	{
		// Offline recovery candidate; native RVA 0x223ee84.
		if (criteria == "rarity") { rarityArrowUp.SetActive(isRarityAscending); rarityArrowDown.SetActive(!isRarityAscending); }
		else if (criteria == "level") { typeArrowUp.SetActive(isTypeAscending); typeArrowDown.SetActive(!isTypeAscending); }
	}

	public void goSummon()
	{
		// Offline recovery candidate; native RVA 0x223f3a8.
		SoundManager.instance.RandomizeSfx(new[] { SoundManager._click });
		summonPage.SetActive(true);
	}
}
