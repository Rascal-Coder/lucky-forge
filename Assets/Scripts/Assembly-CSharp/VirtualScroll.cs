using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualScroll<T> : MonoBehaviour where T : class
{
	[Header("References")]
	public ScrollRect scrollRect;

	public RectTransform content;

	public GameObject itemPrefab;

	[Header("Layout Settings")]
	public int itemsPerRow;

	public int visibleRowCount;

	public float itemWidth;

	public float itemHeight;

	public float spacing;

	public float paddingTop;

	public float paddingLeft;

	private List<T> dataList;

	private List<IVirtualScrollItem<T>> pooledItems;

	private int pooledItemCount;

	private int totalItemCount;

	private int totalRowCount;

	private bool isInitialized;

	public void Init(List<T> data)
	{
	}

	private void OnScrollChanged(Vector2 _)
	{
	}

	public void UpdateVisibleItems()
	{
	}

	private void OnDestroy()
	{
	}
}
