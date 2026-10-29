using System.Collections.Generic;
using CBS.Models;
using CBS.SharedData.Lootbox;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.MultiplayerModels;

namespace CBS.Utils
{
	public static class PlayfabUtils
	{
		public const int DEFAULT_CUSTOM_DATA_SIZE = 10000;

		public const int ITEM_CUSTOM_DATA_SIZE = 1000;

		public const int TITLE_DATA_SIZE = 1000000;

		public const string REAL_MONEY_CODE = "RM";

		public static string ToJson(this PlayFabAuthenticationContext context)
		{
			return null;
		}

		public static string ToJson(this MatchmakingQueueConfig context)
		{
			return null;
		}

		public static Dictionary<string, CBSCurrency> GetCBSCurrencies(this CatalogItemBundleInfo bundle)
		{
			return null;
		}

		public static string GetRMPriceString(this CBSPrice price)
		{
			return null;
		}

		public static string GetRMPriceString(this CatalogItem item)
		{
			return null;
		}

		public static string CurrencyValueToString(string currencyCode, int value)
		{
			return null;
		}

		public static bool IsConsumable(this CatalogItem item)
		{
			return false;
		}

		public static bool IsItem(this CatalogItem item)
		{
			return false;
		}

		public static bool IsPack(this CatalogItem item)
		{
			return false;
		}

		public static bool IsLootbox(this CatalogItem item)
		{
			return false;
		}

		public static string GetCategory(this CatalogItem item)
		{
			return null;
		}

		public static CBSItem ToCBSItem(this CatalogItem item, CBSItemRecipe recipe, List<CBSItemUpgradeState> upgradeState)
		{
			return null;
		}

		public static CBSItemPack ToCBSPack(this CatalogItem item)
		{
			return null;
		}

		public static CBSLootbox ToCBSLootbox(this CatalogItem item, CBSLootboxTable lootboxTable)
		{
			return null;
		}

		public static CBSInventoryItem ToCBSInventoryItem(this ItemInstance instance)
		{
			return null;
		}

		public static CBSLootboxInventoryItem ToCBSLootboxInventoryItem(this ItemInstance instance)
		{
			return null;
		}

		public static CBSLootboxInventoryItem ToCBSLootboxInventoryItem(this CBSInventoryItem instance)
		{
			return null;
		}
	}
}
