using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	[TestFixture]
	public class AccelerationUnitTest
	{
		[Test]
		public void MultiplyOperator_KnotsPerSecondTimesSeconds_ReturnsDeltaVeInKnots()
		{
			var knotsPerSecond = 0.5.KnotsPerSecond();
			Knots du = knotsPerSecond * 2.5.Seconds();

			Assert.AreEqual(1.25.Knots(), du);
		}

		[Test]
		public void MultiplyOperator_MeterPerSecondSquaredTimesSeconds_ReturnsDeltaVeInSpeedUnit()
		{
			var acceleration = new MetersPerSecondSquared(0.3);
			SpeedUnit du = acceleration * new Seconds(12);

			Assert.AreEqual(new MetersPerSecond(3.6), du);
		}

		[Test]
		public void MultiplyOperator_AccelerationTimesSeconds_ReturnsDeltaVeInSpeedUnit()
		{
			Seconds t = 4.Seconds();
			FeetPerMinutePerSecond a = 25.FeetPerMinutePerSecond();
			FeetPerMinute u = 100.FeetPerMinute();
			Assert.AreEqual(u, a * t);

			//Force TimeUnit overloaded operator call
			Assert.AreEqual(u, a * (TimeUnit)t);
		}

		[Test]
		public void DivideOperator_SpeedByAcceleration_ReturnsTimeToCompleteTransition()
		{
			var acceleration = new FeetPerMinutePerSecond(75);
			FeetPerMinute speed = 1800.FeetPerMinute();

			Seconds expected = 24.Seconds();
			Assert.AreEqual(expected, speed / acceleration);

			//Force parent class operator call
			Assert.AreEqual(expected, speed / (AccelerationUnit)acceleration);
		}

		[Test]
		public void DivideOperator_SpeedByZeroAcceleration_ReturnsNull()
		{
			FeetPerMinute speed = 1800.FeetPerMinute();

			Assert.AreEqual(null, speed / FeetPerMinutePerSecond.Zero);

			//Force parent class operator call
			Assert.AreEqual(null, speed / AccelerationUnit.Zero);
		}

		[Test]
		public void NegateOperator()
		{
			MetersPerSecondSquared speed = 3.MetersPerSecondSquared();

			Assert.AreEqual((-3).MetersPerSecondSquared(), -speed);
		}
	}
}
