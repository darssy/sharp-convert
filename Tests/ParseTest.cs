using System;
using System.Globalization;
using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	[TestFixture]
	public class ParseTest
	{
		[Test]
		public void ParseFeet_HappyPathScenario_UsingInvariantCulture()
		{
			UnitBase parsed = "30.5ft".Parse(CultureInfo.InvariantCulture);
			Assert.AreEqual(30.5.Feet(), parsed);
		}

		[Test]
		public void ParseFeet_HappyPathScenario_UsingCurrentCulture()
		{
			string dot = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			UnitBase parsed = $"30{dot}5ft".Parse();
			Assert.AreEqual(30.5.Feet(), parsed);
		}

		[Test]
		public void ParseFeet_HappyPathScenario_WithSpace()
		{
			UnitBase parsed = "30.5 ft".Parse(CultureInfo.InvariantCulture);
			Assert.AreEqual(30.5.Feet(), parsed);
		}

		[Test]
		public void ParseFeet_InvalidInput_ExceptionIsThrown()
		{
			Assert.Catch<FormatException>(() => "garbage".Parse());
			Assert.Catch<FormatException>(() => "390.45garbage".Parse());
		}
	}
}
