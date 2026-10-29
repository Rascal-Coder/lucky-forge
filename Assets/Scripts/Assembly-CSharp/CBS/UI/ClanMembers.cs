using System;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class ClanMembers : MonoBehaviour, IClanScreen
	{
		[SerializeField]
		private ClanMembersScroller Scroller;

		private IProfile Profile { get; set; }

		private IClan CBSClan { get; set; }

		private ClanPrefabs Prefabs { get; set; }

		public Action OnBack { get; set; }

		public string ClanID => null;

		private void Awake()
		{
		}

		private void OnGetMembers(CBSGetClanMembersResult result)
		{
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}

		public void BackHandler()
		{
		}
	}
}
