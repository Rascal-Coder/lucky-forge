using System;

namespace CBS.Core.Auth
{
	[Serializable]
	public class AppleCredential : BaseCredential
	{
		public string IdentityToken;
	}
}
