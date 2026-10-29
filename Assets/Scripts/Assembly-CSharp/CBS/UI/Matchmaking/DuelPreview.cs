using CBS.Models;
using UnityEngine;

namespace CBS.UI.Matchmaking
{
	public class DuelPreview : MonoBehaviour, IMatchmakingPreview
	{
		[SerializeField]
		private MatchmakingPreviewPlayer[] PlayersPreview;

		public void Draw(CBSStartMatchResult result)
		{
		}

		public void StartMatch()
		{
		}
	}
}
