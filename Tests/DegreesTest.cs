using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	[TestFixture]
	public class DegreesTest
	{
		[Test]
		public void VerifyConversion_FromDegreesToRadians()
		{
			double oneDegreeRad = System.Math.PI / 180;
			Degrees halfTurn = new Degrees(180);
			Assert.AreEqual(oneDegreeRad, halfTurn.ToSiFactor, 0.000000001); // π/180
			Assert.AreEqual(halfTurn.To<Radians>().UnitValue, new Radians(System.Math.PI).UnitValue);
		}

		[Test]
		public void NegateOperator()
		{
			Degrees expected = new Degrees(-30);
			Degrees toNegate = new Degrees(30);
			Assert.AreEqual(expected, -toNegate);
		}
	}
}
