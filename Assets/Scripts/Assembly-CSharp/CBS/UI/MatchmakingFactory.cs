using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class MatchmakingFactory : IMatchmakingFactory
	{
		private MatchmakingPrefabs Prefabs { get; set; }

		public GameObject SpawnMatchmakingResult(CBSMatchmakingQueue queue)
		{
			return null;
		}
	}
}
