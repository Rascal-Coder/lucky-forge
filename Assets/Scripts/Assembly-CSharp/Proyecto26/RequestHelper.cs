using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Proyecto26
{
	public class RequestHelper
	{
		private string _uri;

		private string _method;

		private object _body;

		private string _bodyString;

		private byte[] _bodyRaw;

		private int? _timeout;

		private string _contentType;

		private int _retries;

		private float _retrySecondsDelay;

		private Action<RequestException, int> _retryCallback;

		private bool _enableDebug;

		private bool? _useHttpContinue;

		private int? _redirectLimit;

		private bool _ignoreHttpException;

		private WWWForm _formData;

		private Dictionary<string, string> _simpleForm;

		private List<IMultipartFormSection> _formSections;

		private CertificateHandler _certificateHandler;

		private UploadHandler _uploadHandler;

		private DownloadHandler _downloadHandler;

		private Dictionary<string, string> _headers;

		private Dictionary<string, string> _params;

		private bool _parseResponseBody;

		private bool _isAborted;

		private bool _defaultContentType;

		public string Uri
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Method
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public object Body
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string BodyString
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public byte[] BodyRaw
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int? Timeout
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string ContentType
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Retries
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float RetrySecondsDelay
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Action<RequestException, int> RetryCallback
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool EnableDebug
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool? UseHttpContinue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int? RedirectLimit
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IgnoreHttpException
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public WWWForm FormData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Dictionary<string, string> SimpleForm
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<IMultipartFormSection> FormSections
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CertificateHandler CertificateHandler
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public UploadHandler UploadHandler
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DownloadHandler DownloadHandler
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Dictionary<string, string> Headers
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Dictionary<string, string> Params
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool ParseResponseBody
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public UnityWebRequest Request { private get; set; }

		public float UploadProgress => 0f;

		public ulong UploadedBytes => 0uL;

		public float DownloadProgress => 0f;

		public ulong DownloadedBytes => 0uL;

		public bool IsAborted
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool DefaultContentType
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string GetHeader(string name)
		{
			return null;
		}

		public void Abort()
		{
		}
	}
}
