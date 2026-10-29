using CBS.Core;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class RouletteSlot : MonoBehaviour, IScrollableItem<RoulettePosition>
	{
		[SerializeField]
		private Image Icon;

		[SerializeField]
		private Image Background;

		private RoulettePosition Position { get; set; }

		public string ID => null;

		public void Display(RoulettePosition data)
		{
		}

		public void ToDefault()
		{
		}

		public void Activate()
		{
		}
	}
}
