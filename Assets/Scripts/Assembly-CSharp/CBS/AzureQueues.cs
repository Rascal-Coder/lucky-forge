using System.Collections.Generic;

namespace CBS
{
	public static class AzureQueues
	{
		public const string BattlePassPostProcessQueue = "BattlePassPostProcess";

		public const string StartCBSEventQueue = "StartCBSEvent";

		public const string StopCBSEventQueue = "StopCBSEvent";

		public const string ExecuteCBSEventQueue = "ExecuteCBSEvent";

		public const string BattlePassQueueName = "cbs-battlepass-queue";

		public const string StartEventQueueName = "cbs-start-event-queue";

		public const string StopEventQueueName = "cbs-stop-event-queue";

		public const string ExecuteEventQueueName = "cbs-execute-event-queue";

		public static List<string> AllQueues => null;

		public static string GetQueueContainerName(string queue)
		{
			return null;
		}
	}
}
