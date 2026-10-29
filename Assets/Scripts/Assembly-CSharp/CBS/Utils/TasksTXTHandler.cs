using System;
using CBS.Models;

namespace CBS.Utils
{
	public static class TasksTXTHandler
	{
		public const string NotCompleteText = "Task not yet completed";

		public const string CompleteText = "Task completed!";

		public static string GetLockText(int level, IntFilter filter)
		{
			return null;
		}

		public static string GetNextResetDateNotification(DateTime resetDate)
		{
			return null;
		}

		public static string GetNextResetUTCDateNotification(DateTime resetDate)
		{
			return null;
		}
	}
}
