// HelpBoxAttribute
using UnityEngine;

public class HelpBoxAttribute : PropertyAttribute
{
	public readonly string message;

	public readonly float height;

	public HelpBoxAttribute(string helpMessage, float helpHeight)
	{
		message = helpMessage;
		height = helpHeight;
	}
}
