using System.Collections.Generic;
using CBS.Core;
using CBS.Models;
using TMPro;
using UnityEngine;

namespace CBS.UI
{
	public class ClanMemberUI : MonoBehaviour, IScrollableItem<ClanMemberUIRequest>
	{
		[SerializeField]
		private TextMeshProUGUI DisplayName;

		[SerializeField]
		private TextMeshProUGUI ClanRole;

		[SerializeField]
		private GameObject KickBtn;

		[SerializeField]
		private GameObject ChangeRoleBtn;

		[SerializeField]
		private TextMeshProUGUI bugunyaptigikatkitxt;

		[SerializeField]
		private TextMeshProUGUI bugunyaptigikatki;

		[SerializeField]
		private AvatarDrawer Avatar;

		public GameObject imageBack;

		private IClan Clan { get; set; }

		private IProfile Profile { get; set; }

		private ICurrency CurrencyModule { get; set; }

		private string ProfileID { get; set; }

		private string RoleID { get; set; }

		private List<ClanRoleInfo> Roles { get; set; }

		private ClanMember ClanMember { get; set; }

		private void Awake()
		{
		}

		private void OnDisable()
		{
		}

		public void Display(ClanMemberUIRequest request)
		{
		}

		private void OnGetProfileInfo(CBSGetProfileDataResult result)
		{
		}

		public void KickHandler()
		{
		}

		public void ChangeRoleHandler()
		{
		}

		private void ProcessKickMember()
		{
		}

		private void ProcessChangeRole(string roleID)
		{
		}
	}
}
