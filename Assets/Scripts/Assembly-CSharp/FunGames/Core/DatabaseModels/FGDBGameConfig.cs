using System.Collections.Generic;

namespace FunGames.Core.DatabaseModels
{
	public class FGDBGameConfig
	{
		public static string ModulesKey;

		public string id;

		public string name;

		public List<FGDBModuleSettings> modules;

		private const string LastModuleId = "fg_core";

		public void SortModules()
		{
		}

		private int CompareModules(FGDBModuleSettings a, FGDBModuleSettings b)
		{
			return 0;
		}

		public void RemoveParameterValues()
		{
		}

		private void RemoveParameterValues(FGDBModuleSettings module)
		{
		}
	}
}
