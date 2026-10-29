using CBS.Core;
using CBS.Models;
using UnityEngine;

namespace CBS.UI
{
	public class RouletteScroller : PreloadScroller<RoulettePosition>
	{
		protected override float DeltaToPreload => 0f;

		private ScrollerSide CacheDirection { get; set; }

		private void Start()
		{
		}

		public void SetPoolCount(int value)
		{
		}

		public void SetPosition(float positionX)
		{
		}

		public void SetLocalPosition(float positionX, float t)
		{
		}

		public void ResetPosition()
		{
		}

		public float GetPositionX()
		{
			return 0f;
		}

		public float GetDelta()
		{
			return 0f;
		}

		public float GetContentSpace()
		{
			return 0f;
		}

		public int GetPoolIndex()
		{
			return 0;
		}

		public GameObject GetLastViewObject()
		{
			return null;
		}

		public void PrepareFinishAnimation()
		{
		}

		public void PushForward(int num)
		{
		}
	}
}
