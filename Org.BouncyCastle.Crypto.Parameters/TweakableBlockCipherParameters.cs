// TweakableBlockCipherParameters
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;

public class TweakableBlockCipherParameters : ICipherParameters
{
	private readonly byte[] tweak;

	private readonly KeyParameter key;

	public KeyParameter Key => key;

	public byte[] Tweak => tweak;

	public TweakableBlockCipherParameters(KeyParameter key, byte[] tweak)
	{
		this.key = key;
		this.tweak = Arrays.Clone(tweak);
	}
}
