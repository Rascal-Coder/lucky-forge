using System;
using TMPro;
using UnityEngine;

namespace CBS.UI
{
	public class YesNoPopup : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI Title;

		[SerializeField]
		private TextMeshProUGUI Body;

		public TextMeshProUGUI yes;

		public TextMeshProUGUI no;

		private Action YesAction { get; set; }

		private Action NoAction { get; set; }

		public void Setup(YesOrNoPopupRequest request)
		{
		}

		private void Clear()
		{
		}

		public void OnYes()
		{
		}

		public void OnNo()
		{
		}
	}
}
