using System;
using FunGames.Core.Modules;

namespace FunGames.Core
{
	public class FGCoreCallbacks : FGModuleCallbacks
	{
		internal Action _onAdsRemoved;

		internal Action _onAdsRestored;

		private Action<Uri> _fgDeeplinkActivated;

		public event Action OnAdsRemoved
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action OnAdsRestored
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<Uri> FGDeeplinkActivated
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

		internal void TriggerFGDeeplinkActivated(Uri uri)
		{
		}
	}
}
