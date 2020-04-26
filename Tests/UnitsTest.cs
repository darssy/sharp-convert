﻿using System;
using System.Diagnostics.CodeAnalysis;
using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	[TestFixture]
	public class UnitsTest : AssertionHelper
	{
		[Test(Description="Valid values tests, no symbols, no decimals")]
		public void SpeedValidation()
		{
			Knots kts = new Knots(345);
			LengthUnit m = kts * new Minutes(1);
			Expect(m is NauticalMiles);
			Expect(m.UnitValue == 5.75);

			FeetPerMinute fpm = new FeetPerMinute(1800);
			TimeUnit min = new Feet(9000) / fpm;
			Expect(min is Minutes);
			Expect(min.UnitValue == 5);
		}

		[Test]
		public void ImplicitConversionsBetweenUnits()
		{
			Meters m = new Meters(1852);
			NauticalMiles nm = new NauticalMiles(12);
			Meters sum = (nm + m).To<Meters>();
			Expect(sum.UnitValue == 13 * 1852);
		}

		[Test]
		public void ExtensionMethods()
		{
			Feet f = 14.5.Feet();

			Knots speed = 450.Knots();
			Knots speed2 = new Knots(450);
			Assert.AreEqual(speed, speed2);
		}

		[Test]
		[SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
		public void Exceptions()
		{
			Assert.Catch<ArgumentOutOfRangeException>(() => new Meters(-10));
			Assert.Catch<ArgumentOutOfRangeException>(() => new RogueLength(1));
		}

		[Test]
		public void ToStringIncludesUnitSymbol()
		{
			Assert.AreEqual(new Meters(34).ToString(), "34m");
		}

		[Test]
		public void ToStringWithFormatting_FormatIsIdenticalToDouble_IncludesUnitSymbol()
		{
			Assert.AreEqual(0.89.ToString("0.00") + "m", 0.89.Meters().ToString("0.00"));
		}

		[Test]
		public void ToStringWithFormatting_AppliesRounding()
		{
			Assert.AreEqual("0,89m", 0.8934.Meters().ToString("0.00"));
			Assert.AreEqual("0,90m", 0.8958.Meters().ToString("0.00"));
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
		}

		private class RogueLength : LengthUnit
		{
			public RogueLength(double length) : base(length, -7)
			{
			}

			public override string Symbol => "rogue";
		}
	}
}
