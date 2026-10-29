using System.Collections.Generic;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class RewardDrawer : MonoBehaviour
	{
		[SerializeField]
		private Transform BundleRoot;

		private ICBSItems Items { get; set; }

		private CommonPrefabs Prefabs { get; set; }

		protected virtual GameObject RewardPrefab { get; set; }

		private List<GameObject> CurrencyPool { get; set; }

		protected List<GameObject> LootPool { get; set; }

		private void Awake()
		{
		}

		public virtual void Init()
		{
		}

		public void Clear()
		{
		}

		public void Display(RewardObject RewardObject)
		{
		}
	}
}
