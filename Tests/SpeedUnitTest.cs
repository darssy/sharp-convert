using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	[TestFixture]
	public class SpeedUnitTest
	{

		[Test]
		public void Equals_WithNull_ReturnsFalse()
		{
			Assert.False(30.Knots().Equals(null));
		}

		[Test]
		public void Equals_WithSameReference_ReturnsFalse()
		{
			Knots knots = 100.Knots();
			Assert.True(knots.Equals(knots));
		}

		[Test]
		public void EqualityOperator_WithOtherTypes_ReturnsTrue()
		{
			Assert.AreEqual(1000.FeetPerMinute(), new MetersPerSecond(1000 * 0.3048 / 60));
			Assert.True(1000.FeetPerMinute() == new MetersPerSecond(1000 * 0.3048 / 60));
			Assert.True(1000.FeetPerMinute() != new MetersPerSecond(1000));
		}

		[Test]
		public void EqualityOperator_WithNull()
		{
			Assert.False(1000.FeetPerMinute() == null);
			Assert.True(1000.FeetPerMinute() != null);
		}

		[Test]
		public void EqualityOperator_WithSelf()
		{
			FeetPerMinute fpm = 1000.FeetPerMinute();
			Assert.True(fpm == fpm);
			Assert.False(fpm != fpm);
		}

		[Test]
		public void DivisionOperator_DivideSpeedByZeroLength_ReturnsNull()
		{
			Assert.IsNull(3.Knots() / LengthUnit.Zero);
		}

		[Test]
		public void DivisionOperator_DivideSpeedByZeroAngularVelocity_ReturnsNull()
		{
			Assert.IsNull(3.Knots() / 0.DegreesPerSecond());
		}

		[Test]
		public void DivisionOperator_DivideLengthByZeroSpeed_ReturnsNull()
		{
			Assert.IsNull(10.Meters() / 0.MetersPerSecond());
		}

		[Test]
		public void MultiplyOperator_SpeedMultipliedWithTimeSpan_EqualsDistanceTraveled()
		{
			Assert.AreEqual(50.Knots() * TimeSpan.FromMinutes(10), new NauticalMiles(50.0 / 60 * 10));
		}
	}
}
