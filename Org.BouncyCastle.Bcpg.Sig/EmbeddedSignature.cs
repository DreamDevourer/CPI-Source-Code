// EmbeddedSignature
using Org.BouncyCastle.Bcpg;

public class EmbeddedSignature : SignatureSubpacket
{
	public EmbeddedSignature(bool critical, bool isLongLength, byte[] data)
		: base(SignatureSubpacketTag.EmbeddedSignature, critical, isLongLength, data)
	{
	}
}
