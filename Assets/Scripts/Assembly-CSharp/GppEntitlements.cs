public static class GppEntitlements
{
	private const string GppGrantedNoAdsKey = "GppGrantedNoAds";

	private const string GppGrantedVipPackKey = "GppGrantedVipPack";

	private const string GppGrantedPremiumPassKey = "GppGrantedPremiumPass";

	public static void Apply()
	{
	}

	public static void Revoke()
	{
	}

	public static bool IsGamePassAvailable()
	{
		return false;
	}

	public static void ApplyGamePass()
	{
	}

	public static bool TryApplyGamePass()
	{
		return false;
	}

	private static void ApplyNoAds()
	{
	}

	private static void ApplyVip()
	{
	}

	private static void RevokeNoAds()
	{
	}

	private static void RevokeVip()
	{
	}

	private static void RevokeGamePass()
	{
	}

	private static bool ShouldRevokeGppEntitlement(string gppGrantedKey, string entitlementKey, string iapProductId)
	{
		return false;
	}

	private static bool HasPurchasedProduct(string productId)
	{
		return false;
	}
}
