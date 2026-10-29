using System.Collections.Generic;
using FunGames.Tools.Utils;

namespace FunGames.Mediation.ApplovinMax
{
	public class FGMaxLoadEventSender : Singleton<FGMaxLoadEventSender>
	{
		private const string RC_SEND_MAX_LOADING_EVENTS = "SendMaxLoadingEvents";

		private const string EVENT_AD_LOADED = "MaxLoad";

		private const string EVENT_LOAD_ERROR = "MaxLoadError";

		private const string EVENT_WATERFALL_INFO = "Wf";

		private const string EVENT_NETWORK_INFO = "Nw";

		private const string EVENT_CREDENTIALS = "Cr";

		private const string EVENT_ERROR_INFO = "Er";

		public void Initialize()
		{
		}

		private void SendAdLoadedEvent(string unitID, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void SendAdLoadFailedEvent(string unitID, MaxSdkBase.ErrorInfo errorInfo)
		{
		}

		private Dictionary<string, object> GetLoadedAdInfoParameter(MaxSdkBase.AdInfo adInfo)
		{
			return null;
		}

		private Dictionary<string, object> GetWaterfallInfoParameters(MaxSdkBase.WaterfallInfo waterfallInfo)
		{
			return null;
		}

		private Dictionary<string, object> GetNetworkResponseInfoParameters(MaxSdkBase.NetworkResponseInfo networkResponseInfo)
		{
			return null;
		}

		private Dictionary<string, object> GetErrorInfoParameters(MaxSdkBase.ErrorInfo errorInfo)
		{
			return null;
		}

		private void StopSendingEvents()
		{
		}
	}
}
