using System.Collections.Generic;
using CBS.Models;

namespace CBS.UI
{
	public class ClanMemberUIRequest
	{
		public ClanMember ClanMember;

		public List<ClanRoleInfo> AvailableRoles;
	}
}
