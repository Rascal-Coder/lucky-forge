using System;
using System.Collections.Generic;
using CBS.Core;
using CBS.Models;

namespace CBS
{
	[Serializable]
	public class CBSTask : ICustomData<CBSTaskCustomData>
	{
		public string ID;

		public string Title;

		public string Description;

		public string Tag;

		public string PoolID;

		public TaskType Type;

		public int Steps;

		public bool IsLockedByLevel;

		public int LockLevel;

		public IntFilter LevelFilter;

		public string ExternalUrl;

		public RewardObject Reward;

		public List<TaskTier> TierList;

		public BaseTaskState TaskState;

		public ProfileEventContainer Events;

		public bool IsComplete => false;

		public bool IsAvailable => false;

		public bool Rewarded => false;

		public int TierIndex => 0;

		public int CurrentStep => 0;

		public TaskTier CurrentTier => null;

		public string CustomDataClassName { get; set; }

		public string CustomRawData { get; set; }

		public bool CompressCustomData => false;

		public void UpdateState(BaseTaskState state)
		{
		}

		public void AddNewTier(TaskTier tier)
		{
		}

		public void RemoveLastTier()
		{
		}

		public int GetNextTierIndex()
		{
			return 0;
		}

		public T GetCustomData<T>() where T : CBSTaskCustomData
		{
			return null;
		}

		public ProfileEventContainer GetEvents()
		{
			return null;
		}

		public bool IsLevelLocking(int level)
		{
			return false;
		}

		public bool IsRewardAvailable()
		{
			return false;
		}

		public RewardObject GetNotRewardedObject()
		{
			return null;
		}

		public void MarkAsNotRewarded()
		{
		}

		public T Copy<T>() where T : CBSTask
		{
			return null;
		}
	}
}
