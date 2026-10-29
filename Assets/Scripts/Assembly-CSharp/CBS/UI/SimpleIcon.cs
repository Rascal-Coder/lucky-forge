using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class SimpleIcon : MonoBehaviour
	{
		[SerializeField]
		private Image Icon;

		[SerializeField]
		private Text Value;

		private ItemsIcons ItemsIcons { get; set; }

		private CurrencyIcons CurrencyIcons { get; set; }

		private bool IsInited { get; set; }

		private void Awake()
		{
		}

		private void Init()
		{
		}

		public void DrawItem(string id)
		{
		}

		public void DrawCurrency(string id)
		{
		}

		public void DrawValue(string val)
		{
		}

		public void HideValue()
		{
		}

		public void HideIcon()
		{
		}
	}
}
