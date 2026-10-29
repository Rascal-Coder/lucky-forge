using System;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class ItemPopup : MonoBehaviour
	{
		[SerializeField]
		private Text Title;

		[SerializeField]
		private Image ItemIcon;

		private Action CurrentAction { get; set; }

		private ItemsIcons Icons { get; set; }

		private void Awake()
		{
		}

		public void Setup(string itemID, string title, Action onOk)
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
