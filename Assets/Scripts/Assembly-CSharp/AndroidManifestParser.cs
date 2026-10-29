using System.Collections.Generic;
using System.Xml;

public class AndroidManifestParser
{
	public static class AndroidPermission
	{
		public const string INTERNET = "android.permission.INTERNET";

		public const string BIND_GET_INSTALL_REFERRER_SERVICE = "com.google.android.finsky.permission.BIND_GET_INSTALL_REFERRER_SERVICE";

		public const string AD_ID = "com.google.android.gms.permission.AD_ID";

		public const string ACCESS_NETWORK_STATE = "android.permission.ACCESS_NETWORK_STATE";

		public const string ACCESS_WIFI_STATE = "android.permission.ACCESS_WIFI_STATE";

		public const string ADJUST_PREINSTALL = "com.adjust.preinstall.READ_PERMISSION";
	}

	private const string ANDROID_MANIFEST_PATH = "Plugins/Android/AndroidManifest.xml";

	private const string NAMESPACE_URI = "http://schemas.android.com/apk/res/android";

	private static XmlDocument manifest;

	private static string appManifestPath;

	public static readonly string[] RequiredPermissions;

	public void AddAllPermissions()
	{
	}

	public void Save()
	{
	}

	public void AddQuery(string queryValue)
	{
	}

	public void AddPermissions(List<string> permissions)
	{
	}

	private bool AddPermission(string permissionValue)
	{
		return false;
	}

	private void AddPackageQuery(XmlDocument manifest, XmlNode queriesNode, string packageName)
	{
	}

	public bool DoesPermissionExist(string permissionValue)
	{
		return false;
	}

	private XmlNamespaceManager GetNamespaceManager(XmlDocument manifest)
	{
		return null;
	}

	private void AddAndroidNamespaceAttribute(XmlDocument manifest, string key, string value, XmlElement node)
	{
	}

	public void AddFileProvider(string resourceName)
	{
	}

	public void AddDeeplinkScheme(string deeplinkScheme)
	{
	}

	private XmlNode FindMainActivity()
	{
		return null;
	}

	private bool DeeplinkSchemeExists(XmlNode activity, string scheme)
	{
		return false;
	}

	private void AddDeeplinkIntentFilter(XmlNode activity)
	{
	}
}
