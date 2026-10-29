using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class ComplexAvatarSelector : MonoBehaviour
	{
		[SerializeField]
		private Image BackgroundHolder;

		[SerializeField]
		private Image ForegroundHolder;

		[SerializeField]
		private Image EmblemHolder;

		[SerializeField]
		private ComplexAvatarTabListener TabListener;

		[SerializeField]
		private Transform ColorButtonsRoot;

		private ClanPrefabs Prefabs { get; set; }

		private ClanIcons Icons { get; set; }

		private ClanAvatarInfo AvatarInfo { get; set; }

		private Dictionary<AvatarComplexPart, List<IconData>> IconsPreset { get; set; }

		private Dictionary<AvatarComplexPart, int> IconsIndex { get; set; }

		private Dictionary<AvatarComplexPart, int> ColorsIndex { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void Load(List<IconData> backgrounds, List<IconData> foregrounds, List<IconData> emblems, ClanAvatarInfo avatarInfo)
		{
		}

		private void DisplayFromPart(AvatarComplexPart part)
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

		private void OnChangeComplexPart(AvatarComplexPart part)
		{
		}

		private void DrawAvatarSprite(AvatarComplexPart part, Sprite sprite)
		{
		}

		private void DrawAvatarColor(AvatarComplexPart part)
		{
		}

		private void DrawColorTable()
		{
		}
	}
}
