using System;
using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class ProfileTasksWindow : MonoBehaviour
	{
		[SerializeField]
		private string TasksPoolID;

		[SerializeField]
		private TasksScroller Scroller;

		[SerializeField]
		private Text ResetDateTitle;

		private IProfileTasks DailyTasks { get; set; }

		private ProfileTasksPrefabs Prefab { get; set; }

		private DateTime? ResetDate { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void LateUpdate()
		{
		}

		public string GetPoolID()
		{
			return null;
		}

		private void LoadAndShowDailyTasks()
		{
		}

		private void OnGetDailyTasks(CBSGetTasksForProfileResult result)
		{
		}

		private void DisplayTasks(List<CBSProfileTask> tasks)
		{
		}

		private void DisplayResetDate()
		{
		}

		public void ResetTasks()
		{
		}
	}
}
