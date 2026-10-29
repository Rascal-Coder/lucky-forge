namespace FunGames.UserConsent.ATT.UnityATT
{
	public class FGUnityATT : FGATTAbstract<FGUnityATT, FGUnityATTSettings>
	{
		public override FGUnityATTSettings Settings => null;

		protected override string EventName => null;

		protected override string RemoteConfigKey => null;

		protected override void OnAwake()
		{
		}

		protected override void OnStart()
		{
		}

		public override void ShowATT()
		{
		}
	}
}
