using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPS : MonoBehaviour
{
	public int MaxFrames;

	private static float lastFPSCalculated;

	private List<float> frameTimes;

	private float timer;

	public TextMeshProUGUI _text;

	public static float MaxFPS { get; private set; }

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void addFrame()
	{
	}

	private float calculateFPS()
	{
		return 0f;
	}

	private float calculateAverageFPS()
	{
		return 0f;
	}

	public static float GetCurrentFPS()
	{
		return 0f;
	}
}
