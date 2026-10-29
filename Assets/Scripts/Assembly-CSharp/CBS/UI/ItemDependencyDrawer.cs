using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class ItemDependencyDrawer : MonoBehaviour
	{
		[SerializeField]
		private ItemDependencyScroller Scroller;

		private CraftPrefabs CraftPrefabs { get; set; }

		private void Awake()
		{
		}

		public void Draw(CraftStateContainer dependencyState)
		{
		}
	}
}
