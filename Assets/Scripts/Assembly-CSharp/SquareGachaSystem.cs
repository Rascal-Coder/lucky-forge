using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SquareGachaSystem : MonoBehaviour
{
	[Serializable]
	public class RewardGacha
	{
		public int RewardNum;

		public string rewardName;

		public Sprite icon;

		public int amount;

		public int chanceWeight;
	}

	[CompilerGenerated]
	private sealed class _003CAnimateSelector_003Ed__79 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int count;

		public int targetIndex;

		public SquareGachaSystem _003C_003E4__this;

		private int _003CtotalSteps_003E5__2;

		private int _003Cindex_003E5__3;

		private int _003Ci_003E5__4;

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
		public _003CAnimateSelector_003Ed__79(int _003C_003E1__state)
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
	private sealed class _003CSmoothMove_003Ed__71 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SquareGachaSystem _003C_003E4__this;

		public Vector2 targetPos;

		private Vector2 _003CstartPos_003E5__2;

		private float _003Ct_003E5__3;

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
		public _003CSmoothMove_003Ed__71(int _003C_003E1__state)
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
	private sealed class _003CSpinRoutine_003Ed__77 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SquareGachaSystem _003C_003E4__this;

		public int count;

		private List<int> _003Cresults_003E5__2;

		private int _003Ci_003E5__3;

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
		public _003CSpinRoutine_003Ed__77(int _003C_003E1__state)
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

	public GameObject[] insidePages;

	public GameObject[] bottomBtns;

	public TextMeshProUGUI[] bottombtntexts;

	public Transform bottombtnlight;

	public GameObject[] bottominfos;

	public CanvasJobs canvasJobs;

	public TextMeshProUGUI titlegacha;

	public TextMeshProUGUI gachatimer;

	public TextMeshProUGUI eventtokenadet;

	public TextMeshProUGUI eventdiceadet;

	public TextMeshProUGUI skipanimtxt;

	public TextMeshProUGUI middleText;

	public TextMeshProUGUI atilanzaradet;

	public TextMeshProUGUI[] drawtxts;

	public Slider slideraltoduller;

	public TextMeshProUGUI atilanzaraltoduller;

	public TextMeshProUGUI drawntxt;

	public Button[] altoduller;

	public bool[] altodullerbools;

	public int[] altodullerlimits;

	public int[] altodulleroduls;

	private int toplananaltoduller;

	public RectTransform altOdullerRect;

	public TextMeshProUGUI[] chancestxt;

	public Transform[] chancescontent;

	public GameObject chancespage;

	public Transform[] rewardSlots;

	public Image selector;

	public Toggle skipAnimationToggle;

	public TextMeshProUGUI Rewardstxt;

	public TextMeshProUGUI taptocontinue;

	public GameObject popupReward;

	public Transform rewardPopupContainer;

	public GameManager gameManager;

	private int lastSelectorIndex;

	public GameObject[] btnligts;

	public DateTime eventStartTimeUTC;

	private TimeSpan eventCycleDuration;

	private const string SavedCycleKey = "EmeraldGachaSavedCycle";

	public InventoryManager inventoryManager;

	public List<RewardGacha> rewards;

	public int totalSpins;

	public int totalSpinsEmerald;

	public int guaranteedSpin;

	public RewardGacha guaranteedReward;

	public Sprite[] rewardIcons;

	public Color[] rewardColors;

	public Button closebtn;

	public int[] WeeklyCollections;

	public GachaExchange gachaExchange;

	public GachaPurchasePacks gachaPurchasePacks;

	public GachaEventDailySignin gachaEventDailySignin;

	public TextMeshProUGUI[] infotexts;

	public GameObject infopage;

	private bool spinning;

	private bool started;

	private Coroutine smoothMoveCoroutine;

	private void Start()
	{
	}

	public void OpenInfoClose()
	{
	}

	public void OpenClosePage()
	{
	}

	public void ClosePage()
	{
	}

	public bool HandleBackButton()
	{
		return false;
	}

	public void OpenInsidePage(int who)
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void OpenChances()
	{
	}

	public void CloseChances()
	{
	}

	private void ChancesYazdir()
	{
	}

	private void UpdateWeeklyCollections()
	{
	}

	private void AltOdulKontrol()
	{
	}

	[IteratorStateMachine(typeof(_003CSmoothMove_003Ed__71))]
	private IEnumerator SmoothMove(Vector2 targetPos)
	{
		return null;
	}

	public void AltOdulTopla(int kim)
	{
	}

	public void GuncelleData()
	{
	}

	private void UbandaEventRewards()
	{
	}

	private void ApplyRewardsToSlots()
	{
	}

	public void Spin(int count)
	{
	}

	[IteratorStateMachine(typeof(_003CSpinRoutine_003Ed__77))]
	private IEnumerator SpinRoutine(int count)
	{
		return null;
	}

	private int GetRandomWeightedIndex()
	{
		return 0;
	}

	[IteratorStateMachine(typeof(_003CAnimateSelector_003Ed__79))]
	private IEnumerator AnimateSelector(int targetIndex, int count)
	{
		return null;
	}

	private void ShowRewardPopups(List<int> resultIndexes)
	{
	}

	public void ClosePopup()
	{
	}

	private int GetCurrentCycleCount()
	{
		return 0;
	}

	public DateTime GetCurrentCycleStart()
	{
		return default;
	}

	public DateTime GetNextResetTime()
	{
		return default;
	}

	private void UpdateCountdownUI()
	{
	}

	public string UpdateCountdownString()
	{
		return null;
	}

	private void ResetIfNeeded()
	{
	}
}
