using System.Collections.Generic;
using UnityEngine;

namespace GameAnalyticsSDK.Wrapper
{
	public class GA_Wrapper
	{
		private static readonly AndroidJavaClass GA;

		private static readonly AndroidJavaClass UNITY_GA;

		private static void configureAvailableCustomDimensions01(string list)
		{
		}

		private static void configureAvailableCustomDimensions02(string list)
		{
		}

		private static void configureAvailableCustomDimensions03(string list)
		{
		}

		private static void configureAvailableResourceCurrencies(string list)
		{
		}

		private static void configureAvailableResourceItemTypes(string list)
		{
		}

		private static void configureSdkGameEngineVersion(string unitySdkVersion)
		{
		}

		private static void configureGameEngineVersion(string unityEngineVersion)
		{
		}

		private static void configureBuild(string build)
		{
		}

		private static void configureUserId(string userId)
		{
		}

		private static void configureAutoDetectAppVersion(bool flag)
		{
		}

		private static void initialize(string gamekey, string gamesecret)
		{
		}

		private static void setCustomDimension01(string customDimension)
		{
		}

		private static void setCustomDimension02(string customDimension)
		{
		}

		private static void setCustomDimension03(string customDimension)
		{
		}

		private static void setGlobalCustomEventFields(string customFields)
		{
		}

		private static void addBusinessEvent(string currency, int amount, string itemType, string itemId, string cartType, string fields, bool mergeFields)
		{
		}

		private static void addBusinessEventWithReceipt(string currency, int amount, string itemType, string itemId, string cartType, string receipt, string store, string signature, string fields, bool mergeFields)
		{
		}

		private static void addResourceEvent(int flowType, string currency, float amount, string itemType, string itemId, string fields, bool mergeFields)
		{
		}

		private static void addProgressionEvent(int progressionStatus, string progression01, string progression02, string progression03, string fields, bool mergeFields)
		{
		}

		private static void addProgressionEventWithScore(int progressionStatus, string progression01, string progression02, string progression03, int score, string fields, bool mergeFields)
		{
		}

		private static void addDesignEvent(string eventId, string fields, bool mergeFields)
		{
		}

		private static void addDesignEventWithValue(string eventId, float value, string fields, bool mergeFields)
		{
		}

		private static void addErrorEvent(int severity, string message, string fields, bool mergeFields)
		{
		}

		private static void addAdEventWithDuration(int adAction, int adType, string adSdkName, string adPlacement, long duration, string fields, bool mergeFields)
		{
		}

		private static void addAdEventWithReason(int adAction, int adType, string adSdkName, string adPlacement, int noAdReason, string fields, bool mergeFields)
		{
		}

		private static void addAdEvent(int adAction, int adType, string adSdkName, string adPlacement, string fields, bool mergeFields)
		{
		}

		private static void setEnabledInfoLog(bool enabled)
		{
		}

		private static void setEnabledVerboseLog(bool enabled)
		{
		}

		private static void setManualSessionHandling(bool enabled)
		{
		}

		private static void setEventSubmission(bool enabled)
		{
		}

		private static void setEventSubmission(bool enabled, bool doCacheLocally)
		{
		}

		private static void gameAnalyticsStartSession()
		{
		}

		private static void gameAnalyticsEndSession()
		{
		}

		private static string getRemoteConfigsValueAsString(string key, string defaultValue)
		{
			return null;
		}

		private static bool isRemoteConfigsReady()
		{
			return false;
		}

		private static string getRemoteConfigsContentAsString()
		{
			return null;
		}

		private static string getABTestingId()
		{
			return null;
		}

		private static string getABTestingVariantId()
		{
			return null;
		}

		private static string getExternalUserId()
		{
			return null;
		}

		private static void configureExternalUserId(string externalUserId)
		{
		}

		private static void startTimer(string key)
		{
		}

		private static void pauseTimer(string key)
		{
		}

