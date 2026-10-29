using UnityEngine;

public static class VibrationUtils
{
	private static AndroidJavaObject vibrator;

	private static AndroidJavaClass vibrationEffectClass;

	static VibrationUtils()
	{
	}

	public static void Vibrate(long milliseconds = 80L, int amplitude = 255)
	{
	}
}
