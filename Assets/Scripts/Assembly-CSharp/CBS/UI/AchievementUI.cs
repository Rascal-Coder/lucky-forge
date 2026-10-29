namespace CBS.UI
{
	public class AchievementUI : BaseTaskUI<CBSTask>
	{
		protected override string LockText => null;

		protected override string NotCompleteText => null;

		protected override string CompleteText => null;

		private IAchievements Achievements { get; set; }

		protected override void OnInit()
		{
		}

		public override void OnAddPoint()
		{
		}

		public void ResetAchievement()
		{
		}

		public override void GetRewards()
		{
		}
	}
}
