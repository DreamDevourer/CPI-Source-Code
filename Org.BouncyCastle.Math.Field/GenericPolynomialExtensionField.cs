// GenericPolynomialExtensionField
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.Field;
using Org.BouncyCastle.Utilities;

internal class GenericPolynomialExtensionField : IPolynomialExtensionField, IExtensionField, IFiniteField
{
	protected readonly IFiniteField subfield;

	protected readonly IPolynomial minimalPolynomial;

	public virtual BigInteger Characteristic => subfield.Characteristic;

	public virtual int Dimension => subfield.Dimension * minimalPolynomial.Degree;

	public virtual IFiniteField Subfield => subfield;

	public virtual int Degree => minimalPolynomial.Degree;

	public virtual IPolynomial MinimalPolynomial => minimalPolynomial;

	internal GenericPolynomialExtensionField(IFiniteField subfield, IPolynomial polynomial)
	{
		this.subfield = subfield;
		minimalPolynomial = polynomial;
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		GenericPolynomialExtensionField genericPolynomialExtensionField = obj as GenericPolynomialExtensionField;
		if (genericPolynomialExtensionField == null)
		{
			return false;
		}
		if (subfield.Equals(genericPolynomialExtensionField.subfield))
		{
			return minimalPolynomial.Equals(genericPolynomialExtensionField.minimalPolynomial);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return subfield.GetHashCode() ^ Integers.RotateLeft(minimalPolynomial.GetHashCode(), 16);
	}
}
