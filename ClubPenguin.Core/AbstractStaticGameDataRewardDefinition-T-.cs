// AbstractStaticGameDataRewardDefinition<T>
using ClubPenguin.Core;
using ClubPenguin.Core.StaticGameData;
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public abstract class AbstractStaticGameDataRewardDefinition<T> : IRewardableDefinition where T : StaticGameDataDefinition
{
	public abstract IRewardable Reward
	{
		get;
	}

	protected abstract T getField();

	public static T[] ToDefinitionArray<L>(List<L> definitions) where L : AbstractStaticGameDataRewardDefinition<T>
	{
		T[] array = new T[definitions.Count];
		for (int i = 0; i < array.Length; i++)
		{
			T[] array2 = array;
			int num = i;
			L val = definitions[i];
			array2[num] = val.getField();
		}
		return array;
	}
}
