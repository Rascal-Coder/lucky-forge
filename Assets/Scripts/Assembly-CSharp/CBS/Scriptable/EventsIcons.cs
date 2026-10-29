using System.Collections.Generic;
using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "EventsIcons", menuName = "CBS/Add new EventsIcons Sprite pack")]
	public class EventsIcons : IconsData
	{
		public List<IconData> BackgroundSprites;

		public override string ResourcePath => null;

		public override string EditorPath => null;

		public override string EditorAssetName => null;

		public virtual Sprite GetBackgroundSprite(string id)
		{
			return null;
		}
	}
}
