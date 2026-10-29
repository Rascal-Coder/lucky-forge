using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class UserInfoForm : MonoBehaviour
	{
		[SerializeField]
		private Text DisplayName;

		[SerializeField]
		private Text Notification;

		[SerializeField]
		private Text Level;

		[SerializeField]
		private Text Exp;

		[SerializeField]
		private Text Clan;

		[SerializeField]
		private GameObject AddToFriendBtn;

		[SerializeField]
		private GameObject RemoveFriendBtn;

		[SerializeField]
		private GameObject DeclineFriendBtn;

		[SerializeField]
		private GameObject InviteToClanBtn;

		[SerializeField]
		private GameObject ViewClanBtn;

		[SerializeField]
		private AvatarDrawer AvatarDrawer;

		[SerializeField]
		private SharedFriendsLoader FriendsLoader;

		private CBSGetProfileResult CurrentInfo { get; set; }

		private string ProfileID { get; set; }

		private IFriends CBSFriends { get; set; }

		private IClan CBSClan { get; set; }

		private IProfile CBSProfile { get; set; }

		private ProfileConfigData Config { get; set; }

		private void Awake()
		{
		}

		public void Display(CBSGetProfileResult info)
		{
		}

		private void CheckFriendsExist()
		{
		}

		private void CheckClanInvite()
		{
		}

		public void SendFriendsRequest()
		{
		}

		public void RemoveFriend()
		{
		}

		public void DeclineFriendRequest()
		{
		}

		public void SendDirectMessage()
		{
		}

		public void InviteToClan()
		{
		}

		public void ShowClanInfo()
		{
		}
	}
}
