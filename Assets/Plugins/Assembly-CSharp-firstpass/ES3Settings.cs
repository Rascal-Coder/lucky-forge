using System;
using System.ComponentModel;
using System.Text;
using UnityEngine;

public class ES3Settings : ICloneable
{
	private static ES3Settings _defaults;

	private static ES3Defaults _defaultSettingsScriptableObject;

	private const string defaultSettingsPath = "ES3/ES3Defaults";

	private static ES3Settings _unencryptedUncompressedSettings;

	private static readonly string[] resourcesExtensions;

	[SerializeField]
	private ES3.Location _location;

	public string path;

	public ES3.EncryptionType encryptionType;

	public ES3.CompressionType compressionType;

	public string encryptionPassword;

	public ES3.Directory directory;

	public ES3.Format format;

	public bool prettyPrint;

	public int bufferSize;

	public Encoding encoding;

	public bool saveChildren;

	public bool postprocessRawCachedData;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool typeChecking;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool safeReflection;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public ES3.ReferenceMode memberReferenceMode;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public ES3.ReferenceMode referenceMode;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public int serializationDepthLimit;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public string[] assemblyNames;

	public static ES3Defaults defaultSettingsScriptableObject => _defaultSettingsScriptableObject != null ? _defaultSettingsScriptableObject : (_defaultSettingsScriptableObject = Resources.Load<ES3Defaults>("es3/ES3Defaults"));

	public static ES3Settings defaultSettings => _defaults ?? (_defaults = new ES3Settings(false));

	internal static ES3Settings unencryptedUncompressedSettings => _unencryptedUncompressedSettings ?? (_unencryptedUncompressedSettings = new ES3Settings(false));

	public ES3.Location location
	{
		get
		{
			return _location;
		}
		set
		{
			_location = value;
		}
	}

	public string FullPath => OfflineKeyStore.PathFor(path, this);

	public ES3Settings(string path = null, ES3Settings settings = null)
	{
		(settings ?? defaultSettings).CopyInto(this);
		if (path != null) this.path = path;
	}

	public ES3Settings(string path, params Enum[] enums)
	{
		defaultSettings.CopyInto(this);
		if (path != null) this.path = path;
		foreach (Enum option in enums ?? new Enum[0]) { if (option is ES3.Location) location = (ES3.Location)(object)option; else if (option is ES3.Directory) directory = (ES3.Directory)(object)option; else if (option is ES3.EncryptionType) encryptionType = (ES3.EncryptionType)(object)option; else if (option is ES3.CompressionType) compressionType = (ES3.CompressionType)(object)option; else if (option is ES3.Format) format = (ES3.Format)(object)option; else if (option is ES3.ReferenceMode) referenceMode = (ES3.ReferenceMode)(object)option; }
	}

	public ES3Settings(params Enum[] enums)
	{
		defaultSettings.CopyInto(this);
		foreach (Enum option in enums ?? new Enum[0]) { if (option is ES3.Location) location = (ES3.Location)(object)option; else if (option is ES3.Directory) directory = (ES3.Directory)(object)option; else if (option is ES3.EncryptionType) encryptionType = (ES3.EncryptionType)(object)option; else if (option is ES3.CompressionType) compressionType = (ES3.CompressionType)(object)option; else if (option is ES3.Format) format = (ES3.Format)(object)option; else if (option is ES3.ReferenceMode) referenceMode = (ES3.ReferenceMode)(object)option; }
	}

	public ES3Settings(ES3.EncryptionType encryptionType, string encryptionPassword)
	{
		defaultSettings.CopyInto(this); this.encryptionType = encryptionType; this.encryptionPassword = encryptionPassword;
	}

	public ES3Settings(string path, ES3.EncryptionType encryptionType, string encryptionPassword, ES3Settings settings = null)
	{
		(settings ?? defaultSettings).CopyInto(this); if (path != null) this.path = path; this.encryptionType = encryptionType; this.encryptionPassword = encryptionPassword;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public ES3Settings(bool applyDefaults)
	{
		this.path = "medupac.es3"; _location = ES3.Location.Cache; encoding = Encoding.UTF8; bufferSize = 2048; saveChildren = true; typeChecking = true; safeReflection = true; serializationDepthLimit = 64; format = ES3.Format.JSON;
		if (applyDefaults) defaultSettings.CopyInto(this);
	}

	private static bool IsAbsolute(string path)
	{
		return System.IO.Path.IsPathRooted(path);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public object Clone()
	{
		var clone = new ES3Settings(false); CopyInto(clone); return clone;
	}

	private void CopyInto(ES3Settings newSettings)
	{
		if (newSettings == null) throw new ArgumentNullException(nameof(newSettings));
		newSettings._location = _location;
		newSettings.path = path; newSettings.encryptionType = encryptionType; newSettings.compressionType = compressionType; newSettings.encryptionPassword = encryptionPassword; newSettings.directory = directory; newSettings.format = format; newSettings.prettyPrint = prettyPrint; newSettings.bufferSize = bufferSize; newSettings.encoding = encoding; newSettings.saveChildren = saveChildren; newSettings.postprocessRawCachedData = postprocessRawCachedData; newSettings.typeChecking = typeChecking; newSettings.safeReflection = safeReflection; newSettings.memberReferenceMode = memberReferenceMode; newSettings.referenceMode = referenceMode; newSettings.serializationDepthLimit = serializationDepthLimit; newSettings.assemblyNames = assemblyNames;
	}
}
