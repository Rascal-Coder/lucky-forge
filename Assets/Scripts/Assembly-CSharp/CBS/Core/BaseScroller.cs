using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CBS.Core
{
	public class BaseScroller : MonoBehaviour
	{
		[SerializeField]
		private Transform Root;

		[CompilerGenerated]
		private Action<GameObject, int> m_OnSpawn;

		private List<GameObject> AllItems;

		protected GameObject ItemPrefab { private get; set; }

		public event Action<GameObject, int> OnSpawn
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void SpawnItems(GameObject prefab, int count)
		{
		}

		private void Resize(int newCount)
		{
		}

		public void Clear()
		{
		}

		protected virtual void OnItemSpawn(GameObject item, int index)
		{
		}
	}
}
