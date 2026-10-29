using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace LuckyForge.Offline.Editor
{
    public static class OfflineReferenceCatalogBuilder
    {
        // Includes root and sub-assets. GUID:localFileID distinguishes sprites sharing a texture.
        public static int BuildCatalog()
        {
            const string target = "Assets/Resources/OfflineReferenceCatalog.asset";
            var catalog = AssetDatabase.LoadAssetAtPath<OfflineAssetReferenceCatalog>(target);
            if (catalog == null)
            {
                Directory.CreateDirectory(Path.Combine(Application.dataPath, "Resources"));
                catalog = ScriptableObject.CreateInstance<OfflineAssetReferenceCatalog>();
                AssetDatabase.CreateAsset(catalog, target);
            }
            var entries = new List<OfflineAssetReferenceCatalog.Entry>();
            var identities = new HashSet<string>(StringComparer.Ordinal);
            foreach (string path in AssetDatabase.GetAllAssetPaths())
            {
                if (!path.StartsWith("Assets/", StringComparison.Ordinal) || path == target || AssetDatabase.IsValidFolder(path)) continue;
                // Scene instances are session state, not stable template assets.
                if (path.EndsWith(".unity", StringComparison.OrdinalIgnoreCase) || path.EndsWith(".cs", StringComparison.OrdinalIgnoreCase) || path.EndsWith(".dll", StringComparison.OrdinalIgnoreCase)) continue;
                foreach (var asset in AssetDatabase.LoadAllAssetsAtPath(path))
                {
                    if (asset == null || asset is MonoScript || asset is DefaultAsset) continue;
                    Add(asset, entries, identities);
                    var prefab = asset as GameObject;
                    if (prefab != null)
                        foreach (var transform in prefab.GetComponentsInChildren<Transform>(true))
                        {
                            Add(transform.gameObject, entries, identities);
                            foreach (var component in transform.GetComponents<Component>()) if (component != null) Add(component, entries, identities);
                        }
                }
            }
            catalog.entries = entries;
            EditorUtility.SetDirty(catalog);
            AssetDatabase.SaveAssets();
            Debug.Log("Offline stable asset catalog entries: " + entries.Count);
            return entries.Count;
        }

        private static void Add(UnityEngine.Object asset, List<OfflineAssetReferenceCatalog.Entry> entries, HashSet<string> identities)
        {
            string guid; long localId;
            if (!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(asset, out guid, out localId) || string.IsNullOrEmpty(guid)) return;
            string identity = guid + ":" + localId;
            if (identities.Add(identity)) entries.Add(new OfflineAssetReferenceCatalog.Entry {guid = identity, asset = asset});
        }
    }
}
