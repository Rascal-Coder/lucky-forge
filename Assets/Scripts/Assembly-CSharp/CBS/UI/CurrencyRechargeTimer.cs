using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class CurrencyRechargeTimer : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003COnTick_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CurrencyRechargeTimer _003C_003E4__this;

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
			public _003COnTick_003Ed__7(int _003C_003E1__state)
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

		[SerializeField]
		private Text TimerLabel;

		private CBSCurrency Currency { get; set; }

		private void OnDisable()
		{
		}

		public void StartTimer(CBSCurrency currency)
		{
		}

		[IteratorStateMachine(typeof(_003COnTick_003Ed__7))]
		private IEnumerator OnTick()
		{
			return null;
		}

		public void StopTimer()
		{
		}
	}
}
