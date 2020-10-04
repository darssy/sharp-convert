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
			Degrees halfTurn = new Degrees(180);
			Radians expected = new Radians(System.Math.PI);
			Assert.AreEqual(expected, halfTurn.To<Radians>());
			Assert.AreEqual(expected, halfTurn);
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
