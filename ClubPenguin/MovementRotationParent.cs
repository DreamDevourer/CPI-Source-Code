// MovementRotationParent
using ClubPenguin;

public class MovementRotationParent : ProximityBroadcaster
{
	private MovementRotation[] movementRotationChildren;

	public override void Awake()
	{
		base.Awake();
		movementRotationChildren = GetComponentsInChildren<MovementRotation>();
	}

	public override void OnProximityEnter(ProximityListener other)
	{
		MovementRotation[] array = movementRotationChildren;
		foreach (MovementRotation movementRotation in array)
		{
			movementRotation.SetActive(active: true);
		}
	}

	public override void OnProximityExit(ProximityListener other)
	{
		MovementRotation[] array = movementRotationChildren;
		foreach (MovementRotation movementRotation in array)
		{
			movementRotation.SetActive(active: false);
		}
	}
}
