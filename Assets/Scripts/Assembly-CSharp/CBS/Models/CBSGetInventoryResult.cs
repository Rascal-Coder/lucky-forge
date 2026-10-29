using System.Collections.Generic;

namespace CBS.Models
{
	public class CBSGetInventoryResult : CBSBaseResult
	{
		private List<CBSInventoryItem> CBSInstances;

		public string TargetID { get; private set; }

		public List<CBSInventoryItem> AllItems => null;

		public List<CBSInventoryItem> Lootboxes => null;

		public List<CBSInventoryItem> EquippedItems => null;

		public List<CBSInventoryItem> NonEquippedItems => null;

		public List<CBSInventoryItem> EquippableItems => null;

		public List<CBSInventoryItem> TradableItems => null;

		public List<CBSInventoryItem> ConsumableItems => null;

		public List<CBSInventoryItem> RecipeItems => null;

		public List<CBSInventoryItem> IsInTradingItems => null;

		public CBSGetInventoryResult()
		{
		}

		public CBSGetInventoryResult(List<CBSInventoryItem> instances, string profileID)
		{
		}
	}
}
