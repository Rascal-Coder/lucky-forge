using UnityEngine;

namespace CBS.UI
{
	public class ProfileWindows : MonoBehaviour
	{
		[SerializeField]
		private ProfileTab[] AllTabes;

		[SerializeField]
		private GameObject Info;

		[SerializeField]
		private GameObject Avatar;

		private ProfileSection Section { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void DisplayView(ProfileSection title)
		{
		}

		private void OnTabSelected(string title)
		{
		}

		public void CloseWindow()
		{
		}
	}
}
