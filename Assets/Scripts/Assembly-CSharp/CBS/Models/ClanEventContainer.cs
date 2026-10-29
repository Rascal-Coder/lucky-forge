using System.Collections.Generic;

namespace CBS.Models
{
	public class ClanEventContainer
	{
		public List<ClanEvent> Events;

		public void AddEvent(ClanEvent clanEvent)
		{
		}

		public void RemoveEvent(ClanEvent clanEvent)
		{
		}

		public bool IsEmpty()
		{
			return false;
		}

		public ClanEventContainer Merge(ClanEventContainer eventContainer)
		{
			return null;
		}
	}
}
