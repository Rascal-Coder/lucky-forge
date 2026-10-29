using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "ExamplesConfig", menuName = "CBS/Add new ExamplesConfig")]
	public class ExamplesConfig : CBSScriptable
	{
		public Sprite DefaultClanAvatar;

		public override string ResourcePath => null;
	}
}
