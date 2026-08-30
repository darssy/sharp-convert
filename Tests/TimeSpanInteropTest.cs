using System;
using System.Linq;
using System.Reflection;
using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	[TestFixture]
	public class TimeSpanInteropTest
	{
		private static readonly TimeSpan TwoHours = TimeSpan.FromHours(2);

		#region conversion direction

		[Test]
		public void TimeUnitToTimeSpan_IsImplicit()
		{
			bool found = typeof(TimeUnit).GetMethods(BindingFlags.Public | BindingFlags.Static)
				.Any(m => m.Name == "op_Implicit" && m.ReturnType == typeof(TimeSpan));

			Assert.IsTrue(found, "TimeUnit should convert implicitly to TimeSpan");
		}

		[Test]
		public void ImplicitConversion_ToTimeSpan()
		{
			TimeSpan fromHours = 2.Hours();
			TimeSpan fromMinutes = 120.Minutes();
			TimeSpan fromSeconds = 7200.Seconds();

			Assert.AreEqual(TwoHours, fromHours);
			Assert.AreEqual(TwoHours, fromMinutes);
			Assert.AreEqual(TwoHours, fromSeconds);
		}

		[Test]
		public void ImplicitConversion_FromTimeSpan()
		{
			Hours h = TwoHours;
			Minutes m = TwoHours;
			Seconds s = TwoHours;

			Assert.AreEqual(2.Hours(), h);
			Assert.AreEqual(120.Minutes(), m);
			Assert.AreEqual(7200.Seconds(), s);
		}

		[Test]
		public void ConstructorFromTimeSpan_MatchesTheConversion()
		{
			Assert.AreEqual((Hours)TwoHours, new Hours(TwoHours));
			Assert.AreEqual((Minutes)TwoHours, new Minutes(TwoHours));
			Assert.AreEqual((Seconds)TwoHours, new Seconds(TwoHours));
		}

		[Test]
		public void TimeSpanProperty_MatchesTheImplicitConversion()
		{
			TimeSpan implicitly = 2.Hours();
			Assert.AreEqual(implicitly, 2.Hours().TimeSpan);
			Assert.AreEqual(TwoHours, 2.Hours().TimeSpan);
		}

		[Test]
		public void Conversion_RoundTrips()
		{
			TimeSpan ts = 3.5.Hours();
			Assert.AreEqual(3.5.Hours(), (Hours)ts);
		}

		#endregion

		#region typed arithmetic between units

		[Test]
		public void AddOperator_BetweenUnits_ReturnsTheLeftHandUnit()
		{
			Hours h = 1.Hours() + 2.Hours();
			Hours hFromMinutes = 1.Hours() + 30.Minutes();
			Minutes m = 30.Minutes() + 1.Hours();
			Seconds s = 30.Seconds() + 1.Minutes();

			Assert.AreEqual(3.Hours(), h);
			Assert.AreEqual(1.5.Hours(), hFromMinutes);
			Assert.AreEqual(90.Minutes(), m);
			Assert.AreEqual(90.Seconds(), s);
		}

		[Test]
		public void SubtractOperator_BetweenUnits_ReturnsTheAbsoluteDifference()
		{
			Assert.AreEqual(1.Hours(), 1.Hours() - 2.Hours());
			Assert.AreEqual(90.Minutes(), 30.Minutes() - 2.Hours());
			Assert.AreEqual(7140.Seconds(), 60.Seconds() - 2.Hours());
		}

		[Test]
		public void BaseClassArithmetic_StillReturnsTimeUnit()
		{
			TimeUnit t = (TimeUnit)1.Hours() + 30.Minutes();

			Assert.AreEqual(1.5.Hours(), t);
			Assert.IsInstanceOf<TimeUnit>(t);
		}

		#endregion

		#region mixed arithmetic resolves to TimeSpan

		[Test]
		public void ComparisonOperators_UnitAndTimeSpan_ResolveToTimeSpan()
		{
			Assert.IsTrue(1.Hours() < TwoHours);
			Assert.IsTrue(3.Hours() > TwoHours);
			Assert.IsTrue(TwoHours > 1.Hours());
		}

		#endregion
	}
}
