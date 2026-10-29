using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class CurrencySlot : MonoBehaviour
	{
		[SerializeField]
		private Text ValueTitle;

		[SerializeField]
		private Image IconImage;

		private CBSCurrency Currency { get; set; }

		private CurrencyPrefabs Prefabs { get; set; }

		private void Awake()
		{
		}

		public void Display(CBSCurrency currency)
		{
		}

		public void UpdateCurrency(CBSCurrency currency)
		{
		}
	}
}
