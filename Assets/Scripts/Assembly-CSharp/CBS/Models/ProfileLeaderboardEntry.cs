namespace CBS.Models
{
	public class ProfileLeaderboardEntry : ProfileEntity
	{
		public int StatisticPosition;

		public int StatisticValue;

		public static ProfileLeaderboardEntry FromProfileEntity(ProfileEntity profile, int position, int value)
		{
			return null;
		}
	}
}
