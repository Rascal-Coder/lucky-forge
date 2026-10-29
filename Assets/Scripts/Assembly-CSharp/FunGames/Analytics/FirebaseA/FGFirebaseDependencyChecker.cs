using System;
using Firebase;
using FunGames.Tools.Utils;
using UnityEngine;

namespace FunGames.Analytics.FirebaseA
{
	public class FGFirebaseDependencyChecker : Singleton<FGFirebaseDependencyChecker>
	{
		[HideInInspector]
		public DependencyStatus Status;

		private bool _statusChecked;

		private Action<DependencyStatus> _onDependencyResolved;

		private bool _checkAlreadyRequested;

		[HideInInspector]
		public bool StatusChecked => false;

		public event Action<DependencyStatus> OnDependencyResolved
		{
			add
			{
			}
			remove
			{
			}
		}

		public void StartChecking()
		{
		}
	}
}
