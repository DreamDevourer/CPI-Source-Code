// IDrbgProvider
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Prng.Drbg;

internal interface IDrbgProvider
{
	ISP80090Drbg Get(IEntropySource entropySource);
}
