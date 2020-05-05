using MmiSoft.Core.Math;
using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	[TestFixture]
	public class AngleUnitTest
	{
		[Test]
		public void Equals_WithNull_ReturnsFalse()
		{
			Assert.False(3.Radians().Equals(null));
		}

		[Test]
		public void Equals_WithSameReference_ReturnsTrue()
		{
			Degrees angle = 100.Degrees();
			Assert.True(angle.Equals(angle));
		}
		[Test]
		public void TrigonometricFunctions_30Degrees()
		{
			double sin30 = 0.5;
			double cos30 = System.Math.Sqrt(3) / 2;
			double tan30 = sin30 / cos30;
			Assert.AreEqual(sin30, 30.Degrees().Sin(), 0.0001);
			Assert.AreEqual(cos30, 30.Degrees().Cos(), 0.0001);
			Assert.AreEqual(tan30, 30.Degrees().Tan(), 0.0001);
		}

		[Test]
		public void TrigonometricFunctions_45Degrees()
		{
			double sin45 = System.Math.Sqrt(2) / 2;
			double cos45 = sin45;
			double tan45 = 1;
			Assert.AreEqual(sin45, 45.Degrees().Sin(), 0.0001);
			Assert.AreEqual(cos45, 45.Degrees().Cos(), 0.0001);
			Assert.AreEqual(tan45, 45.Degrees().Tan(), 0.0001);
		}

		[Test]
		public void TrigonometricFunctions_60Degrees()
		{
			double sin60 = System.Math.Sqrt(3) / 2;
			double cos60 = 0.5;
			double tan60 = sin60/cos60;
			Assert.AreEqual(sin60, 60.Degrees().Sin(), 0.0001);
			Assert.AreEqual(cos60, 60.Degrees().Cos(), 0.0001);
			Assert.AreEqual(tan60, 60.Degrees().Tan(), 0.0001);
		}

		[Test]
		public void DivisionOperator_PositiveValue_ReturnsAngle()
		{
			Assert.AreEqual(30.Degrees() / 2, 15.Degrees());
			Assert.AreEqual(45.Degrees() / 1.5, 30.Degrees());
			Assert.AreEqual(45.Degrees() / 1.5f, 30.Degrees());
		}

		[Test]
		public void EqualityOperator()
		{
			Assert.IsTrue(30.Degrees() == new Degrees(30));
			Assert.IsTrue(80.Degrees() != 30.Degrees());
			Assert.IsTrue(90.Degrees() == (System.Math.PI / 2).Radians());
		}
	}
}
