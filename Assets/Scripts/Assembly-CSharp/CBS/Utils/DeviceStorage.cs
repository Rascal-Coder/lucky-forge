namespace CBS.Utils
{
	public class DeviceStorage
	{
		public static string LocalFolderAbsolutePath => null;

		private static void WriteText(string relativePath, string data)
		{
		}

		public static byte[] ReadFile(string relativePath)
		{
			return null;
		}

		public static void WriteFile(string relativePath, byte[] data)
		{
		}

		private static string ReadText(string relativePath)
		{
			return null;
		}

		public static void Delete(string relativePath)
		{
		}

		public static bool FileExists(string relativePath)
		{
			return false;
		}

		public static bool PathExists(string path)
		{
			return false;
		}

		private static bool TextExists(string relativePath)
		{
			return false;
		}

		public static T GetJsonFromDisk<T>(string _pathKey)
		{
			return default;
		}

		public static void SaveJsonToDisk<T>(T _obj, string _pathKey)
		{
		}
	}
}
