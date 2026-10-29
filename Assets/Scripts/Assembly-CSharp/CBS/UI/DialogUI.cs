using System;
using CBS.Core;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	[RequireComponent(typeof(Toggle))]
	public class DialogUI : MonoBehaviour, IScrollableItem<DialogSlotRequest>
	{
		[SerializeField]
		private Text DisplayName;

		[SerializeField]
		private Text Message;

		[SerializeField]
		private Text BadgeCount;

		[SerializeField]
		private GameObject BadgeBody;

		[SerializeField]
		private AvatarDrawer Avatar;

		private Toggle Toggle { get; set; }

		private ChatDialogEntry Dialog { get; set; }

		private Action<string> ClickAction { get; set; }

		private Action<ChatDialogEntry> SelectAction { get; set; }

		private ICBSChat CBSChat { get; set; }

		private void Awake()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		public void Display(DialogSlotRequest data)
		{
		}

		private void DrawBadge()
		{
		}

		public void OnClickDialog()
		{
		}

		public void SetClickAction(Action<string> action)
		{
		}

		private void OnUnreadMessageClear(ChatDialogEntry dialogEntry)
		{
		}

		private void OnToggleChange(bool val)
		{
		}
	}
}
