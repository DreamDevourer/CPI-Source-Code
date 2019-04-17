// AttributeTable
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections;

public class AttributeTable
{
	private readonly IDictionary attributes;

	public Org.BouncyCastle.Asn1.Cms.Attribute this[DerObjectIdentifier oid]
	{
		get
		{
			object obj = attributes[oid];
			if (obj is IList)
			{
				return (Org.BouncyCastle.Asn1.Cms.Attribute)((IList)obj)[0];
			}
			return (Org.BouncyCastle.Asn1.Cms.Attribute)obj;
		}
	}

	public int Count
	{
		get
		{
			int num = 0;
			foreach (object value in attributes.Values)
			{
				num = ((!(value is IList)) ? (num + 1) : (num + ((IList)value).Count));
			}
			return num;
		}
	}

	[Obsolete]
	public AttributeTable(Hashtable attrs)
	{
		attributes = Platform.CreateHashtable(attrs);
	}

	public AttributeTable(IDictionary attrs)
	{
		attributes = Platform.CreateHashtable(attrs);
	}

	public AttributeTable(Asn1EncodableVector v)
	{
		attributes = Platform.CreateHashtable(v.Count);
		foreach (Asn1Encodable item in v)
		{
			Org.BouncyCastle.Asn1.Cms.Attribute instance = Org.BouncyCastle.Asn1.Cms.Attribute.GetInstance(item);
			AddAttribute(instance);
		}
	}

	public AttributeTable(Asn1Set s)
	{
		attributes = Platform.CreateHashtable(s.Count);
		for (int i = 0; i != s.Count; i++)
		{
			Org.BouncyCastle.Asn1.Cms.Attribute instance = Org.BouncyCastle.Asn1.Cms.Attribute.GetInstance(s[i]);
			AddAttribute(instance);
		}
	}

	public AttributeTable(Attributes attrs)
		: this(Asn1Set.GetInstance(attrs.ToAsn1Object()))
	{
	}

	private void AddAttribute(Org.BouncyCastle.Asn1.Cms.Attribute a)
	{
		DerObjectIdentifier attrType = a.AttrType;
		object obj = attributes[attrType];
		if (obj == null)
		{
			attributes[attrType] = a;
			return;
		}
		IList list;
		if (obj is Org.BouncyCastle.Asn1.Cms.Attribute)
		{
			list = Platform.CreateArrayList();
			list.Add(obj);
			list.Add(a);
		}
		else
		{
			list = (IList)obj;
			list.Add(a);
		}
		attributes[attrType] = list;
	}

	[Obsolete("Use 'object[oid]' syntax instead")]
	public Org.BouncyCastle.Asn1.Cms.Attribute Get(DerObjectIdentifier oid)
	{
		return this[oid];
	}

	public Asn1EncodableVector GetAll(DerObjectIdentifier oid)
	{
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector();
		object obj = attributes[oid];
		if (obj is IList)
		{
			foreach (Org.BouncyCastle.Asn1.Cms.Attribute item in (IList)obj)
			{
				asn1EncodableVector.Add(item);
			}
			return asn1EncodableVector;
		}
		if (obj != null)
		{
			asn1EncodableVector.Add((Org.BouncyCastle.Asn1.Cms.Attribute)obj);
		}
		return asn1EncodableVector;
	}

	public IDictionary ToDictionary()
	{
		return Platform.CreateHashtable(attributes);
	}

	[Obsolete("Use 'ToDictionary' instead")]
	public Hashtable ToHashtable()
	{
		return new Hashtable(attributes);
	}

	public Asn1EncodableVector ToAsn1EncodableVector()
	{
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector();
		foreach (object value in attributes.Values)
		{
			if (value is IList)
			{
				foreach (object item in (IList)value)
				{
					asn1EncodableVector.Add(Org.BouncyCastle.Asn1.Cms.Attribute.GetInstance(item));
				}
			}
			else
			{
				asn1EncodableVector.Add(Org.BouncyCastle.Asn1.Cms.Attribute.GetInstance(value));
			}
		}
		return asn1EncodableVector;
	}

	public Attributes ToAttributes()
	{
		return new Attributes(ToAsn1EncodableVector());
	}

	public AttributeTable Add(DerObjectIdentifier attrType, Asn1Encodable attrValue)
	{
		AttributeTable attributeTable = new AttributeTable(attributes);
		attributeTable.AddAttribute(new Org.BouncyCastle.Asn1.Cms.Attribute(attrType, new DerSet(attrValue)));
		return attributeTable;
	}

	public AttributeTable Remove(DerObjectIdentifier attrType)
	{
		AttributeTable attributeTable = new AttributeTable(attributes);
		attributeTable.attributes.Remove(attrType);
		return attributeTable;
	}
}
