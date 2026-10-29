using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GameAnalyticsSDK.Events;
using GameAnalyticsSDK.Setup;
using UnityEngine;

namespace GameAnalyticsSDK
{
	[RequireComponent(typeof(GA_SpecialEvents))]
	[ExecuteInEditMode]
	public class GameAnalytics : MonoBehaviour
	{
		private static Settings _settings;

		private static GameAnalytics _instance;

		private static bool _hasInitializeBeenCalled;

		[CompilerGenerated]
		private static EventHandler<bool> m_onInitialize;

		[CompilerGenerated]
		private static Action m_OnRemoteConfigsUpdatedEvent;

		public static Settings SettingsGA
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public static bool Initialized => false;

		public static event EventHandler<bool> onInitialize
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action OnRemoteConfigsUpdatedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnApplicationQuit()
		{
		}

		private static void InitAPI()
		{
		}

		private static void InternalInitialize()
		{
		}

		public static void Initialize()
		{
		}

		public static void NewBusinessEvent(string currency, int amount, string itemType, string itemId, string cartType)
		{
		}

		public static void NewBusinessEvent(string currency, int amount, string itemType, string itemId, string cartType, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewBusinessEventGooglePlay(string currency, int amount, string itemType, string itemId, string cartType, string receipt, string signature)
		{
		}

		public static void NewBusinessEventGooglePlay(string currency, int amount, string itemType, string itemId, string cartType, string receipt, string signature, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewDesignEvent(string eventName)
		{
		}

		public static void NewDesignEvent(string eventName, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewDesignEvent(string eventName, float eventValue)
		{
		}

		public static void NewDesignEvent(string eventName, float eventValue, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, int score)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, int score, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, int score)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, int score, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, int score)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, int score, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewResourceEvent(GAResourceFlowType flowType, string currency, float amount, string itemType, string itemId)
		{
		}

		public static void NewResourceEvent(GAResourceFlowType flowType, string currency, float amount, string itemType, string itemId, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewErrorEvent(GAErrorSeverity severity, string message)
		{
		}

		public static void NewErrorEvent(GAErrorSeverity severity, string message, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, long duration)
		{
		}

		public static void NewAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, long duration, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, GAAdError noAdReason)
		{
		}

		public static void NewAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, GAAdError noAdReason, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement)
		{
		}

		public static void NewAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void SetCustomId(string userId)
		{
		}

		public static string GetUserId()
		{
			return null;
		}

		public static string GetExternalUserId()
		{
			return null;
		}

		public static void SetExternalUserId(string externalUserId)
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

		public static void StartSession()
		{
		}

		public static void EndSession()
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

		public void OnRemoteConfigsUpdated()
		{
		}

		public static void RemoteConfigsUpdated()
		{
		}

		public static string GetRemoteConfigsValueAsString(string key)
		{
			return null;
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

		public static void RequestTrackingAuthorization(IGameAnalyticsATTListener listener)
		{
		}

		public static void EnableAdvertisingIdTracking(bool flag)
		{
		}

		private static string GetUnityVersion()
		{
			return null;
		}

		private static int GetPlatformIndex()
		{
			return 0;
		}

		public static void SetBuildAllPlatforms(string build)
		{
		}
	}
}
