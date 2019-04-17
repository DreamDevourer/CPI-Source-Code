// AllAccessCountdownBarController
using ClubPenguin;
using ClubPenguin.Core;
using Disney.MobileNetwork;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllAccessCountdownBarController : MonoBehaviour
{
	public GameObject Ticker;

	public List<string> ExcludedScenes;

	private void Awake()
	{
		if (isTickerShowable())
		{
			show();
		}
		else
		{
			Hide();
		}
	}

	public void Show()
	{
		if (isTickerShowable())
		{
			show();
		}
	}

	private void show()
	{
		Ticker.SetActive(value: true);
	}

	public void Hide()
	{
		Ticker.SetActive(value: false);
	}

	private bool isTickerShowable()
	{
		if (Service.Get<AllAccessService>().IsAllAccessActive() && !ExcludedScenes.Contains(SceneManager.GetActiveScene().name))
		{
			CPDataEntityCollection cPDataEntityCollection = Service.Get<CPDataEntityCollection>();
			if (cPDataEntityCollection.TryGetComponent(cPDataEntityCollection.LocalPlayerHandle, out MembershipData component) && component.MembershipType != MembershipType.Member)
			{
				return true;
			}
		}
		return false;
	}
}
