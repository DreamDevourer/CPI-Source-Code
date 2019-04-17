// X509CollectionStoreParameters
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509.Store;
using System;
using System.Collections;
using System.Text;

public class X509CollectionStoreParameters : IX509StoreParameters
{
	private readonly IList collection;

	public X509CollectionStoreParameters(ICollection collection)
	{
		if (collection == null)
		{
			throw new ArgumentNullException("collection");
		}
		this.collection = Platform.CreateArrayList(collection);
	}

	public ICollection GetCollection()
	{
		return Platform.CreateArrayList(collection);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("X509CollectionStoreParameters: [\n");
		stringBuilder.Append("  collection: " + collection + "\n");
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}
}
