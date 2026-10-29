using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameAnalyticsSDK.Setup
{
	public class Settings : ScriptableObject
	{
		public enum HelpTypes
		{
			None = 0,
			IncludeSystemSpecsHelp = 1,
			ProvideCustomUserID = 2
		}

		public enum MessageTypes
		{
			None = 0,
			Error = 1,
			Info = 2,
			Warning = 3
		}

		public struct HelpInfo
		{
			public string Message;

			public MessageTypes MsgType;

			public HelpTypes HelpType;
		}

		public enum InspectorStates
		{
			Account = 0,
			Basic = 1,
			Debugging = 2,
			Pref = 3
		}

		[HideInInspector]
		public static string VERSION;

		[HideInInspector]
		public static bool CheckingForUpdates;

		public int TotalMessagesSubmitted;

		public int TotalMessagesFailed;

		public int DesignMessagesSubmitted;

		public int DesignMessagesFailed;

		public int QualityMessagesSubmitted;

		public int QualityMessagesFailed;

		public int ErrorMessagesSubmitted;

		public int ErrorMessagesFailed;

		public int BusinessMessagesSubmitted;

		public int BusinessMessagesFailed;

		public int UserMessagesSubmitted;

		public int UserMessagesFailed;

		public string CustomArea;

		[SerializeField]
		private List<string> gameKey;

		[SerializeField]
		private List<string> secretKey;

		[SerializeField]
		public List<string> Build;

		[SerializeField]
		public List<string> SelectedPlatformOrganization;

		[SerializeField]
		public List<string> SelectedPlatformStudio;

		[SerializeField]
		public List<string> SelectedPlatformGame;

		[SerializeField]
		public List<int> SelectedPlatformGameID;

		[SerializeField]
		public List<int> SelectedOrganization;

		[SerializeField]
		public List<int> SelectedStudio;

		[SerializeField]
		public List<int> SelectedGame;

		public string NewVersion;

		public string Changes;

		public bool SignUpOpen;

		public string StudioName;

		public string GameName;

		public string OrganizationName;

		public string OrganizationIdentifier;

		public string EmailGA;

		[NonSerialized]
		public string PasswordGA;

		[NonSerialized]
		public string TokenGA;

		[NonSerialized]
		public string ExpireTime;

		[NonSerialized]
		public string LoginStatus;

		[NonSerialized]
		public bool JustSignedUp;

		[NonSerialized]
		public bool HideSignupWarning;

		public bool IntroScreen;

		[NonSerialized]
		public List<Organization> Organizations;

		public bool InfoLogEditor;

		public bool InfoLogBuild;

		public bool VerboseLogBuild;

		public bool UseManualSessionHandling;

		public bool SendExampleGameDataToMyGame;

		public bool InternetConnectivity;

		public List<string> CustomDimensions01;

		public List<string> CustomDimensions02;

		public List<string> CustomDimensions03;

		public List<string> ResourceItemTypes;

		public List<string> ResourceCurrencies;

		public RuntimePlatform LastCreatedGamePlatform;

		public List<RuntimePlatform> Platforms;

		public InspectorStates CurrentInspectorState;

		public List<HelpTypes> ClosedHints;

		public bool DisplayHints;

		public Vector2 DisplayHintsScrollState;

		public Texture2D Logo;

		public Texture2D UpdateIcon;

		public Texture2D InfoIcon;

		public Texture2D DeleteIcon;

		public Texture2D GameIcon;

		public Texture2D HomeIcon;

		public Texture2D InstrumentIcon;

		public Texture2D QuestionIcon;

		public Texture2D UserIcon;

		public Texture2D AmazonIcon;

		public Texture2D GooglePlayIcon;

		public Texture2D iosIcon;

		public Texture2D macIcon;

		public Texture2D windowsPhoneIcon;

		[NonSerialized]
		public GUIStyle SignupButton;

		public bool UsePlayerSettingsBuildNumber;

		public bool SubmitErrors;

		public bool NativeErrorReporting;

		public int MaxErrorCount;

		public bool SubmitFpsAverage;

		public bool SubmitFpsCritical;

		public bool IncludeGooglePlay;

		public int FpsCriticalThreshold;

		public int FpsCirticalSubmitInterval;

		public List<bool> PlatformFoldOut;

		public bool CustomDimensions01FoldOut;

		public bool CustomDimensions02FoldOut;

		public bool CustomDimensions03FoldOut;

		public bool ResourceItemTypesFoldOut;

		public bool ResourceCurrenciesFoldOut;

		public bool EnableMemoryHistogram;

		public bool EnableHealthEvent;

		public bool EnableFPSHistogram;

		public bool EnableSDKInitEvent;

		public bool EnableHardwareTracking;

		public bool EnableMemoryTracking;

		public static readonly RuntimePlatform[] AvailablePlatforms;

		public void SetCustomUserID(string customID)
		{
		}

		public void RemovePlatformAtIndex(int index)
		{
		}

		public void AddPlatform(RuntimePlatform platform)
		{
		}

		public string[] GetAvailablePlatforms()
		{
			return null;
		}

		public bool IsGameKeyValid(int index, string value)
		{
			return false;
		}

		public bool IsSecretKeyValid(int index, string value)
		{
			return false;
		}

		public static void UpdateKeys(int index, string gameKey, string secretKey)
		{
		}

		public void UpdateGameKey(int index, string value)
		{
		}

		public void UpdateSecretKey(int index, string value)
		{
		}

		public string GetGameKey(int index)
		{
			return null;
		}

		public string GetSecretKey(int index)
		{
			return null;
		}

		public void SetCustomArea(string customArea)
		{
		}

		public void SetKeys(string gamekey, string secretkey)
		{
		}
	}
}
