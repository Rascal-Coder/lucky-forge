using System;
using CBS.Models;

namespace CBS.UI
{
	public class PopupViewer
	{
		public void ShowSimplePopup(PopupRequest request)
		{
		}

		public void ShowYesNoPopup(YesOrNoPopupRequest request)
		{
		}

		public void ShowEditTextPopup(EditTextPopupRequest request)
		{
		}

		public void ShowChangeRolePopup(ChangeRolePopupRequest request)
		{
		}

		public void ShowFabError(CBSError error)
		{
		}

		public void ShowStackError(CBSError error)
		{
		}

		public void ShowUserInfo(string profileIDToShow)
		{
		}

		public void ShowClanInfo(string clanID)
		{
		}

		public void ShowLoadingPopup()
		{
		}

		public void HideLoadingPopup()
		{
		}

		public void ShowRewardPopup(RewardObject prize)
		{
		}

		public void ShowItemPopup(string itemID, string title, Action onOk = null)
		{
		}

		public void ShowMessagePopup(ChatMessage message, Action<ChatMessage> onModify = null)
		{
		}

		public void ShowStickersPopup(Action<ChatSticker> onSelect)
		{
		}

		public void ShowItemsPopup(Action<CBSInventoryItem> onSelect)
		{
		}
	}
}
