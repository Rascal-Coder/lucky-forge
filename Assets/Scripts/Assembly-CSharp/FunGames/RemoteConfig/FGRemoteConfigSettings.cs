using System.Collections.Generic;
using UnityEngine;

namespace FunGames.RemoteConfig
{
	[CreateAssetMenu(fileName = "Assets/Resources/FunGames/FGRemoteConfigSettings", menuName = "FunGames/FGRemoteConfigSettings", order = 10)]
	public class FGRemoteConfigSettings : FGModuleSettingsAbstract<FGRemoteConfigSettings>
	{
		public const string NAME = "FGRemoteConfigSettings";

		private const string PATH = "FunGames/FGRemoteConfigSettings";

		private List<FGRemoteConfigValue> _defaultValues;

		public List<FGRemoteConfigValue> CustomDefaultValues;

		protected override FGRemoteConfigSettings LoadResources()
		{
			return null;
		}
	}
}
