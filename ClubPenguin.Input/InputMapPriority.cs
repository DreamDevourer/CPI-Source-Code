// InputMapPriority
using ClubPenguin.Input;
using System.Collections.Generic;
using UnityEngine;

public class InputMapPriority : ScriptableObject
{
	public List<InputMapLib> PriorityList;

	public InputMapLib ModalInputMap;

	public InputMapLib AnyKeyInputMap;
}
