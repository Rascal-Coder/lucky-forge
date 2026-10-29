using System;
using CBS.Models;
using CBS.Playfab;

namespace CBS
{
	public class CBSRouletteModule : CBSModule, IRoulette
	{
		private IFabRoulette FabRoulette { get; set; }

		private IProfile Profile { get; set; }

		protected override void Init()
		{
		}

		public void GetRouletteTable(Action<CBSGetRouletteTableResult> result)
		{
		}

		public void Spin(Action<CBSSpinRouletteResult> result)
		{
		}
	}
}
