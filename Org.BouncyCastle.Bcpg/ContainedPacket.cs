// ContainedPacket
using Org.BouncyCastle.Bcpg;
using System.IO;

public abstract class ContainedPacket : Packet
{
	public byte[] GetEncoded()
	{
		MemoryStream memoryStream = new MemoryStream();
		BcpgOutputStream bcpgOutputStream = new BcpgOutputStream(memoryStream);
		bcpgOutputStream.WritePacket(this);
		return memoryStream.ToArray();
	}

	public abstract void Encode(BcpgOutputStream bcpgOut);
}
