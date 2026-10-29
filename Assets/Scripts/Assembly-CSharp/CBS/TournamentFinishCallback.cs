using System;

namespace CBS
{
	[Serializable]
	public class TournamentFinishCallback
	{
		public string ProfileID;

		public int Position;

		public int PositionValue;

		public RewardObject Prize;

		public string FinishTournamentID;

		public string FinishTournamentName;

		public TournamentMigration NewMigration;

		public string NewTournamentID;

		public string NewTournamentName;
	}
}
