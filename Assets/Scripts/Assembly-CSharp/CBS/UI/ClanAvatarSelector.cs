using CBS.Models;
using UnityEngine;

namespace CBS.UI
{
	public class ClanAvatarSelector : MonoBehaviour
	{
		[SerializeField]
		private SimpleAvatarSelector SimpleSelector;

		[SerializeField]
		private ComplexAvatarSelector ComplexSelector;

		public void Load(ClanAvatarInfo avatarInfo)
		{
		}

		public ClanAvatarInfo GetAvatarInfo()
		{
			return null;
		}
	}
}
