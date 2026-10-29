using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class CraftingWindow : MonoBehaviour
	{
		[SerializeField]
		private CraftDropArea DropArea;

		[SerializeField]
		private Transform RootDrop;

		[SerializeField]
		private GameObject DragAndDropNotification;

		[SerializeField]
		private RecipeDependencyDrawer DependencyDrawer;

		[SerializeField]
		private Button CraftButton;

		private ICrafting Crafting { get; set; }

		private DraggableInventorySlot DroppedSlot { get; set; }

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void LoadRecipe(CBSInventoryItem item)
		{
		}

		private void UnloadRecipe()
		{
		}

		private void OnDropInventoryItem(DraggableInventorySlot slot)
		{
		}

		private void OnCancelCraft()
		{
		}

		private void OnGetRecipeDependency(CraftStateContainer state)
		{
		}

		public void CraftItem()
		{
		}
	}
}
