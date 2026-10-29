using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionUIItem : MonoBehaviour
{
	[Header("UI Elements")]
	public TextMeshProUGUI missionNameText;

	public TextMeshProUGUI rewardText;

	public Image missionCheckIcon;

	[Header("Commander Icons (3 adet)")]
	public Image[] rarityColor;

	public Image[] commanderIcons;

	public GameObject[] commanderChecks;

	[HideInInspector]
	public CommanderMission mission;

	private CommanderMissionManager manager;

	public void Setup(CommanderMission mission, CommanderMissionManager manager)
	{
		// Offline recovery candidate; native RVA 0x20122c4.
		this.mission = mission;
		this.manager = manager;
		missionNameText.text = mission.missionName;
		rewardText.text = mission.spintoken >= 1 ? string.Format("<sprite=\"MeduSprite\" index=7>{0}", mission.spintoken) : string.Format("<sprite=\"MeduSprite3\" index=7>{0}", mission.luckytoken);
		CreateCommanderIcons();
		Refresh();
	}

	private void CreateCommanderIcons()
	{
		// Offline recovery candidate; native RVA 0x20123fc.
		System.Collections.Generic.List<Commander> commanders = manager.commanderSpawner.heroController.HeroCommanders;
		int count = Mathf.Min(mission.requiredCommanderIDs.Count, commanderIcons.Length);
		for (int i = 0; i < count; ++i)
		{
		 int id = mission.requiredCommanderIDs[i];
		 commanderIcons[i].sprite = commanders[id].icon.sprite;
		 rarityColor[i].color = manager.commanderSpawner.heroController.rarityColors[(int)commanders[id].Rarity];
		}
	}

	public void Refresh()
	{
		// Offline recovery candidate; native RVA 0x20125e0.
		missionCheckIcon.gameObject.SetActive(mission.isCompleted);
		if (manager.commanderSpawner == null || mission.isCompleted) return;
		System.Collections.Generic.List<int> present = System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(manager.commanderSpawner.activeCommanders, c => (int)c.Rarity != 4), c => c.HeroNum));
		int count = Mathf.Min(mission.requiredCommanderIDs.Count, commanderIcons.Length);
		for (int i = 0; i < count; ++i) commanderChecks[i].SetActive(present.Contains(mission.requiredCommanderIDs[i]));
	}
}
