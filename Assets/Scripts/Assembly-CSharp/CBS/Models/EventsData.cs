using System.Collections.Generic;

namespace CBS.Models
{
	public class EventsData
	{
		public const string ALL_CATEGORY = "ALL";

		public const string UNDEFINED_CATEGORY = "undefined";

		public const int MinDurationInSeconds = 60;

		public const int DefaultDurationInSeconds = 86400;

		public Categories Categories;

		public List<EventMetaData> EventMetaList;

		public Dictionary<string, EventMetaData> GetMetaDataAsDictionary()
		{
			return null;
		}

		public List<EventMetaData> GetMetaList()
		{
			return null;
		}

		public EventMetaData GetMetaData(string eventID)
		{
			return null;
		}

		public void SetCategories(Categories categories)
		{
		}

		public List<string> GetCategories()
		{
			return null;
		}

		public List<string> GetCategoriesToSelect()
		{
			return null;
		}

		public void RemoveEvent(string eventID)
		{
		}

		public void ApplyMetaData(EventMetaData metaData)
		{
		}
	}
}
