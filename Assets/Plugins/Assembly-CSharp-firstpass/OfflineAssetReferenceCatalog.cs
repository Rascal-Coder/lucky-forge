using System;
using System.Collections.Generic;
using UnityEngine;

// Offline rebuild infrastructure, not the original Easy Save implementation.
// Build a Resources/OfflineReferenceCatalog asset from original project asset GUIDs.
public sealed class OfflineAssetReferenceCatalog : ScriptableObject
{
    [Serializable] public sealed class Entry { public string guid; public UnityEngine.Object asset; }
    public List<Entry> entries = new List<Entry>();
    private static readonly Dictionary<string, UnityEngine.Object> ByGuid = new Dictionary<string, UnityEngine.Object>(StringComparer.Ordinal);
    private static readonly Dictionary<UnityEngine.Object, string> ByObject = new Dictionary<UnityEngine.Object, string>();
    private static bool initialized;

    private static void EnsureLoaded()
    {
        if (initialized) return;
        initialized = true;
        var catalog = Resources.Load<OfflineAssetReferenceCatalog>("OfflineReferenceCatalog");
        if (catalog == null || catalog.entries == null) return;
        foreach (var entry in catalog.entries)
            if (entry != null && !string.IsNullOrEmpty(entry.guid) && entry.asset != null) Register(entry.guid, entry.asset);
    }

    public static void Register(string guid, UnityEngine.Object asset)
    {
        if (string.IsNullOrEmpty(guid) || asset == null) throw new ArgumentException("An asset and its stable GUID are required.");
        ByGuid[guid] = asset;
        ByObject[asset] = guid;
    }

    public static string GuidFor(UnityEngine.Object asset)
    {
        if (asset == null) return null;
        EnsureLoaded();
        string guid;
        return ByObject.TryGetValue(asset, out guid) ? guid : null;
    }

    public static UnityEngine.Object Resolve(string guid, Type expectedType)
    {
        EnsureLoaded();
        UnityEngine.Object asset;
        if (!string.IsNullOrEmpty(guid) && ByGuid.TryGetValue(guid, out asset) && asset != null && expectedType.IsInstanceOfType(asset)) return asset;
        return null; // Never guess an asset from a non-unique name.
    }
}
