using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FunGames.Tools.Debugging
{
	public class FGDebugConsole : FGSingleton<FGDebugConsole>
	{
		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private ScrollRect _scrollRect;

		private string _lastMessage;

		private Dictionary<int, StringBuilder> LogsDictionary;

		private StringBuilder currentLogBuilder;

		[Range(1000f, 16000f)]
		public int MaxLogSize;

		public void Init()
		{
		}

		private void OnLogReceived(string message, string stacktrace, LogType type)
		{
		}

		public void Clear()
		{
		}

		public void AddMessage(string text)
		{
		}

		public void OnDestroy()
		{
		}
	}
}
