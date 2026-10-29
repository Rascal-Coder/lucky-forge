using System;
using CBS.Core;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	[RequireComponent(typeof(Button))]
	public class EventSlot : MonoBehaviour, IScrollableItem<CBSEvent>
	{
		[SerializeField]
		private Image BackgroundIcon;

		[SerializeField]
		private Text DisplayName;

		[SerializeField]
		private Text Date;

		[SerializeField]
		private GameObject ActiveBack;

		[SerializeField]
		private GameObject InactiveBack;

		[SerializeField]
		private GameObject Locker;

		[SerializeField]
		private Sprite DefaultSprite;

		private CBSEvent Event { get; set; }

		private Action<CBSEvent> SelectAction { get; set; }

		public void Display(CBSEvent data)
		{
		}

		public void SetSelectAction(Action<CBSEvent> selectAction)
		{
		}

		private void DisplayDate()
		{
		}

		private void LateUpdate()
		{
		}

		public void OnClickView()
		{
		}
	}
}
