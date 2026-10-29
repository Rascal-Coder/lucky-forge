using CBS.Core;

namespace CBS.Models
{
	public class CBSItemRecipe : CBSItemDependency, ICustomData<CBSRecipeCustomData>
	{
		public string ItemIdToGraft;

		public string CustomDataClassName { get; set; }

		public string CustomRawData { get; set; }

		public bool CompressCustomData => false;

		public T GetCustomData<T>() where T : CBSRecipeCustomData
		{
			return null;
		}
	}
}
