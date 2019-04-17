// DHPublicKeyParameters
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using System;

public class DHPublicKeyParameters : DHKeyParameters
{
	private readonly BigInteger y;

	public BigInteger Y => y;

	public DHPublicKeyParameters(BigInteger y, DHParameters parameters)
		: base(isPrivate: false, parameters)
	{
		if (y == null)
		{
			throw new ArgumentNullException("y");
		}
		this.y = y;
	}

	public DHPublicKeyParameters(BigInteger y, DHParameters parameters, DerObjectIdentifier algorithmOid)
		: base(isPrivate: false, parameters, algorithmOid)
	{
		if (y == null)
		{
			throw new ArgumentNullException("y");
		}
		this.y = y;
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		DHPublicKeyParameters dHPublicKeyParameters = obj as DHPublicKeyParameters;
		if (dHPublicKeyParameters == null)
		{
			return false;
		}
		return Equals(dHPublicKeyParameters);
	}

	protected bool Equals(DHPublicKeyParameters other)
	{
		if (y.Equals(other.y))
		{
			return Equals((DHKeyParameters)other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return y.GetHashCode() ^ base.GetHashCode();
	}
}
