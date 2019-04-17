// PCProductContext
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public struct PCProductContext
{
	public List<PCOrderablePricePlan> OrderablePricingPlans;

	public long ProductId;
}
