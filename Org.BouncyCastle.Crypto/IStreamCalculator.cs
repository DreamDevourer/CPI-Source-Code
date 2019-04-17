// IStreamCalculator
using System.IO;

public interface IStreamCalculator
{
	Stream Stream
	{
		get;
	}

	object GetResult();
}
