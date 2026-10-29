using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "PlayfabData", menuName = "CBS/Add new Playfab Data")]
	public class PlayfabData : CBSScriptable
	{
		public bool EnableCustomCloudScript;

		public override string ResourcePath => null;
	}
}
