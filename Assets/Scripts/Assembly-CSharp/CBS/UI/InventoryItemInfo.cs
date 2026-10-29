using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class InventoryItemInfo : MonoBehaviour
	{
		[SerializeField]
		private Text Name;

		[SerializeField]
		private Text Description;

		[SerializeField]
		private Text CustomData;

		[SerializeField]
		private Image Icon;

		[SerializeField]
		private GameObject EquipButton;

		[SerializeField]
		private GameObject UnEquipButton;

		[SerializeField]
		private GameObject ConsumeButton;

		[SerializeField]
		private GameObject ThrowButton;

		[SerializeField]
		private GameObject UpgradeButton;

		[SerializeField]
		private GameObject CountContainer;

		[SerializeField]
		private GameObject UpgradeLevelContainer;

		[SerializeField]
		private GameObject RecipeContainer;

		[SerializeField]
		private GameObject UpgradeContainer;

		[SerializeField]
		private Color CustomDataTitleColor;

		[SerializeField]
		private Color CustomDataValueColor;

		private CBSInventoryItem Item { get; set; }

		private ICBSInventory CBSInventory { get; set; }

		private ICrafting CBSCrafting { get; set; }

		private ItemUpgradeDrawer UpgradeDrawer { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void Draw(CBSInventoryItem item)
		{
		}

		private void DisplayFields()
		{
		}

		private void DisplayCustomData()
		{
		}

		private void DisplayUpgrades()
		{
		}

		private void DisplayRecipe()
		{
		}

		private void OnGetUpgadeDependency(CraftStateContainer craftState)
		{
		}

		public void ClickEquip()
		{
		}

		public void ClickUnequip()
		{
		}

		public void ClickConsume()
		{
		}

		public void ClickThowOut()
		{
		}

		public void ClickUpgrade()
		{
		}

		public void ClickClose()
		{
		}
	}
}
