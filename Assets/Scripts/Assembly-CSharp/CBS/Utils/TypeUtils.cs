using System.Reflection;

namespace CBS.Utils
{
	public static class TypeUtils
	{
		public static bool IsSupportedList(FieldInfo f, object target)
		{
			return false;
		}

		public static bool IsSupportedList(object target)
		{
			return false;
		}

		public static bool IsFloat(object target)
		{
			return false;
		}

		public static bool IsInt(object target)
		{
			return false;
		}
	}
}
