using System;
using System.Collections.Generic;

namespace CBS.Models
{
	public class ProfileOffers
	{
		public List<ProfileOfferInfo> Offers;

		public ProfileOfferInfo GetOfferByItemID(string itemID)
		{
			return null;
		}

		public bool OfferExist(string offerInstanceID)
		{
			return false;
		}

		public bool IsActive(string offerInstanceID, DateTime serverTime)
		{
			return false;
		}

		public void AddOffer(ProfileOfferInfo offer)
		{
		}

		public void RemoveOutDated(DateTime serverTime)
		{
		}

		public void RemoveOffer(string itemID)
		{
		}
	}
}
