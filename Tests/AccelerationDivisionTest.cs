using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	[TestFixture]
	public class AccelerationDivisionTest
	{
		#region FeetPerMinute / FeetPerMinutePerSecond

		[Test]
		public void DivideOperator_FeetPerMinuteByFeetPerMinutePerSecond_ReturnsTransitionTime()
		{
			Seconds t = 1800.FeetPerMinute() / 75.FeetPerMinutePerSecond();
			Assert.AreEqual(24.Seconds(), t);
			Assert.IsInstanceOf<Seconds>(t);
		}

		[Test]
		public void DivideOperator_FeetPerMinute_SignsOfOperandsDoNotAffectTheResult()
		{
			Seconds expected = 24.Seconds();

			Assert.AreEqual(expected, 1800.FeetPerMinute() / 75.FeetPerMinutePerSecond());
			Assert.AreEqual(expected, 1800.FeetPerMinute() / (-75).FeetPerMinutePerSecond());
			Assert.AreEqual(expected, (-1800).FeetPerMinute() / 75.FeetPerMinutePerSecond());
			Assert.AreEqual(expected, (-1800).FeetPerMinute() / (-75).FeetPerMinutePerSecond());
		}

		[Test]
		public void DivideOperator_FeetPerMinute_AgreesWithTheBaseClassOperator()
		{
			TimeUnit viaBase = (SpeedUnit)1800.FeetPerMinute() / (AccelerationUnit)75.FeetPerMinutePerSecond();
			Seconds viaTyped = 1800.FeetPerMinute() / 75.FeetPerMinutePerSecond();

			Assert.AreEqual(viaBase, viaTyped);

			//and when the rate points the other way, where the two used to disagree
			TimeUnit negativeViaBase = (SpeedUnit)1800.FeetPerMinute() / (AccelerationUnit)(-75).FeetPerMinutePerSecond();
			Seconds negativeViaTyped = 1800.FeetPerMinute() / (-75).FeetPerMinutePerSecond();

			Assert.AreEqual(negativeViaBase, negativeViaTyped);
		}

		[Test]
		public void DivideOperator_FeetPerMinuteByZeroAcceleration_ReturnsNull()
		{
			Assert.IsNull(1800.FeetPerMinute() / 0.FeetPerMinutePerSecond());
			Assert.IsNull(1800.FeetPerMinute() / FeetPerMinutePerSecond.Zero);
		}

		#endregion

		#region Knots / KnotsPerSecond

		[Test]
		public void DivideOperator_KnotsByKnotsPerSecond_ReturnsTransitionTime()
		{
			Seconds t = 30.Knots() / 5.KnotsPerSecond();
			Assert.AreEqual(6.Seconds(), t);
			Assert.IsInstanceOf<Seconds>(t);
		}

		[Test]
		public void DivideOperator_KnotsSpeedRestriction_ReturnsTimeToSlowDown()
		{
			//The realistic shape: 250 kt now, 180 kt required, decelerating at 1 kt/s
			Knots delta = 180.Knots() - 250.Knots();
			Assert.AreEqual(new Knots(-70), delta);

			Seconds t = delta / 1.KnotsPerSecond();
			Assert.AreEqual(70.Seconds(), t);

			//stating the rate as a deceleration has to give the same duration
			Assert.AreEqual(t, delta / (-1).KnotsPerSecond());
		}

		[Test]
		public void DivideOperator_Knots_SignsOfOperandsDoNotAffectTheResult()
		{
			Seconds expected = 6.Seconds();

			Assert.AreEqual(expected, 30.Knots() / 5.KnotsPerSecond());
			Assert.AreEqual(expected, 30.Knots() / (-5).KnotsPerSecond());
			Assert.AreEqual(expected, (-30).Knots() / 5.KnotsPerSecond());
			Assert.AreEqual(expected, (-30).Knots() / (-5).KnotsPerSecond());
		}

		[Test]
		public void DivideOperator_Knots_AgreesWithTheBaseClassOperator()
		{
			TimeUnit viaBase = (SpeedUnit)30.Knots() / (AccelerationUnit)5.KnotsPerSecond();
			Seconds viaTyped = 30.Knots() / 5.KnotsPerSecond();

			Assert.AreEqual(viaBase, viaTyped);

			TimeUnit negativeViaBase = (SpeedUnit)30.Knots() / (AccelerationUnit)(-5).KnotsPerSecond();
			Seconds negativeViaTyped = 30.Knots() / (-5).KnotsPerSecond();

			Assert.AreEqual(negativeViaBase, negativeViaTyped);
		}

		[Test]
		public void DivideOperator_KnotsByZeroAcceleration_ReturnsNull()
		{
			Assert.IsNull(30.Knots() / 0.KnotsPerSecond());
		}

		#endregion

		#region MetersPerSecond / MetersPerSecondSquared

		[Test]
		public void DivideOperator_MetersPerSecondByMetersPerSecondSquared_ReturnsTransitionTime()
		{
			Seconds t = 10.MetersPerSecond() / 2.MetersPerSecondSquared();
			Assert.AreEqual(5.Seconds(), t);
			Assert.IsInstanceOf<Seconds>(t);
		}

		[Test]
		public void DivideOperator_MetersPerSecond_SignsOfOperandsDoNotAffectTheResult()
		{
			Seconds expected = 5.Seconds();

			Assert.AreEqual(expected, 10.MetersPerSecond() / 2.MetersPerSecondSquared());
			Assert.AreEqual(expected, 10.MetersPerSecond() / (-2).MetersPerSecondSquared());
			Assert.AreEqual(expected, new MetersPerSecond(-10) / 2.MetersPerSecondSquared());
			Assert.AreEqual(expected, new MetersPerSecond(-10) / (-2).MetersPerSecondSquared());
		}

		[Test]
		public void DivideOperator_MetersPerSecond_AgreesWithTheBaseClassOperator()
		{
			TimeUnit viaBase = (SpeedUnit)10.MetersPerSecond() / (AccelerationUnit)2.MetersPerSecondSquared();
			Seconds viaTyped = 10.MetersPerSecond() / 2.MetersPerSecondSquared();

			Assert.AreEqual(viaBase, viaTyped);

			TimeUnit negativeViaBase = (SpeedUnit)10.MetersPerSecond() / (AccelerationUnit)(-2).MetersPerSecondSquared();
			Seconds negativeViaTyped = 10.MetersPerSecond() / (-2).MetersPerSecondSquared();

			Assert.AreEqual(negativeViaBase, negativeViaTyped);
		}

		[Test]
		public void DivideOperator_MetersPerSecondByZeroAcceleration_ReturnsNull()
		{
			Assert.IsNull(10.MetersPerSecond() / 0.MetersPerSecondSquared());
			Assert.IsNull(10.MetersPerSecond() / MetersPerSecondSquared.Zero);
		}

		#endregion

		[Test]
		public void DivideOperator_EquivalentTransitionInDifferentUnits_GivesTheSameTime()
		{
			//20 ft/s at 5 ft/s^2 is the same physical transition as 6.096 m/s at 1.524 m/s^2
			Seconds imperial = new FeetPerSecond(20) / new FeetPerSecondSquared(5);
			Seconds metric = new MetersPerSecond(6.096) / new MetersPerSecondSquared(1.524);

			Assert.AreEqual(4, imperial.UnitValue, 1e-12);
			Assert.AreEqual(imperial.UnitValue, metric.UnitValue, 1e-12);
		}

		[Test]
		public void DivideOperator_EveryAccelerationUnit_RoundTripsWithMultiplication()
		{
			Seconds t = 4.Seconds();

			FeetPerMinute fpm = 25.FeetPerMinutePerSecond() * t;
			Assert.AreEqual(t, fpm / 25.FeetPerMinutePerSecond());

			Knots kts = 5.KnotsPerSecond() * t;
			Assert.AreEqual(t, kts / 5.KnotsPerSecond());

			MetersPerSecond mps = 2.MetersPerSecondSquared() * t;
			Assert.AreEqual(t, mps / 2.MetersPerSecondSquared());

			FeetPerSecond fps = new FeetPerSecondSquared(5) * t;
			Assert.AreEqual(t, fps / new FeetPerSecondSquared(5));
		}
	}
}
