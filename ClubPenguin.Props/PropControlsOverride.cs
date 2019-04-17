// PropControlsOverride
using ClubPenguin.UI;
using UnityEngine;

public class PropControlsOverride : MonoBehaviour
{
	[SerializeField]
	private InputButtonGroupContentKey SwimControlsScreenDefinitionContentKey;

	[SerializeField]
	private InputButtonGroupContentKey DivingControlsScreenDefinitionContentKey;

	[SerializeField]
	private InputButtonGroupContentKey ControlsScreenDefinitionContentKey;

	[SerializeField]
	private InputButtonGroupContentKey TubeControlsScreenDefinitionContentKey;

	[SerializeField]
	private InputButtonGroupContentKey SitControlsScreenDefinitionContentKey;

	[SerializeField]
	private InputButtonGroupContentKey SitSwimControlsScreenDefinitionContentKey;

	public InputButtonGroupContentKey SwimControls => SwimControlsScreenDefinitionContentKey;

	public InputButtonGroupContentKey DivingControls => DivingControlsScreenDefinitionContentKey;

	public InputButtonGroupContentKey DefaultControls => ControlsScreenDefinitionContentKey;

	public InputButtonGroupContentKey TubeControls => TubeControlsScreenDefinitionContentKey;

	public InputButtonGroupContentKey SitControls => SitControlsScreenDefinitionContentKey;

	public InputButtonGroupContentKey SitSwimControls => SitSwimControlsScreenDefinitionContentKey;
}
