// Tutorial
using System;

[Serializable]
public struct Tutorial
{
	public int tutorialID;

	public bool isComplete;

	public Tutorial(int tutorialID, bool isComplete)
	{
		this.tutorialID = tutorialID;
		this.isComplete = isComplete;
	}

	public override string ToString()
	{
		return $"[Tutorial] ID: {tutorialID} IsComplete: {isComplete}";
	}
}
