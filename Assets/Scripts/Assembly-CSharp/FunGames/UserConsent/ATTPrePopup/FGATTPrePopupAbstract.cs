using FunGames.Core.Modules;
using FunGames.Core.Settings;

namespace FunGames.UserConsent.ATTPrePopup
{
	public abstract class FGATTPrePopupAbstract<M, S> : FGModuleAbstract<M, FGModuleCallbacks, S> where M : FGModuleAbstract<M, FGModuleCallbacks, S> where S : IFGModuleSettings
	{
		protected override FGModule Parent => null;

		protected abstract void Show();

		protected override void InitializeCallbacks()
		{
		}

		protected override void InitializeModule()
		{
		}

		protected void PrePopupAccepted()
		{
		}

		protected override void ClearInitialization()
		{
		}
	}
}
