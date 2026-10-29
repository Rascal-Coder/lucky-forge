using System;
using CBS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	[RequireComponent(typeof(Toggle))]
	public class SimpleItemDrawer : MonoBehaviour, IScrollableItem<CBSInventoryItem>
	{
		[SerializeField]
		private Image Icon;

		private Toggle Toggle { get; set; }

		private CBSInventoryItem Item { get; set; }

		private Action<CBSInventoryItem> SelectAction { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void Display(CBSInventoryItem item)
		{
		}

		public void Configure(Action<CBSInventoryItem> selectAction, ToggleGroup toggleGroup)
		{
		}

		private void OnToggleValueChanged(bool val)
		{
		}
	}
}
