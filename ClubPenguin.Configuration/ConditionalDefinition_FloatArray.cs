// ConditionalDefinition_FloatArray
using ClubPenguin.Configuration;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditional/Definition/FloatArray")]
public class ConditionalDefinition_FloatArray : ConditionalDefinition<float[]>
{
	public ConditionalTier_FloatArray[] _Tiers;

	public override ConditionalTier<float[]>[] Tiers => _Tiers;
}
