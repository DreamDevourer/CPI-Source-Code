// SimpleAttributeTableGenerator
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Cms;
using System.Collections;

public class SimpleAttributeTableGenerator : CmsAttributeTableGenerator
{
	private readonly AttributeTable attributes;

	public SimpleAttributeTableGenerator(AttributeTable attributes)
	{
		this.attributes = attributes;
	}

	public virtual AttributeTable GetAttributes(IDictionary parameters)
	{
		return attributes;
	}
}
