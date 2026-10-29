using System.Linq;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MistikInGameTekliUI : MonoBehaviour
{
	public int WeaponNum;

	public int yuzdekac;

	public TextMeshProUGUI yuzdekactxt;

	public GameObject choosen;

	public Image icon;

	public Commander commander;

	public MistikInGameUI MysticUI;

	public List<Commander> sahipOlunan = new List<Commander>();

	public GameObject favorited;

	public GameObject unlem;

	public void InitWeapon(Commander initcommander, MistikInGameUI ui)
	{
		// Offline recovery candidate; native RVA 0x20129e4.
		gameObject.SetActive(true);
		commander = initcommander;
		MysticUI = ui;
		icon.sprite = commander.icon.sprite;
		UpdateData();
	}

	public void UpdateData()
	{
		// Offline recovery candidate; native RVA 0x2012a84.
		if (commander == null) return;
		CheckRequirements();
	}

	public void CheckRequirements()
	{
		// Offline recovery candidate; native RVA 0x2012afc.
		favorited.gameObject.SetActive(commander.MyFavorite);
		sahipOlunan.Clear();
		var remaining = new List<Commander>(MysticUI.spawner.activeCommanders);
		float coverage = 0f;
		foreach (Commander required in commander.RequiredCommander) {
		    float needed = MysticUI.rarityToCommonValue[required.Rarity];
		    var candidates = remaining.Where(c => c.Type == required.Type && (int)c.Rarity <= (int)required.Rarity).OrderBy(c => MysticUI.rarityToCommonValue[c.Rarity]).ToList();
		    float accumulated = 0f;
		    foreach (Commander candidate in candidates) {
		        accumulated += MysticUI.rarityToCommonValue[candidate.Rarity];
		        sahipOlunan.Add(candidate);
		        remaining.Remove(candidate);
		        if (accumulated >= needed) break;
		    }
		    coverage += Mathf.Clamp01(accumulated / needed);
		}
		yuzdekac = Mathf.RoundToInt(coverage / commander.RequiredCommander.Count * 100f);
		yuzdekactxt.text = yuzdekac.ToString() + "%";
		unlem.SetActive(yuzdekac > 99);
	}

	public void OneCikar()
	{
		// Offline recovery candidate; native RVA 0x201323c.
		MysticUI.OneCikar(this);
		MysticUI.SolPanelTiklandi();
	}
}
