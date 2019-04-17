// SpawnPointSelector
using ClubPenguin.World;
using UnityEngine;

public abstract class SpawnPointSelector : MonoBehaviour
{
	public abstract Vector3 SelectSpawnPosition(CoordinateSpace cs);

	public abstract Quaternion SelectSpawnRotation(CoordinateSpace cs);
}
