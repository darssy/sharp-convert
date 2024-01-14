using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using MmiSoft.Core.Math.Units.Struct;
using UnitsNet;

namespace UnitsBenchmark;

using KnotsClass = MmiSoft.Core.Math.Units.Knots;

[MemoryDiagnoser]
public class KtsToKtsBenchmark
{
	private Random random;

	[GlobalSetup]
	public void GlobalSetup() => random = new(2134);

	[Benchmark]
	public double ScStructConversion() => new Knots(random.Next(120, 310)).To(SpeedConversions.Knot).UnitValue;

	[Benchmark]
	public double ScClassConversion() => new KnotsClass(random.Next(120, 310)).To<KnotsClass>().UnitValue;

	[Benchmark]
	public double UnitsNetConversion() => UnitsNet.Speed.FromKnots(random.Next(120, 310)).Knots;
}

[MemoryDiagnoser]
public class KtsToKtsBenchmarkNoOverhead
{
	[Benchmark]
	public double ScStructConversion() => new Knots(215).To(SpeedConversions.Knot).UnitValue;

	[Benchmark]
	public double ScClassConversion() => new KnotsClass(215).To<KnotsClass>().UnitValue;

	[Benchmark]
	public double UnitsNetConversion() => UnitsNet.Speed.FromKnots(215).Knots;
}

[MemoryDiagnoser]
public class KtsToKtsBenchmarkList
{
	private const int OpCount = 2_000;

	private static List<int> casList = new(OpCount);

	private double[] result = new double[OpCount];

	static KtsToKtsBenchmarkList()
	{
		Random random = new(2134);
		for (int i = 0; i < OpCount; i++)
		{
			casList.Add(random.Next(120, 310));
		}
	}

	[Benchmark(OperationsPerInvoke = OpCount)]
	public void ScStructConversion()
	{
		for (int i = 0; i < OpCount; i++)
		{
			result[i] = new Knots(casList[i]).To(SpeedConversions.Knot).UnitValue;
		}
	}

	[Benchmark(OperationsPerInvoke = OpCount)]
	public void ScClassConversion()
	{
		for (int i = 0; i < OpCount; i++)
		{
			result[i] = new KnotsClass(casList[i]).To<KnotsClass>().UnitValue;
		}
	}

	[Benchmark(OperationsPerInvoke = OpCount)]
	public void UnitsNetConversion()
	{
		for (int i = 0; i < OpCount; i++)
		{
			result[i] = Speed.FromKnots(casList[i]).Knots;
		}
	}
}
