using System;
using System.Collections.Generic;
using CBS.Core;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class ClanRequests : MonoBehaviour, IClanScreen
	{
		[SerializeField]
		private BaseScroller Scroller;

		private IClan CBSClan { get; set; }

		private List<ClanRequestInfo> RequestList { get; set; }

		private ClanPrefabs Prefabs { get; set; }

		public Action OnBack { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnEnable()
		{
		}

		private void OnGetRequests(CBSGetClanJoinRequestListResult result)
		{
		}

		private void OnSpawnItem(GameObject uiItem, int index)
		{
		}

		public void BackHandler()
		{
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}
	}
}
