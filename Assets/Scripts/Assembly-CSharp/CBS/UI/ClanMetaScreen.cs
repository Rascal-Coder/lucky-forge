using System;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class ClanMetaScreen : MonoBehaviour, IClanScreen
	{
		[SerializeField]
		private GameObject InfoPanel;

		[SerializeField]
		private GameObject EditAvatarPanel;

		[SerializeField]
		private Text DisplayName;

		[SerializeField]
		private Text Members;

		[SerializeField]
		private Text Description;

		[SerializeField]
		private Text Level;

		[SerializeField]
		private Text Expirience;

		[SerializeField]
		private Slider ExpSlider;

		[SerializeField]
		private ClanAvatarDrawer Avatar;

		[SerializeField]
		private Toggle IsOpen;

		[SerializeField]
		private ClanAvatarSelector AvatarSelector;

		private IClan Clan { get; set; }

		private IProfile Profile { get; set; }

		private ClanFullInfo ClanInfo { get; set; }

		public Action OnBack { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnGetClanFullInformation(CBSGetClanFullInfoResult result)
		{
		}

		private void Display(ClanFullInfo clanInfo)
		{
		}

		private void DisplayLevel(LevelInfo level)
		{
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}

		public void BackHandler()
		{
		}

		public void EditDisplayNameHandler()
		{
		}

		public void EditDescriptionHandler()
		{
		}

		public void EditAvatarHandler()
		{
		}

		public void SaveAvatarHandler()
		{
		}

		public void CancelAvatarHandler()
		{
		}

		public void OnVisibilityChange(bool val)
		{
		}
	}
}
