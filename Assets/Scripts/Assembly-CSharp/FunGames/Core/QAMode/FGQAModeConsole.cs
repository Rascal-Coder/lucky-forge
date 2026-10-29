using System;
using IngameDebugConsole;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FunGames.Core.QAMode
{
	public class FGQAModeConsole : MonoBehaviour
	{
		[Header("Screens & Menus")]
		[SerializeField]
		private FGQAPasskeyScreen passkeyScreen;

		[SerializeField]
		private FGQAManualConfigScreen manualConfigScreen;

		[SerializeField]
		private FGQAModeFloatingMenu floatingMenu;

		[SerializeField]
		private GameObject screensContainer;

		[SerializeField]
		private GameObject titleBar;

		[Header("Loading popup")]
		[SerializeField]
		private GameObject loadingPopup;

		[SerializeField]
		private TextMeshProUGUI loadingText;

		[Header("Error popup")]
		[SerializeField]
		private GameObject errorPopup;

		[SerializeField]
		private TextMeshProUGUI errorMessageText;

		[SerializeField]
		private Button errorPopupButton;

		[Header("Other views")]
		[SerializeField]
		private Button shareLogsButton;

		[SerializeField]
		private DebugLogManager debugLogManager;

		private static FGQAModeConsole _instance;

		private Action _errorPopupButtonAction;

		private FGQAScreenAbstract[] _screens;

		private float _gameTimeScale;

		public const string FG_QA_APP_ID = "com.fungames.qa";

		public const string FG_QA_APP_SCHEME = "fgqaapp";

		private DebugLogManager _debugLogManagerCached;

		private string SharedLogFilePath => null;

		public static bool IsInQAMode => false;

		public static bool ShouldStartQAMode => false;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public static string GetRCVariablesSetting()
		{
			return null;
		}

		private void OnShareLogsClick()
		{
		}

		private void SetupViews()
		{
		}

		private void SetVisibleScreen(FGQAScreenAbstract screen)
		{
		}

		private void OnRequestLoadingScreen(bool visible, string message)
		{
		}

		private void ShowErrorPopup(string message, string ctaText, Action ctaAction)
		{
		}

		private void OnPasskeyVerifySucceeded()
		{
		}

		private void OnModeConfigCompleted()
		{
		}

		private void OnModeConfigCancelled()
		{
		}

		private void OnClickErrorPopupButton()
		{
		}

		private void ReturnToHomeScreen()
		{
		}
	}
}
