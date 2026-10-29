using System;
using CBS.Models;
using CBS.Scriptable;
using TMPro;
using UnityEngine;

namespace CBS.UI
{
	public class ClanTasksScreen : MonoBehaviour, IClanScreen
	{
		[SerializeField]
		private ClanTasksScroller Scroller;

		[SerializeField]
		private TextMeshProUGUI ResetDateTitle;

		public GameObject taskPrefab;

		public GameObject loadingicon;

		public Action OnBack { get; set; }

		private IClanTasks TaskModule { get; set; }

		private ClanPrefabs Prefabs { get; set; }

		private DateTime? ResetDate { get; set; }

		private void Awake()
		{
		}

		private void initialize()
		{
		}

		private void LateUpdate()
		{
		}

		public void OnDisable()
		{
		}

		public void Hide()
		{
		}

		public void Show()
		{
		}

		private void OnGetTasks(CBSGetTasksForClanResult result)
		{
		}

		private void DisplayResetDate()
		{
		}

		public void BackHandler()
		{
		}

		public void ResetTasksHandler()
		{
		}
	}
}
