using System.Collections.Generic;

namespace CBS.Models
{
	public class ClanLevelTable : LevelTable
	{
		public ClanEventContainer RegistrationEvents;

		public RewardDelivery RewardDelivery;

		public List<ClanEventContainer> LevelEvents;

		public override void AddLevelDetail(LevelDetail level)
		{
		}

		public override void RemoveLevelDetailAt(int index)
		{
		}
	}
}
