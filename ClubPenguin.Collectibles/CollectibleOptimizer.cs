// CollectibleOptimizer
using ClubPenguin;
using UnityEngine;

public class CollectibleOptimizer : ProximityBroadcaster
{
	public MonoBehaviour[] scriptObjects;

	public ParticleSystem[] particleSystems;

	public Animator[] animators;

	public override void Awake()
	{
		base.Awake();
		setActive(isActive: false);
	}

	public override void OnProximityEnter(ProximityListener other)
	{
		setActive(isActive: true);
	}

	public override void OnProximityExit(ProximityListener other)
	{
		setActive(isActive: false);
	}

	private void setActive(bool isActive)
	{
		int num = scriptObjects.Length;
		for (int i = 0; i < num; i++)
		{
			MonoBehaviour monoBehaviour = scriptObjects[i];
			if (monoBehaviour != null)
			{
				monoBehaviour.enabled = isActive;
			}
		}
		num = particleSystems.Length;
		for (int i = 0; i < num; i++)
		{
			ParticleSystem particleSystem = particleSystems[i];
			if (particleSystem != null)
			{
				if (isActive)
				{
					particleSystem.Play();
					continue;
				}
				particleSystem.Stop();
				particleSystem.Clear();
			}
		}
		num = animators.Length;
		for (int i = 0; i < num; i++)
		{
			Animator animator = animators[i];
			if (animator != null)
			{
				animator.enabled = isActive;
			}
		}
	}
}
