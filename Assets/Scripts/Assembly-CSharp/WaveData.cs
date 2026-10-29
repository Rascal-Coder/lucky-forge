using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "Wave System/Wave Data", order = 1)]
public class WaveData : ScriptableObject
{
	public string SiegeName;

	public long EnemysHealth;

	public long EnemysAttack;

	public List<Waves.Wave> waves;
}
