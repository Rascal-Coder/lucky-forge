using System;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class BattlePassTab : MonoBehaviour
	{
		public BattlePassTitle TabType;

		public Action<BattlePassTab> OnTabSelected;

		private Toggle toggle;

		public bool IsActive => false;

		public Toggle Toggle => null;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public void Activate()
		{
		}

		private void OnToggleChanged(bool val)
		{
		}
	}
}
