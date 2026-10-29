using System;

public class GAMaxIntegration
{
	[Serializable]
	public class MaxImpressionData
	{
		public string country;

		public string network_name;

		public string adunit_id;

		public string adunit_format;

		public string placement;

		public string creative_id;

		public float revenue;
	}

	private static bool _subscribed;

	private static void runCallback(string format, MaxSdkBase.AdInfo adInfo, Action<string> callback)
	{
	}

	public static void ListenForImpressions(Action<string> callback)
	{
	}
}
