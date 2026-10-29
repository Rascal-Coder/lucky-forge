using System.Collections.Generic;
using PlayFab.ClientModels;

namespace CBS.Models
{
	public class GrantRewardResult
	{
		public RewardObject OriginReward;

		public List<ItemInstance> GrantedInstances;

		public Dictionary<string, uint> GrantedCurrencies;
	}
}
