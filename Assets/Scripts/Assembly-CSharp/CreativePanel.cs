using UnityEngine;

public class CreativePanel : MonoBehaviour
{
	public HeroController heroController;

	public CommanderSpawner commanderSpawner;

	public WarController warController;

	public static CreativePanel i;

	private const int DefaultMaxPlayerLevel = 200;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private static void RegisterDebugConsoleCommands()
	{
	}

	private static void UnregisterDebugConsoleCommands()
	{
	}

	private void Update()
	{
	}

	public void GiveRandomWeapon(WeaponRarity rarity)
	{
	}

	public void GiveRandomMystic()
	{
	}

	public void Updagradeit()
	{
	}

	public void CompleteLevel()
	{
	}

	public void GameOver()
	{
	}

	public void IncreaseLevel()
	{
	}

	public void AddCoins()
	{
	}

	public void AddGems()
	{
	}

	public void KillAllEnemies()
	{
	}

	public void AddSpinTokens()
	{
	}

	public void UnlockEverythingAt100()
	{
	}

	private static int GetMaxRequiredPlayerLevel()
	{
		return 0;
	}

	private void SetPlayerLevelToMax()
	{
	}

	private void RefreshLevelGatedFeatures()
	{
	}

	private static void MaxAllResearch()
	{
	}

	private static void MaxAllTalents()
	{
	}
}
