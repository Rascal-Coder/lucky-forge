using UnityEngine;

namespace CBS.UI
{
	public class BaseFriendsTab : BaseTab<string>
	{
		[SerializeField]
		private FriendsTabTitle TabTitle;

		private void Start()
		{
		}

		public FriendsTabTitle GetTitle()
		{
			return FriendsTabTitle.FRIENDS;
		}
	}
}
