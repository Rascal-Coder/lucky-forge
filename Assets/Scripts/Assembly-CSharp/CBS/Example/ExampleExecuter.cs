using UnityEngine;
using UnityEngine.UI;

namespace CBS.Example
{
	public class ExampleExecuter : MonoBehaviour
	{
		[SerializeField]
		private string LobbyScene;

		[SerializeField]
		private InputField ExpInput;

		[SerializeField]
		private InputField ClanExpInput;

		[SerializeField]
		private InputField LeaderboardInput;

		[SerializeField]
		private InputField TournamentsInput;

		[SerializeField]
		private InputField TimeInput;

		private CBSProfileModule Profile { get; set; }

		private CBSClanModule Clan { get; set; }

		private CBSLeaderboardModule Leaderboard { get; set; }

		private string PlayerID { get; set; }

		private void Start()
		{
		}

		public void BackToLobby()
		{
		}

		public void AddExpPoints()
		{
		}

		public void AddClanExpPoints()
		{
		}

		public void AddClanLeaderboardPoint()
		{
		}

		public void AddTimeOffset()
		{
		}
	}
}
