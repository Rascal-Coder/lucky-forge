using System.Collections.Generic;
using CBS.Core;

namespace CBS.Models
{
	public class CBSStoreItem : ICustomData<CBSStoreItemCustomData>
	{
		public string ItemID;

		public string StoreID;

		public string DisplayName;

		public string Description;

		public bool HasQuantityLimit;

		public StoreLimitationInfo Limitation;

		public Dictionary<string, int> Discounts;

		public Dictionary<string, uint> Prices;

		public string CustomDataClassName { get; set; }

		public string CustomRawData { get; set; }

		public bool CompressCustomData => false;

		public T GetCustomData<T>() where T : CBSStoreItemCustomData
		{
			return null;
		}

		public bool HasDiscount(string currencyCode)
		{
			return false;
		}

		public int GetDiscount(string currencyCode)
		{
			return 0;
		}
	}
}
