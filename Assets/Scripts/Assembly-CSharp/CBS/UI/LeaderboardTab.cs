using System;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class LeaderboardTab : MonoBehaviour
	{
		public LeaderboardTabType TabType;

		public LeaderboardView TabView;

		public string StatisticName;

		public string TitleText;

		public int MaxCount;

		public Action<LeaderboardTab> OnTabSelected;

		private Toggle toggle;

		public bool IsActive => false;

		private Toggle Toggle => null;

		private Text TitleLabel { get; set; }

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void DrawTab()
		{
		}

		private void OnToggleChanged(bool val)
		{
		}
	}
}
