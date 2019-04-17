// PlayerComponentCollection
using ClubPenguin;
using ClubPenguin.Data;
using System;

public class PlayerComponentCollection : ComponentCollection
{
	public string InternalId
	{
		get;
		protected set;
	}

	public PlayerComponentCollection()
	{
		InternalId = Guid.NewGuid().ToString();
		AddComponent(new PlayerIdComponent());
	}
}
