// AbstractAccountStateHandler
using Disney.Kelowna.Common.SEDFSM;
using UnityEngine;

public class AbstractAccountStateHandler : MonoBehaviour
{
	protected StateMachine rootStateMachine;

	public string HandledState;

	public void Start()
	{
		rootStateMachine = GetComponent<StateMachine>();
	}
}
