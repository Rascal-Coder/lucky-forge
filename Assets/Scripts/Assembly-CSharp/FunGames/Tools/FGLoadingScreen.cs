using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FunGames.Tools
{
	public class FGLoadingScreen : MonoBehaviour
	{
		public Image ProgressBar;

		public LoadedAction ActionWhenLoaded;

		public float MaxLoadingTime;

		public ProgressMode ProgressMode;

		private IEnumerator _checkInitCoroutine;

		private bool _useCheckInit;

		private float _initCounter;

		private Action<bool> _onSdkInitialized;

		private Action<FGAdInfo> _enableCheckInitDelegate;

		private Action _appOpenFailedToLoad;

		private float _timer;

		private float _totalTime;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void UpdateProgress()
		{
		}

		private void CloseLoadingScreen()
		{
		}

		private void CheckInitialization()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDisable()
		{
		}

		private void Dispose()
		{
		}
	}
}
