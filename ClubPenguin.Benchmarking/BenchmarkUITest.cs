// BenchmarkUITest
using ClubPenguin.Benchmarking;
using Disney.Kelowna.Common.GameObjectTree;
using Disney.Kelowna.Common.SEDFSM;
using System;

public class BenchmarkUITest : BenchmarkTest
{
	public StateMachineDefinition RootStateMachine;

	public TreeNodeDefinitionContentKey RootNode;

	public override void Run(Action<int> onFinishDelegate)
	{
		base.Run(onFinishDelegate);
	}
}
