using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommanderMissionUI : MonoBehaviour
{
	public TextMeshProUGUI titleText;

	public List<MissionUIItem> spawnedItems = new List<MissionUIItem>();

	public WarController warController;

	public RectTransform rect;

	public void SetupUI(List<CommanderMission> missions, CommanderMissionManager manager, ref bool uiInitialized)
	{
		// Offline recovery candidate; native RVA 0x21e19a0.
		if (uiInitialized && spawnedItems.Count == missions.Count)
		{
		 for (int i = 0; i < missions.Count; ++i) spawnedItems[i].Setup(missions[i], manager);
		 RefreshAll();
		 return;
		}
		for (int i = 0; i < spawnedItems.Count; ++i) spawnedItems[i].Setup(missions[i], manager);
		uiInitialized = true;
	}

	public void RefreshAll()
	{
		// Offline recovery candidate; native RVA 0x21e27f4.
		foreach (MissionUIItem item in spawnedItems) item.Refresh();
	}

	public void ResetPage()
	{
		// Offline recovery candidate; native RVA 0x21e1dbc.
		rect.anchoredPosition = Vector2.zero;
	}

	private void Start()
	{
		// Offline recovery candidate; native RVA 0x21e2924.
		titleText.text = Lang.Get.Missions;
	}

	public void UpdateMissionStatus(CommanderMission mission)
	{
		// Offline recovery candidate; native RVA 0x21e249c.
		MissionUIItem item = spawnedItems.Find(i => i.mission == mission);
		if (item != null) item.Refresh();
	}

	public void Close()
	{
		// Offline recovery candidate; native RVA 0x21e1ce8.
		gameObject.SetActive(false);
		warController.pageAcik = false;
		SoundManager.instance.CashSound(SoundManager._close);
	}

	public void Open()
	{
		// Offline recovery candidate; native RVA 0x21e29b8.
		if (warController.pageAcik) return;
		gameObject.SetActive(true);
		warController.pageAcik = true;
		RefreshAll();
		SoundManager.instance.CashSound(SoundManager._click);
	}
}
