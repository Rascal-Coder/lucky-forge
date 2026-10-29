namespace FunGames.Monetization.IAP
{
	public class FGReceiptValidatorIOS : IFGReceiptValidator
	{
		public readonly string ProductId;

		public readonly string TransactionId;

		public string Payload { get; }

		public FGReceiptValidatorIOS(string productId, string transactionId, string payload)
		{
		}
	}
}
