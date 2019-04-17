// ConditionalDefinition_Bool
using ClubPenguin.Configuration;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditional/Definition/Bool")]
public class ConditionalDefinition_Bool : ConditionalDefinition<bool>
{
	public ConditionalTier_Bool[] _Tiers;

	public override ConditionalTier<bool>[] Tiers => _Tiers;
}
