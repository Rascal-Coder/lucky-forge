using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class SimpleAvatarSelector : MonoBehaviour
	{
		[SerializeField]
		private Image AvatarHolder;

		private Dictionary<string, IconData> Icons { get; set; }

		private int SelectIndex { get; set; }

		private ClanAvatarInfo AvatarInfo { get; set; }

		public void Load(List<IconData> icons, ClanAvatarInfo avatarInfo)
		{
		}

		private void DisplayFromIndex(int index)
		{
		}

		public void SelectRightHandler()
		{
		}

		public void SelectLeftHandler()
		{
		}

		public ClanAvatarInfo GetAvatarInfo()
		{
			return null;
		}
	}
}
