namespace CBS.Scriptable
{
	public abstract class ExternalData : CBSScriptable
	{
		public abstract string EditorPath { get; }

		public abstract string EditorAssetName { get; }

		internal override T Load<T>()
		{
			return null;
		}
	}
}
