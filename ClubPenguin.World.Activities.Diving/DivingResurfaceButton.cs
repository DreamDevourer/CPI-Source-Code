// DivingResurfaceButton
using ClubPenguin;
using ClubPenguin.UI;
using ClubPenguin.World.Activities.Diving;
using UnityEngine;

[RequireComponent(typeof(InputButtonMapper))]
public class DivingResurfaceButton : MonoBehaviour
{
	public float DEPTH_RESURFACE_ENABLED = 10f;

	private bool isDisabled;

	private TrayInputButton trayInputButton;

	private DivingGameController divingController;

	private GameObject playerGO;

	private void Start()
	{
		divingController = getDivingController();
		trayInputButton = GetComponentInParent<TrayInputButton>();
	}

	private void Update()
	{
		if (trayInputButton.IsLocked)
		{
			return;
		}
		if (divingController == null)
		{
			getDivingController();
			if (!isDisabled)
			{
				isDisabled = true;
				trayInputButton.SetState(TrayInputButton.ButtonState.Disabled);
			}
		}
		else if (divingController.Depth < DEPTH_RESURFACE_ENABLED != isDisabled)
		{
			isDisabled = (divingController.Depth < DEPTH_RESURFACE_ENABLED);
			if (isDisabled)
			{
				trayInputButton.SetState(TrayInputButton.ButtonState.Disabled);
			}
			else
			{
				trayInputButton.SetState(TrayInputButton.ButtonState.Default);
			}
		}
	}

	private DivingGameController getDivingController()
	{
		if (divingController == null)
		{
			divingController = getPlayerGO().GetComponent<DivingGameController>();
		}
		return divingController;
	}

	private GameObject getPlayerGO()
	{
		if (playerGO == null)
		{
			playerGO = SceneRefs.ZoneLocalPlayerManager.LocalPlayerGameObject;
		}
		return playerGO;
	}
}
