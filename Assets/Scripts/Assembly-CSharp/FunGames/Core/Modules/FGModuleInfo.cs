using System;
using System.Collections.Generic;

namespace FunGames.Core.Modules
{
	[Serializable]
	public class FGModuleInfo
	{
		public string Id;

		public string Name;

		public string Version;

		public string LogColor;

		public string PackageUrl;

		public bool HasIssue;

		public bool IsDeprecated;

		public bool IsBeta;

		public List<string> Plugins;

		public List<string> Dependencies;

		public void Set(FGModuleInfo moduleInfo)
		{
		}
	}
}
