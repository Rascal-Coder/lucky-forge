using System;

namespace Proyecto26
{
	public static class JsonHelper
	{
		[Serializable]
		private class Wrapper<T>
		{
			public T[] Items;
		}

		public static T[] ArrayFromJson<T>(string json)
		{
			return null;
		}

		public static T[] FromJsonString<T>(string json)
		{
			return null;
		}

		public static string ArrayToJsonString<T>(T[] array)
		{
			return null;
		}

		public static string ArrayToJsonString<T>(T[] array, bool prettyPrint)
		{
			return null;
		}
	}
}
