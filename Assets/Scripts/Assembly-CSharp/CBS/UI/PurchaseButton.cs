using System;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	[RequireComponent(typeof(Button))]
	public class PurchaseButton : MonoBehaviour
	{
		[SerializeField]
		private Image CurrencyIcon;

		[SerializeField]
		protected Text CurrencyValue;

		private Action<string, int> OnPress { get; set; }

		private string Code { get; set; }

		private int Value { get; set; }

		protected Button Button { get; set; }

		private CurrencyIcons CurrencyIcons { get; set; }

		private bool IsInited { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void Init()
		{
		}

		public virtual void Display(string code, int value, Action<string, int> onPress)
		{
		}

		public virtual void Display(CBSPrice price, Action<string, int> onPress)
		{
		}

		public void SetActivity(bool activity)
		{
		}

		private void OnClick()
		{
		}
	}
}
