using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MmiSoft.Core.Math.Units.Struct;
using SharpConvert.Experimental;
using FeetPerMinute = MmiSoft.Core.Math.Units.FeetPerMinute;

namespace UnitsBenchmark;

[RankColumn]
[SimpleJob(RuntimeMoniker.Net48, baseline: true)]
[SimpleJob(RuntimeMoniker.Net70)]
public class FrameworkBenchmark
{
	private static List<int> casList = new(OpCount);

	private const int OpCount = 2_000;
	private double[] result = new double[OpCount];

	static FrameworkBenchmark()
	{
		Random random = new(1);
		for (int i = 0; i < OpCount; i++)
		{
			casList.Add(random.Next(20, 580));
		}
	}

	[Benchmark(Baseline = true, OperationsPerInvoke = OpCount)]
	public void PlainOlDivision()
	{
		for (var i = 0; i < casList.Count; i++)
		{
			result[i] = casList[i] * SpeedConversions.Knot.ToSiFactor / SpeedConversions.FootPerMinute.ToSiFactor;
		}
	}

	[Benchmark(OperationsPerInvoke = OpCount)]
	public void SharpConvertUglyStruct()
	{
		for (var i = 0; i < casList.Count; i++)
		{
			result[i] = new Speed<Length.NM, Time.h>(casList[i]).To<Length.ft, Time.min>().Value;
		}
	}

	[Benchmark(OperationsPerInvoke = OpCount)]
	public void SharpConvertStruct()
	{
		for (var i = 0; i < casList.Count; i++)
		{
			result[i] = new Knots(casList[i]).To(SpeedConversions.FootPerMinute).UnitValue;
		}
	}

	[Benchmark(OperationsPerInvoke = OpCount)]
	public void SharpConvertClass()
	{
		for (var i = 0; i < casList.Count; i++)
		{
			result[i] = new MmiSoft.Core.Math.Units.Knots(casList[i]).To<FeetPerMinute>().UnitValue;
		}
	}
}
