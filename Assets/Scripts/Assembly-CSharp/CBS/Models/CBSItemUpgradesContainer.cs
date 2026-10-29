using System.Collections.Generic;

namespace CBS.Models
{
	public class CBSItemUpgradesContainer
	{
		public Dictionary<string, List<CBSItemUpgradeState>> Upgrades;

		public bool HasUpgrade(string itemID)
		{
			return false;
		}

		public List<CBSItemUpgradeState> GetUpdgrades(string itemID)
		{
			return null;
		}

		public void AddOrUpdateUpgradeInfo(string itemID, List<CBSItemUpgradeState> upgradeInfo)
		{
		}

		public void RemoveUpgrade(string itemID)
		{
		}

		public void Duplicate(string fromItemID, string toItemID)
		{
		}
	}
}
