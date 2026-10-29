using System;
using FunGames.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace FunGames.Core.QAMode
{
	internal class FGQAModeFloatingMenu : MonoBehaviour
	{
		public Action RequestReturnToHomeScreen;

		[SerializeField]
		private UIDrag expandCollapseHandle;

		[SerializeField]
		private UIDrag adsHandle;

		[SerializeField]
		private UIDrag logsHandle;

		[SerializeField]
		private UIDrag debugHandle;

		[SerializeField]
		private UIDrag customMenuHandle;

		[SerializeField]
		private UIDrag pausePlayHandle;

		[SerializeField]
		private UIDrag homeHandle;

		[SerializeField]
		private UIDrag bgHandle;

		[SerializeField]
		private FGQAModeAdsToggle adsToggle;

		[SerializeField]
		private Sprite menuOpenedSprite;

		[SerializeField]
		private Sprite menuCollapsedSprite;

		[SerializeField]
		private Sprite playSprite;

		[SerializeField]
		private Sprite pauseSprite;

		[SerializeField]
		private Color disabledItemColor;

		[SerializeField]
		private FGDebugConsoleBuilder debugConsoleBuilder;

		private const int ButtonsCount = 7;

		private bool _isExpanded;

		private float _gameTimeScale;

		private FGDebugConsoleBuilder _debugConsoleBuilderCached;

		private VerticalLayoutGroup _verticalLayoutGroup;

		private bool _isPaused;

		private void Awake()
		{
		}

		public void SetVisible(bool visible)
		{
		}

		private void ExpandCollapse()
		{
		}

		private void ToggleAds(bool isOn)
		{
		}

		private void ToggleDebugConsole()
		{
		}

		private void ToggleCustomMenu()
		{
		}

		private void TogglePausePlay()
		{
		}

		private void OnHomeClicked()
		{
		}

		private void UpdateViews()
		{
		}

		private void KeepWithinBoundary()
		{
		}
	}
}
