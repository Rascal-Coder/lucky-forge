using System;
using System.Diagnostics;

namespace FunGames.Tools.Utils
{
	public class GitProcess
	{
		private ProcessStartInfo _gitProcessInfo;

		private string _command;

		private Action<bool> _ended;

		public event Action<bool> OnThreadEnded
		{
			add
			{
			}
			remove
			{
			}
		}

		public GitProcess(string command, string repositoryPath)
		{
		}

		public string Run()
		{
			return null;
		}

		private void KillProcess(Process process)
		{
		}

		public void Kill()
		{
		}
	}
}
