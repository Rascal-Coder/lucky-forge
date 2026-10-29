using System;
using CBS.Models;
using TMPro;
using UnityEngine;

namespace CBS.UI
{
	public class ClanInfoForm : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI DisplayName;

		[SerializeField]
		private TextMeshProUGUI Members;

		[SerializeField]
		private TextMeshProUGUI Level;

		[SerializeField]
		private TextMeshProUGUI Description;

		[SerializeField]
		private GameObject JoinButton;

		[SerializeField]
		private ClanAvatarDrawer Avatar;

		public TextMeshProUGUI jointxt;

		public ClanLogin clanLogin;

		private IClan Clan { get; set; }

		private IProfile Profile { get; set; }

		private ClanEntity ClanEntity { get; set; }

		public Action OnJoin { get; set; }

		private void Awake()
		{
		}

		public void Display(ClanEntity clanEntity)
		{
		}

		public void JoinOrReq()
		{
		}

		public void SendJoinRequest()
		{
		}

		public void JoinHandler()
		{
		}
	}
}
