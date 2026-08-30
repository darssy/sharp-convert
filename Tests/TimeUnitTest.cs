using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	[TestFixture]
	public class TimeUnitTest
	{
		[Test]
		public void Equals_WithNull_ReturnsFalse()
		{
			Assert.False(5.Hours().Equals(null));
		}

		[Test]
		public void Equals_WithSameReference_ReturnsFalse()
		{
			Hours h = 3.6.Hours();
			Assert.True(h.Equals(h));
		}

		[Test]
		public void Conversion_ToHours_ReturnsHour()
		{
			Assert.AreEqual(3600.Seconds().To<Hours>().UnitValue, 1);
			Assert.AreEqual(3601.Seconds().To<Hours>().UnitValue, 3601.0 / 3600);
		}

		[Test]
		public void TimeSpan_RandomValues()
		{
			Assert.AreEqual(3600.Seconds().TimeSpan, TimeSpan.FromHours(1));
			Assert.AreEqual(3600.Seconds().TimeSpan, TimeSpan.FromHours(1));
			Assert.AreEqual(0.002.Seconds().TimeSpan, TimeSpan.FromMilliseconds(2));
		}

		[Test]
		public void HoursTimeSpanConstructor()
		{
			Assert.AreEqual(new Hours(TimeSpan.FromHours(24)), 24.Hours());
		}

		[Test]
		public void ImplicitCasting_TimeSpan_ReturnsHours()
		{
			Hours h = TimeSpan.FromHours(2.5);
			Assert.AreEqual(h, 2.5.Hours());

			Seconds s = new TimeSpan(0, 2, 12);
			Assert.AreEqual(132.Seconds(), s);
		}

		[Test]
		public void MultiplicationOperation_Seconds_ReturnsSeconds()
		{
			Seconds s = new Seconds(TimeSpan.FromHours(2.5));
			Assert.AreEqual(s * 1.5, 3.75.Hours());
			Assert.AreEqual(s * 1.5, 1.5 * s);
		}

		[Test]
		public void DivideOperator_TimeUnit_ReturnsSiRatio()
		{
			Assert.AreEqual(1, 3600.Seconds() / 1.Hours(), 1e-10);
		}
	}
}
