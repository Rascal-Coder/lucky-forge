namespace CBS.Models
{
	public class ProfileEvent
	{
		public ProfileEventType EventType;

		public string ContentBodyRaw;

		public string GetRawData()
		{
			return null;
		}

		public T GetContent<T>() where T : ProfileEvent
		{
			return null;
		}

		public void SaveContent(object data)
		{
		}
	}
}
