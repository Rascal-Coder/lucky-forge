using CBS.Models;

namespace CBS.UI
{
	public class UnreadMessageBadge : BaseBadge
	{
		private ICBSChat CBSChat { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnGetDialogBadge(CBSBadgeResult result)
		{
		}

		private void OnMessageClear(ChatDialogEntry dialogEntry)
		{
		}
	}
}
