namespace GameAnalyticsSDK.Validators
{
	internal static class GAValidator
	{
		public static bool StringMatch(string s, string pattern)
		{
			return false;
		}

		public static bool ValidateBusinessEvent(string currency, int amount, string cartType, string itemType, string itemId)
		{
			return false;
		}

		public static bool ValidateResourceEvent(GAResourceFlowType flowType, string currency, float amount, string itemType, string itemId)
		{
			return false;
		}

		public static bool ValidateProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03)
		{
			return false;
		}

		public static bool ValidateDesignEvent(string eventId)
		{
			return false;
		}

		public static bool ValidateErrorEvent(GAErrorSeverity severity, string message)
		{
			return false;
		}

		public static bool ValidateAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement)
		{
			return false;
		}

		public static bool ValidateSdkErrorEvent(string gameKey, string gameSecret, GAErrorSeverity type)
		{
			return false;
		}

		public static bool ValidateKeys(string gameKey, string gameSecret)
		{
			return false;
		}

		public static bool ValidateCurrency(string currency)
		{
			return false;
		}

		public static bool ValidateEventPartLength(string eventPart, bool allowNull)
		{
			return false;
		}

		public static bool ValidateEventPartCharacters(string eventPart)
		{
			return false;
		}

		public static bool ValidateEventIdLength(string eventId)
		{
			return false;
		}

		public static bool ValidateEventIdCharacters(string eventId)
		{
			return false;
		}

		public static bool ValidateBuild(string build)
		{
			return false;
		}

		public static bool ValidateUserId(string uId)
		{
			return false;
		}

		public static bool ValidateShortString(string shortString, bool canBeEmpty)
		{
			return false;
		}

		public static bool ValidateString(string s, bool canBeEmpty)
		{
			return false;
		}

		public static bool ValidateLongString(string longString, bool canBeEmpty)
		{
			return false;
		}

		public static bool ValidateConnectionType(string connectionType)
		{
			return false;
		}

		public static bool ValidateCustomDimensions(params string[] customDimensions)
		{
			return false;
		}

		public static bool ValidateResourceCurrencies(params string[] resourceCurrencies)
		{
			return false;
		}

		public static bool ValidateResourceItemTypes(params string[] resourceItemTypes)
		{
			return false;
		}

		public static bool ValidateDimension01(string dimension01)
		{
			return false;
		}

		public static bool ValidateDimension02(string dimension02)
		{
			return false;
		}

		public static bool ValidateDimension03(string dimension03)
		{
			return false;
		}

		public static bool ValidateArrayOfStrings(long maxCount, long maxStringLength, bool allowNoValues, string logTag, params string[] arrayOfStrings)
		{
			return false;
		}

		public static bool ValidateClientTs(long clientTs)
		{
			return false;
		}
	}
}
