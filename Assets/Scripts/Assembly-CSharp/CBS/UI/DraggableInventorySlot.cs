using System;
using CBS.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CBS.UI
{
	[RequireComponent(typeof(RectTransform))]
	public class DraggableInventorySlot : InventorySlot, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
	{
		public Action OnStartDrag;

		private RectTransform RectTransform { get; set; }

		private Transform CanvasParent { get; set; }

		private int LastBindIndex { get; set; }

		private Transform LastParent { get; set; }

		protected override void Awake()
		{
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		public void OnEndDrag(PointerEventData eventData)
		{
		}

		public void ReturnToInitialPosition()
		{
		}

		public void SetParent(Transform parent)
		{
		}

		private IDropContainer GetDropContainer(PointerEventData eventData)
		{
			return null;
		}
	}
}
