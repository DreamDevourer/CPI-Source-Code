// Pkcs5Scheme2Utf8PbeKey
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using System;

public class Pkcs5Scheme2Utf8PbeKey : CmsPbeKey
{
	[Obsolete("Use version taking 'char[]' instead")]
	public Pkcs5Scheme2Utf8PbeKey(string password, byte[] salt, int iterationCount)
		: this(password.ToCharArray(), salt, iterationCount)
	{
	}

	[Obsolete("Use version taking 'char[]' instead")]
	public Pkcs5Scheme2Utf8PbeKey(string password, AlgorithmIdentifier keyDerivationAlgorithm)
		: this(password.ToCharArray(), keyDerivationAlgorithm)
	{
	}

	public Pkcs5Scheme2Utf8PbeKey(char[] password, byte[] salt, int iterationCount)
		: base(password, salt, iterationCount)
	{
	}

	public Pkcs5Scheme2Utf8PbeKey(char[] password, AlgorithmIdentifier keyDerivationAlgorithm)
		: base(password, keyDerivationAlgorithm)
	{
	}

	internal override KeyParameter GetEncoded(string algorithmOid)
	{
		Pkcs5S2ParametersGenerator pkcs5S2ParametersGenerator = new Pkcs5S2ParametersGenerator();
		pkcs5S2ParametersGenerator.Init(PbeParametersGenerator.Pkcs5PasswordToUtf8Bytes(password), salt, iterationCount);
		return (KeyParameter)pkcs5S2ParametersGenerator.GenerateDerivedParameters(algorithmOid, CmsEnvelopedHelper.Instance.GetKeySize(algorithmOid));
	}
}
