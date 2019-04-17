// RsaKeyParameters
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using System;

public class RsaKeyParameters : AsymmetricKeyParameter
{
	private readonly BigInteger modulus;

	private readonly BigInteger exponent;

	public BigInteger Modulus => modulus;

	public BigInteger Exponent => exponent;

	public RsaKeyParameters(bool isPrivate, BigInteger modulus, BigInteger exponent)
		: base(isPrivate)
	{
		if (modulus == null)
		{
			throw new ArgumentNullException("modulus");
		}
		if (exponent == null)
		{
			throw new ArgumentNullException("exponent");
		}
		if (modulus.SignValue <= 0)
		{
			throw new ArgumentException("Not a valid RSA modulus", "modulus");
		}
		if (exponent.SignValue <= 0)
		{
			throw new ArgumentException("Not a valid RSA exponent", "exponent");
		}
		this.modulus = modulus;
		this.exponent = exponent;
	}

	public override bool Equals(object obj)
	{
		RsaKeyParameters rsaKeyParameters = obj as RsaKeyParameters;
		if (rsaKeyParameters == null)
		{
			return false;
		}
		if (rsaKeyParameters.IsPrivate == base.IsPrivate && rsaKeyParameters.Modulus.Equals(modulus))
		{
			return rsaKeyParameters.Exponent.Equals(exponent);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return modulus.GetHashCode() ^ exponent.GetHashCode() ^ base.IsPrivate.GetHashCode();
	}
}
