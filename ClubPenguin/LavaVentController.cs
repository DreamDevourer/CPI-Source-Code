// LavaVentController
using ClubPenguin;
using UnityEngine;

public class LavaVentController : ProximityBroadcaster
{
	public enum AnimState
	{
		none,
		idle,
		rampUp,
		erupting
	}

	public float idleDuration = 3f;

	public float rampUpDuration = 3f;

	public float eruptDuration = 5f;

	public ParticleSystem idleParticles;

	public Collider repulseCollider;

	private Animator animator = null;

	private bool ventIsActive = false;

	private float timeStamp = 0f;

	private AnimState animState = AnimState.none;

	public override void Awake()
	{
		base.Awake();
		animator = GetComponent<Animator>();
		setActive(isActive: false);
		enableCollider(isEnabled: false);
	}

	private void Update()
	{
		if (!ventIsActive)
		{
			return;
		}
		switch (animState)
		{
		case AnimState.none:
			break;
		case AnimState.idle:
			if (Time.time >= timeStamp + idleDuration)
			{
				timeStamp = Time.time;
				resetAllTriggers();
				animator.SetTrigger("RampUp");
				setAnimState(AnimState.rampUp);
			}
			break;
		case AnimState.rampUp:
			if (Time.time >= timeStamp + rampUpDuration)
			{
				timeStamp = Time.time;
				resetAllTriggers();
				animator.SetTrigger("Erupt");
				enableCollider(isEnabled: true);
				setAnimState(AnimState.erupting);
			}
			break;
		case AnimState.erupting:
			if (Time.time >= timeStamp + eruptDuration)
			{
				timeStamp = Time.time;
				resetAllTriggers();
				animator.SetTrigger("TurnOff");
				enableCollider(isEnabled: false);
				setAnimState(AnimState.idle);
			}
			break;
		}
	}

	private void resetAllTriggers()
	{
		if (animator != null)
		{
			animator.ResetTrigger("TurnOff");
			animator.ResetTrigger("RampUp");
			animator.ResetTrigger("Erupt");
		}
	}

	private void setAnimState(AnimState state)
	{
		animState = state;
	}

	public override void OnProximityEnter(ProximityListener other)
	{
		setActive(isActive: true);
		timeStamp = Time.time;
		setAnimState(AnimState.idle);
	}

	public override void OnProximityExit(ProximityListener other)
	{
		animator.SetTrigger("TurnOff");
		setActive(isActive: false);
		enableCollider(isEnabled: false);
		setAnimState(AnimState.none);
	}

	private void setActive(bool isActive)
	{
		ventIsActive = isActive;
		if (animator != null)
		{
			animator.enabled = isActive;
		}
		if (idleParticles != null)
		{
			idleParticles.gameObject.SetActive(isActive);
		}
		foreach (Transform item in base.transform)
		{
			item.gameObject.SetActive(isActive);
		}
	}

	private void enableCollider(bool isEnabled)
	{
		if (repulseCollider != null)
		{
			repulseCollider.enabled = isEnabled;
		}
	}
}
