using System;
using CBS.Core;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class SimpleChatMessage : MonoBehaviour, IScrollableItem<ChatMessage>, ITagAction
	{
		[SerializeField]
		private Text Body;

		[SerializeField]
		private RectTransform ClickableArea;

		[SerializeField]
		private Image SlotDrawer;

		private readonly float StickerSize;

		private readonly float ItemSize;

		private ChatMessage Message { get; set; }

		private RectTransform RectTransform { get; set; }

		private LongClickTrigger LongClick { get; set; }

		private Vector2 DefaultSize { get; set; }

		private IProfile Profile { get; set; }

		private ChatLocalConfig ChatConfig { get; set; }

		private RectTransform Parent { get; set; }

		private Rect ParentSize { get; set; }

		private bool IsSlotRequest { get; set; }

		public Action<ChatMember> TagAction { get; set; }

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

		private void DrawTextMessage(string nickname, string body, string senderProfileID)
		{
		}

		private void DrawStickerMessage(string nickname, ChatSticker sticker, string senderProfileID)
		{
		}

		private void DrawItemMessage(string nickname, CBSInventoryItem item, string senderProfileID)
		{
		}

		private void ResizeBody()
		{
		}

		private void ResizeSlot(MessageContent content)
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
