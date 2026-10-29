using System.Collections.Generic;
using PlayFab.ClientModels;

namespace CBS.Models
{
	public class FunctionUpgradeItemResult
	{
		public string ProfileID;

		public int UpgradedLevelIndex;

		public ItemInstance UpgradedItem;

		public List<string> SpendedInstanesIDs;

		public Dictionary<string, uint> SpendedCurrencies;

		public Dictionary<string, uint> ConsumedItems;
	}
}
