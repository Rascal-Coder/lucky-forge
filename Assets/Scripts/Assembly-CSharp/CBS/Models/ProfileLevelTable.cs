using System.Collections.Generic;

namespace CBS.Models
{
	public class ProfileLevelTable : LevelTable
	{
		public ProfileEventContainer RegistrationEvents;

		public RewardDelivery RewardDelivery;

		public List<ProfileEventContainer> LevelEvents;

		public override void AddLevelDetail(LevelDetail level)
		{
		}

		public override void RemoveLevelDetailAt(int index)
		{
		}
	}
}
