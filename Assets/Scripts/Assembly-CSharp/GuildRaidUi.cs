using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuildRaidUi : MonoBehaviour
{
	public TextMeshProUGUI title;

	public TextMeshProUGUI timer;

	public TextMeshProUGUI subtitle;

	public TextMeshProUGUI boss;

	public TextMeshProUGUI dailylimit;

	public TextMeshProUGUI startcha;

	public Button raidbtn;

	public GameObject infodonate;

	public GameObject donateLocker;

	private const string KEY_FREE_COUNT = "ClanRaid_FreeRerollsUsed";

	private const string KEY_FREE_RESET_TIME = "ClanRaid_LastFreeResetTime";

	public int donatedailylimit;

	private const int MAX_FREE_REROLLS = 3;

	public GecisControl gecis;

	private DateTime resettime;

	private void OnEnable()
	{
	}

	private void Check24Hour()
	{
	}

	public void GoRaid()
	{
	}

	private void Update()
	{
	}
}
