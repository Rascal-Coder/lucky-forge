using System;
using CBS.Models;
using CBS.Scriptable;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class CreateClanForm : MonoBehaviour, IClanScreen
	{
		public TextMeshProUGUI title;

		public TextMeshProUGUI guildname;

		public TextMeshProUGUI guilddescription;

		public TextMeshProUGUI anyonejoin;

		public TextMeshProUGUI background;

		public TextMeshProUGUI foreground;

		public TextMeshProUGUI emblem;

		public TextMeshProUGUI createguild;

		public TMP_InputField NameInput;

		public TMP_InputField DescriptionInput;

		public ClanAvatarSelector AvatarSelector;

		public Toggle VisibilityToggle;

		public Button CreateButton;

		public ClanLogin clanLogin;

		public GameObject loadingicon;

		private ILeaderboard LeaderboardModule { get; set; }

		private IClan CBSClan { get; set; }

		private ClanPrefabs Prefabs { get; set; }

		public Action OnBack { get; set; }

		private void Awake()
		{
		}

		public void Show()
		{
		}

		private void OnEnable()
		{
		}

		public void Hide()
		{
		}

		private bool ValidInputs()
		{
			return false;
		}

		public void CreateClan()
		{
		}

		private void OnClanCreated(string clanID)
		{
		}

		public void ReturnBack()
		{
		}

		private void OnUpdate(CBSUpdateClanStatisticResult result)
		{
		}
	}
}
