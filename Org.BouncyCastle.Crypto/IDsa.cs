// IDsa
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math;

public interface IDsa
{
	string AlgorithmName
	{
		get;
	}

	void Init(bool forSigning, ICipherParameters parameters);

	BigInteger[] GenerateSignature(byte[] message);

	bool VerifySignature(byte[] message, BigInteger r, BigInteger s);
}
