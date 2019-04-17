// VerifierCalculator
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Operators;
using System.IO;

internal class VerifierCalculator : IStreamCalculator
{
	private readonly ISigner sig;

	private readonly Stream stream;

	public Stream Stream => stream;

	internal VerifierCalculator(ISigner sig)
	{
		this.sig = sig;
		stream = new SignerBucket(sig);
	}

	public object GetResult()
	{
		return new VerifierResult(sig);
	}
}
