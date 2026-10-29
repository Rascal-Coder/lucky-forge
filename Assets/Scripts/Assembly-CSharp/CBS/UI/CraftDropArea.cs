using System;
using System.Runtime.CompilerServices;
using CBS.Core;
using UnityEngine;

namespace CBS.UI
{
	public class CraftDropArea : MonoBehaviour, IDropContainer
	{
		[CompilerGenerated]
		private Action<DraggableInventorySlot> m_OnDropSlot;

		public event Action<DraggableInventorySlot> OnDropSlot
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

		public void OnDropItem(GameObject item)
		{
		}
	}
}
