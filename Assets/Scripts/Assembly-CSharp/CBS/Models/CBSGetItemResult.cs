namespace CBS.Models
{
	public class CBSGetItemResult : CBSBaseResult
	{
		public CBSItem Item;

		public CBSItemPack Pack;

		public CBSLootbox Lootbox;

		public ItemType ItemType => ItemType.ITEMS;
	}
}
