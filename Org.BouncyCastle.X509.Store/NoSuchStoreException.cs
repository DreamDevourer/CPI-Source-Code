// NoSuchStoreException
using Org.BouncyCastle.X509.Store;
using System;

[Serializable]
public class NoSuchStoreException : X509StoreException
{
	public NoSuchStoreException()
	{
	}

	public NoSuchStoreException(string message)
		: base(message)
	{
	}

	public NoSuchStoreException(string message, Exception e)
		: base(message, e)
	{
	}
}
