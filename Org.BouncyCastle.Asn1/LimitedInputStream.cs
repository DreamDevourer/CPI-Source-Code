// LimitedInputStream
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Utilities.IO;
using System.IO;

internal abstract class LimitedInputStream : BaseInputStream
{
	protected readonly Stream _in;

	private int _limit;

	internal LimitedInputStream(Stream inStream, int limit)
	{
		_in = inStream;
		_limit = limit;
	}

	internal virtual int GetRemaining()
	{
		return _limit;
	}

	protected virtual void SetParentEofDetect(bool on)
	{
		if (_in is IndefiniteLengthInputStream)
		{
			((IndefiniteLengthInputStream)_in).SetEofOn00(on);
		}
	}
}
