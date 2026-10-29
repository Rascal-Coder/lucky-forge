using System;

namespace CBS.Models
{
	[Serializable]
	public class BattlePassTicket : BattlePassInstanceAccess
	{
		private static readonly string CatalogPrefix;

		public string ID;

		public string BattlePassID;

		public string DisplayName;

		public string Description;

		public bool OverrideExpMultiply;

		public bool SkipLevel;

		public int SkipLevelCount;

		public CBSPrice Price;

		public CBSPurchaseType PurchaseType;

		public string GetCatalogID()
		{
			return null;
		}
	}
}
