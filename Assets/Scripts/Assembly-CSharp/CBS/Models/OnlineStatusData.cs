using System;

namespace CBS.Models
{
	public class OnlineStatusData
	{
		public bool IsOnline;

		public DateTime LastUpdate;

		public DateTime ServerTime;

		public long LastSeenOnlineTimeStamp;

		public TimeSpan LastSeenOnline()
		{
			return default;
		}
	}
}
