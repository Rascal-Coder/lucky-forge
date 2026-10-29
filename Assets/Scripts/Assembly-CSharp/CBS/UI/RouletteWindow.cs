using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class RouletteWindow : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003COnSpinAnimation_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RouletteWindow _003C_003E4__this;

			public string ID;

			private int _003CfirstIndex_003E5__2;

			private GameObject _003ClastObject_003E5__3;

			private float _003CfinalPosition_003E5__4;

			private float _003CactualPosition_003E5__5;

			private float _003CcurrentPosition_003E5__6;

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
			public _003COnSpinAnimation_003Ed__38(int _003C_003E1__state)
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
		private RouletteScroller Scroller;

		[SerializeField]
		private Button SpinButton;

		[SerializeField]
		private int AnimationCircleCount;

		[SerializeField]
		private float AnimationSpeed;

		private readonly int MinPoolCount;

		private IRoulette Roulette { get; set; }

		private RoulettePrefabs Prefabs { get; set; }

		private List<RoulettePosition> CachePositions { get; set; }

		private List<GameObject> CacheSlots { get; set; }

		private int ItemsCount { get; set; }

		private bool IsAnimationNow { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void Clear()
		{
		}

		private void GetRouletteData()
		{
		}

		private void OnGetRouletteResult(CBSGetRouletteTableResult result)
		{
		}

		private List<RoulettePosition> GetPoolList(List<RoulettePosition> current)
		{
			return null;
		}

		private List<RoulettePosition> AsignCircleCount(List<RoulettePosition> current)
		{
			return null;
		}

		public void OnSpinClick()
		{
		}

		public void OnCloseWindow()
		{
		}

		[IteratorStateMachine(typeof(_003COnSpinAnimation_003Ed__38))]
		private IEnumerator OnSpinAnimation(string ID)
		{
			return null;
		}
	}
}
