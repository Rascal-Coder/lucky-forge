using System;
using UnityEngine;

namespace FunGames.Core.QAMode
{
	internal abstract class FGQAScreenAbstract : MonoBehaviour
	{
		public Action<bool, string> RequestUpdateLoadingPopup;

		public Action<string, string, Action> RequestShowErrorPopup;

		protected void SetLoadingPopup(bool visible, string message = "Loading...")
		{
		}

		protected void ShowErrorPopup(string errorMessage, string ctaText, Action ctaAction)
		{
		}
	}
}
