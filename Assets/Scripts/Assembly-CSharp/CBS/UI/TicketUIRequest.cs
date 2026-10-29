using System;
using CBS.Models;

namespace CBS.UI
{
	public class TicketUIRequest
	{
		public BattlePassTicket Ticket;

		public bool Puchased;

		public Action<string, string, int> PurchaseRequest;
	}
}
