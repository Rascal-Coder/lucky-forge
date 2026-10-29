using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FunGames.Tools
{
	public class UIDrag : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		[SerializeField]
		private RectTransform target;

		public Image Image;

		public Action FinishedDragging;

		[CompilerGenerated]
		private Action m_Clicked;

		private bool _isDragging;

		private Vector2 _dragPrevLocalPoint;

		private RectTransform TargetParent => null;

		public event Action Clicked
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

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}
	}
}
