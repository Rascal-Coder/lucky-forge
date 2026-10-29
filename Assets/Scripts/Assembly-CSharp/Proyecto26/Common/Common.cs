using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

namespace Proyecto26.Common
{
	public static class Common
	{
		[CompilerGenerated]
		private sealed class _003CSendWebRequestWithOptions_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RequestHelper options;

			public UnityWebRequest request;

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
			public _003CSendWebRequestWithOptions_003Ed__4(int _003C_003E1__state)
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

		private const string CONTENT_TYPE_HEADER = "Content-Type";

		private const string DEFAULT_CONTENT_TYPE = "application/json";

		private static string GetFormSectionsContentType(out byte[] bodyRaw, RequestHelper options)
		{
			bodyRaw = null;
			return null;
		}

		private static void ConfigureWebRequestWithOptions(UnityWebRequest request, byte[] bodyRaw, string contentType, RequestHelper options)
		{
		}

		[IteratorStateMachine(typeof(_003CSendWebRequestWithOptions_003Ed__4))]
		public static IEnumerator SendWebRequestWithOptions(this UnityWebRequest request, RequestHelper options)
		{
			return null;
		}
	}
}
