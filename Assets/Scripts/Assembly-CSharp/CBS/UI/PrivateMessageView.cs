using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class PrivateMessageView : MonoBehaviour
	{
		[SerializeField]
		private ChatView ChatView;

		private ICBSChat cbsChat;

		private ICBSChat CBSChat => null;

		private ChatPrefabs prefabs { get; set; }

		protected ChatPrefabs Prefabs => null;

		private string UserID { get; set; }

		private void OnDisable()
		{
		}

		public void Setup(string userID)
		{
		}
	}
}
