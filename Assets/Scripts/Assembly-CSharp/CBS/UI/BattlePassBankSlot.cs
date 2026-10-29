using CBS.Core;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class BattlePassBankSlot : MonoBehaviour, IScrollableItem<BattlePassBankLevel>
	{
		[SerializeField]
		private Text Title;

		[SerializeField]
		private GameObject Passed;

		[SerializeField]
		private GameObject Locked;

		[SerializeField]
		private RewardDrawer RewardDrawer;

		public void Display(BattlePassBankLevel data)
		{
		}
	}
}
