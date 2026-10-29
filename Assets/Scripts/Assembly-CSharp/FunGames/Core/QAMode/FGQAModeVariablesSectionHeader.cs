using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace FunGames.Core.QAMode
{
	internal class FGQAModeVariablesSectionHeader : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CAnimateFoldoutCoroutine_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FGQAModeVariablesSectionHeader _003C_003E4__this;

			public float duration;

			public float targetRotationZ;

			private RectTransform _003CrectTransform_003E5__2;

			private float _003CstartRotationZ_003E5__3;

			private float _003CelapsedTime_003E5__4;

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
			public _003CAnimateFoldoutCoroutine_003Ed__13(int _003C_003E1__state)
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private Image foldoutImage;

		[SerializeField]
		private Button foldoutButton;

		[SerializeField]
		private bool expanded;

		public Action<bool> FoldoutToggled;

		private const float EXPANDED_ROTATION_Z = 0f;

		private const float COLLAPSED_ROTATION_Z = -90f;

		private Coroutine _rotationCoroutine;

		public bool IsExpanded => false;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnFoldoutClicked()
		{
		}

		private void SetExpanded(bool isExpanded, bool animate)
		{
		}

		[IteratorStateMachine(typeof(_003CAnimateFoldoutCoroutine_003Ed__13))]
		private IEnumerator AnimateFoldoutCoroutine(float targetRotationZ, float duration = 0.2f)
		{
			return null;
		}
	}
}
