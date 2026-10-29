using System;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class RecipeDependencyDrawer : MonoBehaviour
	{
		[SerializeField]
		private GameObject TargetContainer;

		[SerializeField]
		private GameObject DependencyContainer;

		[SerializeField]
		private Image TargetIcon;

		[SerializeField]
		private Text TargetTitle;

		[SerializeField]
		private Text TargetDescription;

		[SerializeField]
		private ItemDependencyDrawer DependencyDrawer;

		[SerializeField]
		private bool Resize;

		public Action<CraftStateContainer> OnGetDependency;

		private ICrafting Crafting { get; set; }

		private ICBSItems Items { get; set; }

		private void Awake()
		{
		}

		public void Load(string recipeItemID, bool fromCache = false)
		{
		}

		private void DrawRecipe(string targetID, CraftStateContainer state)
		{
		}

		private void CalculateSize()
		{
		}

		private void OnGetDependencyState(CBSGetRecipeDependencyStateResult result)
		{
		}
	}
}
