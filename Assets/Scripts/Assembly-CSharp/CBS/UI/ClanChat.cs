using System;
using TMPro;
using UnityEngine;

namespace CBS.UI
{
	public class ClanChat : MonoBehaviour, IClanScreen
	{
		[SerializeField]
		private ChatView ChatView;

		public TextMeshProUGUI sendit;

		public TextMeshProUGUI[] chatrules;

		public GameObject chatrulepage;

		private IProfile Profile { get; set; }

		private ICBSChat Chat { get; set; }

		public Action OnBack { get; set; }

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		public void Hide()
		{
		}

		public void Show()
		{
		}

		public void BackHandler()
		{
		}

		private void LoadChat()
		{
		}

		public void OpenCloseChatRule()
		{
		}

		public void ConfirmChatRules()
		{
		}
	}
}
