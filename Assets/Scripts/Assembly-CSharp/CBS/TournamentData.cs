using System;
using System.Collections.Generic;

namespace CBS
{
	[Serializable]
	public class TournamentData
	{
		public TournamentDate Date;

		public int DateTimestamp;

		public Dictionary<string, TournamentObject> Tournaments;
	}
}
