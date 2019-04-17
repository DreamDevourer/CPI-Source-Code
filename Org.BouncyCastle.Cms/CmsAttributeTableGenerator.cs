// CmsAttributeTableGenerator
using Org.BouncyCastle.Asn1.Cms;
using System.Collections;

public interface CmsAttributeTableGenerator
{
	AttributeTable GetAttributes(IDictionary parameters);
}
