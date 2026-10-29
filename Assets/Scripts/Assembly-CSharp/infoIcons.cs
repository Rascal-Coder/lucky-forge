using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class infoIcons : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003ClateonEnable_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public infoIcons _003C_003E4__this;

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
		public _003ClateonEnable_003Ed__36(int _003C_003E1__state)
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

	[Header("shop")]
	public ShopUi shopui;

	public GameObject shopinfoobj;

	[Header("talents")]
	public TalentManager talenmanager;

	public GameObject taleninfoobj;

	[Header("equipment")]
	public GameObject equipmentinfo;

	[Header("dailyquests")]
	public GunlukGorevler gunlukGorevler;

	public GameObject gunlukgorevinfo;

	[Header("GamePass")]
	public GameObject passinfo;

	public PassGame passgame;

	[Header("Merdiven")]
	public GameObject merdiveninfo;

	[Header("Spin")]
	public DailySpin dailyspin;

	public GameObject spinInfo;

	[Header("x2Kazanc")]
	public GameObject x2Kazancinfo;

	[Header("Piggy")]
	public GameObject piggyinfo;

	[Header("Dungeon")]
	public GameObject dungeonInfo;

	[Header("Research")]
	public GameObject researchInfo;

	public ResearchManager researchManager;

	[Header("OfflineEarnings")]
	public GameObject offlineInfo;

	public NewOfflineRewards offlineRewards;

	[Header("SummonWeapon")]
	public GameObject weaponSummonInfo;

	public GameObject bottomWeapon;

	public double savedcoin;

	public int savedMistikCoin;

	public int savedWeaponToken;

	public HeroController heroController;

	[Header("Saatlik")]
	public GameObject saatlikInfoicerden;

	public GameObject gunlukInfodisardan;

	public SaatlikHediye saatlikHediye;

	[Header("Fortunetrack")]
	public GameObject fortuneTrackinfo;

	public bool pagechanged;

	private float timer;

	public static bool itembulunduinfo;

	public static bool saatlikOdulCheck;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003ClateonEnable_003Ed__36))]
	private IEnumerator lateonEnable()
	{
		return null;
	}

	private void UpdateAll()
	{
	}

	private void ShopInfo()
	{
	}

	private void TalentInfo()
	{
	}

	private void WeaponSummonInfo(bool durum)
	{
	}

	private void GunlukGorevInfo()
	{
	}

	private void MerdivenInfo()
	{
	}

	private void DailySpinInfo()
	{
	}

	private void X2Kazanc()
	{
	}

	private void Piggy()
	{
	}

	private void DungeonInfo()
	{
	}

	private void ResearchInfos()
	{
	}

	private void OfflineInfos()
	{
	}

	public void EquipmentInfoVer()
	{
	}

	public void SaatlikOdulInfos()
	{
	}

	private void FortuneTrackInfos()
	{
	}

	private void passinfoTrack()
	{
	}
}
