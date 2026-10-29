using System;
using CBS.Core;
using CBS.Models;
using CBS.Scriptable;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class BubbleChatMessage : MonoBehaviour, IScrollableItem<ChatMessage>, ITagAction
	{
		[SerializeField]
		private TextMeshProUGUI Body;

		[SerializeField]
		private TextMeshProUGUI Nickname;

		[SerializeField]
		private Text Date;

		[SerializeField]
		private Image Bubble;

		[SerializeField]
		private AvatarDrawer Avatar;

		[SerializeField]
		private Image SlotDrawer;

		private readonly float SlotSize;

		private ChatMessage Message { get; set; }

		private ChatLocalConfig ChatConfig { get; set; }

		private RectTransform TextRect { get; set; }

		private RectTransform BubbleRect { get; set; }

		private RectTransform RootRect { get; set; }

		private LongClickTrigger LongClick { get; set; }

		private Vector2 DefaultTextSize { get; set; }

		private Vector2 DefaultBubbleSize { get; set; }

		private Vector2 DefaultRootSize { get; set; }

		private bool IsSlotRequest { get; set; }

		public Action<ChatMember> TagAction { get; set; }

		private IProfile Profile { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void Display(ChatMessage message)
		{
		}

		private void DrawSystemMessage(ChatMessage message)
		{
		}

		private void DrawDefaultMessage(ChatMessage message)
		{
		}

		private void DrawTextMessage(string body)
		{
		}

		private void DrawSticker(ChatSticker sticker)
		{
		}

		private void DrawItem(CBSInventoryItem item)
		{
		}

		private void ResizeBody()
		{
		}

		private void ClaimItemFromMessage()
		{
		}

		public void ClickNickName()
		{
		}

		public void OnClickSlot()
		{
		}

		private void OnLongClick()
		{
		}

		private void OnModifyMessage(ChatMessage message)
		{
		}
	}
}
