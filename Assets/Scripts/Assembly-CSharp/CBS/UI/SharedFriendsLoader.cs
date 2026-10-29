using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class SharedFriendsLoader : MonoBehaviour
	{
		[SerializeField]
		private FriendsListScroller Scroller;

		private FriendsPrefabs Prefabs { get; set; }

		private IFriends Friends { get; set; }

		private void Awake()
		{
		}

		public void LoadFriends(string profileID)
		{
		}

		protected virtual void OnFriendsGet(CBSGetFriendsResult result)
		{
		}
	}
}
