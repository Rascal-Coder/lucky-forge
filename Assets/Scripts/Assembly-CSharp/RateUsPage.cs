using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google.Play.Common;
using Google.Play.Review;
using TMPro;
using UnityEngine;

public class RateUsPage : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CInitReview_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RateUsPage _003C_003E4__this;

		public bool force;

		private PlayAsyncOperation<PlayReviewInfo, ReviewErrorCode> _003CrequestFlowOperation_003E5__2;

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
		public _003CInitReview_003Ed__17(int _003C_003E1__state)
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
	private sealed class _003CLaunchReview_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RateUsPage _003C_003E4__this;

		private PlayAsyncOperation<VoidResult, ReviewErrorCode> _003ClaunchFlowOperation_003E5__2;

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
		public _003CLaunchReview_003Ed__18(int _003C_003E1__state)
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
	private sealed class _003Cratelate1s_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RateUsPage _003C_003E4__this;

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
		public _003Cratelate1s_003Ed__15(int _003C_003E1__state)
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

	private float closetimer;

	public GameObject _closebtn;

	public TextMeshProUGUI _title;

	public TextMeshProUGUI _subtitle;

	public TextMeshProUGUI _btnrate;

	private ReviewManager _reviewManager;

	private PlayReviewInfo _playReviewInfo;

	private Coroutine _coroutine;

	private bool rateclicked;

	private bool opened;

	private void OnEnable()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void RateClick()
	{
	}

	public void Direk()
	{
	}

	[IteratorStateMachine(typeof(_003Cratelate1s_003Ed__15))]
	private IEnumerator ratelate1s()
	{
		return null;
	}

	public void RateAndReview()
	{
	}

	[IteratorStateMachine(typeof(_003CInitReview_003Ed__17))]
	private IEnumerator InitReview(bool force = false)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CLaunchReview_003Ed__18))]
	public IEnumerator LaunchReview()
	{
		return null;
	}

	private void DirectlyOpen()
	{
	}

	public void Close()
	{
	}

	private void OnApplicationFocus(bool hasFocus)
	{
	}
}
