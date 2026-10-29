using System;

namespace CBS.Core.Auth
{
	[Serializable]
	public class SteamCredential : BaseCredential
	{
		public string SteamTicket;
	}
}
