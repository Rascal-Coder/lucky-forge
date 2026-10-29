using System;
using PlayFab.MultiplayerModels;

namespace CBS.Models
{
	[Serializable]
	public class CBSMatchmakingQueue
	{
		public string QueueName;

		public MatchmakingMode Mode;

		public int PlayersCount;

		public bool IsLevelEquality { get; private set; }

		public bool IsStringEquality { get; private set; }

		public bool IsLevelDifference { get; private set; }

		public bool IsValueDifference { get; private set; }

		public bool IsDuel()
		{
			return false;
		}

		public static CBSMatchmakingQueue FromMatchConfig(MatchmakingQueueConfig config)
		{
			return null;
		}
	}
}
