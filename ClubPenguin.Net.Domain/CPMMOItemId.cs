// CPMMOItemId
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public struct CPMMOItemId
{
	public enum CPMMOItemParent
	{
		PLAYER,
		WORLD
	}

	public readonly CPMMOItemParent Parent;

	public readonly long Id;

	public CPMMOItemId(long id, CPMMOItemParent parent)
	{
		Id = id;
		Parent = parent;
	}

	public override string ToString()
	{
		return Parent.ToString() + ":" + Id.ToString();
	}
}
