using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class AchievementsWindow : MonoBehaviour
	{
		[SerializeField]
		private AchievementScroller Scroller;

		[SerializeField]
		private AchievementsTabListener TabListener;

		private IAchievements Achievements { get; set; }

		private AchievementsPrefabs Prefabs { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnEnable()
		{
		}

		private void OnTabSelected(TasksState tab)
		{
		}

		private void GetAchievements(TasksState tab)
		{
		}

		private void OnGetAchievements(CBSGetAchievementsTableResult result)
		{
		}
	}
}
