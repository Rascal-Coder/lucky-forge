using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FunGames.Core.QAMode
{
	internal class FGQAPasskeyScreen : FGQAScreenAbstract
	{
		public Action PasskeyVerifySucceeded;

		[SerializeField]
		private TMP_InputField keyField;

		[SerializeField]
		private TextMeshProUGUI errorText;

		[SerializeField]
		private Button submitButton;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnTextValueChanged(string value)
		{
		}

		private void VerifyPassphrase()
		{
		}

		private void OnVerifyResult(bool success, string message)
		{
		}

		private void OnFetchedLiveVariables(bool success, string message)
		{
		}
	}
}
