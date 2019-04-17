// Asn1Generator
using Org.BouncyCastle.Asn1;
using System.IO;

public abstract class Asn1Generator
{
	private Stream _out;

	protected Stream Out => _out;

	protected Asn1Generator(Stream outStream)
	{
		_out = outStream;
	}

	public abstract void AddObject(Asn1Encodable obj);

	public abstract Stream GetRawOutputStream();

	public abstract void Close();
}
