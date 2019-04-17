// ObjectManipulationService
using ClubPenguin.ObjectManipulation;
using System;

public class ObjectManipulationService
{
	public Action<int, Action<bool>> ConfirmObjectRemoval;

	private StructurePlotManager structurePlotManager;

	public StructurePlotManager StructurePlotManager => structurePlotManager;

	public ObjectManipulationService()
	{
		structurePlotManager = new StructurePlotManager();
	}
}
