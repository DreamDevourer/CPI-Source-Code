// HeartbeatExtension
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.IO;

public class HeartbeatExtension
{
	protected readonly byte mMode;

	public virtual byte Mode => mMode;

	public HeartbeatExtension(byte mode)
	{
		if (!HeartbeatMode.IsValid(mode))
		{
			throw new ArgumentException("not a valid HeartbeatMode value", "mode");
		}
		mMode = mode;
	}

	public virtual void Encode(Stream output)
	{
		TlsUtilities.WriteUint8(mMode, output);
	}

	public static HeartbeatExtension Parse(Stream input)
	{
		byte b = TlsUtilities.ReadUint8(input);
		if (!HeartbeatMode.IsValid(b))
		{
			throw new TlsFatalAlert(47);
		}
		return new HeartbeatExtension(b);
	}
}
