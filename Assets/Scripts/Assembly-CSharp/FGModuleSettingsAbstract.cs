using FunGames.Core.Settings;

public abstract class FGModuleSettingsAbstract<T> : FGModuleSettings where T : FGModuleSettingsAbstract<T>, new()
{
	protected const int ORDER = 10;

	private static T _instance;

	private static object _lock;

	public static T settings => null;

	protected abstract T LoadResources();
}
