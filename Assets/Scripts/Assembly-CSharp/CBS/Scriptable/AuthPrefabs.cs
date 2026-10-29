using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "AuthPrefabs", menuName = "CBS/Add new Auth Prefabs")]
	public class AuthPrefabs : CBSScriptable
	{
		public GameObject LoginForm;

		public GameObject RegisterForm;

		public GameObject RecoveryForm;

		public GameObject Background;

		public override string ResourcePath => null;
	}
}
