using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PiggyBank : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003Cstartlate_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PiggyBank _003C_003E4__this;

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
		public _003Cstartlate_003Ed__18(int _003C_003E1__state)
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

	public TextMeshProUGUI _title;

	public TextMeshProUGUI _crystalsayisi;

	public TextMeshProUGUI _maxcrystal;

	public TextMeshProUGUI _subtitle;

	public TextMeshProUGUI _bottomsubtitle;

	public TextMeshProUGUI _fiyat;

	public TextMeshProUGUI kalansatinalim;

	public Slider _slider;

	public Button _btn;

	public GameObject _loading;

	public PageReferences _pageRef;

	private const string PrefCountKey = "PiggyBank_PurchaseCount";

	private const string PrefTimeKey = "PiggyBank_FirstPurchaseTime";

	private int purchaseCount;

	private DateTime firstPurchaseTime;

	public static bool piggyacildi;

	private void OnEnable()
	{
	}

	private void Gettext()
	{
	}

	[IteratorStateMachine(typeof(_003Cstartlate_003Ed__18))]
	private IEnumerator startlate()
	{
		return null;
	}

	public void Close()
	{
	}

	public void OpenPiggyBank()
	{
	}

	public void Satinal()
	{
	}

	private void Update()
	{
	}

	private void OnApplicationFocus(bool hasFocus)
	{
	}

	private void LoadPurchaseData()
	{
	}

	private void SavePurchaseData()
	{
	}

	private void ResetIfExpired()
	{
	}

	private void IncrementPurchaseCount()
	{
	}

	private bool CanPurchase()
	{
		return false;
	}

	private void UpdateButtonState()
	{
	}
}
