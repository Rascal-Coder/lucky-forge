using System;
using System.Text;
using CBS.Models;
using UnityEngine;

namespace CBS.Utils
{
	public static class ChatUtils
	{
		public const int DefaultBanHours = 3;

		public const string DefaultBanReason = "Chat rule violation";

		public const string SystemMessageTitle = "System";

		public const string DeletedMessageText = "This message has been deleted";

		private static readonly string DateFormat;

		public const string ClaimItemTitle = "Success";

		public static string MarkNickName(string inputName)
		{
			return null;
		}

		public static string MarkAsItalic(string inputText)
		{
			return null;
		}

		public static string MarkDate(DateTime date)
		{
			return null;
		}

		public static StringBuilder MarkNickName(StringBuilder sBuilder, string inputName)
		{
			return null;
		}

		public static string AddColorTag(Color color, string inputText)
		{
			return null;
		}

		public static StringBuilder AddColorTag(StringBuilder sBuilder, Color color)
		{
			return null;
		}

		public static string MarkAsMine(string inputText)
		{
			return null;
		}

		public static Color GetMineBubbleColor()
		{
			return default;
		}

		public static void ShowSimpleChat(ChatInstance chat)
		{
		}

		public static ChatSticker GetSticker(this ChatMessage message)
		{
			return null;
		}

		public static CBSInventoryItem GetItem(this ChatMessage message)
		{
			return null;
		}
	}
}
