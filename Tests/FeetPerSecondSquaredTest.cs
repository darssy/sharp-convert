using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	/// <summary>
	/// Covers the division operators of <see cref="FeetPerSecondSquared"/>.
	/// <para>
	/// Dividing a speed by an acceleration answers "how long does it take to change speed by this much at this
	/// rate". The result is a magnitude: a duration is always in the future, so the sign of the speed difference
	/// and the sign of the acceleration are deliberately not encoded in it. Client code that needs to know
	/// whether the transition is actually achievable checks those two signs itself.
	/// </para>
	/// </summary>
	[TestFixture]
	public class FeetPerSecondSquaredTest
	{
		#region FeetPerSecond / FeetPerSecondSquared

		[Test]
		public void DivideOperator_SpeedByAcceleration_ReturnsTransitionTime()
		{
			Seconds t = new FeetPerSecond(20) / new FeetPerSecondSquared(5);
			Assert.AreEqual(4.Seconds(), t);
		}

		[Test]
		public void DivideOperator_SpeedByAcceleration_ReturnsSecondsNotTimeUnit()
		{
			//The typed overload has to win over AccelerationUnit.operator /(SpeedUnit, AccelerationUnit),
			//otherwise the caller gets a TimeUnit and has to convert
			Assert.IsInstanceOf<Seconds>(new FeetPerSecond(20) / new FeetPerSecondSquared(5));
		}

		[Test]
		public void DivideOperator_ZeroSpeedDifference_ReturnsZeroSeconds()
		{
			Assert.AreEqual(0.Seconds(), new FeetPerSecond(0) / new FeetPerSecondSquared(5));
		}

		[Test]
		public void DivideOperator_ZeroAcceleration_ReturnsNull()
		{
			Assert.IsNull(new FeetPerSecond(20) / new FeetPerSecondSquared(0));
		}

		[Test]
		public void DivideOperator_SignsOfOperands_DoNotAffectTheResult()
		{
			Seconds expected = 4.Seconds();

			Assert.AreEqual(expected, new FeetPerSecond(20) / new FeetPerSecondSquared(5));
			Assert.AreEqual(expected, new FeetPerSecond(20) / new FeetPerSecondSquared(-5));
			Assert.AreEqual(expected, new FeetPerSecond(-20) / new FeetPerSecondSquared(5));
			Assert.AreEqual(expected, new FeetPerSecond(-20) / new FeetPerSecondSquared(-5));
		}

		[Test]
		public void DivideOperator_SpeedDifferenceByDeceleration_ReturnsTimeToSlowDown()
		{
			FeetPerSecond delta = new FeetPerSecond(30) - new FeetPerSecond(50);
			Assert.AreEqual(new FeetPerSecond(-20), delta);

			Seconds t = delta / new FeetPerSecondSquared(-4);
			Assert.AreEqual(5.Seconds(), t);
		}

		[Test]
		public void DivideOperator_AgreesWithTheBaseClassOperator()
		{
			TimeUnit viaBase = new FeetPerSecond(20) / (AccelerationUnit)new FeetPerSecondSquared(5);
			Seconds viaTyped = new FeetPerSecond(20) / new FeetPerSecondSquared(5);

			Assert.AreEqual(viaBase, viaTyped);
			Assert.AreEqual(4.Seconds(), viaBase);
		}

		#endregion

		#region SpeedUnit / FeetPerSecondSquared

		[Test]
		public void DivideOperator_OtherSpeedUnit_ConvertsToFeetPerSecondFirst()
		{
			//60 kt is 101.268591426072 ft/s
			Seconds t = 60.Knots() / new FeetPerSecondSquared(5);
			Assert.AreEqual(20.2537182852144, t.UnitValue, 1e-10);
		}

		[Test]
		public void DivideOperator_OtherSpeedUnit_MatchesAnExplicitConversion()
		{
			Seconds converted = 60.Knots().To<FeetPerSecond>() / new FeetPerSecondSquared(5);
			Seconds direct = 60.Knots() / new FeetPerSecondSquared(5);

			Assert.AreEqual(converted, direct);
		}

		[Test]
		public void DivideOperator_FeetPerSecondAsSpeedUnit_MatchesTheTypedOverload()
		{
			Seconds viaSpeedUnit = (SpeedUnit)new FeetPerSecond(20) / new FeetPerSecondSquared(5);
			Seconds viaTyped = new FeetPerSecond(20) / new FeetPerSecondSquared(5);

			Assert.AreEqual(viaTyped, viaSpeedUnit);
		}

		[Test]
		public void DivideOperator_OtherSpeedUnitByZeroAcceleration_ReturnsNull()
		{
			//The zero guard must not depend on which speed unit was passed in
			Assert.IsNull(60.Knots() / new FeetPerSecondSquared(0));
			Assert.IsNull((SpeedUnit)new FeetPerSecond(20) / new FeetPerSecondSquared(0));
			Assert.IsNull(1000.FeetPerMinute() / new FeetPerSecondSquared(0));
		}

		[Test]
		public void DivideOperator_OtherSpeedUnit_SignsDoNotAffectTheResult()
		{
			Seconds positive = 60.Knots() / new FeetPerSecondSquared(5);
			Seconds negative = (-60).Knots() / new FeetPerSecondSquared(5);
			Seconds decelerating = 60.Knots() / new FeetPerSecondSquared(-5);

			Assert.AreEqual(positive, negative);
			Assert.AreEqual(positive, decelerating);
		}

		#endregion

		#region FeetPerSecondSquared / scalar

		[Test]
		public void DivideOperator_AccelerationByScalar_ReturnsAcceleration()
		{
			FeetPerSecondSquared halved = new FeetPerSecondSquared(10) / 2.0;
			Assert.AreEqual(new FeetPerSecondSquared(5), halved);
		}

		[Test]
		public void DivideOperator_AccelerationByZeroScalar_ReturnsNull()
		{
			Assert.IsNull(new FeetPerSecondSquared(10) / 0.0);
		}

		[Test]
		public void DivideOperator_AccelerationByNegativeScalar_KeepsTheSign()
		{
			//Unlike a duration, an acceleration is signed - it has a direction
			Assert.AreEqual(new FeetPerSecondSquared(-5), new FeetPerSecondSquared(10) / -2.0);
		}

		#endregion

		[Test]
		public void DivideOperator_RoundTripsWithMultiplication()
		{
			Seconds t = 4.Seconds();
			FeetPerSecondSquared a = new FeetPerSecondSquared(5);

			FeetPerSecond du = a * t;
			Assert.AreEqual(new FeetPerSecond(20), du);
			Assert.AreEqual(t, du / a);

			//and the same when decelerating
			FeetPerSecondSquared decel = new FeetPerSecondSquared(-5);
			FeetPerSecond negativeDu = decel * t;
			Assert.AreEqual(new FeetPerSecond(-20), negativeDu);
			Assert.AreEqual(t, negativeDu / decel);
		}
	}
}
