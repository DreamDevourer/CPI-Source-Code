// PCProduct
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public struct PCProduct
{
	public List<PCPricePlan> PricingPlans;
}
