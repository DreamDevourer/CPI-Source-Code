// DsaKeyGenerationParameters
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

public class DsaKeyGenerationParameters : KeyGenerationParameters
{
	private readonly DsaParameters parameters;

	public DsaParameters Parameters => parameters;

	public DsaKeyGenerationParameters(SecureRandom random, DsaParameters parameters)
		: base(random, parameters.P.BitLength - 1)
	{
		this.parameters = parameters;
	}
}
