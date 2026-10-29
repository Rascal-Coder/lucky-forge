using System;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class BattlePassTicketsDrawer : MonoBehaviour
	{
		[SerializeField]
		private TicketScroller TicketScroller;

		public Action ReloadRequest { get; set; }

		private string BattlePassID { get; set; }

		private IBattlePass BattlePass { get; set; }

		private BattlePassPrefabs PassPrefabs { get; set; }

		private void Awake()
		{
		}

		public void Draw(BattlePassInstance instance, BattlePassUserInfo state)
		{
		}

		private void PurchaseTicketRequest(string ticketID, string code, int value)
		{
		}

		private void OnPurchaseTicket(CBSPurchaseTicketResult result)
		{
		}

		private void OnPurchaseTicketWithRM(CBSPurchaseTicketWithRMResult result)
		{
		}
	}
}
