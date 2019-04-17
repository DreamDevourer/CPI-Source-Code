// SocketUserVarAttribute
using Sfs2X.Entities.Variables;
using System;

internal class SocketUserVarAttribute : Attribute
{
	public string Key
	{
		get;
		private set;
	}

	public VariableType Type
	{
		get;
		private set;
	}

	internal SocketUserVarAttribute(string key, VariableType type)
	{
		Key = key;
		Type = type;
	}
}
