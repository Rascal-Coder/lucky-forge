using System;

namespace CBS.Core.Auth
{
	[Serializable]
	public class PasswordCredential : BaseCredential
	{
		public string Mail;

		public string Password;

		public string Username;
	}
}
