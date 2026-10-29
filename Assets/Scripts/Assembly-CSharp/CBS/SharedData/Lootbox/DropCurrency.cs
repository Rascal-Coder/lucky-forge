using System.Collections.Generic;

namespace CBS.SharedData.Lootbox
{
	public class DropCurrency
	{
		public CurrencyDropType DropType;

		public string CurrencyCode;

		public List<CurrencyDropSlot> DropTable;

		public int Min;

		public int Max;

		public void AddToTable(int value)
		{
		}

		public void RemoveFromTable(int value)
		{
		}
	}
}
