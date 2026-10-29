using System;
using PlayFab;

namespace CBS
{
	public static class JsonPlugin
	{
		public const string EMPTY_JSON = "{}";

		private static ISerializerPlugin Plugin { get; set; }

		static JsonPlugin()
		{
		}

		public static string ToJson(object obj)
		{
			return null;
		}

		public static string ToJsonCompress(object obj)
		{
			return null;
		}

		public static T FromJson<T>(string rawData)
		{
			return default;
		}

		public static T FromJsonDecompress<T>(string rawData)
		{
			return default;
		}

		public static object FromJsonDecompress(string rawData, Type type)
		{
			return null;
		}

		public static object FromJson(string rawData, Type type)
		{
			return null;
		}

		public static bool IsValidJson(string strInput)
		{
			return false;
		}
	}
}
