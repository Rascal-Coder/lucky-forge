using FunGames.Core.Modules;
using FunGames.Core.Settings;

namespace FunGames.UserConsent.ATT
{
	public abstract class FGATTAbstract<M, S> : FGModuleAbstract<M, FGATTCallbacks, S> where M : FGATTAbstract<M, S> where S : IFGModuleSettings
	{
		protected override FGModule Parent => null;

		public abstract void ShowATT();

		protected override void InitializeCallbacks()
		{
		}

		protected override void InitializeModule()
		{
		}

		protected void ATTAnswered(bool result)
		{
		}

		public void Request()
		{
		}

		public void Show()
		{
		}

		protected override void ClearInitialization()
		{
		}
	}
}
