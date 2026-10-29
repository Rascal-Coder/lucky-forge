namespace CBS.Models
{
	public class ClanLeaderboardEntry : ClanEntity
	{
		public int StatisticPosition;

		public int StatisticValue;

		public static ClanLeaderboardEntry FromClanEntity(ClanEntity clan, int position, int value)
		{
			return null;
		}
	}
}
