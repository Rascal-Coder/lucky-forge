using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI.Utils
{
	[RequireComponent(typeof(InputField))]
	public class CBSInputField : MonoBehaviour
	{
		private InputField InputField { get; set; }

		private void Start()
		{
		}

		private void OnEndEdit(string txt)
		{
		}
	}
}
