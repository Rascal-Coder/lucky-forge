using System;

namespace Proyecto26
{
	public class RequestException : Exception
	{
		private bool _isHttpError;

		private bool _isNetworkError;

		private long _statusCode;

		private string _serverMessage;

		private string _response;

		public bool IsHttpError
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public bool IsNetworkError
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public long StatusCode
		{
			get
			{
				return 0L;
			}
			private set
			{
			}
		}

		public string ServerMessage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Response
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public RequestException()
		{
		}

		public RequestException(string message)
		{
		}

		public RequestException(string format, params object[] args)
		{
		}

		public RequestException(string message, bool isHttpError, bool isNetworkError, long statusCode, string response)
		{
		}
	}
}
