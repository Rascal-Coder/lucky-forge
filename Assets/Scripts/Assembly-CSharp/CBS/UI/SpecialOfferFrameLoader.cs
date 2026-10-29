using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class SpecialOfferFrameLoader : MonoBehaviour
	{
		[SerializeField]
		private Transform Root;

		private Dictionary<int, SpecialOfferFrame> FramePool;

		private Dictionary<string, SpecialOfferFrame> UIPool;

		private IStore Store { get; set; }

		private StorePrefabs Prefabs { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void LoadAllFrames()
		{
		}

		private void OnGetOffers(CBSGetSpecialOffersResult result)
		{
		}

		private void DrawOffers(List<CBSSpecialOffer> offers)
		{
		}

		private SpecialOfferFrame GetFrameAt(int index)
		{
			return null;
		}

		private void HideFrameByID(string uniqueID)
		{
		}

		private void HideAllFrames()
		{
		}

		private void OnPurchaseItem(CBSPurchaseStoreItemResult result)
		{
		}

		private void OnPurchaseItemWithRM(CBSPurchaseStoreItemWithRMResult result)
		{
		}
	}
}
