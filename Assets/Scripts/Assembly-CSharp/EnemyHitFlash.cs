using UnityEngine;

public class EnemyHitFlash : MonoBehaviour
{
	[Header("Shake Settings")]
	public Transform model;

	public float shakeDuration;

	private float shakeStrength;

	[Header("Scale Settings")]
	private float scaleDuration;

	private float scaleStrength;

	private float scaleTimer;

	private Vector3 baseScale;

	private Vector3 originalPos;

	private float shakeTimer;

	private Vector3[] randomShakes;

	private int shakeIndex;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void TriggerHitFlash()
	{
	}
}
