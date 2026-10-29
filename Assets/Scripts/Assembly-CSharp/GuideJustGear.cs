using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GuideJustGear : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAgizAnimasyonu_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GuideJustGear _003C_003E4__this;

		private bool _003Cacik_003E5__2;

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
		public _003CAgizAnimasyonu_003Ed__27(int _003C_003E1__state)
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
	private sealed class _003CTypeYazi_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GuideJustGear _003C_003E4__this;

		public string yazi;

		private int _003Ci_003E5__2;

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
		public _003CTypeYazi_003Ed__26(int _003C_003E1__state)
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

	public int GuideNum;

	public GameObject gearClickArrow;

	public GameObject mergeClickArrow;

	public GameObject mergePage;

	public GameObject gearFirstArrow;

	public GameObject gearSecondArrow;

	public GameObject gearThirdArrow;

	public GameObject[] mergeareaDolu;

	public GameObject gearMergeitArrow;

	public GameObject mergeyapiliyorPage;

	public GameObject closeMergePageArrow;

	public GameObject gearWearArrow;

	public GameObject gearPopUpPage;

	public GameObject gearinsideWearitArrow;

	public GameObject gearPopUpCloseArrow;

	public GameObject yaziEkrani;

	public TextMeshProUGUI yazisi;

	private float delayclick;

	public InventoryGearUI gearUi;

	public GameObject agiz;

	[SerializeField]
	private float yazmaHizi;

	private Coroutine yazCoroutine;

	private Coroutine agizCoroutine;

	public static bool guidebaslat;

	public static bool LockGearClick;

	private bool[] bugfixes;

	private bool ready;

	public void yaziver(string yazi)
	{
	}

	[IteratorStateMachine(typeof(_003CTypeYazi_003Ed__26))]
	private IEnumerator TypeYazi(string yazi)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CAgizAnimasyonu_003Ed__27))]
	private IEnumerator AgizAnimasyonu()
	{
		return null;
	}

	public void yazikapandi()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnEnable()
	{
	}
}
