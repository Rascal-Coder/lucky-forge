using System;

[Serializable]
public class GunlukGorev
{
	public int GorevType;

	public int expReward;

	public int maxValue;

	public int currentCount;

	public bool isCompleted;

	public bool isCollected;

	public int OdulType;

	public bool reklamli;

	public GunlukGorev(int _gorevType, int _maxValue, int _odulType, int _expReward, bool _reklam)
	{
        // Original ARM64 recovery 0x1f7c6b8.
        GorevType=_gorevType;maxValue=_maxValue;OdulType=_odulType;expReward=_expReward;reklamli=_reklam;currentCount=0;isCompleted=false;isCollected=false;
	}
}
