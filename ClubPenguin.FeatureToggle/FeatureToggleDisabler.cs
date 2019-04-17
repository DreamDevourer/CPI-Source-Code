// FeatureToggleDisabler
using ClubPenguin.FeatureToggle;

internal class FeatureToggleDisabler : AbstractFeatureToggler
{
	protected override void onFeatureEnabled()
	{
		base.gameObject.SetActive(value: true);
	}

	protected override void onFeatureDisabled()
	{
		base.gameObject.SetActive(value: false);
	}
}
