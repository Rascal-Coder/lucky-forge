namespace CBS.Core.Auth
{
	public class Credential
	{
		private const string CredentialKey = "Credential.json";

		public static void Save<T>(T credential) where T : BaseCredential
		{
		}

		public static T Get<T>() where T : BaseCredential
		{
			return null;
		}

		public static void Clear()
		{
		}

		public static bool Exist()
		{
			return false;
		}
	}
}
