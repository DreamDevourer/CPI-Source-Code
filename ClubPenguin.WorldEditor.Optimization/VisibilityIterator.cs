// VisibilityIterator
using ClubPenguin.WorldEditor.Optimization;
using UnityEngine;

public abstract class VisibilityIterator : MonoBehaviour
{
	public abstract Visibility Current
	{
		get;
	}

	public abstract bool MoveNext();

	public abstract void Reset();
}
