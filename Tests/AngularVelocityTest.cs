using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	[TestFixture]
	public class AngularVelocityTest
	{
		[Test]
		public void MultiplyOperator_VelocityTimesSecond_ReturnsArc()
		{
			Assert.AreEqual(5.DegreesPerSecond() * 32.Seconds(), 160.Degrees());
			Assert.AreEqual(new DegreesPerSecond(5m) * TimeSpan.FromSeconds(32), 160.Degrees());
		}

		[Test]
		public void Get_FromAngleAndLength_ReturnsAngularVelocity()
		{
			DegreesPerSecond pds = AngularVelocity.Get<DegreesPerSecond>(15.Degrees(), 5.Seconds());
			Assert.AreEqual(pds.UnitValue, 3);
		}

		[Test]
		public void DivideOperator_AngleUnitDidvidedByVelocity_ReturnsTime()
		{
			Assert.AreEqual(1.Degrees() / 3.DegreesPerSecond(), 0.33333333333333333333.Seconds());
			Assert.AreEqual(300.Degrees() / 5.DegreesPerSecond(), 60.Seconds());
		}

		[Test]
		public void EqualsMethodOverload()
		{
			object ob1 = 0.DegreesPerSecond();
			object ob2 = 0.RadiansPerSecond();
			Assert.AreEqual(ob1, ob2);
		}

		[Test]
		public void EqualityOperatorOverload()
		{
			AngularVelocity ob1 = 0.DegreesPerSecond();
			AngularVelocity ob2 = 0.RadiansPerSecond();
			Assert.True(ob1 == ob2);

			ob1 = ob2;
			Assert.True(ob1 == ob2);
		}

		[Test]
		public void CompareTo_SameNumberDifferentInstances_ReturnsZero()
		{
			DegreesPerSecond a1 = (-0.1).DegreesPerSecond();
			DegreesPerSecond a2 = (-0.1).DegreesPerSecond();

			Assert.AreEqual(0, a1.CompareTo(a2));
		}

		[Test]
		public void CompareTo_SameAbsoluteValuesDifferentInstances_Returns1()
		{
			DegreesPerSecond a1 = 0.1.DegreesPerSecond();
			DegreesPerSecond a2 = (-0.1).DegreesPerSecond();

			Assert.AreEqual(1, a1.CompareTo(a2));
		}

		[Test]
		public void CompareTo_SameAbsoluteValuesDifferentInstances_ReturnsMinus1()
		{
			DegreesPerSecond a1 = (-0.1).DegreesPerSecond();
			DegreesPerSecond a2 = 0.1.DegreesPerSecond();

			Assert.AreEqual(-1, a1.CompareTo(a2));
		}
	}
}
