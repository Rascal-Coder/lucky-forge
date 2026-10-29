using System;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace FunGames.Tools.Utils
{
	public class WebUtils
	{
		public static void SendRequest(UnityWebRequest webRequest, Action<UnityWebRequest> callback)
		{
		}

		public static UnityWebRequest DownloadRequest(string url)
		{
			return null;
		}

		public static void DownloadFile(string url, string path, Action action = null)
		{
		}

		public static void DownloadFileWAuthorization(string url, string path, Action<bool, long> action = null)
		{
		}

		public static void UploadData(string url, string body, Action<bool, long> action = null)
		{
		}

		private static void FileDownloaded(UnityWebRequest webRequest, string path, Action action = null)
		{
		}

		public static Dictionary<string, string> ParseQueryParams(string url)
		{
			return null;
		}
	}
}
