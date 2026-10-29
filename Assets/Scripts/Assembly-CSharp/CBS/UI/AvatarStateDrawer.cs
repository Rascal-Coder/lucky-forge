using System;
using CBS.Core;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class AvatarStateDrawer : MonoBehaviour, IScrollableItem<CBSAvatarState>
	{
		[Header("States")]
		[SerializeField]
		private GameObject LockState;

		[SerializeField]
		private GameObject AvailableState;

		[SerializeField]
		private GameObject SelectedState;

		[SerializeField]
		private GameObject PurchaseState;

		[SerializeField]
		private Image Avatar;

		[SerializeField]
		private Text LockLabel;

		[SerializeField]
		private PurchaseButton PurchaseButton;

		private Action<CBSAvatarState> SelectionAction { get; set; }

		private Action<CBSAvatarState> PurchaseAction { get; set; }

		private CBSAvatarState AvatarState { get; set; }

		public void Display(CBSAvatarState data)
		{
		}

		public void SetCallbacks(Action<CBSAvatarState> selectAction, Action<CBSAvatarState> purchaseAction)
		{
		}

		private void ClearAllState()
		{
		}

		public void PurchaseClick()
		{
		}

		public void SelectClick()
		{
		}
	}
}
