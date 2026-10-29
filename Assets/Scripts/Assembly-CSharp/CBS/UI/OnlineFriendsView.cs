using CBS.Models;

namespace CBS.UI
{
	public class OnlineFriendsView : FriendsView
	{
		public override FriendsTabTitle TabTitle => FriendsTabTitle.FRIENDS;

		protected override void OnFriendsGet(CBSGetFriendsResult result)
		{
		}
	}
}
