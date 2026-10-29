using System;
using System.IO;

namespace ES3Internal
{
	public class ES3FileStream : FileStream
	{
		private bool isDisposed;

		public ES3FileStream(string path, ES3FileMode fileMode, int bufferSize, bool useAsync)
			: base((IntPtr)0, (FileAccess)0, ownsHandle: false, 0)
		{
		}

		protected static string GetPath(string path, ES3FileMode fileMode)
		{
			return null;
		}

		protected static FileMode GetFileMode(ES3FileMode fileMode)
		{
			return (FileMode)0;
		}

		protected static FileAccess GetFileAccess(ES3FileMode fileMode)
		{
			return (FileAccess)0;
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
