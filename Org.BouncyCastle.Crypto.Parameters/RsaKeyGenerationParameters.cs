// RsaKeyGenerationParameters
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

public class RsaKeyGenerationParameters : KeyGenerationParameters
{
	private readonly BigInteger publicExponent;

	private readonly int certainty;

	public BigInteger PublicExponent => publicExponent;

	public int Certainty => certainty;

	public RsaKeyGenerationParameters(BigInteger publicExponent, SecureRandom random, int strength, int certainty)
		: base(random, strength)
	{
		this.publicExponent = publicExponent;
		this.certainty = certainty;
	}

	public override bool Equals(object obj)
	{
		RsaKeyGenerationParameters rsaKeyGenerationParameters = obj as RsaKeyGenerationParameters;
		if (rsaKeyGenerationParameters == null)
		{
			return false;
		}
		if (certainty == rsaKeyGenerationParameters.certainty)
		{
			return publicExponent.Equals(rsaKeyGenerationParameters.publicExponent);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return certainty.GetHashCode() ^ publicExponent.GetHashCode();
	}
}
