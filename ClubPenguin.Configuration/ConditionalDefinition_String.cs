// ConditionalDefinition_String
using ClubPenguin.Configuration;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditional/Definition/String")]
public class ConditionalDefinition_String : ConditionalDefinition<string>
{
	public ConditionalTier_String[] _Tiers;

	public override ConditionalTier<string>[] Tiers => _Tiers;
}
