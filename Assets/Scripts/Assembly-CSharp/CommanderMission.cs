using System;
using System.Collections.Generic;

[Serializable]
public class CommanderMission
{
	public string missionName;

	public List<int> requiredCommanderIDs;

	public int spintoken;

	public int luckytoken;

	public bool isCompleted;

	public bool rewardClaimed;
}
