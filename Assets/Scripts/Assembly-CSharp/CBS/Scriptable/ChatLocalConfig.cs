using System.Collections.Generic;
using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "ChatConfig", menuName = "CBS/Add new Chat Config")]
	public class ChatLocalConfig : CBSScriptable
	{
		public bool ShowDate;

		public bool UseUniqueColor;

		public Color DefaultTextColor;

		public Color SystemTextColor;

		public Color BubbleTextColor;

		public Color TagTextColor;

		public Color OwnerBubbleColor;

		public Color SystemBubbleColor;

		public List<Color> ColorTable;

		public override string ResourcePath => null;
	}
}
