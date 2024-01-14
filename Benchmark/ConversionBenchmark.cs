using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using MmiSoft.Core.Math.Units.Struct;
using SharpConvert.Experimental;
using FeetPerMinute = MmiSoft.Core.Math.Units.FeetPerMinute;

namespace UnitsBenchmark;

[MemoryDiagnoser]
public class ConversionBenchmark
{
	private static List<int> casList = new(OpCount);

	private const int OpCount = 2_000;
	private double[] result = new double[OpCount];

	static ConversionBenchmark()
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

	[Benchmark(OperationsPerInvoke = OpCount)]
	public void UnitsNet()
	{
		for (var i = 0; i < casList.Count; i++)
		{
			result[i] = global::UnitsNet.Speed.FromKnots(casList[i]).FeetPerMinute;
		}
	}

	private static readonly Gu.Units.SpeedUnit KnotUnit =
		new(kts => 0.51444444444444444 * kts, mps => mps / 0.51444444444444444, "kts");
		
	private static readonly Gu.Units.SpeedUnit FpmUnit =
		new(kts => 0.00508 * kts, mps => mps / 0.00508, "fpm");

	[Benchmark(OperationsPerInvoke = OpCount)]
	public void GuUnits()
	{
		for (var i = 0; i < casList.Count; i++)
		{
			result[i] = FpmUnit.FromSiUnit(Gu.Units.Speed.From(casList[i], KnotUnit).SiValue);
		}
	}
}
