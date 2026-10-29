using System;

namespace FunGames.Core
{
	public class FGLTVMeasurement
	{
		private const string PP_LTV = "fg_ltv";

		private static Action<double> _onNewRevenueTracked;

		public static event Action<double> OnNewRevenueTracked
		{
			add
			{
			}
			remove
			{
			}
		}

		public static void AddRevenue(double revenue)
		{
		}

		public static string GetLtv()
		{
			return null;
		}

		public static double GetLtvValue()
		{
			return 0.0;
		}
	}
}
