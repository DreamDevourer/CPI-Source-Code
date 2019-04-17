// StateMachineLoaderSettings
using ClubPenguin.Core;
using Disney.Kelowna.Common.SEDFSM;
using System;

[Serializable]
public class StateMachineLoaderSettings : AbstractAspectRatioSpecificSettings
{
	public StateMachineLoader.Binding[] BindingOverrides;
}
