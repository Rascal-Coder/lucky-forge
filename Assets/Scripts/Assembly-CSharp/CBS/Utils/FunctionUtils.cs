using PlayFab.CloudScriptModels;

namespace CBS.Utils
{
	public static class FunctionUtils
	{
		public static CBSError GetCBSError(this ExecuteFunctionResult result)
		{
			return null;
		}

		public static T GetResult<T>(this ExecuteFunctionResult result)
		{
			return default;
		}
	}
}
