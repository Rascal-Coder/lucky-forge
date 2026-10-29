using System;
using System.Collections.Generic;
using FunGames.Tools.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FunGames.Core.QAMode
{
	internal class FGQAManualConfigScreen : FGQAScreenAbstract
	{
		public Action ModeConfigCompleted;

		public Action ModeConfigCancelled;

		[SerializeField]
		private Button liveButton;

		[SerializeField]
		private Button clearAllButton;

		[SerializeField]
		private Button debugButton;

		[SerializeField]
		private Button submitButton;

		[SerializeField]
		private Button cancelButton;

		[SerializeField]
		private GameObject liveIndicator;

		[SerializeField]
		private TextMeshProUGUI selectionCountText;

		[SerializeField]
		private FGQAModeAdsToggle adsToggle;

		[SerializeField]
		private FGQAModeVariablesSectionHeader configsSectionHeader;

		[SerializeField]
		private FGQAModeVariablesSectionHeader abTestsSectionHeader;

		[SerializeField]
		private FGQAModeGroupedRCVariablesView groupVariablesViewPrefab;

		[SerializeField]
		private RectTransform restartInfoView;

		[SerializeField]
		private RectTransform scrollViewContent;

		[SerializeField]
		private RectTransform bottomControls;

		[SerializeField]
		private VerticalLayoutGroup abTestViewsParent;

		[SerializeField]
		private VerticalLayoutGroup groupedConfigViewsParent;

		[SerializeField]
		private FGDebugConsoleBuilder debugConsoleBuilder;

		private const float BASELINE_DPI = 160f;

		private readonly FGQAManualConfigController _controller;

		private readonly List<FGQAModeGroupedRCVariablesView> _abTestViews;

		private readonly List<FGQAModeGroupedRCVariablesView> _groupedConfigViews;

		private SortedDictionary<string, List<JSONNode>> ABTests => null;

		private SortedDictionary<string, List<JSONNode>> GroupedConfigs => null;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void ToggleAds(bool isOn)
		{
		}

		private void UpdateUI()
		{
		}

		private void UpdateBottomControlsPosition()
		{
		}

		private void UpdateSelectionCountView()
		{
		}

		private void OnCohortToggleChanged(string id, bool value)
		{
		}

		private void OnConfigToggleChanged(string id, bool value)
		{
		}

		private void OnClickClearButton()
		{
		}

		private void OnClickLiveButton()
		{
		}

		private void OnClickSubmit()
		{
		}

		private void OnSectionHeaderFoldoutToggled(string sectionType)
		{
		}

		private void OnChildHeightChanged(string variableType)
		{
		}

		private float CalculateSectionHeight(string sectionType)
		{
			return 0f;
		}

		private void RebuildLayouts(bool rebuildAbTests = true, bool rebuildConfigs = true)
		{
		}

		private void LoadCachedData()
		{
		}
	}
}
