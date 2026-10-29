using System.Collections.Generic;

namespace CBS.Models
{
	public class OfferContainer
	{
		public List<string> OfferIDs;

		public bool OfferPurchased(string offerInstanceID)
		{
			return false;
		}

		public void AddOffer(string offerInstanceID)
		{
		}
	}
}
