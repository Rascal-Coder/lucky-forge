using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class GlobalChatWindow : MonoBehaviour
	{
		[SerializeField]
		private ChatView ChatUI;

		[SerializeField]
		private ToggleGroup CategoryGroup;

		[SerializeField]
		private Transform TitlesRoot;

		private ICBSChat CBSChat { get; set; }

		private CommonPrefabs Prefabs { get; set; }

		private ChatTitle SelectedChat { get; set; }

		private ChatInstance ActiveChat { get; set; }

		private void Awake()
		{
		}

		public void OnEnable()
		{
		}

		private void DisplayChatTitles()
		{
		}

		private void OnTitleSelected(string title)
		{
		}
	}
}
