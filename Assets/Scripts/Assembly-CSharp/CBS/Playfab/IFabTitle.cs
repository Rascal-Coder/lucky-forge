using System;
using PlayFab;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public interface IFabTitle
	{
		void GetAllTitleData(Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed);

		void GetTitleDataByKey(string key, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed);
	}
}
