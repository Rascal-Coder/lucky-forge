using System;
using System.Text;
using Proyecto26;
using RSG;

namespace FunGames.Core.Utils
{
	public static class FGAPIHelpers
	{
		private static readonly char[] Array1;

		private static string _secret;

		internal static string CreateUniqueId(params string[] strings)
		{
			return null;
		}

		internal static string CreateUniqueId(StringBuilder stringBuilder)
		{
			return null;
		}

		internal static string CreateToken(string message)
		{
			return null;
		}

		internal static string GetBitString()
		{
			return null;
		}

		internal static string CreateAuthorizationHeader(string content)
		{
			return null;
		}

		public static void GET(string url, Action<ResponseHelper, Exception> callback = null)
		{
		}

		public static void POST(string url, string body, Action<ResponseHelper, Exception> callback = null)
		{
		}

		private static void HandleResponse(IPromise<ResponseHelper> request, Action<ResponseHelper, Exception> callback)
		{
		}

		private static void PrintGetRequest(RequestHelper rh)
		{
		}

		private static void PrintPostRequest(RequestHelper rh)
		{
		}
	}
}
