// Pkcs12Entry
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections;

public abstract class Pkcs12Entry
{
	private readonly IDictionary attributes;

	public Asn1Encodable this[DerObjectIdentifier oid]
	{
		get
		{
			return (Asn1Encodable)attributes[oid.Id];
		}
	}

	public Asn1Encodable this[string oid]
	{
		get
		{
			return (Asn1Encodable)attributes[oid];
		}
	}

	public IEnumerable BagAttributeKeys => new EnumerableProxy(attributes.Keys);

	protected internal Pkcs12Entry(IDictionary attributes)
	{
		this.attributes = attributes;
		IDictionaryEnumerator enumerator = attributes.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
				if (!(dictionaryEntry.Key is string))
				{
					throw new ArgumentException("Attribute keys must be of type: " + typeof(string).FullName, "attributes");
				}
				if (!(dictionaryEntry.Value is Asn1Encodable))
				{
					throw new ArgumentException("Attribute values must be of type: " + typeof(Asn1Encodable).FullName, "attributes");
				}
			}
		}
		finally
		{
			(enumerator as IDisposable)?.Dispose();
		}
	}

	[Obsolete("Use 'object[index]' syntax instead")]
	public Asn1Encodable GetBagAttribute(DerObjectIdentifier oid)
	{
		return (Asn1Encodable)attributes[oid.Id];
	}

	[Obsolete("Use 'object[index]' syntax instead")]
	public Asn1Encodable GetBagAttribute(string oid)
	{
		return (Asn1Encodable)attributes[oid];
	}

	[Obsolete("Use 'BagAttributeKeys' property")]
	public IEnumerator GetBagAttributeKeys()
	{
		return attributes.Keys.GetEnumerator();
	}
}
