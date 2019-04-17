// PgpLiteralData
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Utilities.Date;
using System;
using System.IO;

public class PgpLiteralData : PgpObject
{
	public const char Binary = 'b';

	public const char Text = 't';

	public const char Utf8 = 'u';

	public const string Console = "_CONSOLE";

	private LiteralDataPacket data;

	public int Format => data.Format;

	public string FileName => data.FileName;

	public DateTime ModificationTime => DateTimeUtilities.UnixMsToDateTime(data.ModificationTime);

	public PgpLiteralData(BcpgInputStream bcpgInput)
	{
		data = (LiteralDataPacket)bcpgInput.ReadPacket();
	}

	public byte[] GetRawFileName()
	{
		return data.GetRawFileName();
	}

	public Stream GetInputStream()
	{
		return data.GetInputStream();
	}

	public Stream GetDataStream()
	{
		return GetInputStream();
	}
}
