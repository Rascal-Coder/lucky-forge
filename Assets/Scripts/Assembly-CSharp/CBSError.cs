using CBS.Models;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.CloudScriptModels;

public class CBSError
{
	public PlayFabErrorCode FabCode;

	public ErrorCode CBSCode;

	public string Message;

	public bool Exist()
	{
		return false;
	}

	public static CBSError FromTemplate(PlayFabError error)
	{
		return null;
	}

	public static CBSError FromTemplate(PlayFab.ClientModels.ScriptExecutionError error)
	{
		return null;
	}

	public static CBSError FromTemplate(FunctionExecutionError error)
	{
		return null;
	}

	public static CBSError FailedToGrandPack()
	{
		return null;
	}

	public static CBSError CredentialNotFound()
	{
		return null;
	}

	public static CBSError IAPInitializeFailed()
	{
		return null;
	}

	public static CBSError IAPNotEnabledError()
	{
		return null;
	}

	public static CBSError IAPNotInitializedError()
	{
		return null;
	}

	public static CBSError IAPPurchaseError(string message)
	{
		return null;
	}

	public static CBSError RecipeNotFoundError()
	{
		return null;
	}

	public static CBSError UpgradeNotFoundError()
	{
		return null;
	}
}
