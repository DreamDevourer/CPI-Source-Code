// Glancer
using ClubPenguin.Cinematography;
using UnityEngine;

public abstract class Glancer : MonoBehaviour
{
	[HideInInspector]
	public bool Dirty;

	public abstract bool Aim(ref Setup setup);
}
