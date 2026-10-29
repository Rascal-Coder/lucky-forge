using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class AccountInfoForm : MonoBehaviour
	{
		[SerializeField]
		private Text NicknameLabel;

		[SerializeField]
		private Text PlayfabIDLabel;

		[SerializeField]
		private Text RegistrationLabel;

		[SerializeField]
		private Text EntityIDLabel;

		[SerializeField]
		private GameObject UserNamePanel;

		[SerializeField]
		private GameObject EditNamePanel;

		[SerializeField]
		private InputField EditInput;

		private IProfile CBSProfile { get; set; }

		private IAuth Auth { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void DisplayUI()
		{
		}

		public void ShowNickname()
		{
		}

		public void ShowEditName()
		{
		}

		public void OnLogout()
		{
		}

		public void UpdateNickname()
		{
		}

		private void OnUserNameUpdated(CBSUpdateDisplayNameResult result)
		{
		}

		private void OnAccountInfoGetted(CBSGetAccountInfoResult result)
		{
		}
	}
}
