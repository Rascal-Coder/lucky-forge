using System.Collections.Generic;

namespace CBS.Models
{
	public class ClanMetaData
	{
		private static readonly int MaxClanMemberCount;

		private static readonly int DefaultClanMemberCount;

		public static readonly string AdminRoleID;

		public static readonly string MemberRoleID;

		private static readonly string DefaultAdminDisplayName;

		private static readonly string DefaultMemberDisplayName;

		public static readonly string JoinMessageTemplate;

		public static readonly string LeftMessageTemplate;

		public static readonly string RoleMessageTemplate;

		public int ClanMemberCount;

		public bool SendJoinMessage;

		public bool SendLeaveMessage;

		public bool SendChangeRoleMessage;

		public bool DisplayNameProfanityCheck;

		public ClanLevelTable LevelTable;

		public List<ClanRoleInfo> RoleList;

		public int GetClanMemberCount()
		{
			return 0;
		}

		public ClanLevelTable GetLevelTable()
		{
			return null;
		}

		public List<ClanRoleInfo> GetRoleList()
		{
			return null;
		}

		public List<ClanRoleInfo> GetCustomRoleList()
		{
			return null;
		}

		private List<ClanRoleInfo> GetDefaultRoleList()
		{
			return null;
		}

		public void AddNewRole(string roleID)
		{
		}

		public void RemoveRole(string roleID)
		{
		}

		public void MoveRoleUp(string roleID)
		{
		}

		public void MoveRoleDown(string roleID)
		{
		}

		public bool IsDefaultRole(string roleID)
		{
			return false;
		}

		public bool IsAdminRole(string roleID)
		{
			return false;
		}

		public bool HasPermissionForAction(string roleID, ClanRolePermission permission)
		{
			return false;
		}

		public void RemovePermissionForAction(string roleID, ClanRolePermission permission)
		{
		}

		public void AddPermissionForAction(string roleID, ClanRolePermission permission)
		{
		}
	}
}
