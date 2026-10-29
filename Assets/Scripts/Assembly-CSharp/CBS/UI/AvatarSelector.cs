using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class AvatarSelector : MonoBehaviour
	{
		[SerializeField]
		private AvatarListScroller Scroller;

		private IProfile Profile { get; set; }

		private ProfilePrefabs Prefabs { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void LoadAvatars()
		{
		}

		private void DisplayAvatars(AvatarsTableWithStates table)
		{
		}

		private void OnGetAvatars(CBSGetProfileAvatarTableWithStatesResult result)
		{
		}

		private void SelectRequest(CBSAvatarState avatar)
		{
		}

		private void BuyRequest(CBSAvatarState avatar)
		{
		}
	}
}
