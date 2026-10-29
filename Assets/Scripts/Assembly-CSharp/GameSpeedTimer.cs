using System;
using UnityEngine;

public class GameSpeedTimer : MonoBehaviour
{
	private const string KEY_ALINAN_HOUR = "AlinanExtraSpeedHour";

	private const string KEY_EXTRA_SPEED = "ExtraGameSpeed";

	private const string KEY_START_TICKS = "ExtraSpeedStartTime";

	private static DateTime ExtraSpeedStartTime;

	public static bool ExtraSpeed1Alindi;

	public static bool ExtraSpeed2Alindi;

	private void Start()
	{
	}

	public static int GetRemainingHours()
	{
		return 0;
	}

	public static void AddSpeedHours(int hours)
	{
	}

	public static void UpdateSpeed()
	{
	}

	public void DataUpdate()
	{
	}

	public static string GetRemainingHoursString()
	{
		return null;
	}

	private static void SaveState()
	{
	}

	private void Update()
	{
	}
}
