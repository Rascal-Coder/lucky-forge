using System;
using System.Threading;

public class CustomThread
{
	private bool isOn;

	private bool isStopped;

	private Thread thread;

	private int counter;

	public CustomThread(Action action, bool loop = false)
	{
	}

	public void StartOnceAfterTime(int timeInSeconds)
	{
	}

	public void Start()
	{
	}

	public void Stop()
	{
	}

	public bool IsOn()
	{
		return false;
	}

	private void action(Action action)
	{
	}

	private void actionLoop(Action action)
	{
	}
}
