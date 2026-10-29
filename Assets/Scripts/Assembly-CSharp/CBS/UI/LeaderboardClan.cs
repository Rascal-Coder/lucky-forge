using CBS.Core;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class LeaderboardClan : MonoBehaviour, IScrollableItem<ClanLeaderboardEntry>
	{
		[SerializeField]
		private Image Background;

		[SerializeField]
		private Text DisplayName;

		[SerializeField]
		private PlaceDrawer Place;

		[SerializeField]
		private ClanAvatarDrawer Avatar;

		[SerializeField]
		private Text Value;

		[Header("Colors")]
		[SerializeField]
		private Color DefaultColor;

		[SerializeField]
		private Color ActiveColor;

		public void Display(ClanLeaderboardEntry data)
		{
		}
	}
}
