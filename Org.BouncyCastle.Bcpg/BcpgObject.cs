// BcpgObject
using Org.BouncyCastle.Bcpg;
using System.IO;

public abstract class BcpgObject
{
	public virtual byte[] GetEncoded()
	{
		MemoryStream memoryStream = new MemoryStream();
		BcpgOutputStream bcpgOutputStream = new BcpgOutputStream(memoryStream);
		bcpgOutputStream.WriteObject(this);
		return memoryStream.ToArray();
	}

	public abstract void Encode(BcpgOutputStream bcpgOut);
}
