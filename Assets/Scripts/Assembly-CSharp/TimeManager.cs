using System;
using UnityEngine;
// Recovered static clock methods RVA0x204e768..0x204e89c.
public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;
    public long serverTime;
    public long onlineTime;
    public double elapsedTime;
    public static bool offline;
    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else if (Instance != this) Destroy(gameObject);
    }
    private void Start() { serverTime = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(); elapsedTime = 0d; }
    private void Update() { elapsedTime += Time.deltaTime; }
    public long GetCurrentUTCTime() { return serverTime + (long)elapsedTime; }
    public long GetOnlineCurrentUTCTime() { return serverTime + (long)elapsedTime; } // original also reads serverTime, not onlineTime
}
