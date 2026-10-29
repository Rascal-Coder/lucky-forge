using System;
using FunGames.Core.Modules;
using UnityEngine;

namespace FunGames.Core.Settings
{
	public abstract class FGModuleSettings : ScriptableObject, IFGModuleSettings
	{
		[HideInInspector]
		public FGModuleInfo moduleInfo;

		public static Action OnValidateCalled;

		public Color LogColor;

		public bool logEnabled;

		protected const string AllCharsNoNewlineRegex = ".*";

		public Color Color => default;

		public bool LogEnabled => false;

		public FGModuleInfo ModuleInfo
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
	}
}
