using System.Collections.Generic;

namespace CBS.Models
{
	public class ProfileEventContainer
	{
		public List<ProfileEvent> Events;

		public void AddEvent(ProfileEvent profileEvent)
		{
		}

		public void RemoveEvent(ProfileEvent profileEvent)
		{
		}

		public bool IsEmpty()
		{
			return false;
		}

		public ProfileEventContainer Merge(ProfileEventContainer eventContainer)
		{
			return null;
		}
	}
}
