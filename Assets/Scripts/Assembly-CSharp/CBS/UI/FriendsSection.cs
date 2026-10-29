using System;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public abstract class FriendsSection : MonoBehaviour
	{
		private IFriends friends { get; set; }

		protected IFriends Friends => null;

		private ICBSChat chats { get; set; }

		protected ICBSChat Chats => null;

		private FriendsPrefabs prefabs { get; set; }

		protected FriendsPrefabs Prefabs => null;

		protected Action<string> SelectChatAction { get; set; }

		public abstract FriendsTabTitle TabTitle { get; }

		public abstract void Display();

		public abstract void Clean();

		public void Hide()
		{
		}

		public void SetChatAction(Action<string> action)
		{
		}
	}
}
