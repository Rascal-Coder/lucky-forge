using System;
using PlayFab;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public class FabRoulette : FabExecuter, IFabRoulette
	{
		public void GetRouletteTable(string profileID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void SpinRoulette(string profileID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}
	}
}
