using System;
using System.Collections.Generic;
using RSG;

namespace Proyecto26
{
	public static class RestClient
	{
		private static Dictionary<string, string> _defaultRequestParams;

		private static Dictionary<string, string> _defaultRequestHeaders;

		public static Version Version => null;

		public static Dictionary<string, string> DefaultRequestParams
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static Dictionary<string, string> DefaultRequestHeaders
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static void ClearDefaultParams()
		{
		}

		public static void ClearDefaultHeaders()
		{
		}

		public static void Request(RequestHelper options, Action<RequestException, ResponseHelper> callback)
		{
		}

		public static void Request<T>(RequestHelper options, Action<RequestException, ResponseHelper, T> callback)
		{
		}

		public static void Get(string url, Action<RequestException, ResponseHelper> callback)
		{
		}

		public static void Get(RequestHelper options, Action<RequestException, ResponseHelper> callback)
		{
		}

		public static void Get<T>(string url, Action<RequestException, ResponseHelper, T> callback)
		{
		}

		public static void Get<T>(RequestHelper options, Action<RequestException, ResponseHelper, T> callback)
		{
		}

		public static void GetArray<T>(string url, Action<RequestException, ResponseHelper, T[]> callback)
		{
		}

		public static void GetArray<T>(RequestHelper options, Action<RequestException, ResponseHelper, T[]> callback)
		{
		}

		public static void Post(string url, object body, Action<RequestException, ResponseHelper> callback)
		{
		}

		public static void Post(string url, string bodyString, Action<RequestException, ResponseHelper> callback)
		{
		}

		public static void Post(RequestHelper options, Action<RequestException, ResponseHelper> callback)
		{
		}

		public static void Post<T>(string url, object body, Action<RequestException, ResponseHelper, T> callback)
		{
		}

		public static void Post<T>(string url, string bodyString, Action<RequestException, ResponseHelper, T> callback)
		{
		}

		public static void Post<T>(RequestHelper options, Action<RequestException, ResponseHelper, T> callback)
		{
		}

		public static void PostArray<T>(string url, object body, Action<RequestException, ResponseHelper, T[]> callback)
		{
		}

		public static void PostArray<T>(string url, string bodyString, Action<RequestException, ResponseHelper, T[]> callback)
		{
		}

		public static void PostArray<T>(RequestHelper options, Action<RequestException, ResponseHelper, T[]> callback)
		{
		}

		public static void Put(string url, object body, Action<RequestException, ResponseHelper> callback)
		{
		}

		public static void Put(string url, string bodyString, Action<RequestException, ResponseHelper> callback)
		{
		}

		public static void Put(RequestHelper options, Action<RequestException, ResponseHelper> callback)
		{
		}

		public static void Put<T>(string url, object body, Action<RequestException, ResponseHelper, T> callback)
		{
		}

		public static void Put<T>(string url, string bodyString, Action<RequestException, ResponseHelper, T> callback)
		{
		}

		public static void Put<T>(RequestHelper options, Action<RequestException, ResponseHelper, T> callback)
		{
		}

		public static void Delete(string url, Action<RequestException, ResponseHelper> callback)
		{
		}

		public static void Delete(RequestHelper options, Action<RequestException, ResponseHelper> callback)
		{
		}

		public static void Head(string url, Action<RequestException, ResponseHelper> callback)
		{
		}

		public static void Head(RequestHelper options, Action<RequestException, ResponseHelper> callback)
		{
		}

		public static IPromise<ResponseHelper> Request(RequestHelper options)
		{
			return null;
		}

		public static IPromise<T> Request<T>(RequestHelper options)
		{
			return null;
		}

		public static IPromise<ResponseHelper> Get(string url)
		{
			return null;
		}

		public static IPromise<ResponseHelper> Get(RequestHelper options)
		{
			return null;
		}

		public static IPromise<T> Get<T>(string url)
		{
			return null;
		}

		public static IPromise<T> Get<T>(RequestHelper options)
		{
			return null;
		}

		public static IPromise<T[]> GetArray<T>(string url)
		{
			return null;
		}

		public static IPromise<T[]> GetArray<T>(RequestHelper options)
		{
			return null;
		}

		public static IPromise<ResponseHelper> Post(string url, object body)
		{
			return null;
		}

		public static IPromise<ResponseHelper> Post(string url, string bodyString)
		{
			return null;
		}

		public static IPromise<ResponseHelper> Post(RequestHelper options)
		{
			return null;
		}

		public static IPromise<T> Post<T>(string url, object body)
		{
			return null;
		}

		public static IPromise<T> Post<T>(string url, string bodyString)
		{
			return null;
		}

		public static IPromise<T> Post<T>(RequestHelper options)
		{
			return null;
		}

		public static IPromise<T[]> PostArray<T>(string url, object body)
		{
			return null;
		}

		public static IPromise<T[]> PostArray<T>(string url, string bodyString)
		{
			return null;
		}

		public static IPromise<T[]> PostArray<T>(RequestHelper options)
		{
			return null;
		}

		public static IPromise<ResponseHelper> Put(string url, object body)
		{
			return null;
		}

		public static IPromise<ResponseHelper> Put(string url, string bodyString)
		{
			return null;
		}

		public static IPromise<ResponseHelper> Put(RequestHelper options)
		{
			return null;
		}

		public static IPromise<T> Put<T>(string url, object body)
		{
			return null;
		}

		public static IPromise<T> Put<T>(string url, string bodyString)
		{
			return null;
		}

		public static IPromise<T> Put<T>(RequestHelper options)
		{
			return null;
		}

		public static IPromise<ResponseHelper> Delete(string url)
		{
			return null;
		}

		public static IPromise<ResponseHelper> Delete(RequestHelper options)
		{
			return null;
		}

		public static IPromise<ResponseHelper> Head(string url)
		{
			return null;
		}

		public static IPromise<ResponseHelper> Head(RequestHelper options)
		{
			return null;
		}

		private static void Promisify<T>(this Promise<T> promise, RequestException error, T response)
		{
		}

		private static void Promisify<T>(this Promise<T> promise, RequestException error, ResponseHelper response, T body)
		{
		}
	}
}
