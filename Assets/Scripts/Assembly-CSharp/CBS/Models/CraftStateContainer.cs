using System.Collections.Generic;

namespace CBS.Models
{
	public class CraftStateContainer
	{
		public Dictionary<string, ItemDependencyState> ItemsState;

		public Dictionary<string, ItemDependencyState> CurrenciesState;

		public bool ReadyToGraft()
		{
			return false;
		}

		public bool IsFreeToCraft()
		{
			return false;
		}

		public List<ItemDependencyState> GetDependencyList()
		{
			return null;
		}

		private bool IsItemsReady()
		{
			return false;
		}

		private bool IsCurrenciesReady()
		{
			return false;
		}
	}
}
