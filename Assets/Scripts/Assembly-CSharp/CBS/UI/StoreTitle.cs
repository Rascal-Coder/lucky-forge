using System;
using CBS.Core;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	[RequireComponent(typeof(Toggle))]
	public class StoreTitle : MonoBehaviour, IScrollableItem<CBSStoreTitle>
	{
		[SerializeField]
		private Color ActiveColor;

		[SerializeField]
		private Color DisableColor;

		[SerializeField]
		private Text Title;

		private Toggle Toggle { get; set; }

		private Action<CBSStoreTitle> ChangeAction { get; set; }

		private CBSStoreTitle Store { get; set; }

		private RectTransform RootRect { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void Display(CBSStoreTitle store)
		{
		}

		public void SetChangeAction(Action<CBSStoreTitle> changeAction)
		{
		}

		public void SetGroup(ToggleGroup group)
		{
		}

		public void Activate()
		{
		}

		private void Resize()
		{
		}

		private void UpdateLabelColor()
		{
		}

		private void OnToggleChange(bool val)
		{
		}
	}
}
