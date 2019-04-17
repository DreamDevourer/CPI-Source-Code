// ResetObjectManipulationInputController
using ClubPenguin.ObjectManipulation.Input;
using UnityEngine;

[RequireComponent(typeof(ObjectManipulationInputController))]
public class ResetObjectManipulationInputController : MonoBehaviour
{
	private ObjectManipulationInputController objectManipulationInputController;

	private void Awake()
	{
		objectManipulationInputController = GetComponent<ObjectManipulationInputController>();
	}

	public void OnEnable()
	{
		objectManipulationInputController.Reset();
		base.enabled = false;
	}
}
