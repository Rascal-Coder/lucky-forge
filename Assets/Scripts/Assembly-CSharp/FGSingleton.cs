using UnityEngine;

public class FGSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;

	private static object _lock;

	public static T Instance => null;
}
