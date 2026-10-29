namespace FunGames.Tools.Utils
{
	public class Singleton<T> where T : new()
	{
		private static T _instance;

		private static readonly object _lock;

		public static T Instance => default;

		private static T GetInstance()
		{
			return default;
		}
	}
}
