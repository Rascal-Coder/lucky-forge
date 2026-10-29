using CBS.Models;
using CBS.Scriptable;
using CBS.UI;
using UnityEngine;

namespace CBS.Context
{
	public class AuthContext : MonoBehaviour
	{
		[SerializeField]
		private string LobbyScene;

		private AuthPrefabs AuthUIData { get; set; }

		private LoginForm LoginForm { get; set; }

		private AuthData AuthData { get; set; }

		private IAuth Auth { get; set; }

		private void Start()
		{
		}

		private void Init()
		{
		}

		private void ShowLoginScreen()
		{
		}

		private void OnLoginComplete(CBSLoginResult result)
		{
		}
	}
}
