// DsaPrivateKeyParameters
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using System;

public class DsaPrivateKeyParameters : DsaKeyParameters
{
	private readonly BigInteger x;

	public BigInteger X => x;

	public DsaPrivateKeyParameters(BigInteger x, DsaParameters parameters)
		: base(isPrivate: true, parameters)
	{
		if (x == null)
		{
			throw new ArgumentNullException("x");
		}
		this.x = x;
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		DsaPrivateKeyParameters dsaPrivateKeyParameters = obj as DsaPrivateKeyParameters;
		if (dsaPrivateKeyParameters == null)
		{
			return false;
		}
		return Equals(dsaPrivateKeyParameters);
	}

	protected bool Equals(DsaPrivateKeyParameters other)
	{
		if (x.Equals(other.x))
		{
			return Equals((DsaKeyParameters)other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return x.GetHashCode() ^ base.GetHashCode();
	}
}
