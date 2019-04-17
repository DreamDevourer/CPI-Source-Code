// CounterSignatureDigestCalculator
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

internal class CounterSignatureDigestCalculator : IDigestCalculator
{
	private readonly string alg;

	private readonly byte[] data;

	internal CounterSignatureDigestCalculator(string alg, byte[] data)
	{
		this.alg = alg;
		this.data = data;
	}

	public byte[] GetDigest()
	{
		IDigest digestInstance = CmsSignedHelper.Instance.GetDigestInstance(alg);
		return DigestUtilities.DoFinal(digestInstance, data);
	}
}
