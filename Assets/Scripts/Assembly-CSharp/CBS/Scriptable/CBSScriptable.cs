using System;
using System.Collections.Generic;
using UnityEngine;

namespace CBS.Scriptable
{
	public abstract class CBSScriptable : ScriptableObject
	{
		private static Dictionary<Type, CBSScriptable> Scribtables { get; set; }

		public abstract string ResourcePath { get; }

		internal virtual T Load<T>() where T : CBSScriptable
		{
			return null;
		}

		internal virtual void Initialize()
		{
		}

		public void Save()
		{
		}

		public static T Get<T>() where T : CBSScriptable
		{
			return null;
		}
	}
}
