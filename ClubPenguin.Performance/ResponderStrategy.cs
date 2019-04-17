// ResponderStrategy
using ClubPenguin.Performance;
using System;

public abstract class ResponderStrategy
{
	public float GetNormalizedScoreForResponder(FrameData frameData, PerformanceResponder performanceResponder, float maxNormalizedScore)
	{
		if (performanceResponder.GetPerformanceResponderType() != getExpectedResponseType())
		{
			throw new ArgumentException("Expected PerformanceResponseType of " + getExpectedResponseType() + ", but got PerformanceResponder of type " + performanceResponder.GetPerformanceResponderType());
		}
		return evaluateScore(frameData, performanceResponder, maxNormalizedScore);
	}

	protected abstract PerformanceResponderType getExpectedResponseType();

	protected abstract float evaluateScore(FrameData frameData, PerformanceResponder performanceResponder, float maxNormalizedScore);
}
