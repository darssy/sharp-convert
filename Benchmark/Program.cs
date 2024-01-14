using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using MmiSoft.Core.Math.Units.Struct;
using SharpConvert.Experimental;
using KnotsClass = MmiSoft.Core.Math.Units.Knots;
using MetersPerSecondClass = MmiSoft.Core.Math.Units.MetersPerSecond;
using Length = SharpConvert.Experimental.Length;

namespace UnitsBenchmark;

[ExcludeFromCodeCoverage]
public static class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine("Select a benchmark to run");
		Console.WriteLine("1. ConversionBenchmark (KtsToFpm)");
		Console.WriteLine("2. UnitOperation (Kts + Fpm, has random.Next overhead)");
		Console.WriteLine("3. Conversion to same unit (Kts to Kts, has random.Next overhead)");
		Console.WriteLine("4. Framework benchmark (NET7.0 and NETFramework4.8)");
		switch (Console.ReadLine())
		{
			case "1":
				BenchmarkRunner.Run<ConversionBenchmark>();
				break;
			case "2":
				BenchmarkRunner.Run<UnitOperationBenchmark>();
				break;
			case "3":
				BenchmarkRunner.Run<KtsToKtsBenchmarkList>();
				break;
			case "4":
				BenchmarkRunner.Run<FrameworkBenchmark>();
				break;
			default:
				Console.WriteLine("Unknown selection. Quiting");
				return;
		}
		Console.WriteLine("Press enter to exit");
		Console.ReadLine();
	}

	[InliningDiagnoser(true, true)]
	public class KnotsToMpsBenchmarkInlineDiagnosis
	{
		private Random r1 = new(1);
		private Random r2 = new(1);
		private Random r3 = new(1);

		[Benchmark(Baseline = true)]
		public double PlainOlDivisionConversion()
		{
			return r1.Next(20, 580) * SpeedConversions.Knot.ToSiFactor / SpeedConversions.FootPerMinute.ToSiFactor;
		}

		[Benchmark]
		public double ScUglyStructConversion()
		{
			return new Speed<Length.NM, Time.h>(r2.Next(20, 580)).To<Length.ft, Time.min>().Value;
		}

		[Benchmark]
		public double ScStructConversion()
		{
			return new Knots(r3.Next(20, 580)).To(SpeedConversions.FootPerMinute).UnitValue;
		}

		/*[Benchmark]
		public double ScClassConversion()
		{
			return new KnotsClass(486).To<MetersPerSecondClass>().UnitValue;
		}

		[Benchmark]
		public double UnitsNetConversion()
		{
			return UnitsNet.Speed.FromKnots(486).MetersPerSecond;
		}

		private static readonly Gu.Units.SpeedUnit KnotUnit =
			new(kts => 0.51444444444444444 * kts, mps => mps / 0.51444444444444444, "kts");

		[Benchmark]
		public double GuUnitsConversion()
		{
			return Gu.Units.Speed.From(486, KnotUnit).MetresPerSecond;
		}*/
	}

	[MemoryDiagnoser]
	public class UnitOperationBenchmark
	{
		private Random random = new(1);

		[Benchmark(Baseline = true)]
		public Knots SharpConvertStructAddOp() => new Knots(random.Next(120, 310)) + new MetersPerSecond(random.Next(4, 50));

		[Benchmark]
		public KnotsClass SharpConvertClassAddOp() =>
			new KnotsClass(random.Next(120, 310)) + new MetersPerSecondClass(random.Next(4, 50));

		[Benchmark]
		public UnitsNet.Speed UnitsNetAddOp() => UnitsNet.Speed.FromKnots(random.Next(120, 310))
		                                         + UnitsNet.Speed.FromMetersPerSecond(random.Next(4, 50));

		private static readonly Gu.Units.SpeedUnit KnotUnit =
			new(kts => 0.51444444444444444 * kts, mps => mps / 0.51444444444444444, "kts");

		[Benchmark]
		public Gu.Units.Speed GuUnitsAddOp() => Gu.Units.Speed.From(random.Next(120, 310), KnotUnit)
		                                        + Gu.Units.Speed.FromMetresPerSecond(random.Next(4, 50));
	}
}
