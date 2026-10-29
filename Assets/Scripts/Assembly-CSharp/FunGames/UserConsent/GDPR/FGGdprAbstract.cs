using FunGames.Core.Modules;
using FunGames.Core.Settings;

namespace FunGames.UserConsent.GDPR
{
	public abstract class FGGdprAbstract<M, S> : FGModuleAbstract<M, FGGdprCallbacks, S> where M : FGModuleAbstract<M, FGGdprCallbacks, S> where S : IFGModuleSettings
	{
		protected override FGModule Parent => null;

		protected abstract int RemoteConfig { get; }

		protected abstract void RequestShow();

		protected abstract void UpdateAdditionalConsent();

		protected abstract void InitSdk();

		protected override void InitializeCallbacks()
		{
		}

		protected override void InitializeModule()
		{
		}

		protected void Show()
		{
		}

		protected void UpdateConsent(FGGDPRStatus status)
		{
		}

		protected override void ClearInitialization()
		{
		}
	}
}
