using System;
using System.Collections.Generic;
using FunGames.Tools.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FunGames.Core.QAMode
{
	internal class FGQAModeRCVariableView : MonoBehaviour
	{
		public Action<string, bool> ToggleValueChanged;

		[SerializeField]
		private TextMeshProUGUI titleText;

		[SerializeField]
		private TextMeshProUGUI subtitleText;

		[SerializeField]
		private Toggle toggle;

		[SerializeField]
		private Button foldoutButton;

		[SerializeField]
		private RectTransform paramViewsContainer;

		[SerializeField]
		private GameObject runningIndicator;

		public Action HeightChanged;

		private const float VIEWS_SPACING = 30f;

		private const float BOTTOM_PADDING = 30f;

		private readonly List<FGQAModeRCParamView> _paramViews;

		private string _id;

		private bool _isExpanded;

		private bool _isOn;

		private bool _ignoreToggleValueChange;

		private FGQAModeRCParamView _paramViewPrefab;

		private List<KeyValuePair<string, string>> _rcVariableParams;

		private RectTransform _rectTransform;

		private void Awake()
		{
		}

		private void OnToggleValueChanged(bool newValue)
		{
		}

		public void SetData(string id, JSONNode rcVariable, FGQAModeRCParamView paramViewPrefab)
		{
		}

		public void SetIsOn(bool isOn)
		{
		}

		private void UpdateView()
		{
		}

		public float GetCurrentVisibleHeight()
		{
			return 0f;
		}

		public float CalculateFoldoutHeight()
		{
			return 0f;
		}

		private void ToggleFoldout()
		{
		}

		private void OnHeightAnimationStep()
		{
		}

		private List<KeyValuePair<string, string>> GetParams(JSONNode rcVariable)
		{
			return null;
		}
	}
}