		private static void resumeTimer(string key)
		{
		}

		private static long stopTimer(string key)
		{
			return 0L;
		}

		public static string getUserId()
		{
			return null;
		}

		public static void enableGAIDTracking(bool flag)
		{
		}

		public static void enableSDKInitEvent(bool flag)
		{
		}

		public static void enableFpsHistogram(bool flag)
		{
		}

		public static void enableMemoryHistogram(bool flag)
		{
		}

		public static void enableHealthHardwareInfo(bool flag)
		{
		}

		public static void SetAvailableCustomDimensions01(string list)
		{
		}

		public static void SetAvailableCustomDimensions02(string list)
		{
		}

		public static void SetAvailableCustomDimensions03(string list)
		{
		}

		public static void SetAvailableResourceCurrencies(string list)
		{
		}

		public static void SetAvailableResourceItemTypes(string list)
		{
		}

		public static void SetUnitySdkVersion(string unitySdkVersion)
		{
		}

		public static void SetUnityEngineVersion(string unityEngineVersion)
		{
		}

		public static void SetBuild(string build)
		{
		}

		public static void SetCustomUserId(string userId)
		{
		}

		public static void SetEnabledManualSessionHandling(bool enabled)
		{
		}

		public static void SetEnabledEventSubmission(bool enabled)
		{
		}

		public static void SetEnabledEventSubmission(bool enabled, bool doCache)
		{
		}

		public static void SetAutoDetectAppVersion(bool flag)
		{
		}

		public static void StartSession()
		{
		}

		public static void EndSession()
		{
		}

		public static void Initialize(string gamekey, string gamesecret)
		{
		}

		public static void SetCustomDimension01(string customDimension)
		{
		}

		public static void SetCustomDimension02(string customDimension)
		{
		}

		public static void SetCustomDimension03(string customDimension)
		{
		}

		public static void SetGlobalCustomEventFields(IDictionary<string, object> customFields)
		{
		}

		public static void AddBusinessEventWithReceipt(string currency, int amount, string itemType, string itemId, string cartType, string receipt, string store, string signature, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddBusinessEvent(string currency, int amount, string itemType, string itemId, string cartType, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddResourceEvent(GAResourceFlowType flowType, string currency, float amount, string itemType, string itemId, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddProgressionEventWithScore(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, int score, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddDesignEvent(string eventID, float eventValue, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddDesignEvent(string eventID, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddErrorEvent(GAErrorSeverity severity, string message, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddAdEventWithDuration(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, long duration, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddAdEventWithReason(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, GAAdError noAdReason, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void SetInfoLog(bool enabled)
		{
		}

		public static void SetVerboseLog(bool enabled)
		{
		}

		public static string GetRemoteConfigsValueAsString(string key, string defaultValue)
		{
			return null;
		}

		public static bool IsRemoteConfigsReady()
		{
			return false;
		}

		public static string GetRemoteConfigsContentAsString()
		{
			return null;
		}

		public static string GetRemoteConfigsContentAsJSON()
		{
			return null;
		}

		public static string GetABTestingId()
		{
			return null;
		}

		public static string GetABTestingVariantId()
		{
			return null;
		}

		public static void SetExternalUserId(string userId)
		{
		}

		public static string GetExternalUserId()
		{
			return null;
		}

		private static string DictionaryToJsonString(IDictionary<string, object> dict)
		{
			return null;
		}

		public static void StartTimer(string key)
		{
		}

		public static void PauseTimer(string key)
		{
		}

		public static void ResumeTimer(string key)
		{
		}

		public static long StopTimer(string key)
		{
			return 0L;
		}

		public static void EnableSDKInitEvent(bool flag)
		{
		}

		public static void EnableFpsHistogram(bool flag)
		{
		}

		public static void EnableMemoryHistogram(bool flag)
		{
		}

		public static void EnableHealthHardwareInfo(bool flag)
		{
		}
	}
}
