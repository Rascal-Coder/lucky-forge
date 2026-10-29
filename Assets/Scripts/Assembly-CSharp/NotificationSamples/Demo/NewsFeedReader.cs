using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using UnityEngine;
using UnityEngine.Networking;

namespace NotificationSamples.Demo
{
	public class NewsFeedReader : MonoBehaviour
	{
		public class NewsItem
		{
			public string Title;

			public string Description;
		}

		[CompilerGenerated]
		private sealed class _003CGetFirstItemInternal_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string url;

			public Action<NewsItem> doneAction;

			public NewsFeedReader _003C_003E4__this;

			private UnityWebRequest _003Cwww_003E5__2;

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
			public _003CGetFirstItemInternal_003Ed__2(int _003C_003E1__state)
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

		public void GetFirstItem(string url, Action<NewsItem> doneAction)
		{
		}

		[IteratorStateMachine(typeof(_003CGetFirstItemInternal_003Ed__2))]
		private IEnumerator GetFirstItemInternal(string url, Action<NewsItem> doneAction)
		{
			return null;
		}

		private XmlNode FindNode(XmlNode firstNode, string nodeName)
		{
			return null;
		}
	}
}
