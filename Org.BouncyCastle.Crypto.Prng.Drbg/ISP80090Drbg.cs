// ISP80090Drbg
public interface ISP80090Drbg
{
	int BlockSize
	{
		get;
	}

	int Generate(byte[] output, byte[] additionalInput, bool predictionResistant);

	void Reseed(byte[] additionalInput);
}
