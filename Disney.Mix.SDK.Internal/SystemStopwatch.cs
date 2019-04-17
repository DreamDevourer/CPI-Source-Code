// SystemStopwatch
using Disney.Mix.SDK.Internal;
using System.Diagnostics;

public class SystemStopwatch : IStopwatch
{
	private readonly Stopwatch stopwatch;

	public long ElapsedMilliseconds => stopwatch.ElapsedMilliseconds;

	public SystemStopwatch()
	{
		stopwatch = new Stopwatch();
	}

	public void Stop()
	{
		stopwatch.Stop();
	}

	public void Start()
	{
		stopwatch.Start();
	}

	public void Reset()
	{
		stopwatch.Reset();
	}
}
