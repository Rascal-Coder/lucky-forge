using System;
using System.Collections.Generic;
using CBS.Core;

namespace CBS.Models
{
	public class BattlePassInstance : ICustomData<CBSBattlePassCustomData>
	{
		private static readonly string BattlePassPrefix;

		private static readonly string FreeTicketID;

		public string ID;

		public string InstanceID;

		public bool IsActive;

		public string DisplayName;

		public string Description;

		public bool ExtraLevelsEnabled;

		public bool TasksEnabled;

		public string TasksPoolID;

		public bool BankEnabled;

		public RewardDelivery BankRewardDelivery;

		public bool AutomaticRewardOnEnd;

		public RewardDelivery AutomaticRewardDelivery;

		public bool TimeLimitedRewardEnabled;

		public int AvailableRewardsPerDay;

		public float GainExpMultiplier;

		public int ExpStep;

		public int DurationInHours;

		public DateTime? StartDate;

		public DateTime? EndDate;

		public List<BattlePassLevel> LevelTree;

		public List<BattlePassLevel> ExtraLevelTree;

		public BattlePassTicket FreeTicket;

		public List<BattlePassTicket> PaidTickets;

		public string CustomDataClassName { get; set; }

		public string CustomRawData { get; set; }

		public bool CompressCustomData => false;

		public virtual T GetCustomData<T>() where T : CBSBattlePassCustomData
		{
			return null;
		}

		public string GetEventID()
		{
			return null;
		}

		public BattlePassTicket GetFreeTicket()
		{
			return null;
		}

		public List<BattlePassTicket> GetPaidTickets()
		{
			return null;
		}

		public void AddTicket(BattlePassTicket ticket)
		{
		}

		public void RemoveTicket(BattlePassTicket ticket)
		{
		}

		public int GetMaxExpValue()
		{
			return 0;
		}

		public int GetMaxLevelCount()
		{
			return 0;
		}

		public List<BattlePassLevel> GetLevelTree()
		{
			return null;
		}

		public List<BattlePassBankLevel> GetBankLevels(int profilePassLevel, bool available)
		{
			return null;
		}
	}
}
