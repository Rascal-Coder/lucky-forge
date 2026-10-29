using CBS.Models;
using UnityEngine;

namespace CBS.UI
{
	public class EventsBadge : BaseBadge
	{
		[SerializeField]
		private string Category;

		private IEventsModule Events { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void GetCalendarBadge()
		{
		}

		private void OnGetBadge(CBSBadgeResult result)
		{
		}
	}
}
