using System;
using CBS.Core;

namespace CBS.Models
{
	public class CBSEvent : ICustomData<CBSEventsCustomData>
	{
		public string ID;

		public string InstanceID;

		public string DisplayName;

		public string Description;

		public string CronExpression;

		public string Category;

		public bool IsRunning;

		public DateTime? LastRunTime;

		public DateTime? NextRunTime;

		public DateTime? StartDate;

		public DateTime? EndDate;

		public string CustomDataClassName { get; set; }

		public string CustomRawData { get; set; }

		public bool CompressCustomData => false;

		public T GetCustomData<T>() where T : CBSEventsCustomData
		{
			return null;
		}
	}
}
