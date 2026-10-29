using System;
using FunGames.Core.Modules;
using FunGames.UserConsent.GDPR;

namespace FunGames.UserConsent
{
	public class FGUserConsent
	{
		private static Action _onComplete;

		public static FGModuleCallbacks Callbacks => null;

		public static bool IsAttCompliant => false;

		public static FGGDPRStatus GdprStatus => null;

		public static bool IsIABCompliant => false;

		public static string ConsentString => null;

		public static bool HasFullConsent => false;

		public static Location Location => null;

		public static event Action OnComplete
		{
			add
			{
			}
			remove
			{
			}
		}

		public static void ShowATT()
		{
		}

		public static void ShowGDPR()
		{
		}

		internal static void TriggerCompleteCallback()
		{
		}
	}
}
