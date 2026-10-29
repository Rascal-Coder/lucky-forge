using System;
using Firebase;
using UnityEngine;

public class FGFirebaseCustomAdImpression : MonoBehaviour
{
	private Action<string, FGAdInfo> _interImpressionCallback;

	private Action<string, FGAdInfo> _bannerImpressionCallback;

	private Action<string, FGAdInfo> _rewardedImpressionCallback;

	private Action<string, FGAdInfo> _crosspromoImpressionCallback;

	private Action<string, FGAdInfo> _mrecImpressionCallback;

	private bool _isInit;

	private void Awake()
	{
	}

	private void DependencyCheckCompleted(DependencyStatus status)
	{
	}

	private void SendCustomAdImpressionEvent(string format, FGAdInfo adInfo)
	{
	}
}
