using System.Collections.Generic;

namespace CBS.Models
{
	public class StoresContainer
	{
		public const string GLOBAL_OFFER_STORE_ID = "CBSStoreGlobalOffer";

		public const string PROFILE_OFFER_STORE_ID = "CBSStoreProfileOffer";

		public List<string> StoresIDs;

		public Dictionary<string, StoreLimitationMeta> LimitationMeta;

		public List<string> GetStoreIDs()
		{
			return null;
		}

		public void AddStoreID(string id)
		{
		}

		public void RemoveID(string id)
		{
		}

		public void CheckForRemoveLimitation(string storeID, string itemID)
		{
		}

		public void AddOrUpdateLimitation(string storeID, string itemID, StoreLimitationMeta meta)
		{
		}

		public bool ContainLimitationMeta(string storeID, string itemID)
		{
			return false;
		}

		public StoreLimitationMeta GetLimitationMeta(string storeID, string itemID)
		{
			return null;
		}
	}
}
