using CBS.Core;
using CBS.Models;
using TMPro;
using UnityEngine;

namespace CBS.UI
{
	public class ClanRequestedUser : MonoBehaviour, IScrollableItem<ClanRequestInfo>
	{
		[SerializeField]
		private TextMeshProUGUI DisplayName;

		public TextMeshProUGUI Expires;

		public TextMeshProUGUI accept;

		public TextMeshProUGUI decline;

		[SerializeField]
		private AvatarDrawer Avatar;

		private string ProfileID { get; set; }

		private void OnDisable()
		{
		}

		public void Display(ClanRequestInfo profile)
		{
		}

		public void OnAccept()
		{
		}

		public void OnDecline()
		{
		}
	}
}
