using System;
using System.Collections.Generic;

[Serializable]
public class WaveRewardGroup
{
	public int wave;

	public List<WaveReward> rewards = new List<WaveReward>(); // Original 0x21b2bd4
}
