using UnityEngine;

public class UnityLogSaver : MonoBehaviour
{
	private struct Log
	{
		public string message;

		public string stackTrace;

		public LogType type;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void HandleLog(string message, string stackTrace, LogType type)
	{
	}

	private void SaveLog(Log log)
	{
	}

	private string GetTimeAsString(float time)
	{
		return null;
	}
}
