using System;
using CBS.Models;

namespace CBS
{
	public interface IRoulette
	{
		void GetRouletteTable(Action<CBSGetRouletteTableResult> result);

		void Spin(Action<CBSSpinRouletteResult> result);
	}
}
