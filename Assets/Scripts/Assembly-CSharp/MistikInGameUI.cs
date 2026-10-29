using System.Linq;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MistikInGameUI : MonoBehaviour
{
	[Header("SolPanel")]
	public Transform mistikPrefab;

	public Transform MysticListContent;

	public CommanderSpawner spawner;

	public HeroController heroController;

	public WarController warController;

	public TextMeshProUGUI mystictxt;

	public TextMeshProUGUI choosen_MysticName;

	public TextMeshProUGUI YuzdeKac;

	public TextMeshProUGUI requiredWeapons;

	public Transform requiredContent;

	public Image choosen_MysticIcon;

	public TextMeshProUGUI crafttxt;

	public Button craftBtn;

	private MistikInGameTekliUI OneCikanCommander;

	public GameObject favoriteparent;

	public GameObject favoriteObj;

	public MysticFavorites mysticFavorites;

	private bool[] guideicinMatchCheck = new bool[4];

	public readonly Dictionary<WeaponRarity, float> rarityToCommonValue = new Dictionary<WeaponRarity, float> { {(WeaponRarity)0, 1f}, {(WeaponRarity)1, 3f}, {(WeaponRarity)2, 9f}, {(WeaponRarity)3, 27f}, {(WeaponRarity)4, 81f} };

	public List<MistikInGameTekliUI> SolList = new List<MistikInGameTekliUI>();

	private bool guidedone;

	private bool[] done = new bool[3];

	private List<Commander> active => spawner.activeCommanders; // Native getter 0x20152d0.

	private void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x2013950.
		favoriteparent.SetActive(GameManager.Level > 2);
		mystictxt.text = Lang.Get.mystic;
		requiredWeapons.text = Lang.Get.requiredweapon;
		crafttxt.text = Lang.Get.craft;
		foreach (MistikInGameTekliUI item in SolList) item.UpdateData();
		if (OneCikanCommander == null) OneCikar(MysticListContent.GetChild(0).GetComponent<MistikInGameTekliUI>());
		else OneCikar(OneCikanCommander);
		SolPanelTiklandi();
		SortSolListByFavorite();
		mysticFavorites.infoMystics.SetActive(false);
	}

	public void SortSolListByFavorite()
	{
		// Offline recovery candidate; native RVA 0x2013c68.
		var sorted = SolList.OrderByDescending(item => item.commander.MyFavorite).ToList();
		for (int i = 0; i < sorted.Count; i++) sorted[i].transform.SetSiblingIndex(i);
	}

	public void InitHere()
	{
		// Offline recovery candidate; native RVA 0x2013e04.
		foreach (Transform child in MysticListContent) Destroy(child.gameObject);
		SolList.Clear();
		var available = new List<Commander>();
		foreach (Commander commander in heroController.HeroCommanders) if ((int)commander.Rarity == 4 && commander.Level >= 1) available.Add(commander);
		foreach (Commander commander in available) {
		    MistikInGameTekliUI item = Instantiate(mistikPrefab, MysticListContent).GetComponent<MistikInGameTekliUI>();
		    item.InitWeapon(commander, this);
		    SolList.Add(item);
		}
	}

	public void OneCikar(MistikInGameTekliUI mistikUI)
	{
		// Offline recovery candidate; native RVA 0x2013268.
		OneCikanCommander = mistikUI;
		choosen_MysticName.text = mistikUI.commander.HeroName;
		YuzdeKac.text = mistikUI.yuzdekac.ToString() + "%";
		favoriteObj.gameObject.SetActive(mistikUI.commander.MyFavorite);
		List<Commander> required = mistikUI.commander.RequiredCommander;
		var available = new List<Commander>(mistikUI.sahipOlunan);
		for (int i = 0; i < 4; i++) {
		    if (i < required.Count) {
		        Commander requirement = required[i];
		        Transform slot = requiredContent.GetChild(i);
		        Commander match = available.FirstOrDefault(c => c.HeroNum == requirement.HeroNum);
		        bool hasMatch = match != null;
		        UpdateRequirementSlot(slot, requirement, hasMatch);
		        guideicinMatchCheck[i] = hasMatch;
		        if (hasMatch) available.Remove(match);
		    } else requiredContent.GetChild(i).gameObject.SetActive(false);
		}
		GuideKontrol();
		int percent;
		GetMatchingCommanders(mistikUI.commander, out percent);
		choosen_MysticIcon.sprite = mistikUI.commander.icon.sprite;
		craftBtn.interactable = percent > 99;
		SoundManager.instance.CashSound(new[] { SoundManager._click });
	}

	private void UpdateRequirementSlot(Transform slot, Commander required, bool hasMatch)
	{
		// Offline recovery candidate; native RVA 0x2014498.
		slot.gameObject.SetActive(true);
		slot.GetComponent<Image>().color = heroController.rarityColors[(int)required.Rarity];
		slot.GetChild(0).GetComponent<Image>().sprite = required.icon.sprite;
		slot.GetChild(1).GetComponent<TextMeshProUGUI>().text = required.HeroName;
		slot.GetChild(2).gameObject.SetActive(hasMatch);
	}

	private List<Commander> GetMatchingCommanders(Commander mystic, out int yuzde)
	{
		// Offline recovery candidate; native RVA 0x2014998.
		var remaining = new List<Commander>(spawner.activeCommanders);
		var matched = new List<Commander>();
		var groups = mystic.RequiredCommander.GroupBy(c => new { c.Type, c.Rarity }).Select(group => new { group.Key, Count = group.Count() });
		float coverage = 0f;
		foreach (var group in groups) {
		    for (int i = 0; i < group.Count; i++) {
		        float requiredValue = rarityToCommonValue[group.Key.Rarity];
		        Commander match = remaining.Where(c => c.Type == group.Key.Type && (int)c.Rarity <= (int)group.Key.Rarity).OrderByDescending(c => rarityToCommonValue[c.Rarity]).FirstOrDefault();
		        if (match != null) {
		            coverage += Mathf.Clamp01(rarityToCommonValue[match.Rarity] / requiredValue);
		            matched.Add(match);
		            remaining.Remove(match);
		        }
		    }
		}
		yuzde = Mathf.RoundToInt(coverage / mystic.RequiredCommander.Count * 100f);
		return matched;
	}

	public void CraftMystic()
	{
		// Offline recovery candidate; native RVA 0x20152e8.
		int percent;
		List<Commander> matched = GetMatchingCommanders(OneCikanCommander.commander, out percent);
		foreach (Commander commander in matched) {
		    commander.invSlot.commanders.Remove(commander);
		    spawner.ReturnCommanderToPool(commander);
		    commander.invSlot.UpdateRarityVisual();
		}
		warController.SummonedMysticSayisi = unchecked(warController.SummonedMysticSayisi + 1);
		Commander selected = OneCikanCommander.commander;
		spawner.TryAddToInventory((int)selected.Type, (int)selected.Rarity, warController.trailReferans.position, selected.MysticID);
		mysticFavorites.MistikEffectVer(OneCikanCommander.commander);
		Basarimlar.UpdateBasarimlarT(7, 1);
		Close();
	}

	public void SolPanelTiklandi()
	{
		// Offline recovery candidate; native RVA 0x2013698.
		foreach (MistikInGameTekliUI item in SolList) item.choosen.SetActive(item == OneCikanCommander);
	}

	public void FavoriteIt()
	{
		// Offline recovery candidate; native RVA 0x2015650.
		OneCikanCommander.commander.Favorite();
		favoriteObj.gameObject.SetActive(OneCikanCommander.commander.MyFavorite);
		OneCikanCommander.favorited.gameObject.SetActive(OneCikanCommander.commander.MyFavorite);
		SortSolListByFavorite();
	}

	public void Close()
	{
		// Offline recovery candidate; native RVA 0x201557c.
		gameObject.SetActive(false);
		warController.pageAcik = false;
		SoundManager.instance.CashSound(new[] { SoundManager._close });
	}

	public void Open()
	{
		// Offline recovery candidate; native RVA 0x20156e8.
		gameObject.SetActive(true);
		warController.pageAcik = true;
		SoundManager.instance.CashSound(new[] { SoundManager._click });
	}

	private void GuideKontrol()
	{
		// Offline recovery candidate; native RVA 0x201461c.
		if (guidedone || GameManager.Level != 2) return;
		bool changed = false;
		for (int i = 0; i < 3; i++) {
		    if (!guideicinMatchCheck[i] && !done[i]) {
		        Commander required = OneCikanCommander.commander.RequiredCommander[i];
		        spawner.TryAddToInventory((int)required.Type, (int)required.Rarity, warController.trailReferans.position, 0);
		        done[i] = true;
		        changed = true;
		    }
		}
		if (changed) OneCikar(OneCikanCommander);
		guidedone = true;
	}
}
