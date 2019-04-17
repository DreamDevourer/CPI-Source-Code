// BaseDigestCalculator
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Utilities;

internal class BaseDigestCalculator : IDigestCalculator
{
	private readonly byte[] digest;

	internal BaseDigestCalculator(byte[] digest)
	{
		this.digest = digest;
	}

	public byte[] GetDigest()
	{
		return Arrays.Clone(digest);
	}
}
