using UnityEngine;

public sealed class OfflineSaveLifecycle : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Install()
    {
        var host = new GameObject("Offline Save Lifecycle");
        host.hideFlags = HideFlags.HideAndDontSave;
        DontDestroyOnLoad(host);
        host.AddComponent<OfflineSaveLifecycle>();
        Application.quitting -= OfflineKeyStore.FlushAll;
        Application.quitting += OfflineKeyStore.FlushAll;
    }
    private void OnApplicationPause(bool paused) { if (paused) OfflineKeyStore.FlushAll(); }
    private void OnApplicationFocus(bool focused) { if (!focused) OfflineKeyStore.FlushAll(); }
}
