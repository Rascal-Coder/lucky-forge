namespace FunGames.Tools.Utils
{
	public class DeviceInfo
	{
		public string DeviceModel { get; }

		public string DeviceType { get; }

		public string DeviceName { get; }

		public int SystemMemorySize { get; }

		public int GraphicsMemorySize { get; }

		public int ProcessorCount { get; }

		public int ProcessorFrequency { get; }

		public static bool IsTablet()
		{
			return false;
		}
	}
}
