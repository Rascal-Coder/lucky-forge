using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CBS.Models;
using CBS.Scriptable;
using CBS.Utils;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace CBS.UI
{
	public class AvatarDrawer : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDisplayFromUrl_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string url;

			public AvatarDrawer _003C_003E4__this;

			public string profile;

			private UnityWebRequest _003Cwww_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDisplayFromUrl_003Ed__37(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private protected Image AvatarImage;

		[SerializeField]
		private protected Image OnlineImage;

		protected ProfileConfigData Config { get; set; }

		private AvatarIcons AvatarsData { get; set; }

		protected AvatarDisplayOptions DisplayOption { get; set; }

		protected bool UseCache { get; set; }

		protected bool UseOnline { get; set; }

		protected string ProfileID { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void DrawOnlineStatus(OnlineStatusData info)
		{
		}

		public void LoadAvatarFromUrl(string url, string profileID)
		{
		}

		public void LoadProfileAvatar(string profileID, AvatarInfo info)
		{
		}

		public void LoadProfileAvatar(string profileID)
		{
		}

		public void SetClickable(string profileID)
		{
		}

		public virtual void ClickAvatar()
		{
		}

		public virtual void DisplayDefaultAvatar()
		{
		}

		public virtual void DisplaySpriteAvatar(string avatarID)
		{
		}

		[IteratorStateMachine(typeof(_003CDisplayFromUrl_003Ed__37))]
		protected IEnumerator DisplayFromUrl(string url, string profile)
		{
			return null;
		}
	}
}
