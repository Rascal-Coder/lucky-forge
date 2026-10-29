using System;
using CBS.Models;
using UnityEngine.UI;

namespace CBS.UI
{
	public class DialogSlotRequest
	{
		public ChatDialogEntry DialogEntry;

		public ToggleGroup Group;

		public Action<ChatDialogEntry> SelectAction;
	}
}
