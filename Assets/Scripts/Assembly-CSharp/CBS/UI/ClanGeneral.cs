using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CBS.UI
{
	public class ClanGeneral : MonoBehaviour
	{
		[SerializeField]
		private GameObject LeaveIcon;

		[SerializeField]
		private GameObject CreateIcon;

		[SerializeField]
		private GameObject RequestsIcon;

		[SerializeField]
		private GameObject ClanMeta;

		[SerializeField]
		private GameObject Members;

		[SerializeField]
		private GameObject Disband;

		[SerializeField]
		private GameObject Chat;

		[SerializeField]
		private GameObject Inventory;

		[SerializeField]
		private GameObject Tasks;

		[CompilerGenerated]
		private Action<ClanScreen> m_OnLoadScreen;

		private IClan Clan { get; set; }

		private IProfile Profile { get; set; }

		public event Action<ClanScreen> OnLoadScreen
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		public void Load(bool existInClan)
		{
		}

		private void InitMetaIcon()
		{
		}

		public void ShowCreateClan()
		{
		}

		public void ShowSearchClan()
		{
		}

		public void ShowInvations()
		{
		}

		public void ShowRequests()
		{
		}

		public void ShowClanMeta()
		{
		}

		public void ShowClanMembers()
		{
		}

		public void ShowChat()
		{
		}

		public void ShowInventory()
		{
		}

		public void ShowTasks()
		{
		}

		public void LeaveClanHandler()
		{
		}

		public void DisbandClanHandler()
		{
		}
	}
}
