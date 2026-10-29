using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FunGames.Core.QAMode
{
	internal class FGQAModeAdsToggle : MonoBehaviour
	{
		public Action<bool> ValueChanged;

		[SerializeField]
		private GameObject adsOffImage;

		[SerializeField]
		private GameObject adsOnImage;

		[SerializeField]
		private Button adsToggleButton;

		[SerializeField]
		private TextMeshProUGUI adsText;

		[SerializeField]
		private Color adsOffTextColor;

		[SerializeField]
		private Color adsOnTextColor;

		[Tooltip("Whether this toggle should read and write its state directly to PlayerPrefs")]
		[SerializeField]
		private bool readWritePlayerPrefs;

		private bool _inMemoryIsOn;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		public void ToggleAds()
		{
		}

		private void UpdateView()
		{
		}

		public bool GetState()
		{
			return false;
		}

		public void SetState(bool isOn)
		{
		}
	}
}
