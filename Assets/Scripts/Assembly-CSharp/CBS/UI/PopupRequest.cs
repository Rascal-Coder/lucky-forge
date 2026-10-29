using System;

namespace CBS.UI
{
	public struct PopupRequest
	{
		public string Title;

		public string Body;

		public Action OnOkAction;
	}
}
