// BenchmarkWaitForFrame
using ClubPenguin.Benchmarking;
using Disney.Kelowna.Common;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

public class BenchmarkWaitForFrame : BenchmarkTestStage
{
	[Header("Wait For Frame Settings")]
	public int Frames = 30;

	protected override void performBenchmark()
	{
		Service.Get<CoroutineRunner>().StartCoroutine(waitForFrames());
	}

	private IEnumerator waitForFrames()
	{
		for (int framesRemaining = Frames; framesRemaining > 0; framesRemaining--)
		{
			yield return new WaitForEndOfFrame();
		}
		onFinish();
	}
}
