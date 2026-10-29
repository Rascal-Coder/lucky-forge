using System;
using System.Collections.Generic;

namespace CBS
{
	[Serializable]
	public class TournamentObject
	{
		public string TounamentID;

		public string TournamentName;

		public bool IsDefault;

		public string NextTournamentID;

		public string DowngradeTournamentID;

		public List<TournamentPosition> Positions;
	}
}
