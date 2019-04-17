// SignerInputBuffer
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Tls;
using Org.BouncyCastle.Utilities.IO;
using System.IO;

internal class SignerInputBuffer : MemoryStream
{
	private class SigStream : BaseOutputStream
	{
		private readonly ISigner s;

		internal SigStream(ISigner s)
		{
			this.s = s;
		}

		public override void WriteByte(byte b)
		{
			s.Update(b);
		}

		public override void Write(byte[] buf, int off, int len)
		{
			s.BlockUpdate(buf, off, len);
		}
	}

	internal void UpdateSigner(ISigner s)
	{
		WriteTo(new SigStream(s));
	}
}
