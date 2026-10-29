using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class BattlePassFrameLoader : MonoBehaviour
	{
		[SerializeField]
		private Transform Root;

		private Dictionary<int, BattlePassFrame> FramePool;

		private IBattlePass BattlePass { get; set; }

		private BattlePassPrefabs PassPrefabs { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void LoadAllFrames()
		{
		}

		private void OnGetStates(CBSGetPlayerBattlePassStatesResult result)
		{
		}

		private void DrawStates(List<BattlePassUserInfo> states)
		{
		}

		private BattlePassFrame GetFrameAt(int index)
		{
			return null;
		}

		private void HideAllFrames()
		{
		}

		private void OnAddExpirience(string instanceID, int exp)
		{
		}

		private void OnRewardRecived(GrantRewardResult reward)
		{
		}

		private void OnPremiumAccessGranted(BattlePassTicket ticket)
		{
		}
	}
}
