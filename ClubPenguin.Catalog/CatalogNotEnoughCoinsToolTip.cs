// CatalogNotEnoughCoinsToolTip
using Disney.Kelowna.Common;
using System.Collections;
using UnityEngine;

public class CatalogNotEnoughCoinsToolTip : MonoBehaviour
{
	private const string ANIM_ISOPEN = "IsOpen";

	public float ToolTipDisplayTime = 3f;

	private Animator animator;

	private bool isOpen;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		isOpen = false;
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
		CoroutineRunner.Start(showToolTipTimed(), this, "showToolTipTimed_catalog");
	}

	public IEnumerator showToolTipTimed()
	{
		animator.SetBool("IsOpen", value: true);
		yield return new WaitForSeconds(ToolTipDisplayTime);
		Hide();
	}

	public void Hide()
	{
		CoroutineRunner.StopAllForOwner(this);
		if (base.gameObject.activeSelf)
		{
			animator.SetBool("IsOpen", value: false);
		}
	}

	public void OnTooltipOpenAnimationComplete()
	{
		isOpen = true;
	}

	public void OnTooltipCloseAnimationComplete()
	{
		if (isOpen)
		{
			isOpen = false;
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnDestroy()
	{
		CoroutineRunner.StopAllForOwner(this);
	}
}
