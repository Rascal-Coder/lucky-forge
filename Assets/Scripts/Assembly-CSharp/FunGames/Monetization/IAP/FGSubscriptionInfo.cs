using System;

namespace FunGames.Monetization.IAP
{
	public class FGSubscriptionInfo
	{
		public bool IsSubscribed;

		public bool IsExpired;

		public bool IsCancelled;

		public bool IsFreeTrial;

		public bool IsAutoRenewing;

		public bool IsIntroductoryPricePeriod;

		public string ProductId;

		public DateTime PurchaseDate;

		public DateTime SubscriptionExpireDate;

		public DateTime SubscriptionCancelDate;

		public TimeSpan RemainedTime;

		public string IntroductoryPrice;

		public TimeSpan IntroductoryPricePeriod;

		public long IntroductoryPriceCycles;

		public TimeSpan FreeTrialPeriod;

		public TimeSpan SubscriptionPeriod;

		public string FreeTrialPeriodString;

		public string SkuDetails;
	}
}
