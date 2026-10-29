using System;
using TMPro;
using UnityEngine;

namespace CBS.UI
{
	public class EditTextPopup : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI Title;

		[SerializeField]
		private TMP_InputField Input;

		private Action<string> SaveAction { get; set; }

		private Action CancelAction { get; set; }

		public void Setup(EditTextPopupRequest request)
		{
		}

		private void Clear()
		{
		}

		public void SaveHandler()
		{
		}

		public void NoHandler()
		{
		}
	}
}
