using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUi : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CKapaniyor_003Ed__213 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ShopUi _003C_003E4__this;

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
		public _003CKapaniyor_003Ed__213(int _003C_003E1__state)
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
	private sealed class _003CSmoothMove_003Ed__166 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RectTransform contentRect;

		public Vector3 targetPosition;

		public float duration;

		private float _003CelapsedTime_003E5__2;

		private Vector3 _003CstartingPosition_003E5__3;

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
		public _003CSmoothMove_003Ed__166(int _003C_003E1__state)
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
	private sealed class _003Cfiyatfirst_003Ed__180 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ShopUi _003C_003E4__this;

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
		public _003Cfiyatfirst_003Ed__180(int _003C_003E1__state)
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

	public static double[] CoinPackOduls;

	public GameManager gameManager;

	public float[] chestContentYeri;

	public float[] paketlerContentYleri;

	public int[] equipmentCrystalPrices;

	public TextMeshProUGUI _topcrystal;

	public GameObject hourspeedPack;

	public TextMeshProUGUI speedtitles;

	public TextMeshProUGUI h24title;

	public TextMeshProUGUI h72title;

	public TextMeshProUGUI hUnlimitedtitle;

	public TextMeshProUGUI[] speedsubtitles;

	public TextMeshProUGUI[] speedfiyats;

	public TextMeshProUGUI noadstitle;

	public TextMeshProUGUI noadsodul1;

	public TextMeshProUGUI noadsodul2;

	public TextMeshProUGUI noadsodul3;

	public TextMeshProUGUI noadsfiyat;

	public TextMeshProUGUI viptitle;

	public TextMeshProUGUI vipodul1;

	public TextMeshProUGUI vipodul2;

	public TextMeshProUGUI vipodul3;

	public TextMeshProUGUI vipfiyat;

	public TextMeshProUGUI destektitle;

	public TextMeshProUGUI destekodul1;

	public TextMeshProUGUI destekodul2;

	public TextMeshProUGUI destekodul3;

	public TextMeshProUGUI destekfiyat;

	public TextMeshProUGUI plasmapacktitle;

	public GameObject plasmaburstobj;

	public TextMeshProUGUI plasmapacksubtitle;

	public TextMeshProUGUI plasmaburstfiyat;

	public TextMeshProUGUI coinVerilecekTitle1;

	public TextMeshProUGUI coinVerilecekTitle2;

	public TextMeshProUGUI coinVerilecekTitle3;

	public TextMeshProUGUI coinFiyat1;

	public TextMeshProUGUI coinFiyat2;

	public TextMeshProUGUI coinFiyat3;

	public TextMeshProUGUI herostoneFiyat1;

	public TextMeshProUGUI herostoneFiyat2;

	public TextMeshProUGUI herostoneFiyat3;

	public TextMeshProUGUI talentFiyat1;

	public TextMeshProUGUI talentFiyat2;

	public TextMeshProUGUI talentFiyat3;

	public TextMeshProUGUI _kalicix2title;

	public TextMeshProUGUI _kalicix2subtitle;

	public TextMeshProUGUI _kalicix2fiyat;

	public TextMeshProUGUI _mitrilx2title;

	public TextMeshProUGUI _mitrilx2subtitle;

	public TextMeshProUGUI _mitrilx2fiyat;

	public TextMeshProUGUI _offlinex12title;

	public TextMeshProUGUI _offlinex2subtitle;

	public TextMeshProUGUI _offlinex2fiyat;

	public TextMeshProUGUI _dungeonkeytitle;

	public TextMeshProUGUI _dungeonkeyfiyat;

	public TextMeshProUGUI _kristal1fiyat;

	public TextMeshProUGUI _kristal2fiyat;

	public TextMeshProUGUI _kristal3fiyat;

	public TextMeshProUGUI _kristal4fiyat;

	public TextMeshProUGUI _kristal5fiyat;

	public TextMeshProUGUI _kristal6fiyat;

	public TextMeshProUGUI _dungeonskillexpkac;

	public TextMeshProUGUI[] _relicsAdetSatilan;

	public TextMeshProUGUI[] kacvaluekristal;

	public static GameObject _Thanks;

	public Text _thanks;

	public RectTransform _contentrect;

	public RectTransform _chestcontent;

	public RectTransform _contentPacks;

	public RectTransform _contentGeneral;

	public static int skillchestreklamhakki;

	public RewardAdsManager _rewardads;

	public PageReferences _pageref;

	public ParticleSystem _particlepatla;

	private DateTime EarnTimer2;

	private TimeSpan A2;

	public static string KutuTimerS2;

	private DateTime EarnTimer3;

	private TimeSpan A3;

	public static string KutuTimerS3;

	private DateTime EarnTimer4;

	private TimeSpan A4;

	public static string KutuTimerS4;

	public static int coinParaReklamHakki;

	public float timer;

	public GameObject _loading;

	public RateEnabler _rateEnabler;

	private bool rateverdik;

	public CanvasJobs _canvasjobs;

	public GameObject _infoicon;

	public static bool dungeonkeyalindi;

	private const string KEY_COUNTS = "dungeon_PurchaseCounts";

	private const string KEY_RESET = "dungeon_LastResetTime";

	public static int dungeonKeyDailyHak;

	public TextMeshProUGUI dungeonKeyKalanHak;

	public Button dungeonBtn;

	public TextMeshProUGUI packname_levelpacks;

	public TextMeshProUGUI packname_dailyshop;

	public TextMeshProUGUI packname_mysticshop;

	public TextMeshProUGUI packname_weapontoken;

	public TextMeshProUGUI packname_lifetimepacks;

	public TextMeshProUGUI packname_bundles;

	public TextMeshProUGUI packname_coinshop;

	public TextMeshProUGUI packname_crystalshop;

	[Header("GPP ï¿½ hidden when Play Pass active (auto-resolved if empty)")]
	public GameObject levelPacksTitleSection;

	public GameObject levelPacksSection;

	public GameObject crystalIapSection;

	public GameObject dailyCrystalSection;

	public DailyRollShop dailyRollShop;

	[Header("Bottombtnsinapp")]
	public Transform _choosebtn;

	public TextMeshProUGUI[] _btnsbottominapp;

	public GameObject[] _pages;

	[Header("freeandadspack")]
	public TextMeshProUGUI DailyRuneTitle;

	public TextMeshProUGUI DailyRunerewardButtonText;

	private DateTime DailyRunenextFreeRewardTime;

	public int DailyRuneadRewardsRemaining;

	private const string DailyRuneRewardTimerKey = "DailyRuneNextFreeRewardTime";

	private const string DailyRuneAdRewardsKey = "DailyRuneAdRewardsRemaining";

	public Button DailyRuneButton;

	public GameObject _DailyRuneinfo;

	public GameObject _DailyRuneinfobottom;

	public bool dailyrunevar;

	[Header("FreeCrystalPack")]
	public TextMeshProUGUI DailyCrystalTitle;

	public TextMeshProUGUI DailyCrystalRewardButtonText;

	private DateTime DailyCrystalNextFreeRewardTime;

	public int DailyCrystalAdRewardsRemaining;

	private const string DailyCrystalRewardTimerKey = "DailyCrystalNextFreeRewardTime";

	private const string DailyCrystalAdRewardsKey = "DailyCrystalAdRewardsRemaining";

	public Button DailyCrystalButton;

	public GameObject _DailyCrystalinfo;

	public GameObject _DailyCrystalinfobottom;

	[Header("FreeChestPack")]
	public TextMeshProUGUI DailyChestTitle;

	public TextMeshProUGUI DailyChestRewardButtonText;

	private DateTime DailyChestNextFreeRewardTime;

	public int DailyChestAdRewardsRemaining;

	private const string DailyChestRewardTimerKey = "DailyChestNextFreeRewardTime";

	private const string DailyChestAdRewardsKey = "DailyChestAdRewardsRemaining";

	public Button DailyChestButton;

	public GameObject _DailyChestInfo;

	public GameObject _DailyChestInfoBottom;

	public GameObject[] _infoChests;

	private bool anyPotActive;

	private bool refreshprice;

	public void FreeDailyChestClicked()
	{
	}

	public void DailyChestReklamizlendi()
	{
	}

	private void DailyChestOdulVer()
	{
	}

	private void DailyChestResetTimer()
	{
	}

	private void DailyChestTextGuncelle()
	{
	}

	private void LoadDailyChestData()
	{
	}

	private void SaveDailyChestRewardData()
	{
	}

	public void FreeDailyRuneClicked()
	{
	}

	public void DailyRuneReklamizlendi()
	{
	}

	private void DailyRuneOdulVer()
	{
	}

	private void DailyRuneResetTimer()
	{
	}

	private void DailyRuneTextGuncelle()
	{
	}

	private void LoadDailyRuneData()
	{
	}

	private void SaveDailyRuneRewardData()
	{
	}

	public void FreeDailyCrystalClicked()
	{
	}

	public void DailyCrystalReklamizlendi()
	{
	}

	private void DailyCrystalOdulVer()
	{
	}

	private void DailyCrystalResetTimer()
	{
	}

	private void DailyCrystalTextGuncelle()
	{
	}

	private void LoadDailyCrystalData()
	{
	}

	private void SaveDailyCrystalRewardData()
	{
	}

	public void OpenPageinapp(int page)
	{
	}

	private void Start()
	{
	}

	private void ResetDailyCounts()
	{
	}

	public void GoPack(int i)
	{
	}

	[IteratorStateMachine(typeof(_003CSmoothMove_003Ed__166))]
	private IEnumerator SmoothMove(RectTransform contentRect, Vector3 targetPosition, float duration)
	{
		return null;
	}

	public void ApplyGppShopUi(bool hideIapAndAds)
	{
	}

	private void ResolveGppShopSections()
	{
	}

	public void FiyatGuncelle()
	{
	}

	private void TextAyarla()
	{
	}

	public void Openinappbonuses()
	{
	}

	public void Openinappcrystals()
	{
	}

	public void OpeninappbonusesNORULES()
	{
	}

	public void OpeninappbonusesNORULESNOADS()
	{
	}

	public void OpenBonusesSayfadan(GameObject closed)
	{
	}

	public void gocrystals()
	{
	}

	public void OpenChestPackSayfadan(GameObject closed)
	{
	}

	public void OpeninappRegular()
	{
	}

	private void OnEnable()
	{
	}

	[IteratorStateMachine(typeof(_003Cfiyatfirst_003Ed__180))]
	private IEnumerator fiyatfirst()
	{
		return null;
	}

	private void CheckKutu()
	{
	}

	private void Update()
	{
	}

	public void Buy500()
	{
	}

	public void Buy1000()
	{
	}

	public void Buy5000()
	{
	}

	public void Buy20000()
	{
	}

	public void Buy50000()
	{
	}

	public void Buy100000()
	{
	}

	public void BuyDungeonKey()
	{
	}

	public void BuyVip()
	{
	}

	public void BuyPlasmaBurst()
	{
	}

	public void BuyNoAds()
	{
	}

	public void BuySpeed1()
	{
	}

	public void BuySpeed2()
	{
	}

	public void BuyForeverSpeed()
	{
	}

	public void BuyStarterPack()
	{
	}

	public void BuyDestekPack()
	{
	}

	public void BuyKalicix2()
	{
	}

	public void BuyMitrilx2()
	{
	}

	public void BuyOffline12()
	{
	}

	public void BuyCoinPack1()
	{
	}

	public void BuyCoinPack2()
	{
	}

	public void BuyCoinPack3()
	{
	}

	public void BuyTalent1()
	{
	}

	public void BuyTalent2()
	{
	}

	public void BuyTalent3()
	{
	}

	public void BuyHeroStone_1()
	{
	}

	public void BuyHeroStone_2()
	{
	}

	public void BuyHeroStone_3()
	{
	}

	public void Close()
	{
	}

	[IteratorStateMachine(typeof(_003CKapaniyor_003Ed__213))]
	private IEnumerator Kapaniyor()
	{
		return null;
	}

	public void GetSkillChest1Reklam()
	{
	}

	private void ConfetiPlay()
	{
	}

	public void closethanksfor()
	{
	}

	private void OnApplicationFocus(bool hasFocus)
	{
	}
}
