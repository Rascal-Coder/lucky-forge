using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommanderMissionManager : MonoBehaviour
{
	public GameObject btnMission;

	public CommanderSpawner commanderSpawner;

	public CommanderMissionUI missionUI;

	public WarController warController;

	public List<CommanderMission> missions = new List<CommanderMission>();

	private bool uiInitialized;

	private bool started;

	public static bool UpdateData;

	private float timerDataRefresh;

	public GameObject animCompletedOBJ;

	public Animator animCompleted;

	public TextMeshProUGUI completedAnimtxt;

	public TextMeshProUGUI completedRewardtxt;

	private void Start()
	{
		// Offline recovery candidate; native RVA 0x21dfc3c.
		completedAnimtxt.text = Lang.Get.tamamlandi;
		InitializeMissionsIfEmpty();
		missionUI.SetupUI(missions, this, ref uiInitialized);
		started = true;
	}

	private void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x21e1b34.
		missionUI.Close();
		missionUI.ResetPage();
		btnMission.SetActive(GameManager.Level > 2);
		UpdateData = false;
		if (started) foreach (CommanderMission mission in missions) { mission.isCompleted = false; mission.rewardClaimed = false; }
	}

	private void InitializeMissionsIfEmpty()
	{
		// Offline recovery candidate; native RVA 0x21dfcf4.
		if (missions != null && missions.Count != 0) return;
		missions = new List<CommanderMission>
		{
		new CommanderMission { missionName = Lang.Get.SteelVanguard, requiredCommanderIDs = new List<int> { 0, 4, 16 }, spintoken = 50 },
		new CommanderMission { missionName = Lang.Get.FirstLightUnit, requiredCommanderIDs = new List<int> { 8, 12, 1 }, spintoken = 75 },
		new CommanderMission { missionName = Lang.Get.SilentExecution, requiredCommanderIDs = new List<int> { 1, 2, 3 }, luckytoken = 2 },
		new CommanderMission { missionName = Lang.Get.OmegaStrike, requiredCommanderIDs = new List<int> { 4, 5, 17 }, spintoken = 75 },
		new CommanderMission { missionName = Lang.Get.EtherealCircle, requiredCommanderIDs = new List<int> { 18, 15, 13 }, spintoken = 100 },
		new CommanderMission { missionName = Lang.Get.ArcaneTrio, requiredCommanderIDs = new List<int> { 9, 5, 6 }, luckytoken = 2 },
		new CommanderMission { missionName = Lang.Get.CrimsonPatrol, requiredCommanderIDs = new List<int> { 0, 6, 18 }, spintoken = 120 },
		new CommanderMission { missionName = Lang.Get.IronPhalanx, requiredCommanderIDs = new List<int> { 9, 5, 14 }, luckytoken = 3 },
		new CommanderMission { missionName = Lang.Get.CelestialLegion, requiredCommanderIDs = new List<int> { 1, 13, 18 }, spintoken = 150 },
		new CommanderMission { missionName = Lang.Get.TwilightCovenant, requiredCommanderIDs = new List<int> { 6, 10, 11 }, luckytoken = 3 },
		new CommanderMission { missionName = Lang.Get.SpectralAlliance, requiredCommanderIDs = new List<int> { 4, 15, 19 }, spintoken = 250 },
		new CommanderMission { missionName = Lang.Get.ShadowfrontSquad, requiredCommanderIDs = new List<int> { 16, 17, 3 }, luckytoken = 5 },
		new CommanderMission { missionName = Lang.Get.RadiantBattalion, requiredCommanderIDs = new List<int> { 4, 9, 15 }, luckytoken = 4 },
		new CommanderMission { missionName = Lang.Get.NovaDivision, requiredCommanderIDs = new List<int> { 2, 6, 11 }, spintoken = 200 },
		};
	}

	public void CheckAllMissions()
	{
		// Offline recovery candidate; native RVA 0x21e1e18.
		if (commanderSpawner == null || commanderSpawner.activeCommanders == null || GameManager.Level < 3) return;
		System.Collections.Generic.List<int> present = System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(commanderSpawner.activeCommanders, c => (int)c.Rarity != 4), c => c.HeroNum));
		foreach (CommanderMission mission in missions)
		{
		 if (mission.isCompleted) continue;
		 if (System.Linq.Enumerable.All(mission.requiredCommanderIDs, id => present.Contains(id))) { mission.isCompleted = true; GiveReward(mission); }
		 missionUI.UpdateMissionStatus(mission);
		}
	}

	private void GiveReward(CommanderMission mission)
	{
		// Offline recovery candidate; native RVA 0x21e22bc.
		if (mission.rewardClaimed) return;
		if (mission.spintoken >= 1)
		{
		 warController.AddSilver((float)mission.spintoken);
		 completedRewardtxt.text = string.Format("<sprite=\"MeduSprite\" index=7>{0}", mission.spintoken);
		}
		else
		{
		 warController.Addtoken(mission.luckytoken);
		 completedRewardtxt.text = string.Format("<sprite=\"MeduSprite3\" index=7>{0}", mission.luckytoken);
		}
		animCompletedOBJ.SetActive(true);
		animCompleted.Play("Base Layer.CompletedMission", 0, 0f);
		SoundManager.instance.RandomizeSfx(SoundManager._bell);
		mission.rewardClaimed = true;
	}

	private void Update()
	{
		// Offline recovery candidate; native RVA 0x21e25e0.
		if (!UpdateData) return;
		timerDataRefresh = (float)(timerDataRefresh + Time.deltaTime);
		if (!(timerDataRefresh >= 0.7f)) return;
		CheckAllMissions();
		timerDataRefresh = 0f;
		UpdateData = false;
	}
}
