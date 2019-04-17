// ISignatureFactory
using Org.BouncyCastle.Crypto;

public interface ISignatureFactory
{
	object AlgorithmDetails
	{
		get;
	}

	IStreamCalculator CreateCalculator();
}
