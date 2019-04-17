// ConditionalDefinition_Int
using ClubPenguin.Configuration;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditional/Definition/Int")]
public class ConditionalDefinition_Int : ConditionalDefinition<int>
{
	public ConditionalTier_Int[] _Tiers;

	public override ConditionalTier<int>[] Tiers => _Tiers;
}
