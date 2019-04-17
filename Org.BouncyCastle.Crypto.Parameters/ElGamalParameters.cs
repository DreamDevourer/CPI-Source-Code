// ElGamalParameters
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using System;

public class ElGamalParameters : ICipherParameters
{
	private readonly BigInteger p;

	private readonly BigInteger g;

	private readonly int l;

	public BigInteger P => p;

	public BigInteger G => g;

	public int L => l;

	public ElGamalParameters(BigInteger p, BigInteger g)
		: this(p, g, 0)
	{
	}

	public ElGamalParameters(BigInteger p, BigInteger g, int l)
	{
		if (p == null)
		{
			throw new ArgumentNullException("p");
		}
		if (g == null)
		{
			throw new ArgumentNullException("g");
		}
		this.p = p;
		this.g = g;
		this.l = l;
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		ElGamalParameters elGamalParameters = obj as ElGamalParameters;
		if (elGamalParameters == null)
		{
			return false;
		}
		return Equals(elGamalParameters);
	}

	protected bool Equals(ElGamalParameters other)
	{
		if (p.Equals(other.p) && g.Equals(other.g))
		{
			return l == other.l;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return p.GetHashCode() ^ g.GetHashCode() ^ l;
	}
}
