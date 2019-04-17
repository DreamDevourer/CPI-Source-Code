// SkinParticleForXPMascot
using ClubPenguin;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class SkinParticleForXPMascot : MonoBehaviour
{
	public void SetXPMascotColor(Color color)
	{
		ParticleSystem component = GetComponent<ParticleSystem>();
		component.SetStartColor(color);
	}
}
