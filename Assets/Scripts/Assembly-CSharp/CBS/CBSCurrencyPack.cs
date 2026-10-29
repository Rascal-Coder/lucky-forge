using System.Collections.Generic;
using CBS.Models;
using PlayFab.ClientModels;

namespace CBS
{
	public class CBSCurrencyPack
	{
		public string ID { get; private set; }

		public string DisplayName { get; private set; }

		public string Description { get; private set; }

		public string PriceTitle { get; private set; }

		public string ExternalURL { get; private set; }

		public string ItemClass { get; private set; }

		public Dictionary<string, CBSCurrency> Currencies { get; private set; }

		private string CustomData { get; set; }

		public string Tag => null;

		public CatalogItem Detail { get; private set; }

		public CBSCurrencyPack(CatalogItem pack)
		{
		}

		public virtual T GetCustomData<T>() where T : CBSCurrencyPackCustomData
		{
			return null;
		}

		public Dictionary<string, object> GetCustomDataAsDictionary()
		{
			return null;
		}
	}
}
