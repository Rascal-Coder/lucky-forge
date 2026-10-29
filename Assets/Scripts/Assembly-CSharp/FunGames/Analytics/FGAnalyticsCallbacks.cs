using System;
using System.Collections.Generic;
using FunGames.Core.Modules;

namespace FunGames.Analytics
{
	public class FGAnalyticsCallbacks : FGModuleCallbacks
	{
		internal Action<LevelStatus, string, int> _ProgressionEvent01;

		internal Action<LevelStatus, string, string, int> _ProgressionEvent02;

		internal Action<LevelStatus, string, string, string, int> _ProgressionEvent03;

		internal Action<string, float> _DesignEventSimple;

		internal Action<string, Dictionary<string, object>, float> _DesignEventDictio;

		internal Action<AdAction, AdType, string, string> _AdEvent;

		internal Action<string, bool> _EventReceived;

		public event Action<LevelStatus, string, int> OnSendProgressionEvent01
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<LevelStatus, string, string, int> OnSendProgressionEvent02
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<LevelStatus, string, string, string, int> OnSendProgressionEvent03
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<string, float> OnSendDesignEventSimple
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<string, Dictionary<string, object>, float> OnSendDesignEventDictio
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<AdAction, AdType, string, string> OnSendAdEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<string, bool> OnEventReceived
		{
			add
			{
			}
			remove
			{
			}
		}

		public override void Clear()
		{
		}
	}
}
