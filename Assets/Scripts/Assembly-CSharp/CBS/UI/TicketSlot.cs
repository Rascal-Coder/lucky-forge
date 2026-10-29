using System;
using CBS.Core;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class TicketSlot : MonoBehaviour, IScrollableItem<TicketUIRequest>
	{
		[SerializeField]
		private Text DisplayName;

		[SerializeField]
		private Text Description;

		[SerializeField]
		private PurchaseButton Button;

		private BattlePassTicket Ticket { get; set; }

		private Action<string, string, int> PurchaseAction { get; set; }

		public void Display(TicketUIRequest data)
		{
		}

		private void OnPurchasePress(string code, int value)
		{
		}
	}
}
