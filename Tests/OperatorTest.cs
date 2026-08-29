using System;
using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	/// <summary>
	/// Covers the operators that were filled in to make the reference (class based) unit API symmetric across
	/// magnitudes. Most of them delegate to an already tested code path, so the point of these tests is mainly
	/// to pin down overload resolution: an operator declared on a concrete unit must not silently behave
	/// differently than the one declared on its base class.
	/// </summary>
	[TestFixture]
	public class OperatorTest
	{
		#region Length

		[Test]
		public void DivideOperator_MetersBySeconds_ReturnsMetersPerSecond()
		{
			MetersPerSecond speed = 100.Meters() / 4.Seconds();
			Assert.AreEqual(25.MetersPerSecond(), speed);
		}

		[Test]
		public void DivideOperator_FeetBySeconds_ReturnsFeetPerSecond()
		{
			FeetPerSecond speed = 300.Feet() / 5.Seconds();
			Assert.AreEqual(new FeetPerSecond(60), speed);
		}

		[Test]
		public void DivideOperator_NauticalMilesByHours_ReturnsKnots()
		{
			Knots speed = 250.NauticalMiles() / 2.Hours();
			Assert.AreEqual(125.Knots(), speed);
		}

		[Test]
		public void DivideOperator_LengthByZeroTime_ReturnsNull()
		{
			Assert.IsNull(100.Meters() / 0.Seconds());
			Assert.IsNull(300.Feet() / 0.Seconds());
			Assert.IsNull(250.NauticalMiles() / 0.Hours());
		}

		[Test]
		public void AddAndSubtractOperators_TypedKilometers_MatchTheBaseClassResult()
		{
			Kilometers sum = 3.Kilometers() + 4.Kilometers();
			Assert.AreEqual(7.Kilometers(), sum);

			//Length is positive only, so - as with every other length - the difference is the absolute value
			Kilometers diff = 3.Kilometers() - 4.Kilometers();
			Assert.AreEqual(1.Kilometers(), diff);
			Assert.AreEqual((LengthUnit)3.Kilometers() - 4.Kilometers(), diff);
		}

		#endregion

		#region Time

		[Test]
		public void DivideOperator_TimeByScalar_ReturnsSameUnit()
		{
			TimeUnit t = 90.Minutes() / 3.0;
			Assert.AreEqual(30.Minutes(), t);
			Assert.AreEqual(30.Minutes(), 90.Minutes() / 3);
			Assert.AreEqual(30.Minutes(), 90.Minutes() / 3f);
		}

		[Test]
		public void DivideOperator_TimeByZero_ReturnsNull()
		{
			Assert.IsNull(90.Minutes() / 0.0);
			Assert.IsNull(2.Hours() / 0.0);
			Assert.IsNull(60.Seconds() / 0.0);
		}

		[Test]
		public void AddAndSubtractOperators_TypedTimeUnits_MatchTheBaseClassResult()
		{
			Assert.AreEqual(90.Minutes(), 30.Minutes() + 60.Minutes());
			Assert.AreEqual(3.Hours(), 1.Hours() + 2.Hours());
			Assert.AreEqual(90.Seconds(), 30.Seconds() + 60.Seconds());

			//TimeUnit subtraction returns the absolute difference; the typed overloads must not diverge
			Assert.AreEqual(30.Minutes(), 30.Minutes() - 60.Minutes());
			Assert.AreEqual((TimeUnit)30.Minutes() - 60.Minutes(), 30.Minutes() - 60.Minutes());

			Assert.AreEqual(1.Hours(), 1.Hours() - 2.Hours());
			Assert.AreEqual(30.Seconds(), 30.Seconds() - 60.Seconds());
		}

		[Test]
		public void AddAndSubtractOperators_TypedTimeUnitWithOtherTimeUnit_ConvertsToTheLeftHandUnit()
		{
			Minutes m = 30.Minutes() + 1.Hours();
			Assert.AreEqual(90.Minutes(), m);

			Hours h = 1.Hours() + 30.Minutes();
			Assert.AreEqual(1.5.Hours(), h);

			Seconds s = 30.Seconds() + 1.Minutes();
			Assert.AreEqual(90.Seconds(), s);
		}

		[Test]
		public void MultiplyOperator_TypedMinutesAndHours_ReturnsSameUnit()
		{
			Minutes m = 30.Minutes() * 3;
			Assert.AreEqual(90.Minutes(), m);
			Assert.AreEqual(m, 3 * 30.Minutes());

			Hours h = 2.Hours() * 1.5;
			Assert.AreEqual(3.Hours(), h);
			Assert.AreEqual(h, 1.5 * 2.Hours());
		}

		[Test]
		public void ExplicitConversion_TimeUnitToFloatAndInt()
		{
			Assert.AreEqual(2.5f, (float)2.5.Hours());
			Assert.AreEqual(3, (int)2.6.Hours());
		}

		#endregion

		#region Speed

		[Test]
		public void DivideOperator_SpeedBySpeed_ReturnsSiRatio()
		{
			Assert.AreEqual(2, 100.Knots() / 50.Knots(), 1e-10);
			//1 kt is 1852/3600 m/s
			Assert.AreEqual(1852.0 / 3600, 1.Knots() / 1.MetersPerSecond(), 1e-10);
		}

		[Test]
		public void MultiplyOperator_ScalarTimesSpeed_IsCommutative()
		{
			SpeedUnit doubled = 2.0 * 120.Knots();
			Assert.AreEqual(240.Knots(), doubled);
			Assert.AreEqual(120.Knots() * 2.0, doubled);
		}

		[Test]
		public void DivideOperator_SpeedByIntAndFloat()
		{
			Assert.AreEqual(60.Knots(), 120.Knots() / 2);
			Assert.AreEqual(60.Knots(), 120.Knots() / 2f);
			Assert.IsNull(120.Knots() / 0);
		}

		[Test]
		public void DivideOperator_SpeedByTime_ReturnsAcceleration()
		{
			AccelerationUnit a = (SpeedUnit)10.MetersPerSecond() / 5.Seconds();
			Assert.AreEqual(2.MetersPerSecondSquared(), a);
		}

		[Test]
		public void DivideOperator_SpeedByZeroTime_ReturnsNull()
		{
			Assert.IsNull((SpeedUnit)10.MetersPerSecond() / 0.Seconds());
		}

		[Test]
		public void DivideOperator_TypedSpeedBySeconds_ReturnsTypedAcceleration()
		{
			KnotsPerSecond ktsPerSec = 30.Knots() / 6.Seconds();
			Assert.AreEqual(5.KnotsPerSecond(), ktsPerSec);

			MetersPerSecondSquared mpss = 10.MetersPerSecond() / 5.Seconds();
			Assert.AreEqual(2.MetersPerSecondSquared(), mpss);

			FeetPerMinutePerSecond fpmps = 1200.FeetPerMinute() / 4.Seconds();
			Assert.AreEqual(300.FeetPerMinutePerSecond(), fpmps);

			FeetPerSecondSquared fpss = new FeetPerSecond(20) / 4.Seconds();
			Assert.AreEqual(new FeetPerSecondSquared(5), fpss);
		}

		[Test]
		public void MultiplyOperator_TimeTimesSpeed_IsCommutative()
		{
			LengthUnit distance = 2.Hours() * 50.Knots();
			//UnitBase equality uses an absolute 1e-14 epsilon on the SI value, which is far too tight for the
			//185200 m this multiplication produces, so the comparison is done on the unit value with a delta
			Assert.AreEqual(100, distance.To<NauticalMiles>().UnitValue, 1e-10);
			Assert.AreEqual((50.Knots() * 2.Hours()).UnitValue, distance.To<NauticalMiles>().UnitValue, 1e-10);
			Assert.IsInstanceOf<NauticalMiles>(distance);
		}

		[Test]
		public void MultiplyOperator_TimeSpanTimesSpeed_IsCommutative()
		{
			LengthUnit distance = TimeSpan.FromMinutes(10) * 50.Knots();
			Assert.AreEqual(new NauticalMiles(50.0 / 60 * 10), distance);
		}

		[Test]
		public void MultiplyOperator_TypedSpeedTimesTime_ReturnsTypedLength()
		{
			Meters m = 10.MetersPerSecond() * 5.Seconds();
			Assert.AreEqual(50.Meters(), m);

			Feet ft = 1200.FeetPerMinute() * 2.Minutes();
			Assert.AreEqual(2400.Feet(), ft);

			Feet ftFromFps = new FeetPerSecond(20) * 3.Seconds();
			Assert.AreEqual(60.Feet(), ftFromFps);
		}

		[Test]
		public void MultiplyOperator_TypedSpeedTimesTime_ReturnsAbsoluteDistanceLikeTheBaseClass()
		{
			//LengthUnit is positive only - the typed overloads must behave as SpeedUnit.operator *(SpeedUnit, TimeUnit)
			Assert.AreEqual(50.Meters(), (-10).MetersPerSecond() * 5.Seconds());
			Assert.AreEqual(2400.Feet(), (-1200).FeetPerMinute() * 2.Minutes());
			Assert.AreEqual(60.Feet(), new FeetPerSecond(-20) * 3.Seconds());
		}

		[Test]
		public void AddOperator_TypedSpeedWithBaseTypedOperand_Adds()
		{
			//Regression: the SpeedUnit overloads of operator + used to subtract when both operands had the same unit
			Assert.AreEqual(1500.FeetPerMinute(), 1000.FeetPerMinute() + (SpeedUnit)500.FeetPerMinute());
			Assert.AreEqual(150.Knots(), 100.Knots() + (SpeedUnit)50.Knots());
			Assert.AreEqual(15.MetersPerSecond(), 10.MetersPerSecond() + (SpeedUnit)new MetersPerSecond(5));
		}

		[Test]
		public void AddAndSubtractOperators_TypedFeetPerSecond()
		{
			Assert.AreEqual(new FeetPerSecond(30), new FeetPerSecond(10) + new FeetPerSecond(20));
			Assert.AreEqual(new FeetPerSecond(-10), new FeetPerSecond(10) - new FeetPerSecond(20));
			Assert.AreEqual(new FeetPerSecond(30), new FeetPerSecond(10) + (SpeedUnit)new FeetPerSecond(20));
		}

		[Test]
		public void MultiplyAndDivideOperators_TypedSpeeds_ReturnSameUnit()
		{
			Assert.AreEqual(240.Knots(), 120.Knots() * 2.0);
			Assert.AreEqual(240.Knots(), 2.0 * 120.Knots());
			Assert.AreEqual(60.Knots(), 120.Knots() / 2.0);

			Assert.AreEqual(20.MetersPerSecond(), 10.MetersPerSecond() * 2.0);
			Assert.AreEqual(20.MetersPerSecond(), 2.0 * 10.MetersPerSecond());
			Assert.AreEqual(5.MetersPerSecond(), 10.MetersPerSecond() / 2.0);

			Assert.AreEqual(2000.FeetPerMinute(), 2.0 * 1000.FeetPerMinute());
			Assert.AreEqual(500.FeetPerMinute(), 1000.FeetPerMinute() / 2.0);

			Assert.AreEqual(new FeetPerSecond(40), new FeetPerSecond(20) * 2.0);
			Assert.AreEqual(new FeetPerSecond(40), 2.0 * new FeetPerSecond(20));
			Assert.AreEqual(new FeetPerSecond(10), new FeetPerSecond(20) / 2.0);
		}

		[Test]
		public void NegateOperator_Knots()
		{
			Knots negated = -120.Knots();
			Assert.AreEqual(new Knots(-120), negated);
		}

		[Test]
		public void ExplicitConversion_SpeedUnitToDouble()
		{
			Assert.AreEqual(120, (double)120.Knots(), 1e-10);
		}

		#endregion

		#region Acceleration

		[Test]
		public void Zero_MetersPerSecondSquared_IsAMeterPerSecondSquared()
		{
			Assert.IsInstanceOf<MetersPerSecondSquared>(MetersPerSecondSquared.Zero);
			Assert.AreEqual(0, MetersPerSecondSquared.Zero.UnitValue);
		}

		[Test]
		public void AddAndSubtractOperators_Acceleration()
		{
			AccelerationUnit sum = (AccelerationUnit)2.MetersPerSecondSquared() + 3.MetersPerSecondSquared();
			Assert.AreEqual(5.MetersPerSecondSquared(), sum);

			AccelerationUnit diff = (AccelerationUnit)2.MetersPerSecondSquared() - 3.MetersPerSecondSquared();
			Assert.AreEqual((-1).MetersPerSecondSquared(), diff);

			Assert.AreEqual(5.MetersPerSecondSquared(), 2.MetersPerSecondSquared() + 3.MetersPerSecondSquared());
			Assert.AreEqual(300.FeetPerMinutePerSecond(), 100.FeetPerMinutePerSecond() + 200.FeetPerMinutePerSecond());
			Assert.AreEqual(3.KnotsPerSecond(), 5.KnotsPerSecond() - 2.KnotsPerSecond());
			Assert.AreEqual(new FeetPerSecondSquared(7), new FeetPerSecondSquared(3) + new FeetPerSecondSquared(4));
		}

		[Test]
		public void MultiplyAndDivideOperators_AccelerationByScalar()
		{
			Assert.AreEqual(6.MetersPerSecondSquared(), 2.MetersPerSecondSquared() * 3.0);
			Assert.AreEqual(6.MetersPerSecondSquared(), 3.0 * 2.MetersPerSecondSquared());
			Assert.AreEqual(1.MetersPerSecondSquared(), 2.MetersPerSecondSquared() / 2.0);
			Assert.AreEqual(1.MetersPerSecondSquared(), (AccelerationUnit)2.MetersPerSecondSquared() / 2);
			Assert.AreEqual(1.MetersPerSecondSquared(), (AccelerationUnit)2.MetersPerSecondSquared() / 2f);
			Assert.IsNull((AccelerationUnit)2.MetersPerSecondSquared() / 0);

			Assert.AreEqual(50.FeetPerMinutePerSecond(), 25.FeetPerMinutePerSecond() * 2.0);
			Assert.AreEqual(50.FeetPerMinutePerSecond(), 2.0 * 25.FeetPerMinutePerSecond());
			Assert.AreEqual(1.KnotsPerSecond(), 2.KnotsPerSecond() / 2.0);
		}

		[Test]
		public void DivideOperator_AccelerationByAcceleration_ReturnsSiRatio()
		{
			Assert.AreEqual(2, 4.MetersPerSecondSquared() / 2.MetersPerSecondSquared(), 1e-10);
		}

		[Test]
		public void MultiplyOperator_TimeTimesAcceleration_IsCommutative()
		{
			SpeedUnit du = 2.5.Seconds() * 0.5.KnotsPerSecond();
			Assert.AreEqual(1.25.Knots(), du);
			Assert.AreEqual(0.5.KnotsPerSecond() * 2.5.Seconds(), du);
		}

		[Test]
		public void MultiplyOperator_AccelerationTimesTimeSpan()
		{
			SpeedUnit du = (AccelerationUnit)0.5.KnotsPerSecond() * TimeSpan.FromSeconds(2.5);
			Assert.AreEqual(1.25.Knots(), du);
			Assert.AreEqual(du, TimeSpan.FromSeconds(2.5) * (AccelerationUnit)0.5.KnotsPerSecond());
		}

		[Test]
		public void MultiplyOperator_TypedMetersPerSecondSquaredTimesTime_ReturnsMetersPerSecond()
		{
			MetersPerSecond du = 0.3.MetersPerSecondSquared() * new Seconds(12);
			Assert.AreEqual(new MetersPerSecond(3.6), du);
		}

		[Test]
		public void DivideOperator_TypedSpeedByTypedAcceleration_ReturnsSeconds()
		{
			Assert.AreEqual(6.Seconds(), 30.Knots() / 5.KnotsPerSecond());
			Assert.AreEqual(5.Seconds(), 10.MetersPerSecond() / 2.MetersPerSecondSquared());
			Assert.AreEqual(4.Seconds(), new FeetPerSecond(20) / new FeetPerSecondSquared(5));

			Assert.IsNull(30.Knots() / 0.KnotsPerSecond());
			Assert.IsNull(10.MetersPerSecond() / 0.MetersPerSecondSquared());
			Assert.IsNull(new FeetPerSecond(20) / new FeetPerSecondSquared(0));
		}

		[Test]
		public void CompareTo_Acceleration()
		{
			Assert.AreEqual(1, 3.MetersPerSecondSquared().CompareTo(2.MetersPerSecondSquared()));
			Assert.AreEqual(-1, 2.MetersPerSecondSquared().CompareTo(3.MetersPerSecondSquared()));
			Assert.AreEqual(0, 2.MetersPerSecondSquared().CompareTo(2.MetersPerSecondSquared()));
		}

		#endregion

		#region Angle

		[Test]
		public void NegateOperator_AngleUnit_KeepsTheUnit()
		{
			AngleUnit negated = -(AngleUnit)45.Degrees();
			Assert.AreEqual((-45).Degrees(), negated);
			Assert.AreEqual("°", negated.Symbol);
		}

		[Test]
		public void DivideOperator_AngleByAngle_ReturnsSiRatio()
		{
			Assert.AreEqual(2, 90.Degrees() / 45.Degrees(), 1e-10);
			Assert.AreEqual(180 / System.Math.PI, 1.Radians() / 1.Degrees(), 1e-10);
		}

		[Test]
		public void DivideOperator_AngleByTime_ReturnsAngularVelocity()
		{
			AngularVelocity omega = (AngleUnit)90.Degrees() / 3.Seconds();
			Assert.AreEqual(30.DegreesPerSecond(), omega);
			Assert.IsNull((AngleUnit)90.Degrees() / 0.Seconds());
		}

		[Test]
		public void DivideOperator_TypedAngleBySeconds_ReturnsTypedAngularVelocity()
		{
			DegreesPerSecond dps = 90.Degrees() / 3.Seconds();
			Assert.AreEqual(30.DegreesPerSecond(), dps);

			RadiansPerSecond rps = 3.Radians() / 3.Seconds();
			Assert.AreEqual(1.RadiansPerSecond(), rps);
		}

		[Test]
		public void MultiplyAndDivideOperators_TypedAngles_ReturnSameUnit()
		{
			Degrees d = 45.Degrees() * 2.0;
			Assert.AreEqual(90.Degrees(), d);
			Assert.AreEqual(d, 2.0 * 45.Degrees());
			Assert.AreEqual(45.Degrees(), 90.Degrees() / 2.0);
			Assert.IsNull(90.Degrees() / 0.0);

			Radians r = 1.Radians() * 2.0;
			Assert.AreEqual(2.Radians(), r);
			Assert.AreEqual(r, 2.0 * 1.Radians());
			Assert.AreEqual(1.Radians(), 2.Radians() / 2.0);
		}

		[Test]
		public void ExplicitConversion_AngleUnitToDouble()
		{
			Assert.AreEqual(45, (double)45.Degrees(), 1e-10);
		}

		#endregion

		#region Angular velocity

		[Test]
		public void NegateOperator_AngularVelocity()
		{
			Assert.AreEqual((-5).DegreesPerSecond(), -5.DegreesPerSecond());
			Assert.AreEqual((-5).RadiansPerSecond(), -5.RadiansPerSecond());
			Assert.AreEqual((-5).DegreesPerSecond(), -(AngularVelocity)5.DegreesPerSecond());
		}

		[Test]
		public void AddAndSubtractOperators_TypedAngularVelocities()
		{
			Assert.AreEqual(8.DegreesPerSecond(), 5.DegreesPerSecond() + 3.DegreesPerSecond());
			Assert.AreEqual(2.DegreesPerSecond(), 5.DegreesPerSecond() - 3.DegreesPerSecond());
			Assert.AreEqual(8.RadiansPerSecond(), 5.RadiansPerSecond() + 3.RadiansPerSecond());
			Assert.AreEqual(2.RadiansPerSecond(), 5.RadiansPerSecond() - 3.RadiansPerSecond());

			Assert.AreEqual(8.DegreesPerSecond(), 5.DegreesPerSecond() + (AngularVelocity)3.DegreesPerSecond());
		}

		[Test]
		public void MultiplyAndDivideOperators_AngularVelocityByScalar()
		{
			Assert.AreEqual(10.DegreesPerSecond(), 5.DegreesPerSecond() * 2.0);
			Assert.AreEqual(10.DegreesPerSecond(), 2.0 * 5.DegreesPerSecond());
			Assert.AreEqual(2.5.DegreesPerSecond(), 5.DegreesPerSecond() / 2.0);
			Assert.IsNull(5.DegreesPerSecond() / 0.0);

			Assert.AreEqual(10.RadiansPerSecond(), 5.RadiansPerSecond() * 2.0);
			Assert.AreEqual(2.5.RadiansPerSecond(), 5.RadiansPerSecond() / 2.0);

			Assert.AreEqual(2.5.DegreesPerSecond(), (AngularVelocity)5.DegreesPerSecond() / 2);
			Assert.AreEqual(2.5.DegreesPerSecond(), (AngularVelocity)5.DegreesPerSecond() / 2f);
		}

		[Test]
		public void DivideOperator_AngularVelocityByAngularVelocity_ReturnsSiRatio()
		{
			Assert.AreEqual(2, 10.DegreesPerSecond() / 5.DegreesPerSecond(), 1e-10);
		}

		[Test]
		public void MultiplyOperator_TimeTimesAngularVelocity_IsCommutative()
		{
			AngleUnit arc = 32.Seconds() * 5.DegreesPerSecond();
			Assert.AreEqual(160.Degrees(), arc);
			Assert.AreEqual(5.DegreesPerSecond() * 32.Seconds(), arc);
			Assert.AreEqual(arc, TimeSpan.FromSeconds(32) * (AngularVelocity)5.DegreesPerSecond());
		}

		#endregion

		#region Mass

		[Test]
		public void Conversion_MassTo_ReturnsSameUnit()
		{
			Kilogram kg = 5.Kilogram().To<Kilogram>();
			Assert.AreEqual(5.Kilogram(), kg);
		}

		[Test]
		public void AddAndSubtractOperators_Mass()
		{
			MassUnit sum = (MassUnit)3.Kilogram() + 5.Kilogram();
			Assert.AreEqual(8.Kilogram(), sum);

			//Mass is positive only, so the difference is the absolute value - as the typed Kilogram overload does
			MassUnit diff = (MassUnit)3.Kilogram() - 8.3.Kilogram();
			Assert.AreEqual(5.3.Kilogram(), diff);
			Assert.AreEqual(3.Kilogram() - 8.3.Kilogram(), diff);
		}

		[Test]
		public void MultiplyAndDivideOperators_MassByScalar()
		{
			Assert.AreEqual(6.Kilogram(), 3.Kilogram() * 2.0);
			Assert.AreEqual(6.Kilogram(), 2.0 * 3.Kilogram());
			Assert.AreEqual(1.5.Kilogram(), 3.Kilogram() / 2.0);
			Assert.IsNull(3.Kilogram() / 0.0);

			Assert.AreEqual(1.5.Kilogram(), (MassUnit)3.Kilogram() / 2);
			Assert.AreEqual(1.5.Kilogram(), (MassUnit)3.Kilogram() / 2f);
		}

		[Test]
		public void DivideOperator_MassByMass_ReturnsSiRatio()
		{
			Assert.AreEqual(2, 6.Kilogram() / 3.Kilogram(), 1e-10);
		}

		[Test]
		public void ExplicitConversion_MassUnitToDouble()
		{
			Assert.AreEqual(3, (double)3.Kilogram(), 1e-10);
		}

		#endregion
	}
}
