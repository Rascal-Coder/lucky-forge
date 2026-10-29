using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

namespace Proyecto26
{
	public static class HttpBase
	{
		[CompilerGenerated]
		private sealed class _003CCreateRequestAndRetry_003Ed__0 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RequestHelper options;

			public Action<RequestException, ResponseHelper> callback;

			private int _003Cretries_003E5__2;

			private UnityWebRequest _003Crequest_003E5__3;

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
			public _003CCreateRequestAndRetry_003Ed__0(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[IteratorStateMachine(typeof(_003CCreateRequestAndRetry_003Ed__0))]
		public static IEnumerator CreateRequestAndRetry(RequestHelper options, Action<RequestException, ResponseHelper> callback)
		{
			return null;
		}

		private static UnityWebRequest CreateRequest(RequestHelper options)
		{
			return null;
		}

		private static RequestException CreateException(RequestHelper options, UnityWebRequest request)
		{
			return null;
		}

		private static void DebugLog(bool debugEnabled, object message, bool isError)
		{
		}

		public static IEnumerator DefaultUnityWebRequest(RequestHelper options, Action<RequestException, ResponseHelper> callback)
		{
			return null;
		}

		public static IEnumerator DefaultUnityWebRequest<TResponse>(RequestHelper options, Action<RequestException, ResponseHelper, TResponse> callback)
		{
			return null;
		}

		public static IEnumerator DefaultUnityWebRequest<TResponse>(RequestHelper options, Action<RequestException, ResponseHelper, TResponse[]> callback)
		{
			return null;
		}
	}
}
