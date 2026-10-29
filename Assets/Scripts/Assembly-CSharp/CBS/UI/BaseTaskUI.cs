using CBS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class BaseTaskUI<T> : MonoBehaviour, IScrollableItem<T> where T : CBSTask
	{
		[SerializeField]
		private TextMeshProUGUI Title;

		[SerializeField]
		private TextMeshProUGUI StepsLabel;

		[SerializeField]
		private TextMeshProUGUI NotifyLabel;

		[SerializeField]
		private Image IconImage;

		[SerializeField]
		private Slider StepsSlider;

		[SerializeField]
		private TextMeshProUGUI LevelTitle;

		[SerializeField]
		private TextMeshProUGUI Membersrewardtxt;

		[SerializeField]
		private TextMeshProUGUI rewardnedir;

		[SerializeField]
		private TextMeshProUGUI guildexpverilecek;

		[SerializeField]
		protected GameObject IconLock;

		[SerializeField]
		protected GameObject CompleteBtn;

		[SerializeField]
		protected GameObject LockBtn;

		[SerializeField]
		protected GameObject RewardBt;

		[SerializeField]
		protected GameObject LevelIcon;

		protected T Task { get; set; }

		protected virtual string LockText { get; }

		protected virtual string NotCompleteText { get; }

		protected virtual string CompleteText { get; }

		private void Awake()
		{
		}

		protected virtual void OnInit()
		{
		}

		public void Display(T task)
		{
		}

		protected virtual void DrawButtons(bool isLocked, bool isCompleted, bool rewardAvailable)
		{
		}

		public virtual void OnAddPoint()
		{
		}

		public virtual void GetRewards()
		{
		}

		public void ShowRewards()
		{
		}

		private void ToDefault()
		{
		}
	}
}
