namespace FunGames.Tools.Utils
{
	public class CacheFile<T> where T : class
	{
		private string _fileName;

		private T _data;

		public string Path => null;

		public CacheFile(string fileName)
		{
		}

		public T Read()
		{
			return null;
		}

		public void Create()
		{
		}

		public void Update(T data)
		{
		}

		public void AddNode(JSONNode node, string key = "")
		{
		}

		public void RemoveNode(string key)
		{
		}
	}
}
