using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class RegistrationForm : MonoBehaviour
	{
		[SerializeField]
		private InputField MailInput;

		[SerializeField]
		private InputField PasswordInput;

		[SerializeField]
		private InputField PasswordRepeatInput;

		[SerializeField]
		private InputField DisplayNameInput;

		private IAuth Auth { get; set; }

		private AuthPrefabs AuthUIData { get; set; }

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		private void Clear()
		{
		}

		public void ShowLogin()
		{
		}

		public void OnRegister()
		{
		}

		private void OnRegistrationComplete(BaseAuthResult result)
		{
		}

		private void HideWindow()
		{
		}

		private bool ValidInputs()
		{
			return false;
		}
	}
}
