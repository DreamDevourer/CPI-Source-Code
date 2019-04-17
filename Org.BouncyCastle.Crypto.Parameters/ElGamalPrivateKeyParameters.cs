// ElGamalPrivateKeyParameters
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using System;

public class ElGamalPrivateKeyParameters : ElGamalKeyParameters
{
	private readonly BigInteger x;

	public BigInteger X => x;

	public ElGamalPrivateKeyParameters(BigInteger x, ElGamalParameters parameters)
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
		ElGamalPrivateKeyParameters elGamalPrivateKeyParameters = obj as ElGamalPrivateKeyParameters;
		if (elGamalPrivateKeyParameters == null)
		{
			return false;
		}
		return Equals(elGamalPrivateKeyParameters);
	}

	protected bool Equals(ElGamalPrivateKeyParameters other)
	{
		if (other.x.Equals(x))
		{
			return Equals((ElGamalKeyParameters)other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return x.GetHashCode() ^ base.GetHashCode();
	}
}
