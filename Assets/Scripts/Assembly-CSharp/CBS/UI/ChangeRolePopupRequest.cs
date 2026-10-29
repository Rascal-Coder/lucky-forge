using System;
using System.Collections.Generic;
using CBS.Models;

namespace CBS.UI
{
	public struct ChangeRolePopupRequest
	{
		public string CurrentRoleID;

		public List<ClanRoleInfo> Roles;

		public Action<string> SelectAction;

		public Action CancelAction;
	}
}
