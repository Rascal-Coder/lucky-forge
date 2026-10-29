using System;
using CBS.Models;

namespace CBS
{
	public interface IAuth
	{
		bool IsLoggedIn { get; }

		event Action<CBSLoginResult> OnLoginEvent;

		event Action<BaseAuthResult> OnLogoutEvent;

		void LoginWithMailAndPassword(CBSMailLoginRequest request, Action<CBSLoginResult> result);

		void LoginWithUsernameAndPassword(CBSUserNameLoginRequest request, Action<CBSLoginResult> result);

		void LoginWithDevice(Action<CBSLoginResult> result);

		void LoginWithCustomID(string customID, Action<CBSLoginResult> result);

		void LoginWithGoolge(string serverAuthCode, Action<CBSLoginResult> result);

		void LoginWithSteam(string steamTicket, Action<CBSLoginResult> result);

		void LoginWithFacebook(string accessToken, Action<CBSLoginResult> result);

		void LoginWithOpenID(string connectionID, string IDToken, Action<CBSLoginResult> result);

		void LoginWithPlaystation(CBSLoginWithPlaystationRequest request, Action<CBSLoginResult> result);

		void AutoLogin(Action<CBSLoginResult> result);

		void RegisterWithMailAndPassword(CBSMailRegistrationRequest request, Action<BaseAuthResult> result);

		void SendPasswordRecovery(string mail, Action<CBSBaseResult> result);

		void LoginWithApple(string identityToken, Action<CBSLoginResult> result);

		void LinkFacebookAccount(string accessToken, Action<CBSBaseResult> result);

		void UnlinkFacebookAccount(Action<CBSBaseResult> result);

		void LinkGoogleAccount(string serverAuthCode, Action<CBSBaseResult> result);

		void UnlinkGoogleAccount(Action<CBSBaseResult> result);

		void LinkAppleAccount(string identityToken, Action<CBSBaseResult> result);

		void UnlinkAppleAccount(Action<CBSBaseResult> result);

		void LinkSteamAccount(string steamTicket, Action<CBSBaseResult> result);

		void UnlinkSteamAccount(Action<CBSBaseResult> result);

		void Logout(Action<BaseAuthResult> result = null);
	}
}
