using System;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
	[Serializable]
	public class EnemyGroup
	{
		public string enemyTag;

		public int count;
	}

	[Serializable]
	public class Wave
	{
		public List<EnemyGroup> enemyGroups;

		public string bossTag;

		public bool hasBoss;
	}

	public List<Wave> waves;
}
