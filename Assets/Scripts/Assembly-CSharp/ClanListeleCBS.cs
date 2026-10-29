using System.Collections.Generic;
using CBS;
using CBS.Models;
using CBS.UI;
using UnityEngine;

public class ClanListeleCBS : MonoBehaviour
{
	public ClanLeaderboardScroller ClanScroller;

	public GameObject clanTekliPrefab;

	private bool loaded;

	public bool clanleaderboard;

	private ILeaderboard Leaderboard { get; set; }

	private IProfile Profile { get; set; }

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	private void listele()
	{
	}

	private void OnGetClanLeaderboard(CBSGetClanLeaderboardResult result)
	{
	}

	private void ShuffleList(List<ClanLeaderboardEntry> list)
	{
	}
}
