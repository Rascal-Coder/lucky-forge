using System;
using System.Collections.Generic;

namespace CBS
{
	[Serializable]
	public class TournamentStateCallback
	{
		public string ProfileID;

		public string PlayerTournamentID;

		public string TournamentName;

		public bool Joined;

		public bool Finished;

		public int TimeLeft;

		public List<PlayerTournamnetEntry> Leaderboard;
	}
}
