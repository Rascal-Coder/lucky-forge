using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CBS.UI
{
	public class NotificationTabListener : MonoBehaviour
	{
		[CompilerGenerated]
		private Action<NotificationMenu> m_OnTabSelected;

		[SerializeField]
		private GameObject[] AllTabs;

		public NotificationMenu ActiveTab { get; private set; }

		public event Action<NotificationMenu> OnTabSelected
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnToggleSelected(bool val)
		{
		}
	}
}
