// VisibilityBoundsExplorer
using ClubPenguin.WorldEditor.Optimization;
using UnityEngine;

public class VisibilityBoundsExplorer : VisibilityIterator
{
	public float MovementDistance = 1f;

	private Vector3 min;

	private Vector3 max;

	private Vector3 position;

	private bool done = false;

	private VisibilityRegion[] regions;

	private Visibility current;

	public override Visibility Current => current;

	public override bool MoveNext()
	{
		if (regions == null)
		{
			Reset();
		}
		bool flag = false;
		while (!done && !flag)
		{
			for (int i = 0; i < regions.Length; i++)
			{
				if (regions[i].Bounds.Contains(position))
				{
					Quaternion orientation = Quaternion.LookRotation(regions[i].WorldSpaceDirection, regions[i].GetVisibilityDirection().TransformRef.up);
					float directionalFovDegs = regions[i].DirectionalFovDegs;
					current = new Visibility(position, orientation, directionalFovDegs);
					flag = true;
				}
			}
			position.x += MovementDistance;
			if (position.x > max.x)
			{
				position.x = min.x;
				position.y += MovementDistance;
				if (position.y > max.y)
				{
					position.y = min.y;
					position.z += MovementDistance;
					done |= (position.z > max.z);
				}
			}
		}
		if (done)
		{
			regions = null;
		}
		return !done;
	}

	public override void Reset()
	{
		regions = GetComponentsInChildren<VisibilityRegion>();
		min = new Vector3(3.40282347E+38f, 3.40282347E+38f, 3.40282347E+38f);
		max = new Vector3(-3.40282347E+38f, -3.40282347E+38f, -3.40282347E+38f);
		for (int i = 0; i < regions.Length; i++)
		{
			Bounds bounds = regions[i].Bounds;
			if (bounds.min.x < min.x)
			{
				min.x = bounds.min.x;
			}
			if (bounds.min.y < min.y)
			{
				min.y = bounds.min.y;
			}
			if (bounds.min.z < min.z)
			{
				min.z = bounds.min.z;
			}
			if (bounds.max.x > max.x)
			{
				max.x = bounds.max.x;
			}
			if (bounds.max.y > max.y)
			{
				max.y = bounds.max.y;
			}
			if (bounds.max.z > max.z)
			{
				max.z = bounds.max.z;
			}
		}
		position = min;
		done = false;
	}
}
