using System;
using CBS.Models;
using TMPro;
using UnityEngine;

namespace CBS.UI
{
	public class ClanSearchForm : MonoBehaviour, IClanScreen
	{
		[SerializeField]
		private TMP_InputField SearchInput;

		[SerializeField]
		private ClanInfoForm ClanInfo;

		public TextMeshProUGUI searchtxt;

		public TextMeshProUGUI title;

		private IClan CBSClan { get; set; }

		public Action OnBack { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDisable()
		{
		}

		private void OnGetClan(CBSGetClanEntityResult result)
		{
		}

		private void OnJoinClan()
		{
		}

		public void OnSearch()
		{
		}

		public void BackHandler()
		{
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}
	}
}
