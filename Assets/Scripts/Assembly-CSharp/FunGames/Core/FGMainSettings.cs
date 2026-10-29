using FunGames.Core.Utils;
using UnityEngine;

namespace FunGames.Core
{
	[CreateAssetMenu(fileName = "Assets/Resources/FunGames/FGMainSettings", menuName = "FunGames/FGMainSettings", order = 10)]
	public class FGMainSettings : FGModuleSettingsAbstract<FGMainSettings>
	{
		public const string NAME = "FGMainSettings";

		private const string PATH = "FunGames/FGMainSettings";

		public string ApiKey;

		public LogLevel LogLevel;

		public bool AmazonStoreSetup;

		[Header("Editor Settings")]
		[Tooltip("Launch as QA Mode in Unity Editor")]
		public bool QaModeInEditor;

		protected override FGMainSettings LoadResources()
		{
			return null;
		}
	}
}
