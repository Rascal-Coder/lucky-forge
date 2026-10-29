using System;
using System.Collections.Generic;
using CBS.Core;
using CBS.Models;
using CBS.Scriptable;
using TMPro;
using UnityEngine;

namespace CBS.UI
{
	public class ChatView : MonoBehaviour, IDisposable
	{
		[SerializeField]
		private TMP_InputField MessageInput;

		[SerializeField]
		private ChatTagDrawer TagDrawer;

		[SerializeField]
		private ChatScroller Scroller;

		[SerializeField]
		private int MaxMessagesToLoad;

		[SerializeField]
		private float UpateIntervalMiliseconds;

		[SerializeField]
		private ChatDisplayMode DisplayMode;

		[SerializeField]
		private float TextModeSpacing;

		[SerializeField]
		private float BubbleModeSpacing;

		private IChat Chat { get; set; }

		private IProfile Profile { get; set; }

		private bool IsInited { get; set; }

		private ChatPrefabs Prefabs { get; set; }

		private GameObject MessagePrefab { get; set; }

		private void Awake()
		{
		}

		private void OnDisable()
		{
		}

		public void Init(IChat chat)
		{
		}

		private void ApplySpacing()
		{
		}

		public void SendMessage()
		{
		}

		public void OpenItemUI()
		{
		}

		public void OpenStickerUI()
		{
		}

		public void RemoveTag()
		{
		}

		public void TagProfile(ChatMember member)
		{
		}

		public void OnNewMessageAdded(ChatMessage message)
		{
		}

		public void OnGetMessages(List<ChatMessage> messages)
		{
		}

		public void Dispose()
		{
		}
	}
}
