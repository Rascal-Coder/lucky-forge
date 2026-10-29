namespace FunGames.UserConsent.GDPR
{
	public class FGGDPRStatus
	{
		public bool TargetedAdvertisingAccepted;

		public bool AnalyticsAccepted;

		public bool IsAboveAgeLimit;

		public bool IsFullyAccepted => false;

		public static FGGDPRStatus FullyAccepted => null;

		public static FGGDPRStatus Refused => null;

		public void SetGDPRValues(bool result)
		{
		}

		public void SetGDPRValues(FGGDPRStatus fgGdprStatus)
		{
		}
	}
}
