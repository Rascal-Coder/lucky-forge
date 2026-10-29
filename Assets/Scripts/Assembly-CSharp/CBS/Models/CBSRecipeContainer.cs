using System.Collections.Generic;

namespace CBS.Models
{
	public class CBSRecipeContainer
	{
		public Dictionary<string, CBSItemRecipe> Recipes;

		public bool HasRecipe(string itemID)
		{
			return false;
		}

		public CBSItemRecipe GetRecipe(string itemID)
		{
			return null;
		}

		public void AddOrUpdateRecipe(string itemID, CBSItemRecipe recipe)
		{
		}

		public void RemoveRecipe(string itemID)
		{
		}

		public void Duplicate(string fromItemID, string toItemID)
		{
		}
	}
}
