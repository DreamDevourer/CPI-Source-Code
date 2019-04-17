// BenchmarkConfig
using ClubPenguin.Benchmarking;
using Disney.Kelowna.Common.Environment;
using UnityEngine;

public class BenchmarkConfig : ScriptableObject
{
	public string UserName;

	public string Password;

	public Environment ServerEnvironment = Environment.QA;

	public BenchmarkTest[] Tests;
}
