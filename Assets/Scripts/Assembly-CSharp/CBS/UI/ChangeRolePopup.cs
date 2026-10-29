using System;
using System.Collections.Generic;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class ChangeRolePopup : MonoBehaviour
	{
		[SerializeField]
		private Dropdown RoleDropdown;

		private Action<string> SelectAction { get; set; }

		private Action CancelAction { get; set; }

		private List<ClanRoleInfo> Roles { get; set; }

		public void Setup(ChangeRolePopupRequest request)
		{
		}

		private void Clear()
		{
		}

		public void SaveHandler()
		{
		}

		public void NoHandler()
		{
		}
	}
}
