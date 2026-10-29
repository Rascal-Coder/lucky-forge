public static class RewardRateProvider
{
	public static RewardRates GetRates(int level)
	{
        // Original ARM64 0x201a384.
        float nativeLevel=(float)level;
        float scroll=(float)((float)(nativeLevel*0.05f)+1.5f);scroll=scroll<1.5f?1.5f:scroll>5.5f?5.5f:scroll;
        float scaledCoin=(float)(nativeLevel*0.07f);
        float coin=scaledCoin<0f?4f:scaledCoin>2f?6f:(float)((float)(scaledCoin+1f)+3f);
        float talent=(float)((float)(nativeLevel*0.03f)+1f);talent=talent<1f?0.5f:talent>3f?1.5f:(float)(talent*0.5f);
        return new RewardRates{coinPerMin=coin,talentScrollPerMin=talent,weaponTokenPerMin=0.2f,gearScrollsPerMin=new float[]{scroll,scroll,scroll,scroll,scroll,scroll}};
	}
}
