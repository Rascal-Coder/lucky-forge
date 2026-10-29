using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CBS.Context;
using CBS.Models;
using UnityEngine;

namespace CBS
{
	public class ChatInstance : IChat, IDisposable
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass65_0
		{
			public CBSGetMessagesFromChatResult messagesResult;

			internal void _003CCheckNewMessagesCoroutine_003Eb__1(CBSGetMessagesFromChatResult onGet)
			{
			}

			internal bool _003CCheckNewMessagesCoroutine_003Eb__2()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CCheckNewMessagesCoroutine_003Ed__65 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ChatInstance _003C_003E4__this;

			private _003C_003Ec__DisplayClass65_0 _003C_003E8__1;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CCheckNewMessagesCoroutine_003Ed__65(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private Action<ChatMessage> m_OnNewMessage;

		[CompilerGenerated]
		private Action<List<ChatMessage>> m_OnGetHistory;

		public string ChatID { get; private set; }

		public string[] PrivateChatMembers { get; private set; }

		private int HistoryMaxCount { get; set; }

		private int NewMessageCompareCount { get; set; }

		private float CompareWait { get; set; }

		private List<ChatMessage> CacheMessages { get; set; }

		private List<ChatMessage> CompareList { get; set; }

		private ICBSChat ChatModule { get; set; }

		private IProfile Profile { get; set; }

		private ChatAccess ChatType { get; set; }

		private ICoroutineRunner CoroutineRunner { get; set; }

		private Coroutine CheckNewMessageCoroutine { get; set; }

		public event Action<ChatMessage> OnNewMessage
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<List<ChatMessage>> OnGetHistory
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public ChatInstance(ChatInstanceRequest request)
		{
		}

		public void Load()
		{
		}

		private string GetInterlocutorID()
		{
			return null;
		}

		public void SetMaxMessagesCount(int maxMessagesToLoad)
		{
		}

		public void SetUpdateIntervalMiliseconds(float updateInterval)
		{
		}

		public void SendMessage(CBSSendTextMessageRequest request, Action<CBSSendChatMessageResult> result = null)
		{
		}

		public void SendSticker(CBSSendStickerMessageRequest request, Action<CBSSendChatMessageResult> result = null)
		{
		}

		public void SendItem(CBSSendItemMessageRequest request, Action<CBSSendChatMessageResult> result = null)
		{
		}

		public void GetChatHistory(Action<CBSGetMessagesFromChatResult> result = null)
		{
		}

		private void StartCheckNewMessages()
		{
		}

		private void StopCheckNewMessages()
		{
		}

		[IteratorStateMachine(typeof(_003CCheckNewMessagesCoroutine_003Ed__65))]
		private IEnumerator CheckNewMessagesCoroutine()
		{
			return null;
		}

		public void Dispose()
		{
		}
	}
}
