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
		public void VerifyConversion()
		{
			Degrees halfTurn = new Degrees(180);
			Assert.AreEqual(halfTurn.ToSiFactor, 0.017453292519943295); // π/180
			Assert.AreEqual(halfTurn.To<Radians>().UnitValue, new Radians(System.Math.PI).UnitValue);
		}
	}
}
