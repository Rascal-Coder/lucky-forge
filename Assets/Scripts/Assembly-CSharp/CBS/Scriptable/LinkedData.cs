using System.Collections.Generic;
using UnityEngine;

namespace CBS.Scriptable
{
	public abstract class LinkedData<TBase> : CBSScriptable where TBase : Object
	{
		public List<BaseLinkedAsset<TBase>> AssetList;

		public abstract string EditorPath { get; }

		public abstract string EditorAssetName { get; }

		internal override T Load<T>()
		{
			return null;
		}

		public virtual TBase GetLinkedData(string id)
		{
			return null;
		}
	}
}
