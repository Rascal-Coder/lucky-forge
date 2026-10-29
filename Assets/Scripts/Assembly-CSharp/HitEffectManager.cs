using System.Collections.Generic;
using UnityEngine;

public class HitEffectManager : MonoBehaviour
{
	private class HitData
	{
		public Transform model;

		public Vector3 basePos;

		public float timer;

		public float zOffset;
	}

	private List<HitData> activeHits;

	[Header("Settings")]
	public float effectDuration;

	public float zBackAmount;

	public int maxSimultaneousHits;

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void RegisterHit(Transform model)
	{
	}
}
