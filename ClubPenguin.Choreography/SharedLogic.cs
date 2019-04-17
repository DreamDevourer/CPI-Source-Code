// SharedLogic
using ClubPenguin.Choreography;
using UnityEngine;

public abstract class SharedLogic : ScriptableObject
{
	public abstract bool Execute(Actor.InteractionState interactionState);
}
