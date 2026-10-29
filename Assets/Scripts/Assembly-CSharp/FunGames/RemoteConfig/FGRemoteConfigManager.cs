using System.Collections.Generic;
using FunGames.Core.Modules;

namespace FunGames.RemoteConfig
{
	public class FGRemoteConfigManager : FGModuleAbstract<FGRemoteConfigManager, FGModuleCallbacks, FGRemoteConfigSettings>
	{
		public Dictionary<string, object> ValuesDictionary;

		public FGABTest CurrentABTest;

		public override FGRemoteConfigSettings Settings => null;

		protected override FGModule Parent => null;

		protected override string EventName => null;

		protected override string RemoteConfigKey => null;

		protected override void InitializeCallbacks()
		{
		}

		protected override void OnAwake()
		{
		}

		protected override void OnStart()
		{
		}

		protected override void InitializeModule()
		{
		}

		public void InitializeDefaultValues()
		{
		}

		public object GetValueByKey(string key)
		{
			return null;
		}

		private Dictionary<string, object> GetCustomDefaultValues()
		{
			return null;
		}

		public void AddDefaultValues(Dictionary<string, object> defaultValues)
		{
		}

		public void AddDefaultValue(string key, object value)
		{
		}

		public void OverrideDefaultValue(string key, object value)
		{
		}

		protected override void ClearInitialization()
		{
		}
	}
}
