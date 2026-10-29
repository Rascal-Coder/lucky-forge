using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderBoard : MonoBehaviour
{
	[Serializable]
	public class Top10Entry
	{
		public string uniqueID;

		public string nickname;

		public int floors_descended;

		public int player_maincharicon;
	}

	[Serializable]
	public class LeaderboardEntry
	{
		public int id;

		public string nickname;

		public int floors_descended;

		public int rank;

		public string uniqueID;
	}

	[Serializable]
	public class LeaderboardResponse
	{
		public List<LeaderboardEntry> leaderboard;

		public int globalRank;

		public string error;

		public string message;
	}

	[Serializable]
	public class Top10Response
	{
		public List<Top10Entry> top10;

		public string error;

		public string message;
	}

	[Serializable]
	public class RewardCheckResponse
	{
		public string message;

		public int award_rank;

		public string saveID;
	}

	[CompilerGenerated]
	private sealed class _003CCheckClanChat_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string url;

		public LeaderBoard _003C_003E4__this;

		private UnityWebRequest _003Cwww_003E5__2;

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
		public _003CCheckClanChat_003Ed__38(int _003C_003E1__state)
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
	private sealed class _003CCheckCoinReklam_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string url;

		private UnityWebRequest _003Cwww_003E5__2;

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
		public _003CCheckCoinReklam_003Ed__39(int _003C_003E1__state)
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
	private sealed class _003CCheckForWeeklyReward_003Ed__57 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LeaderBoard _003C_003E4__this;

		private UnityWebRequest _003Cwww_003E5__2;

		private RewardCheckResponse _003Cresponse_003E5__3;

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
		public _003CCheckForWeeklyReward_003Ed__57(int _003C_003E1__state)
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
	private sealed class _003CCheckGuild_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string url;

		public LeaderBoard _003C_003E4__this;

		private UnityWebRequest _003Cwww_003E5__2;

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
		public _003CCheckGuild_003Ed__37(int _003C_003E1__state)
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
	private sealed class _003CCheckVersion_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LeaderBoard _003C_003E4__this;

		public string url;

		private UnityWebRequest _003Cwww_003E5__2;

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
		public _003CCheckVersion_003Ed__36(int _003C_003E1__state)
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
	private sealed class _003CGetLeaderboardData_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LeaderBoard _003C_003E4__this;

		private UnityWebRequest _003Cwww_003E5__2;

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
		public _003CGetLeaderboardData_003Ed__43(int _003C_003E1__state)
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
	private sealed class _003CGetTop10Players_003Ed__61 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LeaderBoard _003C_003E4__this;

		private UnityWebRequest _003Cwww_003E5__2;

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
		public _003CGetTop10Players_003Ed__61(int _003C_003E1__state)
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
	private sealed class _003CSendPlayerData_003Ed__55 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LeaderBoard _003C_003E4__this;

		private UnityWebRequest _003Cwww_003E5__2;

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
		public _003CSendPlayerData_003Ed__55(int _003C_003E1__state)
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
	private sealed class _003Cresetimezamanlating_003Ed__47 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LeaderBoard _003C_003E4__this;

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
		public _003Cresetimezamanlating_003Ed__47(int _003C_003E1__state)
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

	public int playerRank;

	[SerializeField]
	private List<LeaderboardEntry> leaderboardEntries;

	private string uniqueID;

	public string playerNickname;

	private float timer60s;

	public float timerforLeaderboard;

	public LeaderBoardUi _leaderUi;

	public static bool connectedOnline;

	public GameObject _leaderboardbtn;

	public CanvasJobs _canvasJobs;

	public Transform karakterlerHiearchy;

	private float kayanyazitimer;

	private float timer1s;

	[Header("ui")]
	public TextMeshProUGUI _youwon;

	public TextMeshProUGUI _weeklyrewards;

	public TextMeshProUGUI _kacincioldu;

	public TextMeshProUGUI _odulunuzhesabiniza;

	public GameObject _weeklywinner;

	[Header("version")]
	private string iosVersionUrl;

	private string androidVersionUrl;

	private string guildUrl;

	private string clanchat;

	private string coinReklam;

	public string OnlineVersionkac;

	private bool uyumlu;

	public static bool guildon;

	public static bool clanchaton;

	public static bool reklamNew;

	public GameObject _updateui;

	private bool connectedtoLearders;

	public GameObject ClanOnlineSystemCBS;

	private bool weeklydone;

	private bool saveidonlinedegisimtamamlandi;

	private bool updated;

	private bool datayoktu;

	private int previousFloors;

	private int newRank;

	public kartlar _kartlar;

	public static bool Weeklysavechanging;

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CCheckVersion_003Ed__36))]
	private IEnumerator CheckVersion(string url)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCheckGuild_003Ed__37))]
	private IEnumerator CheckGuild(string url)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCheckClanChat_003Ed__38))]
	private IEnumerator CheckClanChat(string url)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCheckCoinReklam_003Ed__39))]
	private IEnumerator CheckCoinReklam(string url)
	{
		return null;
	}

	private void Update()
	{
	}

	public string egerkazarsan2(int floorsNeededToAdvance)
	{
		return null;
	}

	private int CalculateFloorsToAdvance(int positionsAhead)
	{
		return 0;
	}

	[IteratorStateMachine(typeof(_003CGetLeaderboardData_003Ed__43))]
	private IEnumerator GetLeaderboardData()
	{
		return null;
	}

	private void ResetTimeNeZaman()
	{
	}

	[IteratorStateMachine(typeof(_003Cresetimezamanlating_003Ed__47))]
	private IEnumerator resetimezamanlating()
	{
		return null;
	}

	public void UpdatePlayerFloors2()
	{
	}

	private void UpdateLocalRanking()
	{
	}

	[IteratorStateMachine(typeof(_003CSendPlayerData_003Ed__55))]
	public IEnumerator SendPlayerData()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCheckForWeeklyReward_003Ed__57))]
	private IEnumerator CheckForWeeklyReward()
	{
		return null;
	}

	public void Closewinner()
	{
	}

	private void OdulVer(int rank)
	{
	}

	[IteratorStateMachine(typeof(_003CGetTop10Players_003Ed__61))]
	public IEnumerator GetTop10Players()
	{
		return null;
	}

	public void ShowTop10Players(List<Top10Entry> top10Players)
	{
	}
}
