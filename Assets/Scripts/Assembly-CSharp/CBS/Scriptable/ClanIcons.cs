using System.Collections.Generic;
using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "ClanIcons", menuName = "CBS/Add new Tasks Clan Icons")]
	public class ClanIcons : IconsData
	{
		public Sprite DefaultAvatar;

		public ClanAvatarViewMode DisplayMode;

		public List<IconData> Backgrounds;

		public List<IconData> Foregrounds;

		public List<IconData> Emblems;

		public List<Color> ColorsToSet;

		public override string ResourcePath => null;

		public override string EditorPath => null;

		public override string EditorAssetName => null;

		private Dictionary<string, Sprite> SimpleIconsDictionary { get; set; }

		private Dictionary<string, Sprite> BackgroundIconsDictionary { get; set; }

		private Dictionary<string, Sprite> ForegroundIconsDictionary { get; set; }

		private Dictionary<string, Sprite> EmblemsIconsDictionary { get; set; }

		internal override void Initialize()
		{
		}

		public bool SimpleIconsExist()
		{
			return false;
		}

		public bool ComplexIconsExist()
		{
			return false;
		}

		public void RemoveBackground(string id)
		{
		}

		public void RemoveForeground(string id)
		{
		}

		public void RemoveEmblems(string id)
		{
		}

		public Sprite GetSimpeIcon(string id)
		{
			return null;
		}

		public Sprite GetBackgroundIcon(string id)
		{
			return null;
		}

		public Sprite GetForegroundIcon(string id)
		{
			return null;
		}

		public Sprite GetEmblemIcon(string id)
		{
			return null;
		}

		public Color GetColorByIndex(int index)
		{
			return default;
		}
	}
}
