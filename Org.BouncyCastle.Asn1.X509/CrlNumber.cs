// CrlNumber
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Math;

public class CrlNumber : DerInteger
{
	public BigInteger Number => base.PositiveValue;

	public CrlNumber(BigInteger number)
		: base(number)
	{
	}

	public override string ToString()
	{
		return "CRLNumber: " + Number;
	}
}
