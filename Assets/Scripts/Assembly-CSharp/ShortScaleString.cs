using UnityEngine;

public class ShortScaleString : MonoBehaviour
{
	private static string[] ShortScaleReference = new string[] { "", "M", "B", "T", "AA", "AB", "AC", "AD", "BA", "BB", "BC", "BD", "CA", "CB", "CC", "DA", "DB", "DC", "DD", "EA", "EB", "EC", "ED", "EE", "FA", "FB", "FC", "FD", "FE", "FF", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JJ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KJ", "KK", "LA", "LB", "LC", "LD", "LE", "LF", "LG", "LH", "LJ", "LK", "LL", "MA", "MB", "MC", "MD", "ME", "MF", "MG", "MH", "MJ", "MK", "ML", "MM", "NA", "NB", "NC", "ND", "NE", "NF", "NG", "NH", "NJ", "NK", "NL", "NM", "NN", "ZZ", "ZA", "ZB", "ZC", "ZD", "ZE", "ZF", "ZG", "ZH", "ZI", "ZJ", "ZK", "ZL", "ZM", "ZN", "ZO", "ZP", "ZQ", "ZR", "ZS", "ZT", "ZU", "ZV", "ZW", "ZX", "ZY", "ZZ", "AAA", "AAB", "AAC", "AAD", "AAE", "AAF", "AAG", "AAH", "AAI", "AAJ", "AAK", "AAL", "AAM", "AAN", "AAO", "AAP", "AAQ", "AAR", "AAS", "AAT", "AAU", "AAV", "AAW", "AAX", "AAY", "AAZ", "ABA", "ABB", "ABC", "ABD", "ABE", "ABF", "ABG", "ABH", "ABI", "ABJ", "ABK", "ABL", "ABM", "ABN", "ABO", "ABP", "ABQ", "ABR", "ABS", "ABT", "ABU", "ABV", "ABW", "ABX", "ABY", "ABZ" };

	private static string[] ShortScaleReferenceforMini = new string[] { "", "k", "m", "b", "t", "q", "g", "qq", "ww", "ee", "rr", "tt", "yy", "uu" };

	public static string ParseMini_int(double value, int precision = 2, int startShortScale = 1000)
	{
		return null;
	}

	public static string parseDouble(double value, int precision = 1, double startShortScale = 1000000.0, bool top = false)
	{
        // Native0x202bf5c, exact suffix initialization from0x203e234.
        string decimalPlaces=new string('#',precision);
        double factor=MeduPow.Pow(10.0,precision);
        double sign=value<0 ? -1.0 : 1.0;
        double magnitude=value<0 ? -value : value;
        // Native unordered comparison reaches suffix[-1] and throws.
        if (double.IsNaN(magnitude)) throw new System.IndexOutOfRangeException();
        if (!(magnitude>=1000.0 && magnitude>=startShortScale))
        {
            if (magnitude<1.0) return "0";
            return (System.Math.Floor(magnitude*sign*factor)/factor).ToString("#,#.");
        }
        int suffix=-1;
        while (magnitude>=1000.0 && suffix<ShortScaleReference.Length-1)
        {
            magnitude/=1000.0;
            suffix++;
        }
        string number=(System.Math.Floor(sign*magnitude*factor)/factor).ToString("#,#."+decimalPlaces).ToUpper();
        string abbreviation=ShortScaleReference[suffix].ToUpper();
        return top ? number+" <color=#7AFF56>"+abbreviation+"</color>" : number+" "+abbreviation;
	}

	public static string parseFloat(float value, int precision = 3, float startShortScale = 1000000f)
	{
		return null;
	}

	public static string parseYuzde(float value, int precision = 3, float startShortScale = 1000000f)
	{
		return null;
	}

	public static string parseInt(int value, int precision = 3, int startShortScale = 1000000)
	{
		return null;
	}
}
