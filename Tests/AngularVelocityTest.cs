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
	}
}
