// ItemGroupSpacingRule<T>
using ClubPenguin.Core;
using ClubPenguin.Core.StaticGameData;
using System;
using System.Collections.Generic;

[Serializable]
public class ItemGroupSpacingRule<T> where T : StaticGameDataDefinition, IMemberLocked
{
	public int Count;

	public bool[] Slots;

	public T[] CreateSpacing(T[] input)
	{
		if (Count <= 0)
		{
			throw new InvalidOperationException("Count must be greater than 0");
		}
		if (Slots.Length < Count)
		{
			throw new InvalidOperationException($"The Rules array length must be equal or greater to Count. Count {Count}, length {Slots.Length}");
		}
		if (input.Length != Count)
		{
			throw new InvalidOperationException($"The input array length must match the Count for this rule. Count {Count}, length {input.Length}");
		}
		int num = 0;
		for (int i = 0; i < Slots.Length; i++)
		{
			num = (Slots[i] ? (num + 1) : num);
		}
		if (num != Count)
		{
			throw new InvalidOperationException($"The slot count must be equal to Count. Count {Count}, slot count {num}");
		}
		List<T> list = new List<T>();
		int num2 = 0;
		for (int i = 0; i < Slots.Length; i++)
		{
			if (Slots[i])
			{
				list.Add(input[num2]);
				num2++;
			}
			else
			{
				list.Add(null);
			}
		}
		return list.ToArray();
	}
}
