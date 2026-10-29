using System.Collections.Generic;
using UnityEngine;

namespace CBS.UI
{
	public class ClanScreenLoader : MonoBehaviour
	{
		[Header("Screens")]
		[SerializeField]
		private ClanGeneral GeneralScreen;

		[SerializeField]
		private CreateClanForm CreateScreen;

		[SerializeField]
		private ClanSearchForm SearchScreen;

		[SerializeField]
		private ProfileInvitations InvitationsScreen;

		[SerializeField]
		private ClanRequests RequestsScreen;

		[SerializeField]
		private ClanMetaScreen MetaScreen;

		[SerializeField]
		private ClanMembers MembersScreen;

		[SerializeField]
		private ClanChat ChatScreen;

		[SerializeField]
		private ClanInventoryScreen InventoryScreen;

		[SerializeField]
		private ClanTasksScreen TasksScreen;

		private Dictionary<ClanScreen, IClanScreen> Screens { get; set; }

		private IProfile Profile { get; set; }

		private IClanScreen LastScreen { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void RegisterScreens()
		{
		}

		private void InitStartScene()
		{
		}

		private void OnLoadScreen(ClanScreen screen)
		{
		}
	}
}
