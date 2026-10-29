using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CBS.UI
{
	public class LeaderboardTabListener : MonoBehaviour
	{
		[CompilerGenerated]
		private Action<LeaderboardTab> m_OnTabSelected;

		private LeaderboardTab[] AllTabs { get; set; }

		public LeaderboardTab ActiveTab => null;

		public event Action<LeaderboardTab> OnTabSelected
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnToggleSelected(LeaderboardTab tab)
		{
		}
	}
}
