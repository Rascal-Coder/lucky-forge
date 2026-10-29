using System;

namespace CBS.Core.Auth
{
	[Serializable]
	public class GoogleCredential : BaseCredential
	{
		public string AuthCode;
	}
}
