// AnimationToggleGroupButton
using ClubPenguin.UI;
using UnityEngine;
using UnityEngine.UI;

public class AnimationToggleGroupButton : MonoBehaviour
{
	public string ANIMATION_BOOL = "IsOn";

	public Animator Animator;

	public Button Button;

	private void SetAnimation(bool on)
	{
		Animator.SetBool(ANIMATION_BOOL, on);
	}

	private void Awake()
	{
		if (Animator == null)
		{
			Animator = GetComponent<Animator>();
		}
		if (Button == null)
		{
			Button = GetComponent<Button>();
		}
		Button.onClick.AddListener(onClick);
	}

	private void Start()
	{
		if (base.transform.parent != null)
		{
			AnimationToggleGroupButton[] componentsInChildren = base.transform.parent.GetComponentsInChildren<AnimationToggleGroupButton>(includeInactive: true);
			if (componentsInChildren[0] == this)
			{
				onClick();
			}
		}
	}

	private void onClick()
	{
		AnimationToggleGroupButton[] componentsInChildren = base.transform.parent.GetComponentsInChildren<AnimationToggleGroupButton>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i] != this)
			{
				componentsInChildren[i].SetAnimation(on: false);
			}
		}
		SetAnimation(on: true);
	}

	private void OnDestroy()
	{
		Button.onClick.RemoveListener(onClick);
	}
}
