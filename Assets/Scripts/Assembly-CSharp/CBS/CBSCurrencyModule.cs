using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CBS.Models;
using CBS.Playfab;
using CBS.Scriptable;
using PlayFab.ClientModels;

namespace CBS
{
	public class CBSCurrencyModule : CBSModule, ICurrency
	{
		[CompilerGenerated]
		private Action<CBSCurrency> m_OnCurrencyUpdated;

		private readonly string CatalogID;

		public Dictionary<string, CBSCurrency> CacheCurrencies { get; private set; }

		private IFabCurrency FabCurrency { get; set; }

		private IProfile Profile { get; set; }

		private ICBSInAppPurchase InAppPurchase { get; set; }

		private IAuth Auth { get; set; }

		private AuthData AuthData { get; set; }

		public event Action<CBSCurrency> OnCurrencyUpdated
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

		public void GetProfileCurrencies(Action<CBSGetCurrenciesResult> result)
		{
		}

		public void GetProfileCurrencies(string profileID, Action<CBSGetCurrenciesResult> result)
		{
		}

		public void AddCurrencyToProfile(string code, int amount, Action<CBSUpdateCurrencyResult> result = null)
		{
		}

		public void SubtractCurrencyFromProfile(string code, int amount, Action<CBSUpdateCurrencyResult> result = null)
		{
		}

		public void AddCurrencyToProfile(string profileID, string code, int amount, Action<CBSUpdateCurrencyResult> result = null)
		{
		}

		public void SubtractCurrencyFromProfile(string profileID, string code, int amount, Action<CBSUpdateCurrencyResult> result = null)
		{
		}

		public void GetCurrenciesPacks(Action<CBSGetCurrenciesPacksResult> result)
		{
		}

		public void GetPacksByTag(string tag, Action<CBSGetCurrenciesPacksResult> result)
		{
		}

		public void GrantCurrencyPack(string packID, Action<CBSGrandPackResult> result)
		{
		}

		public void PurchasePackWithRealMoney(string packID, Action<CBSPurchasePackWithRealMoneyResult> result)
		{
		}

		private void AddCurrency(string profileID, string code, int amount, Action<CBSUpdateCurrencyResult> result = null)
		{
		}

		private void SubtractCurrency(string profileID, string code, int amount, Action<CBSUpdateCurrencyResult> result = null)
		{
		}

		internal void ParseCurrencies(Dictionary<string, CBSCurrency> currencyList)
		{
		}

		private void ParseCurrencies(GetUserInventoryResult inventory)
		{
		}

		internal void ChangeRequest(string code)
		{
		}

		internal void ChangeRequest(string[] codes)
		{
		}

		protected override void OnLogout()
		{
		}

		public CBSCurrency GetFromCache(string code)
		{
			return null;
		}

		private void OnLoginSuccess(CBSLoginResult result)
		{
		}
	}
}
