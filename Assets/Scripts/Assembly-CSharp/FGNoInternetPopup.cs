using UnityEngine;
using UnityEngine.UI;

public class FGNoInternetPopup : MonoBehaviour
{
	public GameObject popUp;

	public Button TryConnectionButton;

	private bool _hasInternetConnection;

	private float _timeCounter;

	private bool _noInternetPopupActivated;

	private double _checkInternetDelayWhenConnected;

	private double _checkInternetDelayWhenNotConnected;

	private bool _buttonClicked;

	private const string RC_NO_INTERNET_POPUP_ACTIVATED = "FGNoInternetPopup";

	private const string RC_CHECK_INTERNET_DELAY_WHEN_CONNECTED = "CheckInternetDelayWhenConnected";

	private const string RC_CHECK_INTERNET_DELAY_WHEN_NOT_CONNECTED = "CheckInternetDelayWhenNotConnected";

	public bool HasInternetConnection => false;

	private void Awake()
	{
	}

	private void FixedUpdate()
	{
	}

	public void Show()
	{
	}

	private void Hide()
	{
	}

	private void CheckConnectionManually()
	{
	}

	private void CheckConnection()
	{
	}

	private void UpdateRemoteConfigValues(bool obj)
	{
	}
}
