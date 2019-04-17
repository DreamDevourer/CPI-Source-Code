// IFiniteField
using Org.BouncyCastle.Math;

public interface IFiniteField
{
	BigInteger Characteristic
	{
		get;
	}

	int Dimension
	{
		get;
	}
}
