using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class FriendsWindow : MonoBehaviour
	{
		[SerializeField]
		private BaseFriendsTab[] AllTabes;

		[SerializeField]
		private FriendsSection[] AllView;

		private FriendsTabTitle CurrentTab { get; set; }

		private ProfileConfigData ProfileConfig { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnTabSelected(string title)
		{
		}

		private void DisplayView(FriendsTabTitle title)
		{
		}

		private void OnChatSelected(string userID)
		{
		}
	}
}
