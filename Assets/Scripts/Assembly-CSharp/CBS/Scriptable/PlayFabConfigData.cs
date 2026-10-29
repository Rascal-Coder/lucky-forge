using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "PlayFabConfigData", menuName = "CBS/Add new PlayFab Config Data")]
	public class PlayFabConfigData : ExternalData
	{
		private static string DefaultAzureProjectPath;

		public string ExternalClassToRegisterAzureFunction;

		public string AzureProjectPath;

		public override string ResourcePath => null;

		public override string EditorPath => null;

		public override string EditorAssetName => null;

		public string GetAzureProjectPath()
		{
			return null;
		}
	}
}
