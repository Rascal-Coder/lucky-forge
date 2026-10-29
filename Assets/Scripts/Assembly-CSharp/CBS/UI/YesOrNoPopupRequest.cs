using System;

namespace CBS.UI
{
	public struct YesOrNoPopupRequest
	{
		public string Title;

		public string Body;

		public Action OnYesAction;

		public Action OnNoAction;
	}
}
