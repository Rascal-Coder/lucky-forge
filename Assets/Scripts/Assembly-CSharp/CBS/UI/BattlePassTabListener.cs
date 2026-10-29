using System;
using System.Runtime.CompilerServices;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class BattlePassTabListener : MonoBehaviour
	{
		[SerializeField]
		private ToggleGroup ToggleGroup;

		[CompilerGenerated]
		private Action<BattlePassTab> m_OnTabSelected;

		private BattlePassTab[] AllTabs { get; set; }

		public BattlePassTab ActiveTab => null;

		public event Action<BattlePassTab> OnTabSelected
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

		private void OnDisable()
		{
		}

		public void HideAll()
		{
		}

		public void SetActiveTitles(BattlePassInstance instance)
		{
		}

		private void OnToggleSelected(BattlePassTab tab)
		{
		}
	}
}
