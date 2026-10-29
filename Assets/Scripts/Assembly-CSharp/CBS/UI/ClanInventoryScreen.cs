using System;
using UnityEngine;

namespace CBS.UI
{
	public class ClanInventoryScreen : MonoBehaviour, IClanScreen
	{
		[SerializeField]
		private ProfileInventoryInsideClan ProfileInventory;

		[SerializeField]
		private ClanInventoryDrawer ClanInventory;

		public Action OnBack { get; set; }

		private void Start()
		{
		}

		public void Hide()
		{
		}

		public void Show()
		{
		}

		public void BackHandler()
		{
		}

		private void UpdateRequest()
		{
		}
	}
}
