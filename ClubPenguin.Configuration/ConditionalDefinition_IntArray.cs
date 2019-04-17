// ConditionalDefinition_IntArray
using ClubPenguin.Configuration;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditional/Definition/IntArray")]
public class ConditionalDefinition_IntArray : ConditionalDefinition<int[]>
{
	public ConditionalTier_IntArray[] _Tiers;

	public override ConditionalTier<int[]>[] Tiers => _Tiers;
}
