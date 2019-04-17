// InteractiveDecorationTarget
using ClubPenguin.Holiday;
using Disney.LaunchPadFramework;
using UnityEngine;

public class InteractiveDecorationTarget : InteractiveDecoration
{
	public InteractiveDecorationController DecorationController;

	public Animator TargetAnimator;

	public string HitAnimName;

	public string SwitchAnimName;

	[Header("Audio")]
	public string AudioTargetSwitch;

	public string AudioTargetHit;

	private ParticleSystem changeParticles;

	public override void Start()
	{
		base.Start();
		if (DuringHidePhase())
		{
			TargetColorChange(isInitializing: true);
		}
		else
		{
			TargetColorChange();
		}
		if (DecorationController == null)
		{
			Log.LogError(this, $"O_o\t Error: {base.gameObject.GetPath()} does not have a controller set");
		}
		changeParticles = GetComponentInChildren<ParticleSystem>();
	}

	public override void OnColorChange()
	{
		base.OnColorChange();
		TargetColorChange();
	}

	public void TargetColorChange(bool isInitializing = false)
	{
		if (!isInitializing)
		{
			int num = (int)(CurrentColor + 1);
			if (num >= 6)
			{
				num = 1;
			}
			CurrentColor = (DecorationColor)num;
			if (changeParticles != null && !changeParticles.isPlaying)
			{
				changeParticles.Play();
			}
		}
		Renderer componentInParent = GetComponentInParent<Renderer>();
		if (componentInParent != null)
		{
			base.ChangeColor(componentInParent, CurrentColor);
			if (TargetAnimator != null && !string.IsNullOrEmpty(SwitchAnimName))
			{
				TargetAnimator.SetTrigger(SwitchAnimName);
				PlayAudioEvent(AudioTargetSwitch, base.gameObject);
			}
		}
		else
		{
			Log.LogError(this, $"O_o\t Error: {base.gameObject.GetPath()} can not find renderer on it's parent");
		}
	}

	private void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.CompareTag("Snowball"))
		{
			if (DecorationController != null)
			{
				DecorationController.OnTargetHit();
			}
			if (TargetAnimator != null && !string.IsNullOrEmpty(HitAnimName))
			{
				TargetAnimator.SetTrigger(HitAnimName);
				PlayAudioEvent(AudioTargetHit, base.gameObject);
			}
		}
	}
}
