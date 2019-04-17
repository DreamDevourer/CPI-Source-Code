// SceneLayout
using ClubPenguin.Net.Domain.Scene;
using System;

[Serializable]
public class SceneLayout : MutableSceneLayout
{
	public long? createdDate;

	public long? lastModifiedDate;

	public bool memberOnly;
}
