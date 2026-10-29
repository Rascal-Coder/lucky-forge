using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI.Matchmaking
{
	public class MatchmakingPreviewPlayer : MonoBehaviour
	{
		[SerializeField]
		private AvatarDrawer Avatar;

		[SerializeField]
		private Text DisplayName;

		private IProfile Profile { get; set; }

		private void Awake()
		{
		}

		public void DrawUser(CBSMatchmakingPlayer player)
		{
		}

		private void OnGetProfileInfo(CBSGetProfileResult result)
		{
		}
	}
}
