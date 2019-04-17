// IEntropySource
public interface IEntropySource
{
	bool IsPredictionResistant
	{
		get;
	}

	int EntropySize
	{
		get;
	}

	byte[] GetEntropy();
}
