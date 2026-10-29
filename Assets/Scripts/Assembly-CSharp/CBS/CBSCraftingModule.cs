using System;
using System.Runtime.CompilerServices;
using CBS.Models;
using CBS.Playfab;

namespace CBS
{
	public class CBSCraftingModule : CBSModule, ICrafting
	{
		[CompilerGenerated]
		private Action<CBSInventoryItem> m_OnItemCrafted;

		[CompilerGenerated]
		private Action<CBSInventoryItem> m_OnItemUpgraded;

		private IFabCrafting FabCrafting { get; set; }

		private IProfile Profile { get; set; }

		private ICBSInventory Inventory { get; set; }

		private ICurrency Currency { get; set; }

		private ICBSItems Items { get; set; }

		public event Action<CBSInventoryItem> OnItemCrafted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<CBSInventoryItem> OnItemUpgraded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Init()
		{
		}

		public void GetRecipeDependencyState(string itemID, Action<CBSGetRecipeDependencyStateResult> result)
		{
		}

		public void GetRecipeDependencyStateFromCache(string itemID, Action<CBSGetRecipeDependencyStateResult> result)
		{
		}

		public void CraftItemFromRecipe(string recipeInventoryID, Action<CBSCraftResult> result)
		{
		}

		public void CraftItemFromRecipeTemplate(string recipeID, Action<CBSCraftResult> result)
		{
		}

		public void GetItemNextUpgradeState(string itemInstanceID, Action<CBSGetNextUpgradeStateResult> result)
		{
		}

		public void GetItemNextUpgradeStateFromCache(string inventoryItemID, Action<CBSGetNextUpgradeStateResult> result)
		{
		}

		public void UpgradeItemToNextLevel(string inventoryItemID, Action<CBSUpgradeItemResult> result)
		{
		}

		private CraftStateContainer CalculateDependencyFromCache(CBSItemDependency dependency, string itemInstanceID)
		{
			return null;
		}
	}
}
