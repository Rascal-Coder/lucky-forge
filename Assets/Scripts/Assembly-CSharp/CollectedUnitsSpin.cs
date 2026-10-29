using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CollectedUnitsSpin : MonoBehaviour
{
	[SerializeField]
	public enum SpinType
	{
		Coin = 0,
		HP = 1,
		ATK = 2,
		DEF = 3,
		MaxHP = 4,
		Silver = 5,
		Random = 6
	}

	[CompilerGenerated]
	private sealed class _003CCloseLate_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CollectedUnitsSpin _003C_003E4__this;

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
		public _003CCloseLate_003Ed__33(int _003C_003E1__state)
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
	private sealed class _003CSmoothSnap_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RectTransform rectTransform;

		public float targetY;

		private float _003Cduration_003E5__2;

		private float _003Celapsed_003E5__3;

		private float _003CstartY_003E5__4;

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
		public _003CSmoothSnap_003Ed__31(int _003C_003E1__state)
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
	private sealed class _003CSpinRoutine_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CollectedUnitsSpin _003C_003E4__this;

		private float _003CelapsedTime_003E5__2;

		private float _003CtotalSpinDistance_003E5__3;

		private RectTransform _003CrectTransform_003E5__4;

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
		public _003CSpinRoutine_003Ed__30(int _003C_003E1__state)
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

	public SpinType spinType;

	public Transform spinContainer;

	public GameObject spinItemPrefab;

	public int numberOfItems;

	public float spinDuration;

	public AnimationCurve decelerationCurve;

	public WarController levelManager;

	public GameManager _gm;

	public TextMeshProUGUI title;

	[Header("Icons")]
	public Sprite coinIcon;

	public Sprite hpIcon;

	public Sprite atkIcon;

	public Sprite defIcon;

	public Sprite maxHpIcon;

	public Sprite silverIcon;

	public Sprite randomIcon;

	private GameObject[] spinItems;

	private bool isSpinning;

	private float itemHeight;

	private bool initialized;

	private double parasi;

	private float soundTimer;

	public bool IsSpinInProgress => false;

	private void Start()
	{
	}

	private void InitializeSpinItems()
	{
	}

	public void StartSpin()
	{
	}

	public void Close()
	{
	}

	private void SetupSpinItems()
	{
	}

	[IteratorStateMachine(typeof(_003CSpinRoutine_003Ed__30))]
	private IEnumerator SpinRoutine()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CSmoothSnap_003Ed__31))]
	private IEnumerator SmoothSnap(float targetY, RectTransform rectTransform)
	{
		return null;
	}

	private void DetermineResult()
	{
	}

	[IteratorStateMachine(typeof(_003CCloseLate_003Ed__33))]
	private IEnumerator CloseLate()
	{
		return null;
	}
}
