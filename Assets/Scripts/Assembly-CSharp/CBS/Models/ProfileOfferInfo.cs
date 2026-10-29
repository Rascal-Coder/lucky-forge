using System;

namespace CBS.Models
{
	public class ProfileOfferInfo
	{
		public string OfferInstanceID;

		public string StoreID;

		public string ItemID;

		public DateTime? EndDate;

		public bool IsActive(DateTime serverDate)
		{
			return false;
		}
	}
}
