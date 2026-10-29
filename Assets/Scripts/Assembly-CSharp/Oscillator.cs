using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
	[SerializeField]
	private Vector3 movementVector;

	[SerializeField]
	private float period;

	public bool local;

	private float movementFactor;

	private Vector3 startingPos;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
