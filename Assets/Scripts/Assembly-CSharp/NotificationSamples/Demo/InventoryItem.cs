using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NotificationSamples.Demo
{
	public class InventoryItem : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Label to store the quantity bought.")]
		protected TextMeshProUGUI quantityLabel;

		[SerializeField]
		protected Image icon;

		private int quantity;

		public InventoryItemData ItemData { get; private set; }

		public void Initialise(InventoryItemData itemData)
		{
		}

		public void OnReceivedItem()
		{
		}

		private void UpdateControls()
		{
		}
	}
}
