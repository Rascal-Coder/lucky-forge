using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class EventsWindow : MonoBehaviour
	{
		[SerializeField]
		private EventsScroller Scroller;

		[SerializeField]
		private EventDetailDrawer EventDrawer;

		[Header("Display options")]
		[SerializeField]
		private bool ActiveOnly;

		[SerializeField]
		private string ByCategory;

		private IEventsModule Events { get; set; }

		private EventsPrefabs Prefabs { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void DisplayEvents(List<CBSEvent> events)
		{
		}

		private void GetEventsList()
		{
		}

		private void OnGetEvents(CBSGetEventsResult result)
		{
		}

		private void OnViewEvent(CBSEvent selectedEvent)
		{
		}

		private void OnBackFromDetail()
		{
		}
	}
}
