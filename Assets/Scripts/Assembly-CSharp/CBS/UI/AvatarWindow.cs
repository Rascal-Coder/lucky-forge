using CBS.Scriptable;
using CBS.Utils;
using UnityEngine;

namespace CBS.UI
{
	public class AvatarWindow : MonoBehaviour
	{
		[SerializeField]
		private GameObject UrlUploadForm;

		[SerializeField]
		private GameObject AvatarSelectForm;

		private ProfileConfigData ProfileConfig { get; set; }

		private AvatarDisplayOptions DisplayOption { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void ShowAvatarForm()
		{
		}
	}
}
