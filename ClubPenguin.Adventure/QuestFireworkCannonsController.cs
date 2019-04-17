// QuestFireworkCannonsController
using ClubPenguin.Adventure;
using UnityEngine;

public class QuestFireworkCannonsController : MonoBehaviour
{
	public QuestFireworkCannon[] FireworkCannons;

	public void OnEnableCannon(int cannonIndex)
	{
		FireworkCannons[cannonIndex].EnableCannon();
	}

	public void OnActivateCannon(int cannonIndex)
	{
		FireworkCannons[cannonIndex].SetCannonActive();
	}

	public void OnDeactiveCannon(int cannonIndex)
	{
		FireworkCannons[cannonIndex].SetCannonInactive();
	}

	public void EnableLongTimer(int cannonIndex)
	{
		if (cannonIndex == -1)
		{
			for (int i = 0; i < FireworkCannons.Length; i++)
			{
				FireworkCannons[i].SetAnimatorBool(FireworkCannons[i].CannonSlowTimerAnimBool, value: true);
			}
		}
		else
		{
			FireworkCannons[cannonIndex].SetAnimatorBool(FireworkCannons[cannonIndex].CannonSlowTimerAnimBool, value: true);
		}
	}

	public void DisableLongTimer(int cannonIndex)
	{
		if (cannonIndex == -1)
		{
			for (int i = 0; i < FireworkCannons.Length; i++)
			{
				FireworkCannons[i].SetAnimatorBool(FireworkCannons[i].CannonSlowTimerAnimBool, value: false);
			}
		}
		else
		{
			FireworkCannons[cannonIndex].SetAnimatorBool(FireworkCannons[cannonIndex].CannonSlowTimerAnimBool, value: false);
		}
	}
}
