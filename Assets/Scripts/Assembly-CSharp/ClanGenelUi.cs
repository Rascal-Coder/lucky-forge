using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CBS;
using CBS.Models;
using CBS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClanGenelUi : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CGuildRaidLater_003Ed__95 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public long damage;

		public ClanGenelUi _003C_003E4__this;

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
		public _003CGuildRaidLater_003Ed__95(int _003C_003E1__state)
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

	private IClan ClanModule;

	private IProfile ProfileModule;

	public TextMeshProUGUI clannameChat;

	public TextMeshProUGUI DisplayName;

	public TextMeshProUGUI subtitle;

	public TextMeshProUGUI clanlvl;

	public TextMeshProUGUI memberscount;

	public Transform selector;

	public ClanAvatarDrawer Avatar;

	public TextMeshProUGUI clanlvlPerks;

	public TextMeshProUGUI memberstitle;

	public static bool IsAdmin;

	public TextMeshProUGUI[] toptexts;

	public GameObject[] _pages;

	public Image[] topBtns;

	public GameObject[] _infopages;

	public ClanMembers clanMembers;

	public ClanTasksScreen clanTasks;

	public GuildRaidUi guildraidui;

	public GameObject clanchat;

	public TextMeshProUGUI clanchattxt;

	public GameObject clanchatbtn;

	public int ClanLevel;

	public int ClanExp;

	public int ClanMaxExp;

	public Slider ClanExpSlider;

	public TextMeshProUGUI expMaxExp;

	public Toggle IsOpen;

	private bool started;

	private float timeCheck;

	public GameObject isjoinarea;

	public GameObject requestbtn;

	public GameObject RequestMenu;

	public TextMeshProUGUI disbandtext;

	public TextMeshProUGUI requestMenutxt;

	public ClanLogin clanLogin;

	public GameObject loadingicon;

	public ClanTaskLocal clanTaskLocal;

	public ClanPerksUi clanPerksUi;

	public TextMeshProUGUI requesttxt;

	public TextMeshProUGUI isjoiningopen;

	private bool justonthestart;

	public TextMeshProUGUI[] chatagevertiftxts;

	[Header("donater")]
	public TextMeshProUGUI donationtitle;

	public TextMeshProUGUI donationsub;

	public TextMeshProUGUI donationdailylimit;

	public TextMeshProUGUI donatebtnustu;

	public TextMeshProUGUI donateprice;

	public TextMeshProUGUI donateregular;

	public GameObject donateobj;

	public Button donatebtn;

	public GameObject infodonate;

	public Animator animDonate;

	public GameObject donateLocker;

	private const string KEY_FREE_COUNT = "ClanDonate_FreeRerollsUsed";

	private const string KEY_FREE_RESET_TIME = "ClanDonate_LastFreeResetTime";

	private int donatedailylimit;

	private const int MAX_FREE_REROLLS = 5;

	public static bool raiddencikildi;

	public GameObject age13confirm;

	private long bossraiddamage;

	public static int clankatkisi;

	private int clankatkisieklenecek;

	private int crystaladded;

	private int talentadded;

	private int herostoneadded;

	private int mistiktokenadded;

	private ICurrency CurrencyModule { get; set; }

	private ClanFullInfo ClanInfo { get; set; }

	private void DonateCheck24Hour()
	{
	}

	public void Donate()
	{
	}

	public void OpenCloseDonation()
	{
	}

	public void CloseChat()
	{
	}

	public void OpenChat()
	{
	}

	public void Chat13Confirmed()
	{
	}

	public void DoNotConfirm13()
	{
	}

	private void Start()
	{
	}

	public void RequestOpen(bool open)
	{
	}

	public void QuitorDisband()
	{
	}

	public void LeaveClanHandler()
	{
	}

	public void DisbandClanHandler()
	{
	}

	private void OnEnable()
	{
	}

	public void UpdateData()
	{
	}

	private void OnGet(CBSGetClanFullInfoResult result)
	{
	}

	public void CheckClandamiyiz()
	{
	}

	private void OnUpdateDisplayName(CBSUpdateDisplayNameResult result)
	{
	}

	private void OnGet2(CBSGetClanMembersResult result)
	{
	}

	public void OpenPage(int page)
	{
	}

	public void EditDisplayNameHandler()
	{
	}

	public void EditDescriptionHandler()
	{
	}

	public void OnVisibilityChange(bool val)
	{
	}

	private void Update()
	{
	}

	private void OnAddTaskPoint(CBSModifyClanTaskPointsResult result)
	{
	}

	private void AddTaskPoint(string taskID, int pointsToAdd)
	{
	}

	public void GuildRaidOduller(long damage)
	{
	}

	[IteratorStateMachine(typeof(_003CGuildRaidLater_003Ed__95))]
	private IEnumerator GuildRaidLater(long damage)
	{
		return null;
	}

	private void SaveKlanKatkisi(CBSBaseResult result)
	{
	}

	private void AddTaskPointsData()
	{
	}

	private void OdulvarsaVer()
	{
	}

	private void OdulTamam(CBSGetCurrenciesResult result)
	{
	}

	private void OnSubtractCR(CBSUpdateCurrencyResult result)
	{
	}

	private void OnSubtractTA(CBSUpdateCurrencyResult result)
	{
	}

	private void OnSubtractHE(CBSUpdateCurrencyResult result)
	{
	}

	private void OnSubtractMS(CBSUpdateCurrencyResult result)
	{
	}
}
