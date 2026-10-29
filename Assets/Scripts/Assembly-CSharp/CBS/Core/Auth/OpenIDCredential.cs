using System;

namespace CBS.Core.Auth
{
	[Serializable]
	public class OpenIDCredential : BaseCredential
	{
		public string ConnectionID;

		public string IDToken;
	}
}
