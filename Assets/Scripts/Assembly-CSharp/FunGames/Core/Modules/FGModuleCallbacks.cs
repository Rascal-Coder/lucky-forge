using System;

namespace FunGames.Core.Modules
{
	public class FGModuleCallbacks
	{
		internal Action _onStart;

		internal Action _onInitialization;

		internal Action<bool> _onInitialized;

		public event Action Initialization
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<bool> OnInitialized
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action OnStart
		{
			add
			{
			}
			remove
			{
			}
		}

		public virtual void Clear()
		{
		}
	}
}
