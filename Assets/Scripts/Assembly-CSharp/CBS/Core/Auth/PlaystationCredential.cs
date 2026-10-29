using System;

namespace CBS.Core.Auth
{
	[Serializable]
	public class PlaystationCredential : BaseCredential
	{
		public string AuthCode;

		public int? IssuerId;

		public string RedirectUri;
	}
}
