// GoalPlanner
using ClubPenguin.Cinematography;
using UnityEngine;

public abstract class GoalPlanner : MonoBehaviour
{
	[HideInInspector]
	public bool Dirty;

	public virtual bool IsFinished => true;

	public abstract void Plan(ref Setup setup);
}
