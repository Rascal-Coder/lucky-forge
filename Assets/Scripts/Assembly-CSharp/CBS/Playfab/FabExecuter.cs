using System.Collections.Generic;

namespace CBS.Playfab
{
	public class FabExecuter
	{
		private static List<FabExecuter> Modules { get; set; }

		protected virtual void Init()
		{
		}

		public static T Get<T>() where T : FabExecuter, new()
		{
			return null;
		}
	}
}
