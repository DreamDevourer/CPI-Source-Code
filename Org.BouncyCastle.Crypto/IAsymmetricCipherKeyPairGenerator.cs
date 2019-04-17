// IAsymmetricCipherKeyPairGenerator
using Org.BouncyCastle.Crypto;

public interface IAsymmetricCipherKeyPairGenerator
{
	void Init(KeyGenerationParameters parameters);

	AsymmetricCipherKeyPair GenerateKeyPair();
}
