using System;
using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	[TestFixture]
	public class MassTest
	{
		[Test]
		public void MassShallNotBeNegative()
		{
			Assert.Catch<ArgumentOutOfRangeException>(() => new Kilogram(-1));
		}

		[Test]
		public void MassSubtraction_ResultShallNotBeNegative()
		{
			Assert.AreEqual(5.3.Kilogram(), 3.Kilogram() - 8.3.Kilogram());
		}

	}
}
