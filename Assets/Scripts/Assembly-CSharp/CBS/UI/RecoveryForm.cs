using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class RecoveryForm : MonoBehaviour
	{
		[SerializeField]
		private InputField EmailField;

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

		public void SendRecovery()
		{
		}

		public void ReturnToLogin()
		{
		}

		private void OnRecoverySent(CBSBaseResult result)
		{
		}
	}
}
