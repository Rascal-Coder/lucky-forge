using System;
using CBS.Core;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	[RequireComponent(typeof(Toggle))]
	public class StickerDrawer : MonoBehaviour, IScrollableItem<ChatSticker>
	{
		[SerializeField]
		private Image Icon;

		private Toggle Toggle { get; set; }

		private ChatSticker Sticker { get; set; }

		private Action<ChatSticker> SelectAction { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void Display(ChatSticker sticker)
		{
		}

		public void Configure(Action<ChatSticker> selectAction, ToggleGroup toggleGroup)
		{
		}

		private void OnToggleValueChanged(bool val)
		{
		}
	}
}
