using System.Collections.Generic;
using CBS.Core.Auth;
using PlayFab.ClientModels;

namespace CBS.Models
{
	public class CBSLoginResult : BaseAuthResult
	{
		public bool IsNew;

		public LoginResult Result;

		public BaseCredential Credential;

		public GetCatalogItemsResult ItemsResult;

		public Dictionary<string, string> ItemsCategoryData;
	}
}
