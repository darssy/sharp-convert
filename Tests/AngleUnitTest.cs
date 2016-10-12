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
		public void Equals_WithSameReference_ReturnsFalse()
		{
			Degrees angle = 100.Degrees();
			Assert.True(angle.Equals(angle));
		}
		[Test]
		public void TrigonometricFunctions_30Degrees()
		{
			//Assert.AreEqual(30.Degrees().Sin().Round(2), 0.5f);
			//Assert.AreEqual(30.Degrees().Cos().Round(10), (System.Math.Sqrt(3) / 2).Round(10));
			Assert.AreEqual((float)30.Degrees().Tan(), (float)(30.Degrees().Sin() / 30.Degrees().Cos()));
		}

		[Test]
		public void TrigonometricFunctions_45Degrees()
		{
			//Assert.AreEqual(45.Degrees().Tan().Round(), 1);
			Assert.AreEqual(45.Degrees().Cos(), System.Math.Sqrt(2) / 2);
			//Assert.AreEqual(45.Degrees().Sin().Round(10), (System.Math.Sqrt(2) / 2).Round(10));
		}

		[Test]
		public void TrigonometricFunctions_60Degrees()
		{
			//Assert.AreEqual(60.Degrees().Sin().Round(10), (System.Math.Sqrt(3) / 2).Round(10));
			//Assert.AreEqual(60.Degrees().Cos().Round(2), 0.5f);
			Assert.AreEqual((float)60.Degrees().Tan(), (float)(60.Degrees().Sin() / 60.Degrees().Cos()));
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