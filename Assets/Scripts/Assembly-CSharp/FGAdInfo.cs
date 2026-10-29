public class FGAdInfo
{
	private string _defaultPlacement;

	public string AdUnitIdentifier { get; set; }

	public string AdFormat { get; private set; }

	public string NetworkName { get; private set; }

	public string NetworkPlacement { get; private set; }

	public string Placement
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string CreativeIdentifier { get; private set; }

	public double Revenue { get; private set; }

	public string RevenuePrecision { get; private set; }

	public FGAdInfo()
	{
	}

	public FGAdInfo(string AdUnitIdentifier, string AdFormat, string NetworkName, string NetworkPlacement, string Placement, string CreativeIdentifier, double Revenue, string RevenuePrecision)
	{
	}

	public void Reset()
	{
	}

	private string GetDefault()
	{
		return null;
	}

	private void SetDefault(string value)
	{
	}

	public void Set(FGAdInfo adInfo)
	{
	}

	public override string ToString()
	{
		return null;
	}
}
