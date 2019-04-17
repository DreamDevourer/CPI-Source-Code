// ElGamalParameter
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Math;
using System;

public class ElGamalParameter : Asn1Encodable
{
	internal DerInteger p;

	internal DerInteger g;

	public BigInteger P => p.PositiveValue;

	public BigInteger G => g.PositiveValue;

	public ElGamalParameter(BigInteger p, BigInteger g)
	{
		this.p = new DerInteger(p);
		this.g = new DerInteger(g);
	}

	public ElGamalParameter(Asn1Sequence seq)
	{
		if (seq.Count != 2)
		{
			throw new ArgumentException("Wrong number of elements in sequence", "seq");
		}
		p = DerInteger.GetInstance(seq[0]);
		g = DerInteger.GetInstance(seq[1]);
	}

	public override Asn1Object ToAsn1Object()
	{
		return new DerSequence(p, g);
	}
}
