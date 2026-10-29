using System;
using System.Collections.Generic;
using CBS.Core;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class ProfileInvitations : MonoBehaviour, IClanScreen
	{
		[SerializeField]
		private BaseScroller Scroller;

		private IClan CBSClan { get; set; }

		private List<ClanInvitationInfo> Invitations { get; set; }

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

		private void OnGetInvitations(CBSGetProfileInvationsResult result)
		{
		}

		private void OnClanSpawn(GameObject uiItem, int index)
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
