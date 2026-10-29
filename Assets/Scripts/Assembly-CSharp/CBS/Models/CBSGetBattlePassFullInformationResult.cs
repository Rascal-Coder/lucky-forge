using System.Collections.Generic;

namespace CBS.Models
{
	public class CBSGetBattlePassFullInformationResult : CBSBaseResult
	{
		public BattlePassUserInfo ProfileState;

		public BattlePassInstance Instance;

		public List<BattlePassLevelInfo> GetLevelTreeDetailList()
		{
			return null;
		}

		public List<BattlePassBankLevel> GetBankLevelTree()
		{
			return null;
		}
	}
}
