namespace CBS.Models
{
	public class CBSGetLevelLeaderboardRequest
	{
		public CBSProfileConstraints Constraints;

		public int MaxCount;

		public int StartPosition;

		public int? Version;

		public CBSGetLeaderboardRequest ToLeaderboardRequest()
		{
			return null;
		}
	}
}
