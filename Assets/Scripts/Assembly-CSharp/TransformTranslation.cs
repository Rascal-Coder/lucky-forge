using UnityEngine;

public class TransformTranslation : MonoBehaviour
{
	[SerializeField]
	private Vector3 movementVector;

	[SerializeField]
	private float speed;

	public bool local;

	private float movementFactor;

	private Vector3 startingPos;

	private Vector3 movemenFactor;

	private Vector3 offset;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnDrawGizmos()
	{
	}
}
