// FixedDistanceTowardsRailGoalPlanner
using ClubPenguin.Cinematography;
using ClubPenguin.Core;
using UnityEngine;

[RequireComponent(typeof(SmoothBezierCurve))]
internal class FixedDistanceTowardsRailGoalPlanner : GoalPlanner
{
	public float Distance;

	private int pathSeg;

	private SmoothBezierCurve rail;

	private Vector3 closestPoint;

	public void Awake()
	{
		rail = GetComponent<SmoothBezierCurve>();
	}

	public override void Plan(ref Setup setup)
	{
		closestPoint = rail.GetClosestPoint(setup.Focus.position, ref pathSeg, out float _);
		Vector3 vector = setup.Focus.position - closestPoint;
		vector.y = 0f;
		float d = vector.magnitude - Distance;
		float y = setup.Goal.y;
		setup.Goal = closestPoint + vector.normalized * d;
		setup.Goal.y = y;
	}

	public void OnDrawGizmos()
	{
		Gizmos.DrawIcon(closestPoint, "Cinematography/RailPosition.png");
	}
}
