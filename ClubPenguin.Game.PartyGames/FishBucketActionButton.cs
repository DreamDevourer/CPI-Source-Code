// FishBucketActionButton
using ClubPenguin.UI;
using UnityEngine;

[RequireComponent(typeof(InputButtonMapper))]
public class FishBucketActionButton : MonoBehaviour
{
	private void Start()
	{
		TrayInputButtonDisabler buttonDisabler = getButtonDisabler();
		if (buttonDisabler != null)
		{
			buttonDisabler.DisableElement(hide: false);
		}
	}

	private TrayInputButtonDisabler getButtonDisabler()
	{
		return GetComponentInParent<TrayInputButtonDisabler>();
	}

	private void OnDestroy()
	{
		TrayInputButtonDisabler buttonDisabler = getButtonDisabler();
		if (buttonDisabler != null)
		{
			buttonDisabler.EnableElement();
		}
	}
}
