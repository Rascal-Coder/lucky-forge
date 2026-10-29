using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class ClanAvatarDrawer : MonoBehaviour
	{
		[SerializeField]
		private Image AvatarImage;

		[SerializeField]
		private Image BackgroundImage;

		[SerializeField]
		private Image ForegroundImage;

		[SerializeField]
		private Image EmblemImage;

		private ClanAvatarInfo ClanAvatar { get; set; }

		private string ClanID { get; set; }

		private ClanIcons ClanIcons { get; set; }

		private ClanAvatarViewMode DisplayMode { get; set; }

		private void Awake()
		{
		}

		public void ClickAvatar()
		{
		}

		public void DisplayDefaultAvatar()
		{
		}

		public void Load(string clanID, ClanAvatarInfo clanAvatar)
		{
		}

		private void DisplaySimpleIcon(ClanAvatarInfo clanAvatar)
		{
		}

		private void DisplayComplexIcon(ClanAvatarInfo clanAvatar)
		{
		}
	}
}
