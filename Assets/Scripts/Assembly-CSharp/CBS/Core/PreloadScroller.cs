using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CBS.Core
{
	[RequireComponent(typeof(ScrollRect))]
	public abstract class PreloadScroller<T> : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler where T : class
	{
		[SerializeField]
		private Transform Root;

		[SerializeField]
		protected int PoolCount;

		[SerializeField]
		protected ScrollerSide Direction;

		private ScrollRect scroll;

		protected abstract float DeltaToPreload { get; }

		protected List<GameObject> PoolItems { get; set; }

		protected List<T> List { get; set; }

		private GameObject UIPrefab { get; set; }

		protected bool NeedToExtend => false;

		private bool IsInited { get; set; }

		private bool IsDragging { get; set; }

		protected HorizontalOrVerticalLayoutGroup Layout { get; set; }

		protected ScrollRect Scroll => null;

		protected int PoolIndex { get; set; }

		private void OnDestroy()
		{
		}

		public List<GameObject> Spawn(GameObject prefab, List<T> list)
		{
			return null;
		}

		public ScrollRect GetScroll()
		{
			return null;
		}

		protected void PushNew(T item)
		{
		}

		private void Init()
		{
		}

		private void OnScrollMove(Vector2 position)
		{
		}

		protected void MovePrev()
		{
		}

		protected void MoveNext()
		{
		}

		public void OnEndDrag(PointerEventData eventData)
		{
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
		}

		protected void ResetSroll()
		{
		}

		public void HideAll()
		{
		}
	}
}
