﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	[TestFixture]
	public class UnitsTest
	{
		[Test(Description="Valid values tests, no symbols, no decimals")]
		public void SpeedValidation()
		{
			Knots kts = new Knots(345);
			LengthUnit m = kts * new Minutes(1);
			Assert.True(m is NauticalMiles);
			Assert.AreEqual(5.75, m.UnitValue, 0.00001);

			FeetPerMinute fpm = new FeetPerMinute(1800);
			TimeUnit min = new Feet(9000) / fpm;
			Assert.True(min is Minutes);
			Assert.AreEqual(5, min.UnitValue, 0.00001);
		}

		[Test]
		public void ImplicitConversionsBetweenUnits()
		{
			Meters m = new Meters(1852);
			NauticalMiles nm = new NauticalMiles(12);
			Meters sum = (nm + m).To<Meters>();
			Assert.AreEqual(13 * 1852, sum.UnitValue, 0.00001);
		}

		[Test]
		public void ExtensionMethods()
		{
			Feet f = 14.5.Feet();
			Assert.AreEqual(14.5, f.UnitValue, 0.00001);

			Knots speed = 450.Knots();
			Knots speed2 = new Knots(450);
			Assert.AreEqual(speed, speed2);
		}

		[Test]
		[SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
		public void NegativeLengthAndSiFactorsAreNotAllowed_ResultsInExceptions()
		{
			Assert.Catch<ArgumentOutOfRangeException>(() => new Meters(-10));
			Assert.Catch<ArgumentOutOfRangeException>(() => new Conversion(-7, UnitType.Length));
		}

		[Test]
		public void ToStringIncludesUnitSymbol_UsesCurrentCulture()
		{
			Assert.AreEqual(new Meters(34).ToString(), "34m");
			string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			Assert.AreEqual(new Meters(34.05).ToString(), $"34{decimalSeparator}05m");
		}

		[Test]
		public void ToStringWithFormatting_FormatIsIdenticalToDouble_IncludesUnitSymbol()
		{
			Assert.AreEqual(0.89.ToString("0.00") + "m", 0.89.Meters().ToString("0.00"));
		}

		[Test]
		public void ToStringWithFormatting_AppliesRounding_UsesCurrentCulture()
		{
			string ds = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			Assert.AreEqual($"0{ds}89m", 0.8934.Meters().ToString("0.00"));
			Assert.AreEqual($"0{ds}90m", 0.8958.Meters().ToString("0.00"));
		}

		[Test]
		[SuppressMessage("ReSharper", "EqualExpressionComparison")]
		public void ComparisonOperators()
		{
			Assert.True(new Feet(10) > new Feet(6));
			Assert.True(10.Meters() > 4.Meters());
			
			Assert.True(18.Kilometers() < 10.NauticalMiles());
			
			Assert.True(1.Feet().Equals(0.3048.Meters()));

			Assert.True(1.Feet() == 0.3048.Meters());
			Assert.True(1.NauticalMiles() == 1852.Meters());
			Assert.False(10.NauticalMiles().Equals(null));
			Assert.False(10.NauticalMiles() == null);
			Assert.True(10.NauticalMiles() != null);

			LengthUnit l = 485.Feet();
			Assert.AreSame(l, l);
			Assert.AreEqual(l, l);
		}

		[Test]
		public void ArithmeticOperators()
		{
			LengthUnit l = 10.Meters();
			Assert.AreEqual(l / new Meters(5), 2);
			Assert.AreEqual(new Meters(1) / new Meters(2), .5); //30.Degrees().Sin()
			Assert.AreEqual(new Feet(10) / 2.5, 4.Feet());
			Assert.AreEqual(new Feet(10) / 2.5f, 4.Feet());
			Assert.AreEqual(new Feet(10) / 5, 2.Feet());

			Assert.AreEqual(new Meters(2.5) * 2, 5.Meters());
			Assert.AreEqual(2 * new Meters(2.5), 5.Meters());
			Assert.AreEqual(new Meters(4.1) * 2, 8.2.Meters().To<Feet>());

			Assert.AreEqual(2.5.Kilometers() - 2.Kilometers(), 500.Meters());
			Assert.AreEqual(2.5.Kilometers() - 2.Kilometers(), 2.Kilometers() - 2.5.Kilometers());
			Assert.AreEqual(2.5.Kilometers() + 500.Meters(), 3.Kilometers());
		}


		[Test]
		public void DivisionOperator_DivideLengthByZero_ReturnsNull()
		{
			Assert.Null(5.Meters() / System.Math.Sin(0));
		}

		[Test]
		public void EqualityPerformance()
		{
			int tests = 100_000_000;
			List<UnitBase> distances = new List<UnitBase>(tests);
			Random r = new Random(1);
			for (int i = 0; i < tests; i++)
			{
				switch (r.Next(0, 4))
				{
					case 0:
						distances.Add(new Meters(r.Next(1, 1000)));
						break;
					case 1:
						distances.Add(new Feet(r.Next(1, 1000)));
						break;
					case 2:
						distances.Add(new Kilometers(r.Next(1, 1000)));
						break;
					case 3:
						distances.Add(new NauticalMiles(r.Next(1, 1000)));
						break;
					case 4:
						distances.Add(new Degrees(r.Next(0, 360)));
						break;
					case 5:
						distances.Add(new Radians(r.NextDouble() * 2));
						break;
				}
			}

			int consecutiveEqual = 0;
			Stopwatch sw = Stopwatch.StartNew();
			for (int i = 0; i < distances.Count - 1; i++)
			{
				if (distances[i].Equals(distances[i + 1]))
				{
					consecutiveEqual++;
				}
			}
			sw.Stop();
			Console.WriteLine(consecutiveEqual);
			Console.WriteLine(sw.Elapsed);
		}
	}
}
