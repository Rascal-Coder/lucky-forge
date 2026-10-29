using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "FriendsPrefabs", menuName = "CBS/Add new Friends Prefabs")]
	public class FriendsPrefabs : CBSScriptable
	{
		public GameObject FriendsWindow;

		public GameObject FriendUI;

		public GameObject SharedFriendUI;

		public GameObject RequestedFriendUI;

		public GameObject DialogUI;

		public override string ResourcePath => null;
	}
}
