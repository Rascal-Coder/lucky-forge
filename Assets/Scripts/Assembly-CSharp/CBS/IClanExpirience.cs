using System;
using CBS.Models;

namespace CBS
{
	public interface IClanExpirience
	{
		void AddExpirienceToClan(string clanID, int expToAdd, Action<CBSLevelDataResult> result = null);

		void GetClanLevelDetail(string clanID, Action<CBSLevelDataResult> result);
	}
}
