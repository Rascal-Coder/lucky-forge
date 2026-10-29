using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardSystem : MonoBehaviour
{
	public Button rewardButton;

	public Image[] rewardImages;

	public TextMeshProUGUI[] rewardTexts;

	public Sprite[] sprites;

	public Material shinemat;

	private int firstWaveIndex;

	private int currentLevel;

	public WarController warController;

	public GameManager gameManager;

	private const string rewardKeyFormat = "chestrewardClaimsave_{0}_{1}";

	public Animator animDone;

	private HashSet<string> claimedRewards;

	private Dictionary<string, bool> claimedRewardsDict;

	private const string rewardSaveKey = "chestrewardClaims";

	public CurrencyCollectedUi collectedUi;

	private int bestsurviekac()
	{
		return 0;
	}

	private void Start()
	{
	}

	private void MigrateOldRewards()
	{
	}

	private void OnEnable()
	{
	}

	private void ClaimReward()
	{
	}

	private void UpdateRewardDisplay()
	{
	}

	private void LoadClaimedRewards()
	{
	}

	private int FindFirstUnclaimedLevel()
	{
		return 0;
	}

	private int FindFirstUnclaimedWave(int level)
	{
		return 0;
	}
}
