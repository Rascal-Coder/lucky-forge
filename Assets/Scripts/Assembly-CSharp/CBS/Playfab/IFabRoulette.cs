using System;
using PlayFab;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public interface IFabRoulette
	{
		void GetRouletteTable(string profileID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed);

		void SpinRoulette(string profileID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed);
	}
}
