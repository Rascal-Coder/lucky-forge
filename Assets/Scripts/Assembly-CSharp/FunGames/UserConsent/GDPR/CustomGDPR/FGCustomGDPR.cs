namespace FunGames.UserConsent.GDPR.CustomGDPR
{
	public class FGCustomGDPR : FGCustomGDPRAbstract<FGCustomGDPR>
	{
		public override FGCustomGDPRSettings Settings => null;

		protected override string EventName => null;

		protected override string RemoteConfigKey => null;

		protected override int RemoteConfig => 0;

		protected override void OnAwake()
		{
		}

		protected override void OnStart()
		{
		}
	}
}
