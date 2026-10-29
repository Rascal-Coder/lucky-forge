using System;

namespace CBS.UI
{
	public struct EditTextPopupRequest
	{
		public string Title;

		public string InitialInput;

		public Action<string> SaveAction;

		public Action CancelAction;
	}
}
