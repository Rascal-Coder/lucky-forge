using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class UpdateAvatarUrlForm : MonoBehaviour
	{
		[SerializeField]
		private InputField URLInput;

		private IProfile Profile { get; set; }

		private void Start()
		{
		}

		private void CleanInput()
		{
		}

		public void UploadUrl()
		{
		}

		private void OnUpdateAvatar(CBSUpdateAvatarUrlResult result)
		{
		}
	}
}
