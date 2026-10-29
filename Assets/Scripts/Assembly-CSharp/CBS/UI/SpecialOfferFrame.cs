using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class SpecialOfferFrame : MonoBehaviour
	{
		[SerializeField]
		private Image Icon;

		[SerializeField]
		private Text Label;

		protected CBSSpecialOffer Offer { get; private set; }

		protected RectTransform Rect { get; private set; }

		protected StorePrefabs Prefabs { get; private set; }

		protected virtual void Awake()
		{
		}

		public virtual void Load(CBSSpecialOffer offer)
		{
		}

		private void OnDisable()
		{
		}

		private void DisplayTimer()
		{
		}

		private void LateUpdate()
		{
		}

		public void ShowOfferWindow()
		{
		}
	}
}
