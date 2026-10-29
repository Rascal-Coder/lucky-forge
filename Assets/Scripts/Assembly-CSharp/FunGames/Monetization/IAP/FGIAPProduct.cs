using UnityEngine;

namespace FunGames.Monetization.IAP
{
	[CreateAssetMenu(fileName = "Resources/FunGames/IAP/Product", menuName = "FunGames/IAP/FGProduct")]
	public class FGIAPProduct : ScriptableObject
	{
		public string GooglePlayId;

		public string AppleStoreId;

		public string AmazonStoreId;

		public FGProductType ProductType;

		public string Id => null;
	}
}
