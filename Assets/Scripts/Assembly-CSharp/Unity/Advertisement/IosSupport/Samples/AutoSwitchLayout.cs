using UnityEngine;

namespace Unity.Advertisement.IosSupport.Samples
{
	[ExecuteInEditMode]
	public class AutoSwitchLayout : MonoBehaviour
	{
		public Transform portraitModeLayoutTransform;

		public Transform landscapeModeLayoutTransform;

		private float m_PreviousAspectRatio;

		private void Update()
		{
		}
	}
}
