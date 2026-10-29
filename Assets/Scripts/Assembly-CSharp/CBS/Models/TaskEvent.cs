namespace CBS.Models
{
	public class TaskEvent
	{
		public TaskEventType EventType;

		public string ContentBodyRaw;

		public string GetRawData()
		{
			return null;
		}

		public T GetContent<T>() where T : TaskEvent
		{
			return null;
		}

		public void SaveContent(object data)
		{
		}
	}
}
