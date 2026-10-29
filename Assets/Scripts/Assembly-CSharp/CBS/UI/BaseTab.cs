using System;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	[RequireComponent(typeof(Toggle))]
	public class BaseTab<T> : MonoBehaviour where T : class
	{
		[SerializeField]
		private Text Title;

		private T tabObject;

		public T TabObject
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private Action<T> SelectAction { get; set; }

		private Toggle Toggle { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void SetSelectAction(Action<T> action)
		{
		}

		private void OnToggleValueChanged(bool val)
		{
		}
	}
}
