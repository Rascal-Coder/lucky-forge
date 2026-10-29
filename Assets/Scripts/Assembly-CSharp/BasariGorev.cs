using System;

[Serializable]
public class BasariGorev
{
	public int GorevType;

	public int expReward;

	public int maxValue;

	public int StartMaxValue;

	public int currentCount;

	public bool isCompleted;

	public bool isCollected;

	public int OdulType;

	public int KacKereYapildi;

	public bool ilk10da;

	public BasariGorev(int gorevType, int maxValue, int startMaxValue, int odulType, int expReward, int kacKereYapildi, bool ilksiralarda = false)
	{
        // Original ARM64 recovery 0x21b12b4.
        GorevType=gorevType;this.maxValue=maxValue;StartMaxValue=startMaxValue;OdulType=odulType;this.expReward=expReward;KacKereYapildi=kacKereYapildi;ilk10da=ilksiralarda;currentCount=0;isCompleted=false;isCollected=false;
	}
}
