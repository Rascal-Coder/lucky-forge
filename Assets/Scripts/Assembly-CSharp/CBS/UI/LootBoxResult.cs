using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class LootBoxResult : MonoBehaviour
	{
		[SerializeField]
		private Transform CurrencyRoot;

		[SerializeField]
		private Transform BundleRoot;

		private ItemsIcons ItemIcons { get; set; }

		private CommonPrefabs Prefabs { get; set; }

		private List<GameObject> CurrencyPool { get; set; }

		private List<GameObject> LootPool { get; set; }

		private void Awake()
		{
		}

		public void Display(CBSOpenLootboxResult result)
		{
		}

		public void Display(GrantRewardResult result)
		{
		}
	}
}
