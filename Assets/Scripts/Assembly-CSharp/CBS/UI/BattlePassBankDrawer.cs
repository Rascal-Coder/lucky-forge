using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class BattlePassBankDrawer : MonoBehaviour
	{
		[SerializeField]
		private BattlePassBankScroller Scroller;

		private BattlePassPrefabs PassPrefabs { get; set; }

		private void Awake()
		{
		}

		public void Draw(List<BattlePassBankLevel> levelTree)
		{
		}
	}
}
