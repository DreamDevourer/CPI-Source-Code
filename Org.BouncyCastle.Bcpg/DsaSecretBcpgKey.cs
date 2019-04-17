// DsaSecretBcpgKey
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Math;
using System;

public class DsaSecretBcpgKey : BcpgObject, IBcpgKey
{
	internal MPInteger x;

	public string Format => "PGP";

	public BigInteger X => x.Value;

	public DsaSecretBcpgKey(BcpgInputStream bcpgIn)
	{
		x = new MPInteger(bcpgIn);
	}

	public DsaSecretBcpgKey(BigInteger x)
	{
		this.x = new MPInteger(x);
	}

	public override byte[] GetEncoded()
	{
		try
		{
			return base.GetEncoded();
		}
		catch (Exception)
		{
			return null;
		}
	}

	public override void Encode(BcpgOutputStream bcpgOut)
	{
		bcpgOut.WriteObject(x);
	}
}
