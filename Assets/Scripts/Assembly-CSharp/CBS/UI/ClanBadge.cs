using CBS.Models;
using UnityEngine;

namespace CBS.UI
{
	public class ClanBadge : BaseBadge
	{
		[SerializeField]
		private ClanBadgeMode DisplayMode;

		private IClan CBSClan { get; set; }

		private IProfile CBSProfile { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnEnable()
		{
		}

		private void CheckState()
		{
		}

		private void OnGetBadge(CBSGetClanBadgeResult result)
		{
		}

		private void OnProfileJoinClan(CBSJoinToClanResult result)
		{
		}

		private void OnLeaveClan()
		{
		}

		private void OnCreateClan(CBSCreateClanResult result)
		{
		}

		private void OnKickMember()
		{
		}

		private void OnAcceptRequest(CBSAcceptDeclineClanRequestResult result)
		{
		}

		private void OnDeclineRequest(CBSAcceptDeclineClanRequestResult result)
		{
		}

		private void OnDeclineInvation(CBSDeclineInviteResult result)
		{
		}

		private void OnAcceptInvation(CBSJoinToClanResult result)
		{
		}
	}
}
