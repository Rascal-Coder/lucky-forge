using System;
using System.Runtime.CompilerServices;
using CBS.Models;
using UnityEngine;

namespace CBS.UI
{
	public class AchievementsTabListener : MonoBehaviour
	{
		[CompilerGenerated]
		private Action<TasksState> m_OnTabSelected;

		[SerializeField]
		private GameObject[] AllTabs;

		public TasksState ActiveTab { get; private set; }

		public event Action<TasksState> OnTabSelected
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

		private void OnDestroy()
		{
		}

		private void OnToggleSelected(bool val)
		{
		}
	}
}
