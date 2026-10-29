using System;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace Proyecto26
{
	[Serializable]
	public class ResponseHelper
	{
		public UnityWebRequest Request { get; private set; }

		public long StatusCode => 0L;

		public byte[] Data => null;

		public string Text => null;

		public string Error => null;

		public Dictionary<string, string> Headers => null;

		public ResponseHelper(UnityWebRequest request)
		{
		}

		public string GetHeader(string name)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
