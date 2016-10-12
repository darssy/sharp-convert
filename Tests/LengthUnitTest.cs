using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	[TestFixture]
	public class LengthUnitTest
	{
		[Test]
		public void Equals_WithNull_ReturnsFalse()
		{
			Assert.AreNotEqual(30.Degrees(), null);
		}

		[Test]
		public void Equals_WithSameReference_ReturnsFalse()
		{
			Degrees degrees = 30.Degrees();
			Assert.AreEqual(degrees, degrees);
		}

		[Test]
		public void CompareTo_DifferentTypes_ComparesSiValues()
		{
			Assert.AreEqual(5.2.NauticalMiles().CompareTo(5.2.Kilometers()), 1);
			Assert.AreEqual(5.2.NauticalMiles().CompareTo(8.Kilometers()), 1);
			Assert.AreEqual(5.2.NauticalMiles().CompareTo(8.Kilometers()), 1);

			Assert.AreEqual(1000.Meters().CompareTo(3800.Feet()), -1);

			Assert.AreEqual(1000.Meters().CompareTo(1000.Meters().To<Feet>()), 0);
		}

		[Test]
		public void MetersAdditionOperator_AddLengthUnit_ReturnsMeters()
		{
			Assert.AreEqual(1000.Meters() + 852.Meters().To<Feet>(), 1.NauticalMiles());
		}
		
		[Test]
		public void FeetAdditionOperator_AddLengthUnit_ReturnsFeet()
		{
			Assert.AreEqual(300.Feet() + 152.Feet(), 452.Feet());
			Assert.AreEqual(300.Feet() - 152.Feet(), 148.Feet());
		}

		[Test]
		public void LessThanOperator_ComparesDifferentUnits()
		{
			Assert.IsTrue(1000.Feet() < 1000.Meters());
			Assert.IsTrue(1000.Feet() <= 1000.Meters());
			Assert.IsTrue(1000.Feet() <= (1000 * 0.3048).Meters());
			Assert.IsTrue(1000.Feet() <= (1001 * 0.3048).Meters());
		}

		[Test]
		public void GreaterThanOperator_ComparesDifferentUnits()
		{
			Assert.IsTrue(1000.Meters() > 1000.Feet());
			Assert.IsTrue(1000.Meters() >= 1000.Feet());
			Assert.IsTrue(1000.Meters() >= (1000 * 0.3048).Feet());
			Assert.IsTrue(1000.Meters() >= (1001 * 0.3048).Feet());
		}

		[Test]
		public void HashCode_SameValuesAmongDifferentTypes_IsNotTheSame()
		{
			Assert.AreNotEqual(2.Radians().GetHashCode(), 2.Meters().GetHashCode());
			Assert.AreNotEqual(11.MetersPerSecond().GetHashCode(), 11.Meters().GetHashCode());
			Assert.AreNotEqual(11.MetersPerSecond().GetHashCode(), 11.Seconds().GetHashCode());
		}
	}
}