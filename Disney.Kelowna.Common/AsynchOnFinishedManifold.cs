// AsynchOnFinishedManifold
using System;
using System.Threading;

public class AsynchOnFinishedManifold
{
	private int asyncStartedCount = 0;

	private Action allFinishedCallback;

	public AsynchOnFinishedManifold(Action allFinishedCallback)
	{
		this.allFinishedCallback = allFinishedCallback;
	}

	public void MainStart()
	{
		AsynchStart();
	}

	public void MainFinished()
	{
		AsynchFinished();
	}

	public void AsynchStart()
	{
		Interlocked.Increment(ref asyncStartedCount);
	}

	public void AsynchFinished()
	{
		Interlocked.Decrement(ref asyncStartedCount);
		if (asyncStartedCount <= 0 && allFinishedCallback != null)
		{
			allFinishedCallback();
			allFinishedCallback = null;
		}
	}
}
