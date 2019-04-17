// Framer
using ClubPenguin.Cinematography;
using UnityEngine;

public abstract class Framer : MonoBehaviour
{
	[HideInInspector]
	public bool Dirty;

	public virtual bool IsFinished => true;

	public abstract void Aim(ref Setup setup);
}
