using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CBS.UI
{
	public class ComplexAvatarTabListener : MonoBehaviour
	{
		[CompilerGenerated]
		private Action<AvatarComplexPart> m_OnTabSelected;

		[SerializeField]
		private GameObject[] AllTabs;

		public AvatarComplexPart ActiveTab { get; private set; }

		public event Action<AvatarComplexPart> OnTabSelected
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnToggleSelected(bool val)
		{
		}
	}
}
