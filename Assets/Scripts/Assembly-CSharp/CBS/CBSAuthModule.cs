using System;
using System.Runtime.CompilerServices;
using CBS.Models;
using CBS.Playfab;
using CBS.Scriptable;

namespace CBS
{
	public class CBSAuthModule : CBSModule, IAuth
	{
		[CompilerGenerated]
		private Action<CBSLoginResult> m_OnLoginEvent;

		[CompilerGenerated]
		private Action<BaseAuthResult> m_OnLogoutEvent;

		public bool IsLoggedIn => false;

		private IFabAuth FabAuth { get; set; }

		private AuthData AuthData { get; set; }

		public event Action<CBSLoginResult> OnLoginEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<BaseAuthResult> OnLogoutEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Init()
		{
		}

		public void LoginWithMailAndPassword(CBSMailLoginRequest request, Action<CBSLoginResult> result)
		{
		}

		public void LoginWithUsernameAndPassword(CBSUserNameLoginRequest request, Action<CBSLoginResult> result)
		{
		}

		public void LoginWithCustomID(string customID, Action<CBSLoginResult> result)
		{
		}

		public void LoginWithDevice(Action<CBSLoginResult> result)
		{
		}

		public void LoginWithGoolge(string serverAuthCode, Action<CBSLoginResult> result)
		{
		}

		public void LoginWithOpenID(string connectionID, string IDToken, Action<CBSLoginResult> result)
		{
		}

		public void LoginWithSteam(string steamTicket, Action<CBSLoginResult> result)
		{
		}

		public void LoginWithFacebook(string accessToken, Action<CBSLoginResult> result)
		{
		}

		public void LoginWithApple(string identityToken, Action<CBSLoginResult> result)
		{
		}

		public void LoginWithPlaystation(CBSLoginWithPlaystationRequest request, Action<CBSLoginResult> result)
		{
		}

		public void AutoLogin(Action<CBSLoginResult> result)
		{
		}

		public void RegisterWithMailAndPassword(CBSMailRegistrationRequest request, Action<BaseAuthResult> result)
		{
		}

		public void SendPasswordRecovery(string mail, Action<CBSBaseResult> result)
		{
		}

		public void LinkFacebookAccount(string accessToken, Action<CBSBaseResult> result)
		{
		}

		public void UnlinkFacebookAccount(Action<CBSBaseResult> result)
		{
		}

		public void LinkGoogleAccount(string serverAuthCode, Action<CBSBaseResult> result)
		{
		}

		public void UnlinkGoogleAccount(Action<CBSBaseResult> result)
		{
		}

		public void LinkAppleAccount(string identityToken, Action<CBSBaseResult> result)
		{
		}

		public void UnlinkAppleAccount(Action<CBSBaseResult> result)
		{
		}

		public void LinkSteamAccount(string steamTicket, Action<CBSBaseResult> result)
		{
		}

		public void UnlinkSteamAccount(Action<CBSBaseResult> result)
		{
		}

		public void Logout(Action<BaseAuthResult> result = null)
		{
		}

		private void LoginPostProcess(Action<CBSLoginResult> successAction, CBSLoginResult loginResult, FunctionPostLoginResult postLoginResult)
		{
		}
	}
}
