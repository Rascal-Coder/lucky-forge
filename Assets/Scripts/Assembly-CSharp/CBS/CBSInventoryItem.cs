using System;
using System.Collections.Generic;
using CBS.Models;
using PlayFab.ClientModels;

namespace CBS
{
	public class CBSInventoryItem : CBSBaseItem
	{
		private Dictionary<string, string> InventoryData;

		public string InstanceID { get; private set; }

		public bool IsEquippable { get; private set; }

		public bool IsConsumable { get; private set; }

		public bool IsStackable { get; private set; }

		public bool IsTradable { get; private set; }

		public bool IsRecipe { get; private set; }

		public bool IsUpgradable { get; private set; }

		public bool HasLifeTime { get; private set; }

		public DateTime? Expiration { get; private set; }

		public DateTime? PurchaseDate { get; private set; }

		public int? Count { get; private set; }

		public int PurchasePrice { get; private set; }

		public string PurchaseCurrency { get; private set; }

		public PurchaseType PurchaseAction { get; private set; }

		public int UpgradeIndex { get; private set; }

		public bool Equipped { get; private set; }

		public ItemInstance PlayFabInstance { get; private set; }

		internal bool IsInTrading { get; private set; }

		private CBSBaseItem BaseItem { get; set; }

		public CBSInventoryItem(ItemInstance inventoryItem, CBSBaseItem baseItem)
		{
		}

		public Dictionary<string, string> GetInventoryData()
		{
			return null;
		}

		public string GetInventoryDataByKey(string key)
		{
			return null;
		}

		public override T GetCustomData<T>()
		{
			return null;
		}

		public Dictionary<string, object> GetInventoryDataAsDictionary<T>(string key) where T : class
		{
			return null;
		}

		public override CBSItemRecipe GetRecipeData()
		{
			return null;
		}

		public override List<CBSItemUpgradeState> GetUpgradeList()
		{
			return null;
		}

		public bool IsMaxUpgrade()
		{
			return false;
		}

		public CBSItemUpgradeState GetCurrentUpgradeData()
		{
			return null;
		}

		public CBSItemUpgradeState GetNextUpgradeData()
		{
			return null;
		}

		public T GetCurrentUpgradeCustomData<T>() where T : CBSUpgradeItemCustomData
		{
			return null;
		}

		public Dictionary<string, object> GetCurrentUpgradeCustomDataAsDictionary()
		{
			return null;
		}

		public T GetNextUpgradeCustomData<T>() where T : CBSUpgradeItemCustomData
		{
			return null;
		}

		public Dictionary<string, object> GetNextUpgradeCustomDataAsDictionary()
		{
			return null;
		}

		internal void SetUsageCount(int count)
		{
		}

		internal void SpendCount(int count)
		{
		}
	}
}
