using System.Collections.Generic;
using CBS.Models;
using UnityEngine;

namespace CBS
{
	public abstract class CBSBaseItem
	{
		public string ItemID { get; protected set; }

		public string DisplayName { get; protected set; }

		public string Description { get; protected set; }

		public string Category { get; protected set; }

		public string ItemClass { get; protected set; }

		public string ExternalIconURL { get; protected set; }

		public ItemType Type { get; protected set; }

		public Dictionary<string, uint> Prices { get; protected set; }

		internal string CustomData { get; set; }

		public virtual T GetCustomData<T>() where T : CBSItemCustomData
		{
			return null;
		}

		public Dictionary<string, object> GetCustomDataAsDictionary()
		{
			return null;
		}

		public GameObject GetLinkedPrefab()
		{
			return null;
		}

		public TScriptable GetLinkedScriptable<TScriptable>() where TScriptable : ScriptableObject
		{
			return null;
		}

		public abstract CBSItemRecipe GetRecipeData();

		public abstract List<CBSItemUpgradeState> GetUpgradeList();
	}
}
