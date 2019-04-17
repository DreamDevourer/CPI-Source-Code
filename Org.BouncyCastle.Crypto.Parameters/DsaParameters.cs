// DsaParameters
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using System;

public class DsaParameters : ICipherParameters
{
	private readonly BigInteger p;

	private readonly BigInteger q;

	private readonly BigInteger g;

	private readonly DsaValidationParameters validation;

	public BigInteger P => p;

	public BigInteger Q => q;

	public BigInteger G => g;

	public DsaValidationParameters ValidationParameters => validation;

	public DsaParameters(BigInteger p, BigInteger q, BigInteger g)
		: this(p, q, g, null)
	{
	}

	public DsaParameters(BigInteger p, BigInteger q, BigInteger g, DsaValidationParameters parameters)
	{
		if (p == null)
		{
			throw new ArgumentNullException("p");
		}
		if (q == null)
		{
			throw new ArgumentNullException("q");
		}
		if (g == null)
		{
			throw new ArgumentNullException("g");
		}
		this.p = p;
		this.q = q;
		this.g = g;
		validation = parameters;
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		DsaParameters dsaParameters = obj as DsaParameters;
		if (dsaParameters == null)
		{
			return false;
		}
		return Equals(dsaParameters);
	}

	protected bool Equals(DsaParameters other)
	{
		if (p.Equals(other.p) && q.Equals(other.q))
		{
			return g.Equals(other.g);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return p.GetHashCode() ^ q.GetHashCode() ^ g.GetHashCode();
	}
}
