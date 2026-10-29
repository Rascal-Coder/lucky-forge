using System;
using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class BattlePassLevelTreeDrawer : MonoBehaviour
	{
		[SerializeField]
		private Text DisplayName;

		[SerializeField]
		private Text Timer;

		[SerializeField]
		private Text Level;

		[SerializeField]
		private Text Description;

		[SerializeField]
		private BattlePassScroller Scroller;

		private DateTime? EndDate;

		public Action ReloadRequest { get; set; }

		private string BattlePassID { get; set; }

		private IBattlePass BattlePass { get; set; }

		private bool IsActive { get; set; }

		private BattlePassPrefabs PassPrefabs { get; set; }

		private BattlePassInstance PassInstance { get; set; }

		private void Awake()
		{
		}

		public void Draw(BattlePassInstance instance, List<BattlePassLevelInfo> levelTree, BattlePassUserInfo state)
		{
		}

		private void DrawLevels(List<BattlePassLevelInfo> levels)
		{
		}

		private void CleanUI()
		{
		}

		private void LateUpdate()
		{
		}

		public void Add10Exp()
		{
		}

		public void Add150Exp()
		{
		}

		private void OnAddExpirience(CBSAddExpirienceToInstanceResult result)
		{
		}
	}
}
