using System;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class EventDetailDrawer : MonoBehaviour
	{
		[SerializeField]
		private Image Icon;

		[SerializeField]
		private Text DisplayName;

		[SerializeField]
		private Text Description;

		private Action BackAction { get; set; }

		public void Draw(CBSEvent eventInstance, Action backAction)
		{
		}

		public void OnBackHandler()
		{
		}
	}
}
