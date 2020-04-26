using System;
using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	[TestFixture]
	public class RadiansPerSecondTest
	{
		[Test]
		public void ComputeTimeFromOmegaAndArc()
		{
			var angularVelocity = new RadiansPerSecond(0.5);

			Seconds duration = 2.Radians() / angularVelocity;

			Assert.AreEqual(4.Seconds(), duration);
		}

		[Test]
		public void ComputeArcFromOmegaAndTime()
		{
			var angularVelocity = new RadiansPerSecond(0.5);

			Radians arc = angularVelocity * TimeSpan.FromSeconds(4);

			Assert.AreEqual(2.Radians(), arc);
		}
	}
}
