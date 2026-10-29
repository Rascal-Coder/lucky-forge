using UnityEditor;
using UnityEngine;

namespace LuckyForge.Offline.Editor
{
    public static class RecoveryInspectionBatch
    {
        public static void RunBatch()
        {
            var persistence = OfflinePersistenceVerification.RunChecks();
            if (!persistence.passed) { EditorApplication.Exit(1); return; }
            int references = OfflineReferenceCatalogBuilder.BuildCatalog();
            Debug.Log("Recovery reference catalog built: " + references);
            SceneRecoveryInspection.RunBatch();
        }
    }
}
