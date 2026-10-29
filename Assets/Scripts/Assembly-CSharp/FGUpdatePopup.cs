using UnityEngine;
using UnityEngine.UI;

public class FGUpdatePopup : MonoBehaviour
{
	public GameObject popUp;

	public Button UpdateAppButton;

	public Button CloseButton;

	private const string RC_UPDATE_POPUP_ACTIVATED = "FGVersionToBeUpdated";

	private const string RC_UPDATE_POPUP_CLOSABLE = "FGUpdatePopupClosable";

	private void Awake()
	{
	}

	private void ActivatePopup()
	{
	}

	private void GoToStore()
	{
	}

	private void Close()
	{
	}

	private bool IsAppUpToDate()
	{
		return false;
	}
}
