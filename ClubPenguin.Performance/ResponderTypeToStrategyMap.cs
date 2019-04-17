// ResponderTypeToStrategyMap
using ClubPenguin.Performance;
using System;
using System.Collections.Generic;

public static class ResponderTypeToStrategyMap
{
	private static Dictionary<PerformanceResponderType, ResponderStrategy> map = new Dictionary<PerformanceResponderType, ResponderStrategy>
	{
		{
			PerformanceResponderType.AvatarLod,
			new AvatarLODResponderStrategy()
		}
	};

	public static ResponderStrategy GetStrategyForResponderType(PerformanceResponderType performanceResponderType)
	{
		if (!map.ContainsKey(performanceResponderType))
		{
			throw new Exception("ResponderTypeToStrategyMap does not contain an entry for PerformanceResponderType: " + performanceResponderType);
		}
		return map[performanceResponderType];
	}
}
