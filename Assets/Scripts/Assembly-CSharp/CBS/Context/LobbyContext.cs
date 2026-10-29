using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.Context
{
	public class LobbyContext : MonoBehaviour
	{
		[SerializeField]
		private string LoginScene;

		private ProfilePrefabs ProfilePrefabs { get; set; }

		private CommonPrefabs CommonPrefabs { get; set; }

		private CurrencyPrefabs CurrencyPrefabs { get; set; }

		private IAuth CBSAuth { get; set; }

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void Init()
		{
		}

		private void OnUserLogout(BaseAuthResult result)
		{
		}
	}
}
