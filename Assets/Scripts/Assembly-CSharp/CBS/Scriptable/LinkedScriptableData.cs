using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "LinkedScriptableData", menuName = "CBS/Add new Linked Scriptable Data")]
	public class LinkedScriptableData : LinkedData<ScriptableObject>
	{
		public override string ResourcePath => null;

		public override string EditorPath => null;

		public override string EditorAssetName => null;

		public TScriptable GetScriptableData<TScriptable>(string id) where TScriptable : ScriptableObject
		{
			return null;
		}
	}
}
