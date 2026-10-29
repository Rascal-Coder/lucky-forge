using System;
using PlayFab;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public class FabCurrency : FabExecuter, IFabCurrency
	{
		public void AddProfileCurrerncy(string profileID, string code, int amount, Action<ExecuteFunctionResult> onUpdate, Action<PlayFabError> onFailed)
		{
		}

		public void SubtractProfileCurrerncy(string profileID, string code, int amount, Action<ExecuteFunctionResult> onUpdate, Action<PlayFabError> onFailed)
		{
		}

		public void GetProfileCurrencies(string profileID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetCurrenciesPacks(string tag, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GrantCurrencyPack(string profileID, string packID, Action<ExecuteFunctionResult> onGrant, Action<PlayFabError> onFailed)
		{
		}
	}
}
