using CBS.Models;

namespace CBS.UI
{
	public class ClanTaskSlotUI : BaseTaskUI<CBSClanTask>
	{
		protected override string LockText => null;

		protected override string NotCompleteText => null;

		protected override string CompleteText => null;

		private IClanTasks ClanTasks { get; set; }

		protected override void OnInit()
		{
		}

		protected override void DrawButtons(bool isLocked, bool isCompleted, bool rewardAvailable)
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
