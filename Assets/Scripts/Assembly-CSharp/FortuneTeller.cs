using System;
using UnityEngine;

public class FortuneTeller : MonoBehaviour
{
	private const string FORTUNE_KEY = "dailyFortuneData";

	private const string FORTUNE_TIME_KEY = "dailyFortuneTime";

	private const string FORTUNE_NUM = "dailyFortuneNum";

	private TimeSpan fortuneDuration;

	public GameObject fortuneinfo;

	public int fortuneNum;

	private void Start()
	{
	}

	public void GiveRandomFortune()
	{
	}

	public bool IsFortuneActive()
	{
		return false;
	}

	public TimeSpan GetRemainingTime()
	{
		return default;
	}

	public string GetRemainingTimeFormatted()
	{
		return null;
	}

	public void CheckFortuneExpired()
	{
	}

	private void ResetFortune()
	{
	}

	private void LoadFortune()
	{
	}

	private PlayerData.DailyFortune GetRandomFortune()
	{
		return null;
	}
}
