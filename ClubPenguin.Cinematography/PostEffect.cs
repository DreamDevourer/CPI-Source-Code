// PostEffect
using UnityEngine;

public abstract class PostEffect : MonoBehaviour
{
	public abstract void Apply(bool snapMove, bool snapAim);
}
