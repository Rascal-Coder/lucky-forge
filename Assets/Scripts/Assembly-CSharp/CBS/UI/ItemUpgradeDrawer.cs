using System;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class ItemUpgradeDrawer : MonoBehaviour
	{
		[SerializeField]
		private GameObject DependencyContainer;

		[SerializeField]
		private Color CustomDataTitleColor;

		[SerializeField]
		private Color CustomDataValueColor;

		[SerializeField]
		private Text UpgradeTitle;

		[SerializeField]
		private Text UpgradeData;

		[SerializeField]
		private ItemDependencyDrawer DependencyDrawer;

		[SerializeField]
		private bool Resize;

		[SerializeField]
		private float ResizeBottomOfset;

		[SerializeField]
		private RectTransform[] TransformsToCalculateHeight;

		public Action<CraftStateContainer> OnGetDependency;

		private ICrafting Crafting { get; set; }

		private ICBSItems Items { get; set; }

		private void Awake()
		{
		}

		public void Load(CBSInventoryItem item, bool fromCache = false)
		{
		}

		private void DrawDependency(CraftStateContainer state)
		{
		}

		private void CalculateSize()
		{
		}

		private void OnGetDependencyState(CBSGetNextUpgradeStateResult result)
		{
		}
	}
}
