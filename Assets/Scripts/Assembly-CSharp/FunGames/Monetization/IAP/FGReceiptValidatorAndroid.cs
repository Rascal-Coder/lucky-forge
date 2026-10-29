namespace FunGames.Monetization.IAP
{
	public class FGReceiptValidatorAndroid : IFGReceiptValidator
	{
		public readonly string OrderUniqueId;

		public readonly string PurchaseToken;

		public string Payload { get; }

		public FGReceiptValidatorAndroid(string orderUniqueId, string purchaseToken, string payload)
		{
		}
	}
}
