using System;
using TMPro;
using UnityEngine;

namespace CBS.UI
{
	public class SimplePopup : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI Title;

		[SerializeField]
		private TextMeshProUGUI Body;

		public TextMeshProUGUI ok;

		private Action CurrentAction { get; set; }

		public void Setup(PopupRequest request)
		{
		}

		private void Clear()
		{
		}

		public void OnOk()
		{
		}
	}
}
