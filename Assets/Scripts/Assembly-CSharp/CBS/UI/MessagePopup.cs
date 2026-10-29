using System;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class MessagePopup : MonoBehaviour
	{
		[SerializeField]
		private AvatarDrawer Avatar;

		[SerializeField]
		private Text DisplayName;

		[SerializeField]
		private Text MessageContent;

		[SerializeField]
		private InputField EditField;

		[SerializeField]
		private InputField HoursField;

		[SerializeField]
		private InputField ReasonField;

		[SerializeField]
		private GameObject ViewProfileButton;

		[SerializeField]
		private GameObject EditButton;

		[SerializeField]
		private GameObject SaveButton;

		[SerializeField]
		private GameObject DeleteButton;

		[SerializeField]
		private GameObject BanButton;

		[SerializeField]
		private GameObject ConfirmBanButton;

		[SerializeField]
		private GameObject BanPanel;

		private ChatMessage Message { get; set; }

		private Action<ChatMessage> ModifyAction { get; set; }

		private IProfile Profile { get; set; }

		private ICBSChat CBSChat { get; set; }

		private bool IsEditMode { get; set; }

		private bool IsBanMode { get; set; }

		private void Awake()
		{
		}

		public void Show(ChatMessage message, Action<ChatMessage> onModify = null)
		{
		}

		private void DisplayPopup()
		{
		}

		private bool IsMine()
		{
			return false;
		}

		private void CancelEditMode()
		{
		}

		private void CancelBanMode()
		{
		}

		public void ClosePopup()
		{
		}

		public void ViewProfile()
		{
		}

		public void SaveRequest()
		{
		}

		public void EditRequest()
		{
		}

		public void DeleteRequest()
		{
		}

		public void BanRequest()
		{
		}

		public void ConfirmBan()
		{
		}
	}
}
