using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CBS.Models;
using CBS.Playfab;
using CBS.SharedData.Lootbox;
using PlayFab.ClientModels;

namespace CBS
{
	public class CBSItemsModule : CBSModule, ICBSItems
	{
		[CompilerGenerated]
		private Action<CBSPurchaseItemWithCurrencyResult> m_OnItemPurchased;

		[CompilerGenerated]
		private Action<CBSPurchaseItemWithRealMoneyResult> m_OnItemPurchasedWithRealMoney;

		[CompilerGenerated]
		private Action<CBSGrantItemsResult> m_OnItemGranted;

		public List<CBSItem> AllItems { get; private set; }

		public List<CBSItemPack> AllPacks { get; private set; }

		public List<CBSLootbox> AllLootboxes { get; private set; }

		public CBSRecipeContainer Recipes { get; private set; }

		public CBSLootboxTable LootboxTable { get; private set; }

		public CBSItemUpgradesContainer Upgrades { get; private set; }

		public Dictionary<string, CBSBaseItem> ItemsDictionary { get; private set; }

		public string[] ItemCategories { get; set; }

		public string[] PackCategories { get; set; }

		public string[] LootboxCategories { get; set; }

		private IFabItems FabItems { get; set; }

		private IAuth Auth { get; set; }

		private IProfile Profile { get; set; }

		private ICBSInAppPurchase InAppPurchase { get; set; }

		public event Action<CBSPurchaseItemWithCurrencyResult> OnItemPurchased
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

		public event Action<CBSPurchaseItemWithRealMoneyResult> OnItemPurchasedWithRealMoney
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

		public event Action<CBSGrantItemsResult> OnItemGranted
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

		protected override void Init()
		{
		}

		public void FetchAll(Action<CBSFetchAllResult> result)
		{
		}

		public void GetCategories(ItemType type, Action<CBSGetCategoriesResult> result)
		{
		}

		public void GetCBSItems(CBSGetItemsRequest request, Action<CBSGetItemsResult> result)
		{
		}

		public void GetCBSItemByID(string itemID, Action<CBSGetItemResult> result)
		{
		}

		public void PurchaseCBSItemWithCurrency(string itemID, string currencyCode, int currencyValue, Action<CBSPurchaseItemWithCurrencyResult> result)
		{
		}

		public void PurchaseCBSItemWithRealMoney(string itemID, Action<CBSPurchaseItemWithRealMoneyResult> result)
		{
		}

		public void GrantItem(string itemID, Action<CBSGrantItemsResult> result)
		{
		}

		public void GrantItems(string[] itemsIDs, Action<CBSGrantItemsResult> result)
		{
		}

		public void GrantItemToProfile(string profileID, string itemID, Action<CBSGrantItemsResult> result)
		{
		}

		public void GrantItemsToProfile(string profileID, string[] itemsIDs, Action<CBSGrantItemsResult> result)
		{
		}

		public CBSBaseItem GetFromCache(string itemID)
		{
			return null;
		}

		internal bool IsItemsFromPack(string[] itemsIDs)
		{
			return false;
		}

		private void InternalGrantItemsToProfile(string profileID, string[] itemsIDs, Action<CBSGrantItemsResult> result)
		{
		}

		private void ParseItems(GetCatalogItemsResult result)
		{
		}

		private void ParseCategories(Dictionary<string, string> data)
		{
		}

		internal CBSBaseItem GetFromDictionary(string itemID)
		{
			return null;
		}

		internal void ParseMetaData(CBSRecipeContainer recipes, CBSItemUpgradesContainer upgrades, CBSLootboxTable lootboxTable)
		{
		}

		private string[] GetCategoryFromType(ItemType type)
		{
			return null;
		}

		private void OnPlayerLogined(CBSLoginResult loginResult)
		{
		}

		protected override void OnLogout()
		{
		}
	}
}
