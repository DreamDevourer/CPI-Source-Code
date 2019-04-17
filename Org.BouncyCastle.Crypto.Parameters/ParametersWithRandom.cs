// ParametersWithRandom
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;

public class ParametersWithRandom : ICipherParameters
{
	private readonly ICipherParameters parameters;

	private readonly SecureRandom random;

	public SecureRandom Random => random;

	public ICipherParameters Parameters => parameters;

	public ParametersWithRandom(ICipherParameters parameters, SecureRandom random)
	{
		if (parameters == null)
		{
			throw new ArgumentNullException("parameters");
		}
		if (random == null)
		{
			throw new ArgumentNullException("random");
		}
		this.parameters = parameters;
		this.random = random;
	}

	public ParametersWithRandom(ICipherParameters parameters)
		: this(parameters, new SecureRandom())
	{
	}

	[Obsolete("Use Random property instead")]
	public SecureRandom GetRandom()
	{
		return Random;
	}
}
