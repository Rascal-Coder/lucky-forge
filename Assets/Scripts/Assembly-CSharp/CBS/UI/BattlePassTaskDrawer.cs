using System;
using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class BattlePassTaskDrawer : MonoBehaviour
	{
		[SerializeField]
		private BattlePassTasksScroller Scroller;

		[SerializeField]
		private Text NotificationLabel;

		[SerializeField]
		private Text ResetDateLabel;

		private BattlePassPrefabs PassPrefabs { get; set; }

		private string BattlePassID { get; set; }

		private IBattlePass BattlePass { get; set; }

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

		public void Draw(BattlePassInstance instance)
		{
		}

		private void DisplayTasks(List<CBSProfileTask> tasks)
		{
		}

		private void DisplayResetDate()
		{
		}

		private void OnGetTasks(CBSGetTasksForProfileResult result)
		{
		}
	}
}
