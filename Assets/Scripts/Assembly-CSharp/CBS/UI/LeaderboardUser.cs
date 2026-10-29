using CBS.Core;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class LeaderboardUser : MonoBehaviour, IScrollableItem<ProfileLeaderboardEntry>
	{
		[SerializeField]
		private Image Background;

		[SerializeField]
		private Text DisplayName;

		[SerializeField]
		private PlaceDrawer Place;

		[SerializeField]
		private AvatarDrawer Avatar;

		[SerializeField]
		private Text Value;

		[Header("Colors")]
		[SerializeField]
		private Color DefaultColor;

		[SerializeField]
		private Color ActiveColor;

		public void Display(ProfileLeaderboardEntry data)
		{
		}
	}
}
