// IglooData
using ClubPenguin.Net.Domain.Igloo;
using ClubPenguin.Net.Domain.Scene;
using System;

[Serializable]
public class IglooData : MutableIglooData
{
	public int maxIglooLayouts;

	public SceneLayout activeLayout;
}
