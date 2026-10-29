using UnityEngine;
using UnityEngine.SceneManagement;

public class GppUiController : MonoBehaviour
{
	[Header("Hidden when GPP is active")]
	public GameObject[] adUiRoots;

	public GameObject[] iapUiRoots;

	public ShopUi shopUi;

	public WarController warController;

	public static GppUiController Instance { get; private set; }

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
	}

	private void ResolveSceneReferences()
	{
	}

	public void Refresh()
	{
	}

	private static void SetRootsActive(GameObject[] roots, bool active)
	{
	}
}
