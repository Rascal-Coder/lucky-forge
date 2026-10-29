using System;
using CBS.Models;
using CBS.Scriptable;
using PlayFab;
using PlayFab.ClientModels;

namespace CBS.Playfab
{
	public class FabAuth : FabExecuter, IFabAuth
	{
		private AuthData AuthData { get; set; }

		public bool IsLoggedIn => false;

		protected override void Init()
		{
		}

		public void RegisterWithMailAndPassword(CBSMailRegistrationRequest request, Action<RegisterPlayFabUserResult> onSuccess, Action<CBSError> onFailed)
		{
		}

		public void LoginWithMailAndPassword(CBSMailLoginRequest request, Action<LoginResult, FunctionPostLoginResult> onSuccess, Action<CBSError> onFailed)
		{
		}

		public void LoginWithUserNameAndPassword(CBSUserNameLoginRequest request, Action<LoginResult, FunctionPostLoginResult> onSuccess, Action<CBSError> onFailed)
		{
		}

		public void LoginWithDevice(Action<LoginResult, FunctionPostLoginResult> onSuccess, Action<CBSError> onFailed)
		{
		}

		public void LoginWithCustomID(string id, Action<LoginResult, FunctionPostLoginResult> onSuccess, Action<CBSError> onFailed)
		{
		}

		public void LoginWithGoogle(string serverAuthCode, Action<LoginResult, FunctionPostLoginResult> onSuccess, Action<CBSError> onFailed)
		{
		}

		public void LoginWithOpenID(string connectionID, string IDToken, Action<LoginResult, FunctionPostLoginResult> onSuccess, Action<CBSError> onFailed)
		{
		}

		public void LoginWithSteam(string steamTicket, Action<LoginResult, FunctionPostLoginResult> onSuccess, Action<CBSError> onFailed)
		{
		}

		public void LoginWithFacebook(string accessToken, Action<LoginResult, FunctionPostLoginResult> onSuccess, Action<CBSError> onFailed)
		{
		}

		public void LoginWithApple(string identityToken, Action<LoginResult, FunctionPostLoginResult> onSuccess, Action<CBSError> onFailed)
		{
		}

		public void LoginWithPlaystation(string authCode, int? issuerId, string redirectUri, Action<LoginResult, FunctionPostLoginResult> onSuccess, Action<CBSError> onFailed)
		{
		}

		public void SendPasswordRecovery(string mail, Action<SendAccountRecoveryEmailResult> onSuccess, Action<PlayFabError> onFailed)
		{
		}

		public void LinkFacebookAccount(string accessToken, Action<LinkFacebookAccountResult> onSuccess, Action<PlayFabError> onFailed)
		{
		}

		public void LinkAppleAccount(string identityToken, Action<EmptyResult> onSuccess, Action<PlayFabError> onFailed)
		{
		}

		public void LinkGoogleAccount(string serverAuthCode, Action<LinkGoogleAccountResult> onSuccess, Action<PlayFabError> onFailed)
		{
		}

		public void LinkSteamAccount(string steamTicket, Action<LinkSteamAccountResult> onSuccess, Action<PlayFabError> onFailed)
		{
		}

		public void UnlinkFacebookAccount(Action<UnlinkFacebookAccountResult> onSuccess, Action<PlayFabError> onFailed)
		{
		}

		public void UnlinkAppleAccount(Action<EmptyResponse> onSuccess, Action<PlayFabError> onFailed)
		{
		}

		public void UnlinkGoogleAccount(Action<UnlinkGoogleAccountResult> onSuccess, Action<PlayFabError> onFailed)
		{
		}

		public void UnlinkSteamAccount(Action<UnlinkSteamAccountResult> onSuccess, Action<PlayFabError> onFailed)
		{
		}

		public void Logout()
		{
		}

		private void PostAuthProccess(LoginResult loginResult, Action<LoginResult, FunctionPostLoginResult> onLogin, Action<CBSError> onFailed)
		{
		}

		private void LoadCatalogItems(Action<LoginResult, FunctionPostLoginResult> onLogin, LoginResult loginResult, FunctionPostLoginResult postLoginResult, Action<CBSError> onFailed)
		{
		}

		private void PostMailRegistrationProccess(RegisterPlayFabUserResult registerResult, Action<RegisterPlayFabUserResult> onRegister, Action<CBSError> onFailed)
		{
		}

		private GetPlayerCombinedInfoRequestParams GetLoginRequestParams()
		{
			return null;
		}
	}
}
