using UnityEngine;

public class AnalyticsTimeEvent : MonoBehaviour
{
	public static int totalMinutes;

	private float elapsedTime;

	private const string saveKey = "totalPlayTimeMinutes";

	private void Update()
	{
		// Recovered from original ARM64 0x21ad640.
		elapsedTime+=Time.unscaledDeltaTime; if(elapsedTime>=60f){elapsedTime-=60f;totalMinutes=unchecked(totalMinutes+1);ES3.Save<int>("totalPlayTimeMinutes",totalMinutes);}
	}

	public static int GetTotalMinutes()
	{
		// Recovered from original ARM64 0x21ad710.
		return totalMinutes;
	}
}
