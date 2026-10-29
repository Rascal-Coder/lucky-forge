using System;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class BattlePassFrame : MonoBehaviour
	{
		[SerializeField]
		private Text Title;

		[SerializeField]
		private Text Time;

		[SerializeField]
		private Text CurrentLevel;

		[SerializeField]
		private Text CurrentExp;

		[SerializeField]
		private BattlePassBadge Badge;

		[SerializeField]
		private GameObject LockBlock;

		private DateTime? EndDate;

		private string BattlePassID { get; set; }

		private BattlePassPrefabs PassPrefabs { get; set; }

		private RectTransform Rect { get; set; }

		private void Awake()
		{
		}

		public void Draw(BattlePassUserInfo passUserInfo)
		{
		}

		public void OpenPassWindow()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
