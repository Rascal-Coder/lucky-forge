using CBS.Models;

namespace CBS.UI
{
	public class BattlePassTaskUI : BaseTaskUI<CBSProfileTask>
	{
		protected override string LockText => null;

		protected override string NotCompleteText => null;

		protected override string CompleteText => null;

		private IBattlePass BattlePass { get; set; }

		private string BattlePassID { get; set; }

		protected override void OnInit()
		{
		}

		public void SetBattlePassID(string id)
		{
		}

		public override void OnAddPoint()
		{
		}

		public override void GetRewards()
		{
		}
	}
}
