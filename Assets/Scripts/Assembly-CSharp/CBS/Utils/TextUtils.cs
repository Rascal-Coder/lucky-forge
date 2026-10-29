using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace CBS.Utils
{
	public static class TextUtils
	{
		public static bool ContainSpecialSymbols(string input)
		{
			return false;
		}

		public static bool ContainUpperCase(string input)
		{
			return false;
		}

		public static string GetCustomDataAsReadableText(this CBSInventoryItem inventoryItem, Color titleColor, Color valueColor)
		{
			return null;
		}

		public static string GetCurrentUpgradeCustomDataAsReadableText(this CBSInventoryItem inventoryItem, Color titleColor, Color valueColor)
		{
			return null;
		}

		public static string GetNextUpgradeCustomDataAsReadableText(this CBSInventoryItem inventoryItem, Color titleColor, Color valueColor)
		{
			return null;
		}

		private static string ConvertCustomDataToReadableText(Dictionary<string, object> customData, Color titleColor, Color valueColor)
		{
			return null;
		}

		public static string GetDiscountText(int discount)
		{
			return null;
		}

		public static void Clear(this StringBuilder value)
		{
		}
	}
}
