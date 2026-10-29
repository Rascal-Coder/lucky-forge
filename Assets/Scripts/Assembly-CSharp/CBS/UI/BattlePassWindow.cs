using CBS.Models;
using UnityEngine;

namespace CBS.UI
{
	public class BattlePassWindow : MonoBehaviour
	{
		[SerializeField]
		private BattlePassTabListener TabListener;

		[SerializeField]
		private BattlePassLevelTreeDrawer LevelDrawer;

		[SerializeField]
		private BattlePassBankDrawer BankDrawer;

		[SerializeField]
		private BattlePassTaskDrawer TasksDrawer;

		[SerializeField]
		private BattlePassTicketsDrawer TicketsDrawer;

		private string BattlePassID { get; set; }

		private IBattlePass BattlePass { get; set; }

		private bool IsLoaded { get; set; }

		private BattlePassInstance PassInstance { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDisable()
		{
		}

		public void Load(string battlePassID)
		{
		}

		private void EnableAllTitle()
		{
		}

		private void EnableTitle(BattlePassTitle title)
		{
		}

		public void CloseWindow()
		{
		}

		private void OnGetBattlePassInfo(CBSGetBattlePassFullInformationResult result)
		{
		}

		private void OnChangeTab(BattlePassTab tab)
		{
		}

		private void OnReload()
		{
		}
	}
}
