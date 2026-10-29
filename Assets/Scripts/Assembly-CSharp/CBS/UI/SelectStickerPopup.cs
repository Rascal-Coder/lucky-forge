using System;
using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class SelectStickerPopup : MonoBehaviour
	{
		[SerializeField]
		private StickerScroller Scroller;

		[SerializeField]
		private GameObject SendButton;

		[SerializeField]
		private ToggleGroup Group;

		private ICBSChat Chat { get; set; }

		private ChatPrefabs ChatPrefabs { get; set; }

		private Action<ChatSticker> SelectAction { get; set; }

		private ChatSticker SelectedSticker { get; set; }

		private void Awake()
		{
		}

		public void Show(Action<ChatSticker> selectAction)
		{
		}

		private void LoadStickers()
		{
		}

		private void DisplayStickers(List<ChatSticker> stickers)
		{
		}

		private void OnGetStickers(CBSGetStickersResult result)
		{
		}

		private void OnSelectSticker(ChatSticker sticker)
		{
		}

		public void SelectStickerHandler()
		{
		}
	}
}
