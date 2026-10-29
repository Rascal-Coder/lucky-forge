using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class ChatTagDrawer : MonoBehaviour
	{
		[SerializeField]
		private Text DisplayNameLabel;

		private readonly float WidthOfset;

		private LayoutElement DrawerLayout { get; set; }

		public string TagProfileID { get; private set; }

		private void Awake()
		{
		}

		public void DrawTag(ChatMember chatMember)
		{
		}

		private void OnDisable()
		{
		}
	}
}
