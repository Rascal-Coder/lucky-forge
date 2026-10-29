using CBS.Models;
using CBS.Scriptable;
using CBS.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class ProfileIcon : MonoBehaviour
	{
		[SerializeField]
		private Text NickNameLabel;

		[SerializeField]
		private Text LevelLabel;

		[SerializeField]
		private Text ExpLabel;

		[SerializeField]
		private Slider ExpSlider;

		[SerializeField]
		private AvatarDrawer Avatar;

		private IProfile CBSProfile { get; set; }

		private ProfilePrefabs Prefabs { get; set; }

		private AuthData AuthData { get; set; }

		private ProfileConfigData ProfileConfig { get; set; }

		private AvatarDisplayOptions DisplayOption { get; set; }

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void DisplayName()
		{
		}

		private void DrawAvatar()
		{
		}

		private void DisplayLevelData()
		{
		}

		public void ShowAccountInfo()
		{
		}

		private void OnPlayerExperienceUpdated(CBSLevelDataResult result)
		{
		}

		private void OnDisplayNameUpdated(CBSUpdateDisplayNameResult result)
		{
		}

		private void OnAccountInfoGetted(CBSGetAccountInfoResult result)
		{
		}

		private void OnGetLevelData(CBSLevelDataResult result)
		{
		}

		private void OnAvatarImageUpdated(AvatarInfo obj)
		{
		}
	}
}
