using System;
using FunGames.Core.Modules;

namespace FunGames.UserConsent.GDPR
{
	public class FGGdprCallbacks : FGModuleCallbacks
	{
		internal Action _show;

		internal Action<FGGDPRStatus> _consentUpdated;

		public event Action Show
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGGDPRStatus> OnConsentUpdated
		{
			add
			{
			}
			remove
			{
			}
		}

		public override void Clear()
		{
		}
	}
}
