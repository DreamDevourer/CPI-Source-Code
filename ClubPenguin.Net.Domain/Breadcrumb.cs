// Breadcrumb
using System;

[Serializable]
public struct Breadcrumb
{
	public int breadcrumbType;

	public string id;

	public Breadcrumb(string id, int type)
	{
		this.id = id;
		breadcrumbType = type;
	}

	public override string ToString()
	{
		return $"[Breadcrumb] Type: {breadcrumbType} Id: {id}";
	}
}
