using System;
using CBS.Core;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class ClanInvationResult : MonoBehaviour, IScrollableItem<ClanInvitationInfo>
	{
		[SerializeField]
		private Text Name;

		[SerializeField]
		private Text Expires;

		[SerializeField]
		private ClanAvatarDrawer Avatar;

		private string ClanID { get; set; }

		public Action AcceptAction { get; set; }

		public void Display(ClanInvitationInfo invitation)
		{
		}

		public void OnAccept()
		{
		}

		public void OnDecline()
		{
		}

		private void OnJoinClan()
		{
		}
	}
}
