using System.Collections.Generic;

namespace CBS.Models
{
	public class ChatConfigData
	{
		public const int MAX_HISTORY_LENGTH = 1000;

		public static readonly int MaxMessageLength;

		public static readonly int DefaultMessageLength;

		public static readonly int DefaultMessageTTL;

		public static readonly int DefaultAutoBanSeconds;

		public static readonly int DefaultDontRemoveCount;

		public static string DefaultCensorChar;

		public static string DefaultBanNotificationTemplate;

		public static readonly string DefaultAutoBanReason;

		public static string SystemBanNotificationTemplate;

		public int MaxCharCountPerMessage;

		public List<ChatSticker> Stiсkers;

		public CBSTTL GeneralChatTTL;

		public int? GeneralChatSecondsTTL;

		public int? GeneralChatDontRemoveCount;

		public CBSTTL PrivateChatTTL;

		public int? PrivateChatSecondsTTL;

		public int? PrivateChatDontRemoveCount;

		public bool AutomaticModeration;

		public List<string> AdditionalBadWorldList;

		public string CensorChar;

		public bool AutoBan;

		public int AutoBanSeconds;

		public string AutoBanReason;

		public bool BanNotification;

		public string BanNotificationTemplate;

		public int GetGeneralTTL()
		{
			return 0;
		}

		public int GetPrivateTTL()
		{
			return 0;
		}

		public int GetDontRemoveCount(ChatAccess access)
		{
			return 0;
		}

		public int GetMaxCharCount()
		{
			return 0;
		}

		public List<string> GetBadWordList()
		{
			return null;
		}

		public void AddBadWord(string word)
		{
		}

		public void RemoveBadWord(string word)
		{
		}

		public string GetCensorChar()
		{
			return null;
		}

		public int GetAutoBanDuration()
		{
			return 0;
		}

		public void AddSticker(ChatSticker sticker)
		{
		}

		public void RemoveSticker(ChatSticker sticker)
		{
		}

		public bool StickerExist(string stickerID)
		{
			return false;
		}

		public string GetBanNotificationTemplate()
		{
			return null;
		}

		public string GetAutoBanReason()
		{
			return null;
		}
	}
}
