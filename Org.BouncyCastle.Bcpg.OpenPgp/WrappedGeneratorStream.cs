// WrappedGeneratorStream
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Utilities.IO;
using System.IO;

public class WrappedGeneratorStream : FilterStream
{
	private readonly IStreamGenerator gen;

	public WrappedGeneratorStream(IStreamGenerator gen, Stream str)
		: base(str)
	{
		this.gen = gen;
	}

	public override void Close()
	{
		gen.Close();
	}
}
