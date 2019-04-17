// SystemEnvironment
using Disney.Mix.SDK.Internal;
using System;

public class SystemEnvironment : ISystemEnvironment
{
	public int ProcessorCount => Environment.ProcessorCount;
}
