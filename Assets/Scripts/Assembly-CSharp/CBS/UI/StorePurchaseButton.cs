using System;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	[RequireComponent(typeof(Button))]
	public class StorePurchaseButton : PurchaseButton
	{
		[SerializeField]
		private GameObject DiscountObject;

		[SerializeField]
		private Text DiscountLabel;

		public override void Display(string code, int value, Action<string, int> onPress)
		{
		}

		public void DrawDicount(int discount)
		{
		}

		public void SetPurchaseActivity(bool activity)
		{
		}

		private void SetContentAligment(TextAnchor anchor)
		{
		}
	}
}
