using System;
using System.Runtime.CompilerServices;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class LoginForm : MonoBehaviour
	{
		[SerializeField]
		private InputField MailInput;

		[SerializeField]
		private InputField PasswordInput;

		[SerializeField]
		private InputField CustomIDInput;

		[CompilerGenerated]
		private Action<CBSLoginResult> m_OnLogined;

		private IAuth Auth { get; set; }

		private AuthPrefabs AuthUIData { get; set; }

		public event Action<CBSLoginResult> OnLogined
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

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		public void OnLoginWithMail()
		{
		}

		public void OnLoginWithdeviceID()
		{
		}

		public void OnLoginWithCustomID()
		{
		}

		private void OnUserLogined(CBSLoginResult result)
		{
		}

		public bool IsSubscribeToLogin()
		{
			return false;
		}

		public void OnRegistration()
		{
		}

		public void OnFogotPassword()
		{
		}

		private bool InputValid()
		{
			return false;
		}

		private void Clear()
		{
		}

		private void HideWindow()
		{
		}
	}
}
