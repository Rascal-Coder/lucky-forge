using System;

namespace CBS.Utils
{
	public class DateUtils
	{
		public const string DefaultTimer = "00:00";

		public const string TournamentTimerFormat = "hh\\:mm\\:ss";

		public const string StoreTimerFormat = "hh\\:mm\\:ss";

		public const string LeaderboardTimerFormat = "hh\\:mm\\:ss";

		public const string ProfileDateFormat = "hh\\:mm";

		public const string CurrencyTimerFormat = "mm\\:ss";

		public const string EventTimerFormat = "dd\\D\\:hh\\:mm\\:ss";

		public const string LootboxTimerFormat = "dd\\:hh\\:mm\\:ss";

		public static DateTime ConvertFromUnixTimestamp(long timestamp)
		{
			return default;
		}

		public static DateTime GetDateFromString(string data)
		{
			return default;
		}

		public static int TimestampToHours(int timestamp)
		{
			return 0;
		}

		public static int TournamentDateToHours(TournamentDate date)
		{
			return 0;
		}

		public static int HoursToMiliseconds(int hours)
		{
			return 0;
		}

		public static int ToutnamentDateMiliseconds(TournamentDate date)
		{
			return 0;
		}

		public static int GetZoneOffset()
		{
			return 0;
		}
	}
}
