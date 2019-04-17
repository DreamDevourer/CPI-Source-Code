// AbstractPenguinSnowballThrower
using UnityEngine;

public abstract class AbstractPenguinSnowballThrower : MonoBehaviour
{
	public abstract void OnEnterIdle();

	public abstract void EnableSnowballThrow(bool enable);
}
