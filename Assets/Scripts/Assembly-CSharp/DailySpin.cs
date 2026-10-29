using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailySpin : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CSpinAnimation_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DailySpin _003C_003E4__this;

		private float _003Cduration_003E5__2;

		private float _003Celapsed_003E5__3;

		private float _003Cspeed_003E5__4;

		private float _003CsoundTimer_003E5__5;

		private float _003CmaxInterval_003E5__6;

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
		public _003CSpinAnimation_003Ed__34(int _003C_003E1__state)
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

	public TextMeshProUGUI title;

	public GameObject spinWheel;

	public TextMeshProUGUI remainingTriesText;

	public Button spinButton;

	public TextMeshProUGUI dondurtxt;

	public Transform arrow;

	public Transform[] rewardSlots;

	public int remainingTries;

	private bool isSpinning;

	private DateTime lastResetTime;

	private const string LastResetTimeKey = "SpinLastResetTime";

	private const string RemainingTriesKey = "SpinRemainingTries";

	public GameObject closebtn;

	public Animator _spintopanim;

	public int mistikToken;

	private double[] paraOdulleri;

	private int[] kristalOduller;

	public GameManager gameManager;

	public RewardAdsManager rewardAdsManager;

	public TextMeshProUGUI[] paraOdullerText;

	public TextMeshProUGUI[] kristalOdullerText;

	public WarController warController;

	public bool IsSpinInProgress => false;

	private void Start()
	{
	}

	public void OyunBaslayinca()
	{
	}

	private void OnEnable()
	{
	}

	public void OpenWheel()
	{
	}

	public void Close()
	{
	}

	private void UpdateOduls()
	{
	}

	private void LoadData()
	{
	}

	private void SaveData()
	{
	}

	private void ResetTriesIfNeeded()
	{
	}

	public void Spin()
	{
	}

	[IteratorStateMachine(typeof(_003CSpinAnimation_003Ed__34))]
	private IEnumerator SpinAnimation()
	{
		return null;
	}

	public int GetClosestOdul()
	{
		return 0;
	}

	private void Closeallsecilen()
	{
	}

	public void Reklamizlendi()
	{
	}

	private void UpdateUI()
	{
	}

	private void Update()
	{
	}

	private void OdulVer(int odulnum)
	{
	}
}
