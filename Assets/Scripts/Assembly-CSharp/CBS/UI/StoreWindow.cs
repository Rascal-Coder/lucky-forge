using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class StoreWindow : MonoBehaviour
	{
		[SerializeField]
		private StoreTitleScroller TitleScroller;

		[SerializeField]
		private ToggleGroup TitleGroup;

		[SerializeField]
		private StoreContentScroller ContentScroller;

		[SerializeField]
		private StoreLoad LoadType;

		private IStore Store { get; set; }

		private StorePrefabs StorePrefabs { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void LoadStore()
		{
		}

		private void ClearStore()
		{
		}

		private void SpawnStoresTitle(List<CBSStoreTitle> stores)
		{
		}

		private void SpawnStoreContent(List<CBSStoreItem> items)
		{
		}

		private void OnGetStores(CBSGetStoresResult result)
		{
		}

		private void OnGetStore(CBSGetStoreResult result)
		{
		}

		private void OnGetStoreTitles(CBSGetStoreTitlesResult result)
		{
		}

		private void OnSelectTitle(CBSStoreTitle storeTitle)
		{
		}

		public void CloseStore()
		{
		}
	}
}
