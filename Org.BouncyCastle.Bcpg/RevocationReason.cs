// RevocationReason
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Utilities;
using System;

public class RevocationReason : SignatureSubpacket
{
	public RevocationReason(bool isCritical, bool isLongLength, byte[] data)
		: base(SignatureSubpacketTag.RevocationReason, isCritical, isLongLength, data)
	{
	}

	public RevocationReason(bool isCritical, RevocationReasonTag reason, string description)
		: base(SignatureSubpacketTag.RevocationReason, isCritical, isLongLength: false, CreateData(reason, description))
	{
	}

	private static byte[] CreateData(RevocationReasonTag reason, string description)
	{
		byte[] array = Strings.ToUtf8ByteArray(description);
		byte[] array2 = new byte[1 + array.Length];
		array2[0] = (byte)reason;
		Array.Copy(array, 0, array2, 1, array.Length);
		return array2;
	}

	public virtual RevocationReasonTag GetRevocationReason()
	{
		return (RevocationReasonTag)GetData()[0];
	}

	public virtual string GetRevocationDescription()
	{
		byte[] data = GetData();
		if (data.Length == 1)
		{
			return string.Empty;
		}
		byte[] array = new byte[data.Length - 1];
		Array.Copy(data, 1, array, 0, array.Length);
		return Strings.FromUtf8ByteArray(array);
	}
}
