public static class MeduPow
{
	public static double Pow(double num, int exp)
	{
        // Native0x2008b48: nonpositive exponents return1, no reciprocal branch.
        double result=1.0;
        while (exp>=1)
        {
            if ((exp&1)!=0) result*=num;
            num*=num;
            exp=(int)((uint)exp>>1);
        }
        return result;
	}

	public static double PowFloat(double num, float exp)
	{
        return 1.0; // Native0x2008b88 has only fmov1 + ret, regardless of arguments.
	}
}
