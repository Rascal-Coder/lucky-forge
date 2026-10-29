namespace CBS.Models
{
	public class CBSClanTask : CBSTask
	{
		public int Weight;

		public RewardObject ProfileReward;

		public ClanEventContainer ClanEvents;

		public ClanEventContainer GetClanEvents()
		{
			return null;
		}

		public RewardObject GetNotRewardedObjectForProfile()
		{
			return null;
		}
	}
}
