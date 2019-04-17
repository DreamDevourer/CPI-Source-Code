// BackButtonDisabler
using ClubPenguin;
using UnityEngine;

public class BackButtonDisabler : MonoBehaviour
{
	private void OnEnable()
	{
		BackButtonStateHandler componentInParent = GetComponentInParent<BackButtonStateHandler>();
		if (!(componentInParent == null) && !componentInParent.CanGoBack())
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
