// CorruptionDetectedEventArgs
using System;

public class CorruptionDetectedEventArgs : EventArgs
{
	public bool Recovered;

	public CorruptionDetectedEventArgs(bool recovered)
	{
		Recovered = recovered;
	}
}
