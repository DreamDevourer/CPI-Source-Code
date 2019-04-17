// ISignerWithRecovery
using Org.BouncyCastle.Crypto;

public interface ISignerWithRecovery : ISigner
{
	bool HasFullMessage();

	byte[] GetRecoveredMessage();

	void UpdateWithRecoveredMessage(byte[] signature);
}
