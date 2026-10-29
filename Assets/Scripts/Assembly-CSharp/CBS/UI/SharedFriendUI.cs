using CBS.Core;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class SharedFriendUI : MonoBehaviour, IScrollableItem<ProfileEntity>
	{
		[SerializeField]
		private Text DisplayName;

		[SerializeField]
		private AvatarDrawer Avatar;

		protected ProfileEntity CurrentFriend { get; set; }

		protected ProfileConfigData Config { get; set; }

		protected IFriends Friends { get; set; }

		private void Awake()
		{
		}

		public void Display(ProfileEntity data)
		{
		}
	}
}
