using System;
using UnityEngine;

namespace CBS.Scriptable
{
	[Serializable]
	public class BaseLinkedAsset<TBase> where TBase : UnityEngine.Object
	{
		public string ID;

		public TBase Asset;
	}
}
