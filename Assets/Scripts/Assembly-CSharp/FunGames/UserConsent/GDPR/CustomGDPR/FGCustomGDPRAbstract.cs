using System.Collections.Generic;

namespace FunGames.UserConsent.GDPR.CustomGDPR
{
	public abstract class FGCustomGDPRAbstract<M> : FGGdprAbstract<M, FGCustomGDPRSettings> where M : FGGdprAbstract<M, FGCustomGDPRSettings>
	{
		public List<FGGDPRDisplayAbstract> gdprWindows;

		private FGGDPRDisplayAbstract _currentGdpr;

		protected override void InitSdk()
		{
		}

		protected override void RequestShow()
		{
		}

		protected override void UpdateAdditionalConsent()
		{
		}

		private void InitWithLocalisation(Location location)
		{
		}
	}
}
