using System;

namespace CBS.Models
{
	public class CBSCurrency
	{
		public string Code;

		public int Value;

		public bool Rechargeable;

		public int MaxRecharge;

		public DateTime? RechargeTime;

		public int SecondsToRecharge;

		public int GetSecondsToNextRecharge()
		{
			return 0;
		}

		public bool IsMaxRecharge()
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public static CBSCurrency Default(string code)
		{
			return null;
		}

		public static CBSCurrency Create(string code, uint value)
		{
			return null;
		}
	}
}
