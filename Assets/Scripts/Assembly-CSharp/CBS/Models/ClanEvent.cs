namespace CBS.Models
{
	public class ClanEvent
	{
		public ClanEventType EventType;

		public string ContentBodyRaw;

		public string GetRawData()
		{
			return null;
		}

		public T GetContent<T>() where T : ClanEvent
		{
			return null;
		}

		public void SaveContent(object data)
		{
		}
	}
}
