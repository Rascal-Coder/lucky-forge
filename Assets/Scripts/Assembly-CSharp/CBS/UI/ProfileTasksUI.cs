using CBS.Models;

namespace CBS.UI
{
	public class ProfileTasksUI : BaseTaskUI<CBSProfileTask>
	{
		protected override string LockText => null;

		protected override string NotCompleteText => null;

		protected override string CompleteText => null;

		private IProfileTasks ProfileTask { get; set; }

		protected override void OnInit()
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
