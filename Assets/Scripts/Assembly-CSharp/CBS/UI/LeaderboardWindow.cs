using System;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class LeaderboardWindow : MonoBehaviour
	{
		[SerializeField]
		private LeaderboardTabListener TabListener;

		[SerializeField]
		private PlayerLeaderboardScroller ProfileScroller;

		[SerializeField]
		private ClanLeaderboardScroller ClanScroller;

		[SerializeField]
		private Text VersionTitle;

		[SerializeField]
		private Text TimerLabel;

		[SerializeField]
		private GameObject TimerContainer;

		private DateTime? ResetDate;

		private float LastExecuteTime;

		private LeaderboardPrefabs Prefabs { get; set; }

		private ILeaderboard Leaderboard { get; set; }

		private IProfile Profile { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnEnable()
		{
		}

		private void OnTabSelected(LeaderboardTab tab)
		{
		}

		private void LoadTab(LeaderboardTab tab)
		{
		}

		private void LateUpdate()
		{
		}

		private void ResetTimer()
		{
		}

		private void OnGetLeaderboard(CBSGetLeaderboardResult result)
		{
		}

		private void OnGetClanLeaderboard(CBSGetClanLeaderboardResult result)
		{
		}
	}
}
