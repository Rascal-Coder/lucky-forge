using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "ProfilePrefabs", menuName = "CBS/Add new Profile Prefabs")]
	public class ProfilePrefabs : CBSScriptable
	{
		public GameObject ProfileIcon;

		public GameObject AccountForm;

		public GameObject AvatarState;

		public override string ResourcePath => null;
	}
}
