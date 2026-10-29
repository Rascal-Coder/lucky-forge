using System;
using System.Collections.Generic;

namespace FunGames.Core.DatabaseModels
{
	[Serializable]
	public class FGDBModuleSettings
	{
		public string id;

		public string name;

		public string module_version;

		public bool is_mandatory;

		public bool is_active;

		public string deployment_folder;

		public List<FGDBModuleParameter> parameters;

		public List<FGDBModuleSettings> submodules;
	}
}
