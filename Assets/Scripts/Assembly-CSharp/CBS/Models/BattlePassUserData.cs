using System;
using System.Collections.Generic;

namespace CBS.Models
{
	public class BattlePassUserData : BattlePassInstanceAccess
	{
		public string BattlePassID;

		public string InstanceID;

		public int CurrentExp;

		public List<int> CollectedSimpleReward;

		public List<int> CollectedPremiumReward;

		public List<string> PurchasedTickets;

		public DateTime? LimitStartDate;

		public void AddExp(int value)
		{
		}

		public void AddPurchasedTicket(string ticketID)
		{
		}
	}
}
