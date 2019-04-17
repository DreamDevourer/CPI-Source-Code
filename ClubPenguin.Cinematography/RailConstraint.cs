// RailConstraint
using ClubPenguin.Cinematography;
using ClubPenguin.Core;
using UnityEngine;

[RequireComponent(typeof(SmoothBezierCurve))]
public class RailConstraint : Constraint
{
	public float Distance;

	public bool ClampY = true;

	private int pathSeg;

	private SmoothBezierCurve rail;

	public Vector3 ClosestPoint
	{
		get;
		private set;
	}

	public void Awake()
	{
		rail = GetComponent<SmoothBezierCurve>();
	}

	public override void Apply(ref Setup setup)
	{
		float y = setup.Goal.y;
		ClosestPoint = rail.GetClosestPoint(setup.Goal, ref pathSeg, out float distance);
		if (distance > Distance)
		{
			float d = distance - Distance;
			setup.Goal += (ClosestPoint - setup.Goal) / distance * d;
		}
		setup.Goal.y = (ClampY ? ClosestPoint.y : y);
	}

	public void OnDrawGizmosSelected()
	{
		Gizmos.DrawIcon(ClosestPoint, "Cinematography/RailPosition.png");
	}
}
