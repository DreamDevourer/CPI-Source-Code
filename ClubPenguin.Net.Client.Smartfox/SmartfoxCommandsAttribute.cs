// SmartfoxCommandsAttribute
using System;

internal class SmartfoxCommandsAttribute : Attribute
{
	public string Command
	{
		get;
		private set;
	}

	internal SmartfoxCommandsAttribute(string command)
	{
		Command = command;
	}
}
