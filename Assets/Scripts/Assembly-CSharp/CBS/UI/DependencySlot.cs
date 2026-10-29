using CBS.Core;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class DependencySlot : MonoBehaviour, IScrollableItem<ItemDependencyState>
	{
		[SerializeField]
		private Text NeedTitle;

		[SerializeField]
		private Text PresentTitle;

		[SerializeField]
		private Image Icon;

		[SerializeField]
		private GameObject CheckMark;

		[SerializeField]
		private GameObject Close;

		private CurrencyIcons CurrencyIcons { get; set; }

		private ItemsIcons ItemsIcons { get; set; }

		private void Awake()
		{
		}

		public void Display(ItemDependencyState item)
		{
		}
	}
}
