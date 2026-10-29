using System;
using System.Collections.Generic;

namespace CBS.Models
{
	public class ProfileChatData
	{
		public bool IsModerator;

		public Dictionary<string, ChatBanDetail> BanDictionary;

		public bool IsBanned(string chatID, DateTime serverTime)
		{
			return false;
		}

		public ChatBanDetail GetBanDetail(string chatID)
		{
			return null;
		}

		public void AddBan(string chatID, ChatBanDetail banDetail)
		{
		}
	}
}
