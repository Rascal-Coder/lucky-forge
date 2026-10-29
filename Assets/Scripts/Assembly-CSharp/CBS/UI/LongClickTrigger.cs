using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CBS.UI
{
	public class LongClickTrigger : MonoBehaviour, IPointerUpHandler, IEventSystemHandler, IPointerDownHandler
	{
		[SerializeField]
		private float LongClickSeconds;

		[CompilerGenerated]
		private Action m_OnLongClick;

		private float LastDownTime;

		private bool IsDown;

		public event Action OnLongClick
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

		public void OnPointerDown(PointerEventData data)
		{
		}

		public void OnPointerUp(PointerEventData data)
		{
		}

		private void LateUpdate()
		{
		}
	}
}
