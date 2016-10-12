using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	[TestFixture]
	public class NauticalMilesTest
	{
		[Test]
		public void Conversion_1NM_Equals1852M()
		{
			Assert.AreEqual(1.NauticalMiles().To<Meters>(), 1852.Meters());
		}
		[Test]
		public void SubtractOperator_SmallSubtractedFromLarger_ReturnsLengthUnit()
		{
			Assert.AreEqual(10.NauticalMiles() - 8.NauticalMiles(), 2.NauticalMiles());
		}

		[Test]
		public void SubtractOperator_LargeSubtractedFromSmaller_ReturnsPositiveLengthUnit()
		{
			Assert.AreEqual(1127.Meters() - 2000.Meters(), 873.Meters());
		}
	}
}
