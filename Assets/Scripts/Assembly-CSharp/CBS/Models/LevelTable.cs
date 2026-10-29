using System;
using System.Collections.Generic;

namespace CBS.Models
{
	[Serializable]
	public class LevelTable
	{
		private static readonly float DefaultExpMultiply;

		public float? ExpMultiply;

		public RewardObject RegistrationPrize;

		public List<LevelDetail> Table;

		public float GetExpMultiply()
		{
			return 0f;
		}

		public virtual void AddLevelDetail(LevelDetail level)
		{
		}

		public virtual void RemoveLevelDetailAt(int index)
		{
		}
	}
}
