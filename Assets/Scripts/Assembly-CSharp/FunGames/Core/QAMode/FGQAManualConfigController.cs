using System.Collections.Generic;
using FunGames.Tools.Utils;

namespace FunGames.Core.QAMode
{
	internal class FGQAManualConfigController
	{
		private readonly List<JSONNode> _allCohorts;

		private readonly List<JSONNode> _allConfigs;

		private readonly Dictionary<string, JSONNode> _cohortsLookup;

		private readonly Dictionary<string, JSONNode> _configsLookup;

		private readonly HashSet<string> _enabledVariableIds;

		internal readonly SortedDictionary<string, List<JSONNode>> ABTests;

		internal readonly SortedDictionary<string, List<JSONNode>> GroupedConfigs;

		private readonly Comparer<string> _descendingComparer;

		private JSONNode _liveVariables;

		public bool IsLiveMode { get; private set; }

		internal int EnabledVariablesCount => 0;

		internal FGQAManualConfigController()
		{
		}

		internal bool GetCachedAdsEnabled()
		{
			return false;
		}

		internal bool HasEverBeenSetup()
		{
			return false;
		}

		internal void OnCohortToggleChanged(string id, bool value)
		{
		}

		internal void OnConfigToggleChanged(string id, bool value)
		{
		}

		internal void ClearSelection()
		{
		}

		internal void SetToLiveVariables()
		{
		}

		internal void LoadCachedRemoteVariables()
		{
		}

		private void ParseAllRemoteVariables(string serverResponse)
		{
		}

		private void AddCohort(string id, JSONNode node)
		{
		}

		private void AddConfig(string id, JSONNode node)
		{
		}

		private int CompareCohorts(JSONNode a, JSONNode b)
		{
			return 0;
		}

		private int CompareConfigs(JSONNode a, JSONNode b)
		{
			return 0;
		}

		private void RestorePrefsSettings()
		{
		}

		private bool HasKeyWithValue(JSONNode node, string key, string value)
		{
			return false;
		}

		private JSONArray GetEnabledIdsAsJson()
		{
			return null;
		}

		private void SetVariableEnabled(JSONNode rcVariable, bool isEnabled)
		{
		}

		private void SetVariableEnabled(string id, bool isEnabled)
		{
		}

		internal bool IsVariableEnabled(string jsonNodeId)
		{
			return false;
		}

		private void ClearVariablesSelection()
		{
		}

		internal bool Submit()
		{
			return false;
		}
	}
}
