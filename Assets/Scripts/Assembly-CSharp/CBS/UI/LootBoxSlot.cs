using System;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class LootBoxSlot : MonoBehaviour
	{
		[SerializeField]
		private Image Icon;

		[SerializeField]
		private GameObject Locker;

		[SerializeField]
		private Text TimerLabel;

		private ItemsIcons ItemIcons { get; set; }

		private CBSLootboxInventoryItem Box { get; set; }

		private Action<CBSLootboxInventoryItem, LootBoxSlot> SelectAction { get; set; }

		private Toggle Toggle { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void LateUpdate()
		{
		}

		public void Configurate(CBSLootboxInventoryItem item, ToggleGroup group)
		{
		}

		public void SetSelectAction(Action<CBSLootboxInventoryItem, LootBoxSlot> action)
		{
		}

		private void DisplayDate()
		{
		}

		private void OnToggleValueChanged(bool val)
		{
		}

		public void SetToggleValue(bool val)
		{
		}
	}
}
