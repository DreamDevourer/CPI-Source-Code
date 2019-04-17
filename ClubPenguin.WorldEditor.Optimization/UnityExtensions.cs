// UnityExtensions
using UnityEngine;

public static class UnityExtensions
{
	public static string GetPath(this Transform current)
	{
		if (current.parent == null)
		{
			return current.name;
		}
		return GetPath(current.parent) + "/" + current.name;
	}

	public static string GetPath(this Component current)
	{
		if (current.transform.parent == null)
		{
			return current.name;
		}
		return GetPath(current.transform.parent) + "/" + current.name;
	}
}
