using System.Collections.Generic;
using UnityEngine;

namespace CBS.Scriptable
{
	public abstract class IconsData : CBSScriptable
	{
		public List<IconData> AllSprites;

		public abstract string EditorPath { get; }

		public abstract string EditorAssetName { get; }

		internal override T Load<T>()
		{
			return null;
		}

		public virtual Sprite GetSprite(string id)
		{
			return null;
		}
	}
}
