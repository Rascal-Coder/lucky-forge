using FunGames.Core.Modules;
using UnityEngine;

namespace FunGames.Core.Settings
{
	public interface IFGModuleSettings
	{
		FGModuleInfo ModuleInfo { get; set; }

		Color Color { get; }

		bool LogEnabled { get; }
	}
}
