using System;
using UnityEngine;

namespace FunGames.UserConsent.GDPR.CustomGDPR
{
	public abstract class FGGDPRDisplayAbstract : MonoBehaviour
	{
		public int RemoteConfigValue;

		public GdprFlexibility Flexibility;

		private Action<FGGDPRStatus> _validate;

		[HideInInspector]
		protected FGGDPRStatus status;

		public event Action<FGGDPRStatus> OnValidated
		{
			add
			{
			}
			remove
			{
			}
		}

		private void Awake()
		{
		}

		protected abstract void OnAwake();

		public void ShowGDPR()
		{
		}

		public void ValidateGDPR()
		{
		}
	}
}
