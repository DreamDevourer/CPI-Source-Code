// SetErrorArrow
using ClubPenguin.Error;
using UnityEngine;

public class SetErrorArrow : MonoBehaviour
{
	public GameObject leftArrow;

	public GameObject upArrow;

	public GameObject rightArrow;

	public GameObject downArrow;

	private void OnEnable()
	{
		leftArrow.SetActive(value: false);
		upArrow.SetActive(value: false);
		rightArrow.SetActive(value: false);
		downArrow.SetActive(value: false);
	}

	public void SetArrowByDirection(ErrorDirection errorPosition)
	{
		switch (errorPosition)
		{
		case ErrorDirection.DOWN:
			upArrow.SetActive(value: true);
			break;
		case ErrorDirection.LEFT:
			rightArrow.SetActive(value: true);
			break;
		case ErrorDirection.RIGHT:
			leftArrow.SetActive(value: true);
			break;
		case ErrorDirection.UP:
			downArrow.SetActive(value: true);
			break;
		}
	}
}
