using System;
using System.Collections.Generic;
using FunGames.Tools.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FunGames.Core.QAMode
{
	internal class FGQAModeGroupedRCVariablesView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI nameText;

		[SerializeField]
		private RectTransform itemViewsParent;

		[SerializeField]
		private FGQAModeRCVariableView rcVariableViewPrefab;

		[SerializeField]
		private FGQAModeRCParamView paramViewPrefab;

		[SerializeField]
		private Button foldoutButton;

		[SerializeField]
		private RectTransform collapsedHeightReference;

		public Action<string, bool> VariableToggleChanged;

		public Action HeightChanged;

		private Func<string, bool> _isVariableOn;

		private bool _isExpanded;

		private RectTransform _rectTransform;

		private readonly List<FGQAModeRCVariableView> _itemViews;

		private void Awake()
		{
		}

		public void Setup(Func<string, bool> isVariableOn)
		{
		}

		public void UpdateView(string title, List<JSONNode> variables)
		{
		}

		private void OnVariableToggleChanged(string id, bool isOn)
		{
		}

		private void RebuildLayouts()
		{
		}

		private void ToggleFoldout()
		{
		}

		private void UpdateHeight()
		{
		}

		public float GetCurrentVisibleHeight()
		{
			return 0f;
		}

		private float CalculateFoldoutHeight()
		{
			return 0f;
		}

		private void OnHeightAnimationStep()
		{
		}
	}
}
