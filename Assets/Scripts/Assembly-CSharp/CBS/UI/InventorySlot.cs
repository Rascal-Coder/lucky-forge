using System;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class InventorySlot : MonoBehaviour
	{
		[SerializeField]
		private Image Icon;

		[SerializeField]
		private GameObject CounterBack;

		[SerializeField]
		private Text Counter;

		public CBSInventoryItem Item { get; private set; }

		private Action<CBSInventoryItem> ClickAction { get; set; }

		private ICBSInventory CBSInventory { get; set; }

		protected virtual void Awake()
		{
		}

		public void Init(CBSInventoryItem item, Action<CBSInventoryItem> onClick)
		{
		}

		public void UpdateCount(int count)
		{
		}

		public void UpdateItem(CBSInventoryItem item)
		{
		}

		public void ClickSlot()
		{
		}
	}
}
