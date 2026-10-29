using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "ChatPrefabs", menuName = "CBS/Add new Chat Prefabs")]
	public class ChatPrefabs : CBSScriptable
	{
		public GameObject ChatWindow;

		public GameObject SimpleChatMessage;

		public GameObject BubbleChatMessage;

		public GameObject ClanChatMessage;

		public GameObject SimpleChatView;

		public GameObject StickerSlot;

		public GameObject ItemSlot;

		public GameObject DialogSlot;

		public override string ResourcePath => null;
	}
}
