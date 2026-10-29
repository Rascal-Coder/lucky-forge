using System.Collections.Generic;
using PlayFab.ClientModels;

namespace CBS.Models
{
	public class FunctionGrantItemsResult
	{
		public string TargetID;

		public List<ItemInstance> GrantedInstances;

		public Dictionary<string, uint> GrantedCurrencies;
	}
}
