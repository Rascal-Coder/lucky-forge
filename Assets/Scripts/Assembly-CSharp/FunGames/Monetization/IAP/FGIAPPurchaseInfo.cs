using System;

namespace FunGames.Monetization.IAP
{
	[Serializable]
	public class FGIAPPurchaseInfo
	{
		public class Builder
		{
			private FGIAPPurchaseInfo _purchaseInfo;

			public Builder SetTransactionID(string transactionID)
			{
				return null;
			}

			public Builder SetReceipt(string receipt)
			{
				return null;
			}

			public Builder SetPrice(double price)
			{
				return null;
			}

			public Builder SetCurrencyCode(string currencyCode)
			{
				return null;
			}

			public Builder SetPayload(string payload)
			{
				return null;
			}

			public FGIAPPurchaseInfo Build()
			{
				return null;
			}
		}

		public string transactionID;

		public string receipt;

		public double price;

		public string currencyCode;

		public string payload;

		private FGIAPPurchaseInfo()
		{
		}
	}
}
