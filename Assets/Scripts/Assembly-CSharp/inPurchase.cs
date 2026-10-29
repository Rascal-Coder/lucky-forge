using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FunGames.Monetization.IAP;
using UnityEngine;
using UnityEngine.Purchasing;

public class inPurchase : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CBetPrice_003Ed__77 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public inPurchase _003C_003E4__this;

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
		public _003CBetPrice_003Ed__77(int _003C_003E1__state)
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
	private sealed class _003CInitializeAndStartPurchasing_003Ed__72 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public inPurchase _003C_003E4__this;

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
		public _003CInitializeAndStartPurchasing_003Ed__72(int _003C_003E1__state)
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
	private sealed class _003CInitializeUnityGamingServices_003Ed__73 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		private Task _003CinitTask_003E5__2;

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
		public _003CInitializeUnityGamingServices_003Ed__73(int _003C_003E1__state)
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
	private sealed class _003CStart_003Ed__71 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public inPurchase _003C_003E4__this;

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
		public _003CStart_003Ed__71(int _003C_003E1__state)
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

	public static inPurchase instance;

	public static string CRYSTAL_500;

	public static string CRYSTAL_1000;

	public static string CRYSTAL_5000;

	public static string CRYSTAL_20000;

	public static string CRYSTAL_50000;

	public static string CRYSTAL_100000;

	public static string CRYSTAL_BANK;

	public static string MERDiVEN_1;

	public static string MERDiVEN_2;

	public static string MERDiVEN_3;

	public static string MERDiVEN_4;

	public static string GAMEPASS;

	public static string STARTPACK;

	public static string NOADSPACK;

	public static string ViPPACK;

	public static string DESTEKPACK;

	public static string DUNGEONKEY;

	public static string COINX2;

	public static string TALENT2X;

	public static string OFFLiNEX2;

	public static string CASTLEPACK1;

	public static string CASTLEPACK2;

	public static string CASTLEPACK3;

	public static string CASTLEPACK4;

	public static string CASTLEPACK5;

	public static string CASTLEPACK6;

	public static string CASTLEPACK7;

	public static string CASTLEPACK8;

	public static string CASTLEPACK9;

	public static string FOREVERSPEED;

	public static string PLASMABURST;

	public static bool internetconnected;

	private float timer;

	public static string _crystalfiyat1;

	public static string _crystalfiyat2;

	public static string _crystalfiyat3;

	public static string _crystalfiyat4;

	public static string _crystalfiyat5;

	public static string _crystalfiyat6;

	public static int CastlePacksNum;

	public static string _castlepackfiyat1;

	public static string _castlepackfiyat2;

	public static string _castlepackfiyat3;

	public static string _castlepackfiyat4;

	public static string _castlepackfiyat5;

	public static string _castlepackfiyat6;

	public static string _castlepackfiyat7;

	public static string _castlepackfiyat8;

	public static string _castlepackfiyat9;

	public static string _starterpackfiyat;

	public static string _foreverspeedfiyat;

	public static string _vippackfiyat;

	public static string _noadspackfiyat;

	public static string _destekpackfiyat;

	public static string _plasmaburstfiyat;

	public static string _kalici2xfiyat;

	public static string _talent2xfiyat;

	public static string _offline2xfiyat;

	public static string _dungeonkeyfiyat;

	public static string _gamepassfiyat;

	public static string[] _merdivenfiyats;

	public static string _bankfiyat;

	private bool isok;

	public static bool getforUi;

	public static bool uiopened;

	public static bool bankpurchased;

	private static bool fgInitialized;

	private int alinanGetPricing;

	public static bool SiegePackAlindi;

	public static int AlinanSiegePackNum;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public bool HasInternet()
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CStart_003Ed__71))]
	private IEnumerator Start()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CInitializeAndStartPurchasing_003Ed__72))]
	private IEnumerator InitializeAndStartPurchasing()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CInitializeUnityGamingServices_003Ed__73))]
	private IEnumerator InitializeUnityGamingServices()
	{
		return null;
	}

	public void StartBaska()
	{
	}

	private void Update()
	{
	}

	public static bool IsInitialized()
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CBetPrice_003Ed__77))]
	private IEnumerator BetPrice()
	{
		return null;
	}

	public string GetPrice(string productID)
	{
		return null;
	}

	public decimal GetPriceJUSTPrice(string productID)
	{
		return 0m;
	}

	public static void BuyCRYSTAL_500()
	{
	}

	public static void BuyCRYSTAL_1000()
	{
	}

	public static void BuyCRYSTAL_5000()
	{
	}

	public static void BuyCRYSTAL_20000()
	{
	}

	public static void BuyCRYSTAL_50000()
	{
	}

	public static void BuyCRYSTAL_100000()
	{
	}

	public static void BuyDungeonKey()
	{
	}

	public static void BuyVip()
	{
	}

	public static void BuyPlasmaBurst()
	{
	}

	public static void BuyNoAds()
	{
	}

	public static void BuyForeverSpeed()
	{
	}

	public static void BuyGamePass()
	{
	}

	public static void BuyDestekPack()
	{
	}

	public static void BuyStarterPack()
	{
	}

	public static void BuyMistikPack()
	{
	}

	public static void BuyLosePack()
	{
	}

	public static void BuyReset1()
	{
	}

	public static void BuyReset2()
	{
	}

	public static void BuyReset3()
	{
	}

	public static void BuyKalici2x()
	{
	}

	public static void BuyMitril2x()
	{
	}

	public static void BuyOffline2x()
	{
	}

	public static void BuyCrystalBank()
	{
	}

	public static void BuyMerdiven_1()
	{
	}

	public static void BuyMerdiven_2()
	{
	}

	public static void BuyMerdiven_3()
	{
	}

	public static void BuyMerdiven_4()
	{
	}

	public static void BuyCoin_1()
	{
	}

	public static void BuyCoin_2()
	{
	}

	public static void BuyCoin_3()
	{
	}

	public static void BuyHeroStone_1()
	{
	}

	public static void BuyHeroStone_2()
	{
	}

	public static void BuyHeroStone_3()
	{
	}

	public static void BuyTalentScroll_1()
	{
	}

	public static void BuyTalentScroll_2()
	{
	}

	public static void BuyTalentScroll_3()
	{
	}

	public static void BuyGachaPremium()
	{
	}

	public static void BuyGachaDeluxe()
	{
	}

	public static void BuyGachaPack1()
	{
	}

	public static void BuyGachaPack2()
	{
	}

	public static void BuyGachaPack3()
	{
	}

	public static void BuyGachaPack4()
	{
	}

	public static void BuyGachaPack5()
	{
	}

	public static void BuyGachaPack6()
	{
	}

	public static void BuySpeedPack1()
	{
	}

	public static void BuySpeedPack2()
	{
	}

	public static void BuySiegePack(int FiyatNum, int SiegeNum)
	{
	}

	public static void BuyProductID(string productId)
	{
	}

	public static void Restore2()
	{
	}

	private void OnInitialized(bool success)
	{
	}

	private void OnPurchaseSucceeded(FGIAPProduct product, FGIAPPurchaseInfo purchaseInfo, IFGReceiptValidator[] validators)
	{
	}

	private void OnRestorationSucceeded(FGIAPProduct product, FGIAPPurchaseInfo purchaseInfo, IFGReceiptValidator[] validators)
	{
	}

	private void ApplyPurchaseById(string productId)
	{
	}

	public void OnInitializeFailed(InitializationFailureReason error)
	{
	}

	private void Crystaltoplandi(int i)
	{
	}

	private void CompletePurchaseFB(string productID)
	{
	}

	private void CastleSeriPackOdulleri()
	{
	}

	private void LogPurchase(float amount, string currency)
	{
	}

	public (decimal, string) GetPriceAndCurrency(string productID)
	{
		return default;
	}
}
