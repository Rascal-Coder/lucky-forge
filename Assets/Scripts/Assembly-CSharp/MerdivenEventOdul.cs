using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MerdivenEventOdul : MonoBehaviour
{
	public enum OdulNedir
	{
		Crystal = 0,
		GoldCoin = 1,
		TalentCoin = 2,
		WeaponToken = 3,
		MistikToken = 4,
		HeroStone = 5,
		Yok = 6
	}

	[CompilerGenerated]
	private sealed class _003Cstartlate_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MerdivenEventOdul _003C_003E4__this;

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
		public _003Cstartlate_003Ed__35(int _003C_003E1__state)
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

	private static readonly bool[] SatinAlimTamamlandi;

	private static bool[] satinalimProcessed;

	public MerdivenEventManager _manager;

	public int parali;

	[Header("Odul B\ufffdR")]
	public OdulNedir odul_1;

	public int odul_1Adet;

	[Header("Odul \ufffdK\ufffd")]
	public OdulNedir odul_2;

	public int odul_2Adet;

	public bool toplandi;

	private bool firstdone;

	[Header("Others")]
	public int OdulNum;

	public TextMeshProUGUI _odulNum;

	public TextMeshProUGUI _free;

	public GameObject _lockicon;

	public Button _btnget;

	public Transform _odul1icon;

	public TextMeshProUGUI _odul1adet;

	public Transform _odul2icon;

	public TextMeshProUGUI _odul2adet;

	public GameObject OdulAlindi;

	public GameObject OdulAlinmadi;

	public RectTransform OdulAlani;

	public MerdivenEventOdul _bendenOnceki;

	public bool KapaliOlan;

	public TextMeshProUGUI _varsaHeroinfo;

	public TextMeshProUGUI _odulalindi;

	public GameObject _shadowKilit;

	public GameObject lightuphere;

	public bool IsPaidTierFree => false;

	public GameObject GetIcon(OdulNedir odul, Transform parent)
	{
		return null;
	}

	public void ApplyGppFreeLabel()
	{
	}

	private void RefreshPriceLabel()
	{
	}

	private void OnEnable()
	{
	}

	[IteratorStateMachine(typeof(_003Cstartlate_003Ed__35))]
	private IEnumerator startlate()
	{
		return null;
	}

	private void Start()
	{
	}

	public void CheckData()
	{
	}

	public void Collectit()
	{
	}

	public void CollectArea(bool iap = false)
	{
	}

	public void VerOdulu(OdulNedir odul, int adet, bool iap = false)
	{
	}

	public static void CompletePaidTierPurchase(int tier)
	{
	}

	private void Update()
	{
	}
}
