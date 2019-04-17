// LocalStorageCorruptedEventArgs
using Disney.Mix.SDK;

public class LocalStorageCorruptedEventArgs : AbstractLocalStorageCorruptedEventArgs
{
	public LocalStorageCorruptedEventArgs(bool recovered)
	{
		Recovered = recovered;
	}
}
