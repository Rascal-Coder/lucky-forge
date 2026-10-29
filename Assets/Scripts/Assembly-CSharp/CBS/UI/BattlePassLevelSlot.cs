using System;
using CBS.Core;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	[RequireComponent(typeof(RectTransform))]
	public class BattlePassLevelSlot : MonoBehaviour, IScrollableItem<BattlePassLevelInfo>
	{
		private readonly float DisabledAlpha;

		private readonly float LockAlpha;

		private readonly float DefaultAlpha;

		private readonly float ExpandWidthPerReward;

		[SerializeField]
		private CanvasGroup PremuimGroup;

		[SerializeField]
		private CanvasGroup DefaultGroup;

		[SerializeField]
		private Text LevelLabel;

		[SerializeField]
		private Text ExpToNextLevel;

		[SerializeField]
		private Slider ExpSlider;

		[SerializeField]
		private BattlePassRewardDrawer PremiumRewardDrawer;

		[SerializeField]
		private BattlePassRewardDrawer DefaultRewardDrawer;

		[SerializeField]
		private GameObject CollectPremiumButton;

		[SerializeField]
		private GameObject CollectDefaultButton;

		[SerializeField]
		private Image SliderBackground;

		[SerializeField]
		private GameObject ExtraLevelFrame;

		[SerializeField]
		private GameObject TimeLocker;

		[SerializeField]
		private Text TimeLablel;

		[SerializeField]
		private Color DefaultLineColor;

		[SerializeField]
		private Color ExtraLineColor;

		private RectTransform Rect { get; set; }

		private float DefaultFrameWith { get; set; }

		private string BattlePassID { get; set; }

		private int LevelIndex { get; set; }

		private bool IsTimerSlot { get; set; }

		private DateTime? TimerDate { get; set; }

		public BattlePassLevelInfo LevelInfo { get; private set; }

		private void Awake()
		{
		}

		private void OnDisable()
		{
		}

		public void Display(BattlePassLevelInfo data)
		{
		}

		public void SetTimerActivity(bool val)
		{
		}

		private void LateUpdate()
		{
		}

		public void GrantPremiumReward()
		{
		}

		public void GrantDefaultReward()
		{
		}

		private void OnReciveReward(CBSGrantAwardToPlayerResult result)
		{
		}
	}
}
