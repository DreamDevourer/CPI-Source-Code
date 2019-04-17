// IDsaKCalculator
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

public interface IDsaKCalculator
{
	bool IsDeterministic
	{
		get;
	}

	void Init(BigInteger n, SecureRandom random);

	void Init(BigInteger n, BigInteger d, byte[] message);

	BigInteger NextK();
}
