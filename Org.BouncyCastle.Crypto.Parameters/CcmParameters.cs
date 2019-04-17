// CcmParameters
using Org.BouncyCastle.Crypto.Parameters;
using System;

[Obsolete("Use AeadParameters")]
public class CcmParameters : AeadParameters
{
	public CcmParameters(KeyParameter key, int macSize, byte[] nonce, byte[] associatedText)
		: base(key, macSize, nonce, associatedText)
	{
	}
}
