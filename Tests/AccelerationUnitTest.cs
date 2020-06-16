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
			var knotsPerSecond = new MeterPerSecondSquared(0.3);
			SpeedUnit du = knotsPerSecond * new Seconds(12);

			Assert.AreEqual(new MetersPerSecond(3.6), du);
		}
	}
}
